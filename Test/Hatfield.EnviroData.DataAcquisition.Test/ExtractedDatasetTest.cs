using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;

namespace Hatfield.EnviroData.DataAcquisition.Test
{
    [TestFixture]
    public class ExtractedDatasetTest
    {
        [Test]
        public void AssertExtractedSuccessDataset()
        {
            var mockDataSourceLocation = new Mock<IDataSourceLocation>();
            var dataSet = new ExtractedDataset<int>(ResultLevel.ERROR);

            var baseResult = new BaseResult(ResultLevel.INFO, "Base result message");
            var parsingResult = new ParsingResult(ResultLevel.INFO, "Parsing result", 123, mockDataSourceLocation.Object);

            dataSet.AddParsingResult(baseResult);
            dataSet.AddParsingResult(parsingResult);

            Assert.True(dataSet.IsExtractedSuccess);
            Assert.AreEqual(ResultLevel.ERROR, dataSet.ThresholdLevel);

            var entities = dataSet.ExtractedEntities;

            Assert.AreEqual(1, entities.Count());
            Assert.AreEqual(123, (int)entities.First());

        }

        [Test]
        public void AssertExtractedFailDataset()
        {
            var mockDataSourceLocation = new Mock<IDataSourceLocation>();
            var dataSet = new ExtractedDataset<int>(ResultLevel.FATAL);

            var baseResult = new BaseResult(ResultLevel.FATAL, "Base result message");
            var parsingResult = new ParsingResult(ResultLevel.ERROR, "Parsing result", 123, mockDataSourceLocation.Object);

            dataSet.AddParsingResult(baseResult);
            dataSet.AddParsingResult(parsingResult);

            Assert.False(dataSet.IsExtractedSuccess);
            Assert.AreEqual(ResultLevel.FATAL, dataSet.ThresholdLevel);

            var entities = dataSet.ExtractedEntities;

            Assert.Null(entities);

        }
    }
}