using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class DataSetsResultConverterTest
    {
        [Test]
        public void DataSetsResultTest()
        {
            var chemistry = new ChemistryFileData();
            var result = new Result();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var dataSetsResultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSetsResult)) as DataSetsResultConverter;
            var datasetsResult = dataSetsResultConverter.Convert(chemistry, result, converterFactory);

            Assert.AreEqual(0, datasetsResult.BridgeID);
            Assert.AreEqual(0, datasetsResult.DataSetID);
            Assert.AreEqual(0, datasetsResult.ResultID);
        }
    }
}
