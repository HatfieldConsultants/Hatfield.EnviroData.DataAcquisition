using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ESDATModel
    {
        //Header file properties
        public DateTime DateReported { get ; set; }
        public int ProjectId { get; set; }
        public string LabName { get; set; }
        public string LabSignatory { get; set; }
        public List<string> Associated_Files { get; set; }
        public List<string> Copies_Sent_To { get; set; }
        public int SDGID { get; set; }
        public int COCNumber { get; set; }
        public int LabRequestId { get; set; }
        public int LabRequestNumber { get; set; }
        public decimal LabRequestVersion { get; set; }

        //Other Data
        public List<AnalyzedData> AnalyzedData { get; set; }
      
    }
}
