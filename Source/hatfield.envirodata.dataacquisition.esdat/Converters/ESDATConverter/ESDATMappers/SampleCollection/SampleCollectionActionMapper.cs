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


        public SampleCollectionActionMapper(ESDATDuplicateChecker duplicateChecker, ESDATSampleCollectionMapperFactory sampleCollectionFactory, IWQDefaultValueProvider WQDefaultValueProvider, ESDATChemistryMapperFactory chemistryFactory, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
            _sampleCollectionFactory = sampleCollectionFactory;
            _chemistryFactory = chemistryFactory;
        }

        public IEnumerable<IResult> Convert(ESDATModel model)
        {
            var action = Map(model);

            var resultLevel = ResultLevel.INFO;
            var location = new MapperSourceLocation(this.ToString(), "Core.Action");
            var message = string.Format("{0}: Core.Action is mappped.", location);
            var result = new ParsingResult(resultLevel, message, action, location);

            _results.Add(result);
            PrintToConsole(message);

            return _results;
        }

        public Core.Action Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);

            // Feature Actions
            var featureAction = _sampleCollectionFactory.FeatureActionMapper.Map(esdatModel);
            ODM2EntityLinker.Link(entity, featureAction);

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
                    _chemistryFactory.ActionMapper.ParentAction = entity;
                    _chemistryFactory.ActionMapper.SampleFileData = sample_;
                    var chemistryAction = _chemistryFactory.ActionMapper.Map(esdatModel, chemistry_);

                    _chemistryFactory.RelatedActionMapper.SetRelationship(entity, _WQDefaultValueProvider.ActionRelationshipTypeCVSampleCollection, chemistryAction);
                    var relatedAction = _chemistryFactory.RelatedActionMapper.Map(esdatModel);

                    ODM2EntityLinker.Link(entity, relatedAction);
                }
            }

            // Action Bies
            {
                ActionBy actionBy = _sampleCollectionFactory.ActionByMapper.Map(esdatModel);
                ODM2EntityLinker.Link(entity, actionBy);

                var person = _chemistryFactory.PersonMapper.Map(esdatModel);
                _chemistryFactory.AffiliationMapper.Person = person;

                var affiliation = _chemistryFactory.AffiliationMapper.Map(esdatModel);

                ODM2EntityLinker.Link(actionBy, affiliation);
            }


            // Method
            {
                var method = _sampleCollectionFactory.MethodMapper.Map(esdatModel);
                ODM2EntityLinker.Link(entity, method);

                var organization = _sampleCollectionFactory.OrganizationMapper.Map(esdatModel);
                ODM2EntityLinker.Link(method, organization);
            }

            return entity;
        }

        public Core.Action Draft(ESDATModel esdatModel)
        {
            var entity = new Core.Action();

            entity.ActionTypeCV = _WQDefaultValueProvider.ActionTypeCVSampleCollection;
            entity.BeginDateTime = esdatModel.DateReported;

            Validate(entity);

            return entity;
        }
    }
}
