using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.Criterias;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.CSV.Importers;
using Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{   

    internal class TestImporterBuilder
    {
        public IDataImporter Build()
        {
            var parserFactory = new DefaultCSVParserFactory();

            var testImporter = new SimpleCSVDataImporter(ResultLevel.ERROR, 4);

            var extensionValidationRule = new CSVFileNameExtensionMatchValidationRule(".dat", false);
            testImporter.AddValidationRule(extensionValidationRule);

            var stationNameMatchRule = new CellValueMatchCriteriaValidationRule(new CSVDataSourceLocation(0, 0), new DefaultCSVParserFactory(), typeof(string), new RegexCriteria("^TOA5$"));
            testImporter.AddValidationRule(stationNameMatchRule);


            var dateTimeFieldExtractConfiguration = new SimpleCSVExtractConfiguration(0,
                                                                                      "DateTime", 
                                                                                      parserFactory.GetCellParser(typeof(DateTime)), 
                                                                                      new SimpleValueAssigner(), 
                                                                                      typeof(DateTime));

            var waterLevelExtractConfiguration = new SimpleCSVExtractConfiguration(2,
                                                                                   "WaterLevel",
                                                                                   parserFactory.GetCellParser(typeof(double?)),
                                                                                   new SimpleValueAssigner(),
                                                                                   typeof(double?));

            var waterTemperatureExtractConfiguration = new SimpleCSVExtractConfiguration(3,
                                                                                         "WaterTemperature",
                                                                                         parserFactory.GetCellParser(typeof(double?)),
                                                                                         new SimpleValueAssigner(),
                                                                                         typeof(double?));


            testImporter.AddExtractConfiguration(dateTimeFieldExtractConfiguration);
            testImporter.AddExtractConfiguration(waterLevelExtractConfiguration);
            testImporter.AddExtractConfiguration(waterTemperatureExtractConfiguration);

            return testImporter;
        }
    }

    internal class TestDataModel
    {
        public DateTime DateTime { get; set; }
        public double? WaterLevel { get; set; }
        public double? WaterTemperature { get; set; }
    }
}
