using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public static class ESDATChemistryConstants
    {
        public static string ResultExtensionPropertyValueKeySampleCode { get { return "SampleCode"; } }
        public static string ResultExtensionPropertyValueKeyPrefix { get { return "Prefix"; } }
        public static string ResultExtensionPropertyValueKeyTotalOrFiltered { get { return "Total or Filtered"; } }
        public static string ResultExtensionPropertyValueKeyResultType { get { return "Result Type"; } }
        public static string ResultExtensionPropertyValueKeyEQL { get { return "EQL"; } }
        public static string ResultExtensionPropertyValueKeyEQLUnits { get { return "EQL Units"; } }
        public static string ResultExtensionPropertyValueKeyUCL { get { return "UCL"; } }
        public static string ResultExtensionPropertyValueKeyComments { get { return "Comments"; } }
        public static string ResultExtensionPropertyValueKeyLCL { get { return "LCL"; } }
    }
}
