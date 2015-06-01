using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Hatfield.EnviroData.DataAcquisition.Criterias;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.CSV.Importers;
using Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules;
using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.DataAcquisition.CSV;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;
using Hatfield.EnviroData.DataAcquisition.XML;

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

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(10,
                                                                                    "ExtractionDate",
                                                                                    parserFactory.GetCellParser(typeof(DateTime?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(DateTime?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(11,
                                                                                    "AnalysedDate",
                                                                                    parserFactory.GetCellParser(typeof(DateTime?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(DateTime?)));

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

        public static IDataImporter BuildSampleDataFileImporter()
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
                                                                                    "SampledDateTime",
                                                                                    parserFactory.GetCellParser(typeof(DateTime?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(DateTime?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(2,
                                                                                    "FieldID",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(4,
                                                                                    "SampleDepth",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(6,
                                                                                    "MatrixType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(7,
                                                                                    "SampleType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(8,
                                                                                    "ParentSample",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(10,
                                                                                    "SDG",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(11,
                                                                                    "LabName",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(12,
                                                                                    "LabSampleID",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(13,
                                                                                    "Comments",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(14,
                                                                                    "LabReportNumber",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));
            return testImporter;
        }

        public static void AddXMLExtractConfigurationsToImporter(IDataImporter dataImporter)
        {
            var parserFactory = new DefaultXMLParserFactory();
            var labNameFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Lab_Name", parserFactory.GetElementParser(typeof(string)), new SimpleValueAssigner(), typeof(string), "LabName");

            var dateReportedFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Date_Reported", parserFactory.GetElementParser(typeof(DateTime)), new SimpleValueAssigner(), typeof(DateTime), "DateReported");

            var projectIDFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Project_ID", parserFactory.GetElementParser(typeof(int)), new SimpleValueAssigner(), typeof(int), "ProjectId");

            var sdgIDFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "SDG_ID", parserFactory.GetElementParser(typeof(int)), new SimpleValueAssigner(), typeof(int), "SDGID");

            var labSignatoryFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Lab_Signatory", parserFactory.GetElementParser(typeof(string)), new SimpleValueAssigner(), typeof(string), "LabSignatory");

            dataImporter.AddExtractConfiguration(labNameFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(dateReportedFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(projectIDFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(sdgIDFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(labSignatoryFieldExtractConfiguration);
        }

        public static XMLDataToImport CreateXMLDatoToImport(string filePath)
        {
            var dataSource = new WindowsFileSystem(filePath);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new XMLDataToImport(dataFromFileSystem);

            return dataToImport;
        }

        public static CSVDataToImport CreateCSVDataToImport(string filePath)
        {
            var dataSource = new WindowsFileSystem(filePath);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            return dataToImport;
        }

        public static IExtractConfiguration CreateChemistryFileDataExtractConfiguration()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var simpleValueAssginer = new SimpleValueAssigner();

            var chemistryImporter = ESDATTestHelper.BuildChemistryFileImporter();

            var childObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryImporter, "ChemistryData", simpleValueAssginer);

            return childObjectExtractConfiguration;
        }

        public static IExtractConfiguration CreateSampleFileDataExtractConfiguration()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();

            var childObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            return childObjectExtractConfiguration;
        }
    }
}
