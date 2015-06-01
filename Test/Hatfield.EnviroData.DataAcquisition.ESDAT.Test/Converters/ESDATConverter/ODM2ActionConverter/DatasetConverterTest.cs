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
    class DatasetConverterTest : ESDATDataConverterBaseTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var esdatModel = new ESDATModel();
            esdatModel.SDGID = 101;

            var dataset = datasetConverter.Convert(new DataSetsResult(), esdatModel);

            Assert.AreEqual(0, dataset.DataSetID);
            Assert.AreEqual(datasetConverter.ToGuid(esdatModel.SDGID), dataset.DataSetUUID);
            Assert.AreEqual("other", dataset.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataset.DataSetCode);
            Assert.AreEqual(string.Empty, dataset.DataSetTitle);
            Assert.AreEqual(string.Empty, dataset.DataSetAbstract);
        }

        [Test]
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            var dataset = datasetConverter.Convert(new DataSetsResult(), chemistry);

            Assert.AreEqual(0, dataset.DataSetID);
            Assert.AreEqual(datasetConverter.ToGuid(0), dataset.DataSetUUID);
            Assert.AreEqual("other", dataset.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataset.DataSetCode);
            Assert.AreEqual(string.Empty, dataset.DataSetTitle);
            Assert.AreEqual(string.Empty, dataset.DataSetAbstract);
        }
    }
}
