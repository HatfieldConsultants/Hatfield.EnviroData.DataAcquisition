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
    class PersonConverterTest
    {
        [Test]
        public void PersonTest()
        {
            var affiliation = new Affiliation();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var personConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Person)) as PersonConverter;
            var person = personConverter.Convert(affiliation);

            Assert.AreEqual(0, person.PersonID);
            Assert.AreEqual(string.Empty, person.PersonFirstName);
            Assert.AreEqual(null, person.PersonMiddleName);
            Assert.AreEqual(string.Empty, person.PersonLastName);
        }
    }
}
