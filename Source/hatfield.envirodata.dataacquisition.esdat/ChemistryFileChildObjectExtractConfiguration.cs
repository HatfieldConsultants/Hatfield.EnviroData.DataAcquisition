using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ChemistryFileChildObjectExtractConfiguration : IChildObjectExtractConfiguration
    {
        private IDataImporter _dataImporter;
        private string _propertyPath;
        private IValueAssigner _valueAssigner;

        public ChemistryFileChildObjectExtractConfiguration(IDataImporter dataImporter, string propertyPath, IValueAssigner valueAssigner)
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
            var extractResult = _dataImporter.Extract<ChemistryFileData>(dataToImport);

            _valueAssigner.AssignValue(model, _propertyPath, extractResult.ExtractedEntities, typeof(ChemistryFileData));

            return extractResult.AllParsingResults;
        }
    }
}
