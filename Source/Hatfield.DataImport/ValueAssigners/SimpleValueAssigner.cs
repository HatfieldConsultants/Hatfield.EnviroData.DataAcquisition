using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Hatfield.EnviroData.DataImport.Helpers;

namespace Hatfield.EnviroData.DataImport.ValueAssigners
{
    public class SimpleValueAssigner : IValueAssigner
    {
        public void AssignValue(object model, string path, object value, Type type)
        {
            PropertyInfo propertyInfo = null;
            var parentObject = PropertyInfoHelper.GetProperty(model, path, out propertyInfo);
            PropertyInfoHelper.SetPropertyValue(propertyInfo, parentObject, value, type);
        }
    }
}
