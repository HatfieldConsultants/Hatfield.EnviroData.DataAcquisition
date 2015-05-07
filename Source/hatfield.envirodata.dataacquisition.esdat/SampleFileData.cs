using Hatfield.EnviroData.DataAcquisition.ESDAT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class SampleFileData
    {
        public string SampleCode { get ; set; }
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
        // Not sure about the type here
        public string QA {get;set;}
        public int UCL { get; set; }
        public int LCL { get; set; }

        //public string 
        //Make constructor
    }
}
