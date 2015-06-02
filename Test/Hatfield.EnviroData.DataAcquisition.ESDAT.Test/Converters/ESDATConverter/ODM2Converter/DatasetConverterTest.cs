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
    class DatasetConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var esdatModel = new ESDATModel();
            esdatModel.SDGID = 101;
            var dataSetsResult = new DataSetsResult();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var datasetConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSet)) as DataSetConverter;
            var dataSet = datasetConverter.Convert(dataSetsResult, esdatModel);

            Assert.AreEqual(0, dataSet.DataSetID);
            Assert.AreEqual(datasetConverter.ToGuid(esdatModel.SDGID), dataSet.DataSetUUID);
            Assert.AreEqual("other", dataSet.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DataSetCode);
            Assert.AreEqual(string.Empty, dataSet.DataSetTitle);
            Assert.AreEqual(string.Empty, dataSet.DataSetAbstract);
        }

        [Test]
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            var dataSetsResult = new DataSetsResult();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var datasetConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSet)) as DataSetConverter;
            var dataSet = datasetConverter.Convert(dataSetsResult, chemistry);

            Assert.AreEqual(0, dataSet.DataSetID);
            Assert.AreEqual(datasetConverter.ToGuid(0), dataSet.DataSetUUID);
            Assert.AreEqual("other", dataSet.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DataSetCode);
            Assert.AreEqual(string.Empty, dataSet.DataSetTitle);
            Assert.AreEqual(string.Empty, dataSet.DataSetAbstract);
        }
    }
}
