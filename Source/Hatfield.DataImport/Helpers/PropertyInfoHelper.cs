using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Hatfield.EnviroData.DataImport.Helpers
{
    public static class PropertyInfoHelper
    {
        public static object GetProperty(object SourceObject, string PropertyPath, out PropertyInfo PropertyInfo)
        {
            try
            {
                if (SourceObject == null)
                {
                    throw new NullReferenceException("System assign value fails since it is trying to assign value to null object.");                    
                }
                string[] Splitter = { "." };
                string[] SourceProperties = PropertyPath.Split(Splitter, StringSplitOptions.None);
                object TempSourceProperty = SourceObject;
                Type PropertyType = SourceObject.GetType();
                PropertyInfo = GetPropertyInfoFromSinglePath(PropertyType, SourceProperties[0]);
                PropertyType = PropertyInfo.PropertyType;
                for (int x = 1; x < SourceProperties.Length; ++x)
                {
                    if (TempSourceProperty != null)
                    {
                        TempSourceProperty = PropertyInfo.GetValue(TempSourceProperty, null);
                    }
                    PropertyInfo = GetPropertyInfoFromSinglePath(PropertyType, SourceProperties[x]);
                    PropertyType = PropertyInfo.PropertyType;
                }
                return TempSourceProperty;
            }
            catch { throw; }
        }

        public static void SetPropertyValue(PropertyInfo propertyInfo, object model, object value, Type type)
        {
            try
            {
                propertyInfo.SetValue(model, value, null);            
            }
            catch(ArgumentException)
            {
                throw new ArgumentException(
                        string.Format("System be able to find property {0}, it is expecting {1} type. But the actual value is {2} type.", propertyInfo.Name, propertyInfo.PropertyType.Name, value.GetType().Name)
                    );
            }
            
        }

        private static PropertyInfo GetPropertyInfoFromSinglePath(Type type, string singlePath)
        {
            var propertyInfo = type.GetProperty(singlePath);
            if(propertyInfo == null)
            {
                throw new NullReferenceException(
                    string.Format("System could not find property '{0}' for {1}.", singlePath, type.Name)
                    );
            }
            
            return propertyInfo;
        }
    }
}
