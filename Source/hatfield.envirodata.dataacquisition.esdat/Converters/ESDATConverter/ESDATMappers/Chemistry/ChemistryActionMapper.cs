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

        // Chemistry Constants
        private const string ActionTypeCVChemistry = "Specimen analysis";
        private const string isChildOfCV = "Is child of";

        protected ESDATChemistryMapperFactory _factory;
        public  Core.Action ParentAction { get; set; }

        public ChemistryActionMapper(ESDATDuplicateChecker duplicateChecker, ESDATChemistryMapperFactory factory, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
            _factory = factory;
        }

        public Core.Action Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var action = Scaffold(esdatModel, chemistry);

            // Feature Actions
            var featureAction = _factory.FeatureActionMapper.Map(esdatModel, chemistry);
            ODM2EntityLinker.Link(action, featureAction);

            // Sampling Feature
            var samplingFeature = _factory.SamplingFeatureMapper.Map(esdatModel, chemistry);
            ODM2EntityLinker.Link(featureAction, samplingFeature);

            // Result
            // Each Feature Action contains 1 Result (Chemistry)
            {
                var result = _factory.ResultMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(featureAction, result);

                // Unit
                var unit = _factory.UnitMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(result, unit);

                // Variable
                var variable = _factory.VariableMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(result, variable);

                // Datasets Result
                {
                    var datasetsResult = _factory.DatasetsResultMapper.Map(esdatModel);
                    ODM2EntityLinker.Link(result, datasetsResult);

                    var dataset = _factory.DatasetMapper.Map(esdatModel);
                    ODM2EntityLinker.Link(datasetsResult, dataset);
                }

                // Processing Level
                var processingLevel = _factory.ProcessingLevelMapper.Map(esdatModel);
                ODM2EntityLinker.Link(result, processingLevel);

                // Measurement Result
                {
                    var measurementResult = _factory.MeasurementResultMapper.Map(esdatModel, chemistry);
                    ODM2EntityLinker.Link(result, measurementResult);

                    ODM2EntityLinker.Link(measurementResult, unit);

                    var measurementResultValue = _factory.MeasurementResultValueMapper.Map(esdatModel, chemistry);
                    ODM2EntityLinker.Link(measurementResult, measurementResultValue);
                }
            }

            // Action Bies
            {
                ActionBy actionBy = _factory.ActionByMapper.Map(esdatModel);
                ODM2EntityLinker.Link(action, actionBy);

                var affiliation = _factory.AffiliationMapper.Map(esdatModel);
                ODM2EntityLinker.Link(actionBy, affiliation);

                var person = _factory.PersonMapper.Map(esdatModel);
                ODM2EntityLinker.Link(affiliation, person);
            }

            // Method
            {
                var method = _factory.MethodMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(action, method);

                _factory.OrganizationMapper.SampleFileData = SampleFileData;
                var organization = _factory.OrganizationMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(method, organization);
            }

            // Related Actions
            _factory.RelatedActionMapper.SetRelationship(action, isChildOfCV, ParentAction);
            RelatedAction relatedAction = _factory.RelatedActionMapper.Map(esdatModel);

            ODM2EntityLinker.Link(action, relatedAction);

            return action;
        }

        public Core.Action Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Core.Action();

            entity.ActionTypeCV = ActionTypeCVChemistry;
            entity.BeginDateTime = chemistry.AnalysedDate;

            return entity;
        }
    }
}
