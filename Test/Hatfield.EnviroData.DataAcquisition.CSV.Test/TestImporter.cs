using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.CSV.Importers;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{   

    internal class TestImporterBuilder
    {
        public IDataImporter Build()
        {
            var parserFactory = new DefaultCSVParserFactory();

            var testImporter = new SimpleCSVDataImporter();

            var dateTimeFieldExtractConfiguration = new SimpleCSVExtractConfiguration(
                                                                                        "DateTime", 
                                                                                        parserFactory.GetCellParser(typeof(DateTime)), 
                                                                                        new SimpleValueAssigner(), 
                                                                                        typeof(DateTime));
            testImporter.AddExtractConfiguration(dateTimeFieldExtractConfiguration);

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
