using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class AnalyzedData
    {
        List<ChemistryFileData> ChemistryFileData { get; set; }
        List<SampleFileData> SampleFileData { get; set; }

        public AnalyzedData(List<ChemistryFileData> chemData, List<SampleFileData> sampleData)
        {
            this.SampleFileData = sampleData;
            this.ChemistryFileData = chemData;
        }
    }
}
