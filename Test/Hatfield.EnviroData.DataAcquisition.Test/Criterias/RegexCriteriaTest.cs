﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.Criterias;

namespace Hatfield.EnviroData.DataAcquisition.Test.Criterias
{
    [TestFixture]
    public class RegexCriteriaTest
    {
        [Test]
        [TestCase("^Test.*$", "Test123", true)]
        [TestCase("^Test.*$", "Test", true)]
        [TestCase("^Test.*$", "test", true)]
        [TestCase("^Test.*$", "abc", false)]
        public void MatchTest(string testRegex, string testValue, bool expectedIsMatch)
        {
            var regextCriteria = new RegexCriteria(testRegex);
            var actualIsMatch = regextCriteria.Meet(testValue);

            Assert.AreEqual(expectedIsMatch, actualIsMatch);
        }

        [Test]
        public void DescriptionTest()
        {
            var regextCriteria = new RegexCriteria("Hello World");

            Assert.AreEqual("Value containing text that matches pattern \"Hello World\"", regextCriteria.Description);
        }
    }
}
