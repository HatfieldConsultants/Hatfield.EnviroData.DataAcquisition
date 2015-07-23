using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMeasurementResultValueMapper : MeasurementResultValueMapperBase, IESDATChemistryMapper<MeasurementResultValue>
    {
        public ChemistryMeasurementResultValueMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public MeasurementResultValue Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Draft(esdatModel, chemistry);

            return entity;
        }

        public MeasurementResultValue Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new MeasurementResultValue();

            entity.DataValue = (double)chemistry.Result;
            entity.ValueDateTime = chemistry.AnalysedDate;

            Validate(entity);

            return entity;
        }
    }
}
