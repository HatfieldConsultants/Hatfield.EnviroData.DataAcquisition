using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class SampleFileChildObjectExtractConfiguration : IChildObjectExtractConfiguration
    {
        private IDataImporter _dataImporter;
        private string _propertyPath;
        private IValueAssigner _valueAssigner;

        public SampleFileChildObjectExtractConfiguration(IDataImporter dataImporter, string propertyPath, IValueAssigner valueAssigner)
        {
            _dataImporter = dataImporter;
            _propertyPath = propertyPath;
            _valueAssigner = valueAssigner;
        }

        public IDataImporter ChildObjectImporter
        {
            get { return _dataImporter; }
        }

        public Type ChildObjectType
        {
            get { return typeof (ChemistryFileData); }
        }

        public string PropertyPath
        {
            get { return _propertyPath; }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get { return _valueAssigner;  }
        }


        public IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport)
        {
            var extractResult = _dataImporter.Extract<SampleFileData>(dataToImport);

            _valueAssigner.AssignValue(model, _propertyPath, extractResult.ExtractedEntities, typeof(SampleFileData));

            return extractResult.AllParsingResults.Where(x => x is BaseResult);
        }
    }
}
