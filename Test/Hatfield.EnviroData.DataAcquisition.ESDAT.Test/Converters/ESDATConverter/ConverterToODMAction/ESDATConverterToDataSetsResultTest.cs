using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ConverterToODMAction
{
    [TestFixture]
    class ESDATConverterToDataSetsResultTest : ESDATConverterToODMActionTest
    {
        [Test]
        public void DataSetsResultTest()
        {
            var chemistry = new ChemistryFileData();
            var datasetsResult = dataSetsResultConverter.Convert(new Result(), chemistry, datasetConverter);

            Assert.AreEqual(0, datasetsResult.BridgeID);
            Assert.AreEqual(0, datasetsResult.DataSetID);
            Assert.AreEqual(0, datasetsResult.ResultID);
        }
    }
}
