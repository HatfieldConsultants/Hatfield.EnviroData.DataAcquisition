using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ChemistryFeatureActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();
            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATChemistryParameters(mockDbContext, esdatModel, sample, chemistry);
            var mapper = new ChemistryFeatureActionMapper(parameters);

            var featureAction = mapper.Scaffold();

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }
    }
}
