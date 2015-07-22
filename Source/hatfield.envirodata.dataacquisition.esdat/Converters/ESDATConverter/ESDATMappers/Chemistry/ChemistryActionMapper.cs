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
            var entity = Draft(esdatModel, chemistry);

            // Feature Actions
            var featureAction = _chemistryFactory.FeatureActionMapper.Map(esdatModel, chemistry);
            ODM2EntityLinker.Link(entity, featureAction);

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

                // Result Extension Property Values
                {
                    var properties = new Dictionary<string, string>();

                    properties["SampleCode"] = chemistry.SampleCode;
                    properties["Prefix"] = chemistry.Prefix;
                    properties["Total_or_Filtered"] = chemistry.TotalOrFiltered;
                    properties["Result_Type"] = chemistry.ResultType;
                    properties["EQL"] = chemistry.EQL.ToString();
                    properties["EQL_Units"] = chemistry.EQLUnits;
                    properties["Comments"] = chemistry.Comments;
                    properties["UCL"] = chemistry.UCL.ToString();
                    properties["LCL"] = chemistry.LCL.ToString();

                    foreach (var property in properties)
                    {
                        var extensionProperty = _chemistryFactory.ExtensionPropertyMapper.Map(property.Key);

                        var propertyID = extensionProperty.PropertyID;
                        var propertyValue = property.Value;
                        var resultExtensionPropertyValue = _chemistryFactory.ResultExtensionPropertyValueMapper.Map(propertyID, propertyValue);

                        ODM2EntityLinker.Link(result, resultExtensionPropertyValue);
                    }
                }
            }

            // Action Bies
            {
                ActionBy actionBy = _chemistryFactory.ActionByMapper.Map(esdatModel);
                ODM2EntityLinker.Link(entity, actionBy);

                var person = _chemistryFactory.PersonMapper.Map(esdatModel);
                _chemistryFactory.AffiliationMapper.Person = person;

                var affiliation = _chemistryFactory.AffiliationMapper.Map(esdatModel);

                ODM2EntityLinker.Link(actionBy, affiliation);
            }

            // Method
            {
                var method = _chemistryFactory.MethodMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(entity, method);

                _chemistryFactory.OrganizationMapper.SampleFileData = SampleFileData;
                var organization = _chemistryFactory.OrganizationMapper.Map(esdatModel, chemistry);
                ODM2EntityLinker.Link(method, organization);
            }

            // Related Actions
            _chemistryFactory.RelatedActionMapper.SetRelationship(entity, _WQDefaultValueProvider.ActionRelationshipTypeCVChemistry, ParentAction);
            RelatedAction relatedAction = _chemistryFactory.RelatedActionMapper.Map(esdatModel);

            ODM2EntityLinker.Link(entity, relatedAction);

            return entity;
        }

        public Core.Action Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Core.Action();

            entity.ActionTypeCV = _WQDefaultValueProvider.ActionTypeCVChemistry;
            entity.BeginDateTime = chemistry.ExtractionDate;
            entity.EndDateTime = chemistry.AnalysedDate;

            Validate(entity);

            return entity;
        }
    }
}
