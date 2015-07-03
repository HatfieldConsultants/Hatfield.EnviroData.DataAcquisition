using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryActionMapper : ActionMapperBase
    {
        // Chemistry Constants
        private const string ActionTypeCVChemistry = "Specimen analysis";
        private const string isChildOfCV = "Is child of";

        protected ESDATChemistryParameters _parameters;
        protected ESDATChemistryMapperSingletonFactory _factory;

        public ChemistryActionMapper(ESDATChemistryMapperSingletonFactory factory, ESDATChemistryParameters parameters)
        {
            _parameters = parameters;
            _factory = factory;
        }

        public override Core.Action Map()
        {
            var action = Scaffold();

            // Feature Actions
            var featureAction = _factory.FeatureActionMapper.Map();
            _parameters.Linker.Link(action, featureAction);

            // Sampling Feature
            var samplingFeature = _factory.SamplingFeatureMapper.Map();
            _parameters.Linker.Link(featureAction, samplingFeature);

            // Result
            // Each Feature Action contains 1 Result (Chemistry)
            {
                var result = _factory.ResultMapper.Map();
                _parameters.Linker.Link(featureAction, result);

                // Unit
                var unit = _factory.UnitMapper.Map();
                _parameters.Linker.Link(result, unit);

                // Variable
                var variable = _factory.VariableMapper.Map();
                _parameters.Linker.Link(result, variable);

                // Datasets Result
                {
                    var datasetsResult = _factory.DatasetsResultMapper.Map();
                    _parameters.Linker.Link(result, datasetsResult);

                    var dataset = _factory.DatasetMapper.Map();
                    _parameters.Linker.Link(datasetsResult, dataset);
                }

                // Processing Level
                var processingLevel = _factory.ProcessingLevelMapper.Map();
                _parameters.Linker.Link(result, processingLevel);

                // Measurement Result
                {
                    var measurementResult = _factory.MeasurementResultMapper.Map();
                    _parameters.Linker.Link(result, measurementResult);

                    _parameters.Linker.Link(measurementResult, unit);

                    var measurementResultValue = _factory.MeasurementResultValueMapper.Map();
                    _parameters.Linker.Link(measurementResult, measurementResultValue);
                }
            }

            // Action Bies
            {
                ActionBy actionBy = _factory.ActionByMapper.Map();
                _parameters.Linker.Link(action, actionBy);

                var affiliation = _factory.AffiliationMapper.Map();
                _parameters.Linker.Link(actionBy, affiliation);

                var person = _factory.PersonMapper.Map();
                _parameters.Linker.Link(affiliation, person);
            }

            // Method
            {
                var method = _factory.MethodMapper.Map();
                _parameters.Linker.Link(action, method);

                var organization = _factory.OrganizationMapper.Map();
                _parameters.Linker.Link(method, organization);
            }

            // Related Actions
            _factory.RelatedActionMapper.SetRelationship(action, isChildOfCV, _parameters.ParentAction);
            RelatedAction relatedAction = _factory.RelatedActionMapper.Map();

            _parameters.Linker.Link(action, relatedAction);

            return action;
        }

        public override Core.Action Scaffold()
        {
            var chemistry = _parameters.ChemistryFileData;

            var entity = new Core.Action();

            entity.ActionTypeCV = ActionTypeCVChemistry;
            entity.BeginDateTime = chemistry.AnalysedDate;

            return entity;
        }
    }
}
