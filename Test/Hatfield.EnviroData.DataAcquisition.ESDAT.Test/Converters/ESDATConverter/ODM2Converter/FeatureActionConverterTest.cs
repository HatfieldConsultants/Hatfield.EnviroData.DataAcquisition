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
    class FeatureActionConverterTest
    {
        [Test]
        public void FeatureActionTest()
        {
            var chemistryFileData = new ChemistryFileData();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var featureActionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(FeatureAction)) as FeatureActionConverter;
            var featureAction = featureActionConverter.Convert(chemistryFileData, converterFactory);

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }
    }
}
