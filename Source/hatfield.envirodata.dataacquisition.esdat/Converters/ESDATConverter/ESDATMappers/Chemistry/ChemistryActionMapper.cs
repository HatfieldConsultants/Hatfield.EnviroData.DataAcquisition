using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryActionMapper : ActionMapperBase, IESDATChemistryMapper<Core.Action>
    {
        public SampleFileData SampleFileData { get; set; }
        protected ESDATChemistryMapperFactory _chemistryFactory;
        public Core.Action ParentAction { get; set; }

        public ChemistryActionMapper(ESDATDuplicateChecker duplicateChecker, ESDATChemistryMapperFactory factory, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
            _chemistryFactory = factory;
        }

        public Core.Action Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var action = Scaffold(esdatModel, chemistry);

            // Feature Actions
            var featureAction = _chemistryFactory.FeatureActionMapper.Map(esdatModel, chemistry);
            ODM2EntityLinker.Link(action, featureAction);

            // Sampling Feature
            var samplingFeature = _chemistryFactory.SamplingFeatureMapper.Map(esdatModel, chemistry);
            ODM2EntityLinker.Link(featureAction, samplingFeature);

            // Result
            // Each Feature Action contains 1 Result (Chemistry)
            {
                var result = _chemistryFactory.ResultMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(featureAction, result);

                // Unit
                var unit = _chemistryFactory.UnitMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(result, unit);

                // Variable
                var variable = _chemistryFactory.VariableMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(result, variable);

                // Datasets Result
                {
                    var datasetsResult = _chemistryFactory.DatasetsResultMapper.Map(esdatModel);
                    ODM2EntityLinker.Link(result, datasetsResult);

                    var dataset = _chemistryFactory.DatasetMapper.Map(esdatModel);
                    ODM2EntityLinker.Link(datasetsResult, dataset);
                }

                // Processing Level
                var processingLevel = _chemistryFactory.ProcessingLevelMapper.Map(esdatModel);
                ODM2EntityLinker.Link(result, processingLevel);

                // Measurement Result
                {
                    var measurementResult = _chemistryFactory.MeasurementResultMapper.Map(esdatModel, chemistry);
                    ODM2EntityLinker.Link(result, measurementResult);

                    ODM2EntityLinker.Link(measurementResult, unit);

                    var measurementResultValue = _chemistryFactory.MeasurementResultValueMapper.Map(esdatModel, chemistry);
                    ODM2EntityLinker.Link(measurementResult, measurementResultValue);
                }
            }

            // Action Bies
            {
                ActionBy actionBy = _chemistryFactory.ActionByMapper.Map(esdatModel);
                ODM2EntityLinker.Link(action, actionBy);

                var person = _chemistryFactory.PersonMapper.Map(esdatModel);
                _chemistryFactory.AffiliationMapper.Person = person;
                
                var affiliation = _chemistryFactory.AffiliationMapper.Map(esdatModel);

                ODM2EntityLinker.Link(actionBy, affiliation);
            }

            // Method
            {
                var method = _chemistryFactory.MethodMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(action, method);

                _chemistryFactory.OrganizationMapper.SampleFileData = SampleFileData;
                var organization = _chemistryFactory.OrganizationMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(method, organization);
            }

            // Related Actions
            _chemistryFactory.RelatedActionMapper.SetRelationship(action, _WQDefaultValueProvider.ActionRelationshipTypeCVChemistry, ParentAction);
            RelatedAction relatedAction = _chemistryFactory.RelatedActionMapper.Map(esdatModel);

            ODM2EntityLinker.Link(action, relatedAction);

            LogMappingComplete(this);

            return action;
        }

        public Core.Action Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Core.Action();

            entity.ActionTypeCV = _WQDefaultValueProvider.ActionTypeCVChemistry;
            entity.BeginDateTime = chemistry.AnalysedDate;

            LogScaffoldingComplete(this);

            return entity;
        }
    }
}
