using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ConverterToODMAction
{
    [TestFixture]
    class ESDATConverterToPersonTest : ESDATConverterToODMActionTest
    {
        [Test]
        public void PersonTest()
        {
            var person = personConverter.Convert(new Affiliation());

            Assert.AreEqual(0, person.PersonID);
            Assert.AreEqual(string.Empty, person.PersonFirstName);
            Assert.AreEqual(null, person.PersonMiddleName);
            Assert.AreEqual(string.Empty, person.PersonLastName);
        }
    }
}
