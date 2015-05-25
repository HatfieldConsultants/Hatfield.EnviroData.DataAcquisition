using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public abstract class ChildObjectExtractConfigurationBase : IChildObjectExtractConfiguration
    {
        public IDataImporter ChildObjectImporter
        {
            get { throw new NotImplementedException(); }
        }

        public string PropertyPath
        {
            get { throw new NotImplementedException(); }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get { throw new NotImplementedException(); }
        }


        public Type ChildObjectType
        {
            get { throw new NotImplementedException(); }
        }


        public abstract IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport);

    }
}
