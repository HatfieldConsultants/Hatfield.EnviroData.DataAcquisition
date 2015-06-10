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
    class ESDATDataMapperFactoryTest
    {
        [Test]
        [TestCase(typeof(ActionBy), typeof(ActionByMapper))]
        [TestCase(typeof(Core.Action), typeof(ActionMapper))]
        [TestCase(typeof(Affiliation), typeof(AffiliationMapper))]
        [TestCase(typeof(DataSet), typeof(DatasetMapper))]
        [TestCase(typeof(DataSetsResult), typeof(DataSetsResultMapper))]
        [TestCase(typeof(FeatureAction), typeof(FeatureActionMapper))]
        [TestCase(typeof(MeasurementResult), typeof(MeasurementResultMapper))]
        [TestCase(typeof(MeasurementResultValue), typeof(MeasurementResultValueMapper))]
        [TestCase(typeof(Method), typeof(MethodMapper))]
        [TestCase(typeof(Organization), typeof(OrganizationMapper))]
        [TestCase(typeof(Person), typeof(PersonMapper))]
        [TestCase(typeof(ProcessingLevel), typeof(ProcessingLevelMapper))]
        [TestCase(typeof(RelatedAction), typeof(RelatedActionMapper))]
        [TestCase(typeof(Result), typeof(ResultMapper))]
        [TestCase(typeof(SamplingFeature), typeof(SamplingFeatureMapper))]
        [TestCase(typeof(Unit), typeof(UnitMapper))]
        [TestCase(typeof(Variable), typeof(VariableMapper))]
        public void ValidFactoryTest(Type typeToConvert, Type expectedMapperType)
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var mockDuplicateChecker = new Mock<DuplicateChecker>(mockDbContext).Object;
            var factory = new ESDATDataMapperFactory(mockDbContext, mockDuplicateChecker);

            var mapper = factory.BuildDataConverter(typeof(ESDATModel), typeToConvert);

            Assert.IsTrue(object.ReferenceEquals(expectedMapperType, mapper.GetType()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidFactoryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var mockDuplicateChecker = new Mock<DuplicateChecker>(mockDbContext).Object;
            var factory = new ESDATDataMapperFactory(mockDbContext, mockDuplicateChecker);

            var mapper = factory.BuildDataConverter(typeof(ESDATModel), null);
        }
    }
}
