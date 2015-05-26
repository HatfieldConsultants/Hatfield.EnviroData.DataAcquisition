using Hatfield.EnviroData.DataAcquisition.Criterias;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.XML.Importers;
using Hatfield.EnviroData.DataAcquisition.XML.ValidationRules;
using Hatfield.EnviroData.DataAcquisition.XML.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.XML.Test
{
    internal class TestXMLImporterBuilder
    {
        public IDataImporter Build()
        {
            var parserFactory = new DefaultXMLParserFactory();
            var testImporter = new SimpleXMLDataImporter(ResultLevel.ERROR);

            var extensionValidationRule = new XMLFileNameExtensionMatchValidationRule(".xml", false);
            testImporter.AddValidationRule(extensionValidationRule);

            var labNameFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Lab_Name", parserFactory.GetElementParser(typeof(string)), new SimpleValueAssigner(), typeof(string), "LabName");

            var dateReportedFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Date_Reported", parserFactory.GetElementParser(typeof(DateTime)), new SimpleValueAssigner(), typeof(DateTime), "DateReported");

            var projectIDFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Project_ID", parserFactory.GetElementParser(typeof(int)), new SimpleValueAssigner(), typeof(int), "ProjectId");

            var sdgIDFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "SDG_ID", parserFactory.GetElementParser(typeof(int)), new SimpleValueAssigner(), typeof(int), "SDGID");

            var labSignatoryFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Lab_Signatory", parserFactory.GetElementParser(typeof(string)), new SimpleValueAssigner(), typeof(string), "LabSignatory");

            testImporter.AddExtractConfiguration(labNameFieldExtractConfiguration);
            testImporter.AddExtractConfiguration(dateReportedFieldExtractConfiguration);
            testImporter.AddExtractConfiguration(projectIDFieldExtractConfiguration);
            testImporter.AddExtractConfiguration(sdgIDFieldExtractConfiguration);
            testImporter.AddExtractConfiguration(labSignatoryFieldExtractConfiguration);

            return testImporter;
        }
    }
}
