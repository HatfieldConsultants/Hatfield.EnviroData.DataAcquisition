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
        public DateTime SampledDateTime { get; set; }
        public string FieldID { get; set; }
        public double Blank1 { get; set; }
        public double SampleDepth { get; set; }
        public double Blank2 { get; set; }
        public string MatrixType { get; set; }
        public string SampleType { get; set; }
        public string ParentSample { get; set; }
        public double Blank3 { get; set; }
        public string SDG { get; set; }
        public string Lab_Name { get; set; }
        public string LabSampleID { get; set; }
        public string Comments { get; set; }
        public string LabReportNumber { get; set; }
    }
}
