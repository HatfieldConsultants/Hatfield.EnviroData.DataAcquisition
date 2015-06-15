using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ChemistryFileData
    {
        public string SampleCode { get; set; }
        public string OriginalChemName { get; set; }
        public string ChemCode { get; set; }
        public string Prefix { get; set; }
        public double? Result { get; set; }
        public string ResultUnit { get; set; }
        public string TotalOrFiltered { get; set; }
        public string ResultType { get; set; }
        public string MethodType { get; set; }
        public string MethodName { get; set; }
        public DateTime ExtractionDate { get; set; }
        public DateTime AnalysedDate { get; set; }
        public double? EQL { get; set; }
        public string EQLUnits { get; set; }
        public string Comments { get; set; }
        public string LabQualifier { get; set; }
        public double? UCL { get; set; }
        public double? LCL { get; set; }

        public ChemistryFileData()
        {
            ExtractionDate = new DateTime();
            AnalysedDate = new DateTime();
        }

        public ChemistryFileData(string sampleCode, string originalChemName, string chemCode,
            string prefix, double? result, string resultUnit, string totalOrFiltered, string resultType,
            string methodType, string methodName, DateTime extractionDate, DateTime analysedDate,
            double? eql, string eqlUnits, string comments, string labQualifier, double? ucl, double? lcl)
        {
            SampleCode = sampleCode;
            OriginalChemName = originalChemName;
            ChemCode = chemCode;
            Prefix = prefix;
            Result = result;
            ResultUnit = resultUnit;
            TotalOrFiltered = totalOrFiltered;
            ResultType = resultType;
            MethodType = methodType;
            MethodName = methodName;
            ExtractionDate = extractionDate;
            AnalysedDate = analysedDate;
            EQL = eql;
            EQLUnits = eqlUnits;
            Comments = comments;
            LabQualifier = labQualifier;
            UCL = ucl;
            LCL = lcl;
        }
    }
}
