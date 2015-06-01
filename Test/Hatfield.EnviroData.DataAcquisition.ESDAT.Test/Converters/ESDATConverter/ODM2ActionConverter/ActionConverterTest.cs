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
    class ActionConverterTest : ODM2ActionConverterTest
    {
        [Test]
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            chemistry.AnalysedDate = DateTime.Now;

            var parentAction = new Core.Action();

            Core.Action action = actionConverter.Convert(chemistry, parentAction, actionByConverter, featureActionConverter, methodConverter, organizationConverter, affiliationConverter, personConverter, relatedActionConverter, samplingFeatureConverter, resultConverter, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);

            Assert.AreEqual(0, action.ActionID);
            Assert.AreEqual("specimenAnalysis", action.ActionTypeCV);
            Assert.AreEqual(0, action.MethodID);
            Assert.AreEqual(chemistry.AnalysedDate, action.BeginDateTime);
            Assert.AreEqual(0, action.BeginDateTimeUTCOffset);
            Assert.AreEqual(null, action.EndDateTime);
            Assert.AreEqual(null, action.EndDateTimeUTCOffset);
            Assert.AreEqual(null, action.ActionDescription);
            Assert.AreEqual(null, action.ActionFileLink);
        }
    }
}
