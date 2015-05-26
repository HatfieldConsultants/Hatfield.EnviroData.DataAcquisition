using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ChemistryFileChildObjectExtractConfiguration : ChildObjectExtractConfigurationBase
    {

        public ChemistryFileChildObjectExtractConfiguration(IDataImporter dataImporter, string propertyPath, IValueAssigner valueAssigner)
            : base(dataImporter, propertyPath, valueAssigner)
        {            
        }

        public override Type ChildObjectType
        {
            get { return typeof (ChemistryFileData); }
        }


        public override IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport)
        {
            var extractResult = _dataImporter.Extract<ChemistryFileData>(dataToImport);

            _valueAssigner.AssignValue(model, _propertyPath, extractResult.ExtractedEntities, typeof(ChemistryFileData));

            return extractResult.AllParsingResults.Where(x => x is BaseResult);
        }
    }
}
