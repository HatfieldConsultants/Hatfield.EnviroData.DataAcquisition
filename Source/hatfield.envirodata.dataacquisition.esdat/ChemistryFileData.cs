using Hatfield.EnviroData.DataAcquisition.ESDAT.Common;
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
        public char Prefix { get; set; }
        public double Result { get; set; }
        public string ResultUnit { get; set; }
        public bool TotalOrUnfiltered { get; set; }
        public string ResultType { get; set; }
        public string MethodType { get; set; }
        public string MethodName { get; set; }
        public DateTime ExtractionDate { get; set; }
        public DateTime AnalysedDate { get; set; }
        public double EQL { get; set; }
        public string EQLUnits { get; set; }
        public string Comments { get; set; }
        public string LabQualifier { get; set; }
        public double UCL { get; set; }
        public double LCL { get; set; }

        public ChemistryFileData()
        {
            ExtractionDate = new DateTime();
            AnalysedDate = new DateTime();
        }

        public ChemistryFileData(string sampleCode, string originalChemName, string chemCode,
            char prefix, double result, string resultUnit, bool totalOrUnfiltered, string resultType,
            string methodType, string methodName, DateTime extractionDate, DateTime analysedDate,
            double eql, string eqlUnits, string comments, string labQualifier, double ucl, double lcl)
        {
            this.SampleCode = sampleCode;
            this.OriginalChemName = originalChemName;
            this.ChemCode = chemCode;
            this.Prefix = prefix;
            this.Result = result;
            this.ResultUnit = resultUnit;
            this.TotalOrUnfiltered = totalOrUnfiltered;
            this.ResultType = resultType;
            this.MethodType = methodType;
            this.MethodName = methodName;
            this.ExtractionDate = extractionDate;
            this.AnalysedDate = analysedDate;
            this.EQL = eql;
            this.EQLUnits = eqlUnits;
            this.Comments = comments;
            this.LabQualifier = labQualifier;
            this.UCL = ucl;
            this.LCL = lcl;
        }
    }
}
