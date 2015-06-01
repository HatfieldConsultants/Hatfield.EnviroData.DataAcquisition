using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using Moq;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ConverterToODMAction
{
    class ESDATConverterToODMActionTest
    {
        protected ESDATConverterToActionBy actionByConverter = new ESDATConverterToActionBy(new Mock<IDbContext>().Object);
        protected ESDATConverterToAction actionConverter = new ESDATConverterToAction(new Mock<IDbContext>().Object);
        protected ESDATConverterToFeatureAction featureActionConverter = new ESDATConverterToFeatureAction(new Mock<IDbContext>().Object);
        protected ESDATConverterToMethod methodConverter = new ESDATConverterToMethod(new Mock<IDbContext>().Object);
        protected ESDATConverterToOrganization organizationConverter = new ESDATConverterToOrganization(new Mock<IDbContext>().Object);
        protected ESDATConverterToAffiliation affiliationConverter = new ESDATConverterToAffiliation(new Mock<IDbContext>().Object);
        protected ESDATConverterToPerson personConverter = new ESDATConverterToPerson(new Mock<IDbContext>().Object);
        protected ESDATConverterToRelatedAction relatedActionConverter = new ESDATConverterToRelatedAction(new Mock<IDbContext>().Object);
        protected ESDATConverterToSamplingFeature samplingFeatureConverter = new ESDATConverterToSamplingFeature(new Mock<IDbContext>().Object);
        protected ESDATConverterToResult resultConverter = new ESDATConverterToResult(new Mock<IDbContext>().Object);
        protected ESDATConverterToDatasetsResult datasetsResultConverter = new ESDATConverterToDatasetsResult(new Mock<IDbContext>().Object);
        protected ESDATConverterToDataset datasetConverter = new ESDATConverterToDataset(new Mock<IDbContext>().Object);
        protected ESDATConverterToProcessingLevel processingLevelConverter = new ESDATConverterToProcessingLevel(new Mock<IDbContext>().Object);
        protected ESDATConverterToUnit unitConverter = new ESDATConverterToUnit(new Mock<IDbContext>().Object);
        protected ESDATConverterToVariable variableConverter = new ESDATConverterToVariable(new Mock<IDbContext>().Object);
        protected ESDATConverterToMeasurementResult measurementResultConverter = new ESDATConverterToMeasurementResult(new Mock<IDbContext>().Object);
        protected ESDATConverterToDatasetsResult dataSetsResultConverter = new ESDATConverterToDatasetsResult(new Mock<IDbContext>().Object);
        protected ESDATConverterToMeasurementResultValue measurementResultValueConverter = new ESDATConverterToMeasurementResultValue(new Mock<IDbContext>().Object);
    }
}
