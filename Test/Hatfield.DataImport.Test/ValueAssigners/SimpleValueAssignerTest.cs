using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.ValueAssigners;

namespace Hatfield.EnviroData.DataImport.Test.ValueAssigners
{
    [TestFixture]
    public class SimpleValueAssignerTest
    {
        [Test]
        public void AssignSuccessTest()
        {
            var testModel = new SimpleValueAssignerRootClass { 
                Child = new SimpleValueAssignerChildClass()
            };

            var simpleAssigner = new SimpleValueAssigner();

            simpleAssigner.AssignValue(testModel, "RootName", "test root name", typeof(string));
            simpleAssigner.AssignValue(testModel, "RootValue", 123, typeof(int));

            simpleAssigner.AssignValue(testModel, "Child.ChildName", "test child name", typeof(string));
            simpleAssigner.AssignValue(testModel, "Child.ChildValue", 321, typeof(int));

            Assert.AreEqual("test root name", testModel.RootName);
            Assert.AreEqual(123, testModel.RootValue);
            Assert.AreEqual("test child name", testModel.Child.ChildName);
            Assert.AreEqual(321, testModel.Child.ChildValue);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "System assign value fails since it is trying to assign value to null object.")]
        public void AssignToNullValueTest()
        {
            var simpleAssigner = new SimpleValueAssigner();

            simpleAssigner.AssignValue(null, "RootName", "test", typeof(string));   
        }

        [Test]
        [TestCase("Name", "test root name", typeof(string), ExpectedExceptionName = "System.NullReferenceException", ExpectedMessage = "System could not find property 'Name' for SimpleValueAssignerRootClass.")]
        [TestCase("Child.Name", "test child name", typeof(string), ExpectedExceptionName = "System.NullReferenceException", ExpectedMessage = "System could not find property 'Name' for SimpleValueAssignerChildClass.")]
        [TestCase("RootName", 123, typeof(string), ExpectedExceptionName = "System.ArgumentException", ExpectedMessage = "System be able to find property RootName, it is expecting String type. But the actual value is Int32 type.")]
        [TestCase("Child.ChildValue", "Child Name", typeof(string), ExpectedExceptionName = "System.ArgumentException", ExpectedMessage = "System be able to find property ChildValue, it is expecting Int32 type. But the actual value is String type.")]
        public void AssignFailTest(string propertyName, object valueToAssign, Type type)
        {
            var testModel = new SimpleValueAssignerRootClass
            {
                Child = new SimpleValueAssignerChildClass()
            };

            var simpleAssigner = new SimpleValueAssigner();

            simpleAssigner.AssignValue(testModel, propertyName, valueToAssign, type);            
        }
    }

    internal class SimpleValueAssignerRootClass
    {
        public string RootName { get; set; }
        public int RootValue { get; set; }
        public SimpleValueAssignerChildClass Child { get; set; }
    }

    internal class SimpleValueAssignerChildClass
    {
        public string ChildName { get; set; }
        public int ChildValue { get; set; }
    }
}
