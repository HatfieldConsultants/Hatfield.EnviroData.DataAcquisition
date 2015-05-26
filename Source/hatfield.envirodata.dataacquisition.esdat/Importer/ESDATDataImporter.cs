using Hatfield.EnviroData.DataAcquisition.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Importer
{
    public class ESDATDataImporter : IDataImporter
    {
        private IList<IExtractConfiguration> _extractConfigurations;
        private IList<IValidationRule> _validationRules;
        private ResultLevel _thresholdLevel = ResultLevel.ERROR;

        public ESDATDataImporter(ResultLevel thresholdLevel)
        {
            _extractConfigurations = new List<IExtractConfiguration>();
            _validationRules = new List<IValidationRule>();
            _thresholdLevel = thresholdLevel;
        }

        public bool IsDataSupported(IDataToImport dataToImport)
        {
            return dataToImport is ESDATDataToImport;
        }

        public IExtractedDataset<T> Extract<T>(IDataToImport dataToImport) where T : new()
        {
            var extractedDataset = new ExtractedDataset<T>(_thresholdLevel);

            ChemistryFileChildObjectExtractConfiguration chemistryDataExtractConfiguration = null;
            SampleFileChildObjectExtractConfiguration sampleDataExtractConfiguration = null;

            

            var castedDataToImport = dataToImport as ESDATDataToImport;

            if(castedDataToImport == null)
            {                
                extractedDataset.AddParsingResult(new BaseResult(ResultLevel.FATAL, "Data to Import needs to be ESDATDataToImport"));
            }

            try
            {
                chemistryDataExtractConfiguration = _extractConfigurations.Where(x => x is ChemistryFileChildObjectExtractConfiguration)
                                                                            .Cast<ChemistryFileChildObjectExtractConfiguration>()
                                                                            .SingleOrDefault();
            }
            catch(Exception ex)
            {
                chemistryDataExtractConfiguration = null;
                extractedDataset.AddParsingResult(new BaseResult(ResultLevel.FATAL, "ESDAT data importer needs to have one and only one Chemistry file extract configuration"));

            }

            try
            {
                sampleDataExtractConfiguration = _extractConfigurations.Where(x => x is SampleFileChildObjectExtractConfiguration)
                                                                            .Cast<SampleFileChildObjectExtractConfiguration>()
                                                                            .SingleOrDefault();
            }
            catch (Exception ex)
            {
                sampleDataExtractConfiguration = null;
                extractedDataset.AddParsingResult(new BaseResult(ResultLevel.FATAL, "ESDAT data importer needs to have one and only one Sample file extract configuration"));
            }

            var model = new T();

            var headerFileExtractResults = ExtractHeaderFile(model, _extractConfigurations, castedDataToImport.HeaderFileToImport);
            extractedDataset.AddParsingResults(headerFileExtractResults);

            if (chemistryDataExtractConfiguration != null && sampleDataExtractConfiguration != null)
            {                

                var chemistryFileExtractResults = ExtractChemistryFileData(model, chemistryDataExtractConfiguration, castedDataToImport.ChemistryFileToImport);
                extractedDataset.AddParsingResults(chemistryFileExtractResults);

                var sampleFileExtractResults = ExtractSampleFileData(model, sampleDataExtractConfiguration, castedDataToImport.SampleFileToImport);
                extractedDataset.AddParsingResults(sampleFileExtractResults);

                var parsingResult = new ParsingResult(ResultLevel.DEBUG, "Extract data from ESDAT data success", model);

                extractedDataset.AddParsingResults(new List<IResult>{parsingResult});

            }

            return extractedDataset;
        }

        public IEnumerable<IValidationRule> AllValidationRules
        {
            get { return _validationRules; }
        }

        public IEnumerable<IExtractConfiguration> ExtractConfigurations
        {
            get { return _extractConfigurations; }
        }

        public ResultLevel ThresholdLevel
        {
            get { return _thresholdLevel; }
        }

        public void AddExtractConfiguration(IExtractConfiguration extractConfigurationToAdd)
        {
            _extractConfigurations.Add(extractConfigurationToAdd);
        }

        private IEnumerable<IResult> ExtractHeaderFile(object model, IList<IExtractConfiguration> extractConfiguration, IDataToImport xmlDataToImport)
        {
            var results = new List<IResult>();
            IDataSourceLocation currentLocation = null;
            foreach (var configuration in extractConfiguration.Where(x => x is ISimpleExtractConfiguration))
            {
                if (configuration is SimpleXMLExtractConfiguration)
                {
                    currentLocation = new XMLDataSourceLocation(((SimpleXMLExtractConfiguration)configuration).ElementName, ((SimpleXMLExtractConfiguration)configuration).AttributeName);
                }

                results.AddRange(((SimpleXMLExtractConfiguration)configuration).ExtractData(model, xmlDataToImport, currentLocation));

            }

            return results;
        }

        private IEnumerable<IResult> ExtractChemistryFileData(object model, ChemistryFileChildObjectExtractConfiguration configuration, IDataToImport dataToImport)
        {
            var extractResults = configuration.ExtractData(model, dataToImport);

            return extractResults;        
        }

        private IEnumerable<IResult> ExtractSampleFileData(object model, SampleFileChildObjectExtractConfiguration configuration, IDataToImport dataToImport)
        {
            var extractResults = configuration.ExtractData(model, dataToImport);

            return extractResults;  
        }


        
    }
}
