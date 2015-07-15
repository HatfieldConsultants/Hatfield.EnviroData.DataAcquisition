using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionActionMapper : ActionMapperBase, IESDATSampleCollectionMapper<Core.Action>
    {
        protected ESDATSampleCollectionMapperFactory _sampleCollectionFactory;
        protected ESDATChemistryMapperFactory _chemistryFactory;

        public SampleCollectionActionMapper(ESDATDuplicateChecker duplicateChecker, ESDATSampleCollectionMapperFactory sampleCollectionFactory, IWQDefaultValueProvider WQDefaultValueProvider, ESDATChemistryMapperFactory chemistryFactory, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
            _sampleCollectionFactory = sampleCollectionFactory;
            _chemistryFactory = chemistryFactory;
        }

        public Core.Action Map(ESDATModel esdatModel)
        {
            var action = Scaffold(esdatModel);

            // Feature Actions
            var featureAction = _sampleCollectionFactory.FeatureActionMapper.Map(esdatModel);
            ODM2EntityLinker.Link(action, featureAction);

            // Sampling Feature
            var samplingFeature = _sampleCollectionFactory.SamplingFeatureMapper.Map(esdatModel);
            ODM2EntityLinker.Link(featureAction, samplingFeature);

            // Results
            // Each Feature Action can contain many results (Samples)
            foreach (SampleFileData sample_ in esdatModel.SampleFileData)
            {
                _sampleCollectionFactory.ResultMapper.Sample = sample_;
                Result result = _sampleCollectionFactory.ResultMapper.Map(esdatModel);

                ODM2EntityLinker.Link(featureAction, result);

                // Unit
                var unit = _sampleCollectionFactory.UnitMapper.Map(esdatModel);
                ODM2EntityLinker.Link(result, unit);

                // Variable
                var variable = _sampleCollectionFactory.VariableMapper.Map(esdatModel);
                ODM2EntityLinker.Link(result, variable);

                // Processing Level
                var processingLevel = _sampleCollectionFactory.ProcessingLevelMapper.Map(esdatModel);
                ODM2EntityLinker.Link(result, processingLevel);

                // Related Actions
                // Create a new related Action for each chemistry file
                // Assume that 1 unique sample maps to one or more chemistry files
                var chemistryData = esdatModel.ChemistryData.Where(x => x.SampleCode.Equals(sample_.SampleCode));

                foreach (ChemistryFileData chemistry_ in chemistryData)
                {
                    _chemistryFactory.ActionMapper.ParentAction = action;
                    _chemistryFactory.ActionMapper.SampleFileData = sample_;
                    var chemistryAction = _chemistryFactory.ActionMapper.Map(esdatModel, chemistry_);

                    _chemistryFactory.RelatedActionMapper.SetRelationship(action, _WQDefaultValueProvider.ActionRelationshipTypeCVSampleCollection, chemistryAction);
                    var relatedAction = _chemistryFactory.RelatedActionMapper.Map(esdatModel);

                    ODM2EntityLinker.Link(action, relatedAction);
                }
            }

            // Action Bies
            {
                ActionBy actionBy = _sampleCollectionFactory.ActionByMapper.Map(esdatModel);
                ODM2EntityLinker.Link(action, actionBy);

                var affiliation = _sampleCollectionFactory.AffiliationMapper.Map(esdatModel);
                ODM2EntityLinker.Link(actionBy, affiliation);

                var person = _sampleCollectionFactory.PersonMapper.Map(esdatModel);
                ODM2EntityLinker.Link(affiliation, person);
            }


            // Method
            {
                var method = _sampleCollectionFactory.MethodMapper.Map(esdatModel);
                ODM2EntityLinker.Link(action, method);

                var organization = _sampleCollectionFactory.OrganizationMapper.Map(esdatModel);
                ODM2EntityLinker.Link(method, organization);
            }

            return action;
        }

        public Core.Action Scaffold(ESDATModel esdatModel)
        {
            Core.Action entity = new Core.Action();

            entity.ActionTypeCV = _WQDefaultValueProvider.ActionTypeCVSampleCollection;
            entity.BeginDateTime = esdatModel.DateReported;

            return entity;
        }
    }
}
