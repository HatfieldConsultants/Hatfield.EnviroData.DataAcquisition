using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.Criterias;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.CSV.Importers;
using Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules;
using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.DataAcquisition.CSV;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    public static class ESDATTestHelper
    {
        public static IDataImporter BuildChemistryFileImporter()
        {
            var simpleValueAssigner = new SimpleValueAssigner();

            var parserFactory = new DefaultCSVParserFactory();

            var testImporter = new SimpleCSVDataImporter(ResultLevel.ERROR, 1);

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(0,
                                                                                    "SampleCode",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(1,
                                                                                    "ChemCode",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(2,
                                                                                    "OriginalChemName",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(3,
                                                                                    "Prefix",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(4,
                                                                                    "Result",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(5,
                                                                                    "ResultUnit",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(6,
                                                                                    "TotalOrFiltered",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(7,
                                                                                    "ResultType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(8,
                                                                                    "MethodType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(9,
                                                                                    "MethodName",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            //testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(10,
            //                                                                        "ExtractionDate",
            //                                                                        parserFactory.GetCellParser(typeof(DateTime?)),
            //                                                                        simpleValueAssigner,
            //                                                                        typeof(DateTime?)));

            //testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(11,
            //                                                                        "AnalysedDate",
            //                                                                        parserFactory.GetCellParser(typeof(DateTime?)),
            //                                                                        simpleValueAssigner,
            //                                                                        typeof(DateTime?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(12,
                                                                                    "EQL",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(13,
                                                                                    "EQLUnits",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(14,
                                                                                    "Comments",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(16,
                                                                                    "UCL",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(17,
                                                                                    "LCL",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));
            return testImporter;

        }

    }
}
