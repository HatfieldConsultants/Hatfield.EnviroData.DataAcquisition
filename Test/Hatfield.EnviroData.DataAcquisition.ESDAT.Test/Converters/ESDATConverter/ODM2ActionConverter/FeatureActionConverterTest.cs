using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ODMActionConverter
{
    [TestFixture]
    class FeatureActionConverterTest : ODM2ActionConverterTest
    {
        [Test]
        public void FeatureActionTest()
        {
            var chemistryFileData = new ChemistryFileData();

            var featureAction = featureActionConverter.Convert(chemistryFileData, samplingFeatureConverter, resultConverter, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }
    }
}
