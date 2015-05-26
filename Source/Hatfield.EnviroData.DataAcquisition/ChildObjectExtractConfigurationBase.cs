using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public abstract class ChildObjectExtractConfigurationBase : IChildObjectExtractConfiguration
    {
        protected IDataImporter _dataImporter;
        protected string _propertyPath;
        protected IValueAssigner _valueAssigner;

        public ChildObjectExtractConfigurationBase(IDataImporter dataImporter, string propertyPath, IValueAssigner valueAssigner)
        {
            _dataImporter = dataImporter;
            _propertyPath = propertyPath;
            _valueAssigner = valueAssigner;
        }

        public IDataImporter ChildObjectImporter
        {
            get { return _dataImporter; }
        }

        public string PropertyPath
        {
            get { return _propertyPath; }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get { return _valueAssigner; }
        }


        public abstract Type ChildObjectType{ get; }
        public abstract IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport);

    }
}
