using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class SampleFileChildObjectExtractConfiguration : ChildObjectExtractConfigurationBase
    {

        public SampleFileChildObjectExtractConfiguration(IDataImporter dataImporter, string propertyPath, IValueAssigner valueAssigner)
            : base(dataImporter, propertyPath, valueAssigner)
        {
        }

        public override Type ChildObjectType
        {
            get { return typeof (SampleFileData); }
        }

        public override IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport)
        {
            var extractResult = _dataImporter.Extract<SampleFileData>(dataToImport);

            _valueAssigner.AssignValue(model, _propertyPath, extractResult.ExtractedEntities, typeof(SampleFileData));

            return extractResult.AllParsingResults.Where(x => x is BaseResult);
        }
    }
}
