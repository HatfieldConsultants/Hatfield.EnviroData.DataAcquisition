using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionActionMapper : ActionMapperBase
    {
        // Sample Collection Constants
        private const string ActionTypeCVSampleCollection = "Specimen collection";
        private const string isRelatedToCV = "Is related to";

        protected ESDATSampleCollectionParameters _parameters;
        protected ESDATSampleCollectionMapperSingletonFactory _factory;

        public SampleCollectionActionMapper(ESDATSampleCollectionMapperSingletonFactory factory, ESDATSampleCollectionParameters parameters)
        {
            _factory = factory;
            _parameters = parameters;
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

            // Results
            // Each Feature Action can contain many results (Samples)
            var esdatModel = _parameters.EsdatModel;

            foreach (SampleFileData sample in esdatModel.SampleFileData)
            {
                _parameters.SampleFileData = sample;
                Result result = _factory.ResultMapper.Map();

                _parameters.Linker.Link(featureAction, result);

                // Unit
                var unit = _factory.UnitMapper.Map();
                _parameters.Linker.Link(result, unit);

                // Variable
                var variable = _factory.VariableMapper.Map();
                _parameters.Linker.Link(result, variable);

                // Processing Level
                var processingLevel = _factory.ProcessingLevelMapper.Map();
                _parameters.Linker.Link(result, processingLevel);

                // Related Actions
                // Create a new related Action for each chemistry file
                // Assume that 1 unique sample maps to one or more chemistry files
                var chemistryData = esdatModel.ChemistryData.Where(x => x.SampleCode.Equals(sample.SampleCode));

                foreach (ChemistryFileData chemistry in chemistryData)
                {
                    var parameters = new ESDATChemistryParameters(_parameters.DbContext, esdatModel, sample, chemistry);
                    var factory = new ESDATChemistryMapperSingletonFactory(parameters);
                    parameters.ParentAction = action;
                    var chemistryAction = factory.ActionMapper.Map();

                    factory.RelatedActionMapper.SetRelationship(action, isRelatedToCV, chemistryAction);
                    var relatedAction = factory.RelatedActionMapper.Map();

                    _parameters.Linker.Link(action, relatedAction);
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

            return action;
        }

        public override Core.Action Scaffold()
        {
            var esdatModel = _parameters.EsdatModel;

            Core.Action entity = new Core.Action();

            entity.ActionTypeCV = ActionTypeCVSampleCollection;
            entity.BeginDateTime = esdatModel.DateReported;

            return entity;
        }
    }
}
