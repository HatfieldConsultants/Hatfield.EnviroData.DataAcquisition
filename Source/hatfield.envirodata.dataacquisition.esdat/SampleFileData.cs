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
            public string LabName { get; set; }
            public string LabSampleID { get; set; }
            public string Comments { get; set; }
            public string LabReportNumber { get; set; }

            public SampleFileData(string sampleCode, DateTime sampledDateTime, string fieldID, double blank1, double sampleDepth, double blank2, string matrixType, string sampleType, string parentSample, double blank3, string sdg, string labName, string labSampleID, string comments, string labReportNumber)
            {
                this.SampleCode = sampleCode;
                this.SampledDateTime = sampledDateTime;
                this.FieldID = fieldID;
                this.Blank1 = blank1;
                this.SampleDepth = sampleDepth;
                this.Blank2 = blank2;
                this.MatrixType = matrixType;
                this.SampleType = sampleType;
                this.ParentSample = parentSample;
                this.Blank3 = blank3;
                this.SDG = sdg;
                this.LabName = labName;
                this.LabSampleID = labSampleID;
                this.Comments = comments;
                this.LabReportNumber = labReportNumber;
            }
        }
    }
