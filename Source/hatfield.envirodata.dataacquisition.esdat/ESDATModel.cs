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
        public DateTime Date_Reported { get ; set; }
        public int Project_Id { get; set; }
        public string Lab_Name { get; set; }
        public string Lab_Signatory { get; set; }
        public List<string> Associated_Files { get; set; }
        public List<string> Copies_Sent_To { get; set; }
        public int SDG_ID { get; set; }
        public int COC_Number { get; set; }
        public int Lab_Request_Id { get; set; }
        public int Lab_Request_Number { get; set; }
        public decimal Lab_Request_Version { get; set; }

        //Other Data
        public List<AnalyzedData> AnalyzedData { get; set; }
      
    }
}
