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
        public ChemistryMeasurementResultValueMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public MeasurementResultValue Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            LogMappingComplete(this);

            return Scaffold(esdatModel, chemistry);
        }

        public MeasurementResultValue Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var measurementResultValue = new MeasurementResultValue();

            if (chemistry.Result.HasValue)
            {
                measurementResultValue.DataValue = (double)chemistry.Result;
            }

            measurementResultValue.ValueDateTime = chemistry.AnalysedDate;

            LogScaffoldingComplete(this);

            return measurementResultValue;
        }
    }
}
