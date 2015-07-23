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


        public SampleCollectionActionMapper(ODM2DuplicateChecker duplicateChecker, ESDATSampleCollectionMapperFactory sampleCollectionFactory, IWQDefaultValueProvider WQDefaultValueProvider, ESDATChemistryMapperFactory chemistryFactory, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
            _sampleCollectionFactory = sampleCollectionFactory;
            _chemistryFactory = chemistryFactory;
        }

        public IEnumerable<IResult> Convert(ESDATModel model)
        {
            var action = Map(model);

            var resultLevel = ResultLevel.INFO;
            var location = new ODM2MapperSourceLocation(this.ToString(), "Core.Action");
            var message = string.Format("{0}: Core.Action is mappped.", location);
            var result = new ParsingResult(resultLevel, message, action, location);

            _iResults.Add(result);
            PrintToConsole(message);

            return _iResults;
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

                // Result Extension Property Values
                {
                    var properties = new Dictionary<string, string>();

                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeySampleCode] = sample_.SampleCode;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeyFieldID] = sample_.FieldID;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeySampleDepth] = sample_.SampleDepth.ToString();
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeyMatrixType] = sample_.MatrixType;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeySampleType] = sample_.SampleType;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeyParentSample] = sample_.ParentSample;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeySDG] = sample_.SDG;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeyLabSampleID] = sample_.LabSampleID;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeyComments] = sample_.Comments;
                    properties[ESDATSampleCollectionConstants.ResultExtensionPropertyValueKeyLabReportNumber] = sample_.LabReportNumber;

                    foreach (var property in properties)
                    {
                        var extensionProperty = _sampleCollectionFactory.ExtensionPropertyMapper.Map(property.Key);

                        var propertyID = extensionProperty.PropertyID;
                        var propertyValue = property.Value;
                        var resultExtensionPropertyValue = _sampleCollectionFactory.ResultExtensionPropertyValueMapper.Map(propertyID, propertyValue);

                        ODM2EntityLinker.Link(resultExtensionPropertyValue, extensionProperty);
                        ODM2EntityLinker.Link(result, resultExtensionPropertyValue);
                    }
                }

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
