using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMeasurementResultMapper : MeasurementResultMapperBase, IESDATChemistryMapper<MeasurementResult>
    {
        // Constants
        private const string CensorCodeCV = "Not censored";
        private const string QualityCodeCV = "Unknown";
        private const string AggregationStatisticCV = "Unknown";

        public ChemistryMeasurementResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public MeasurementResult Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);

            return entity;
        }

        public MeasurementResult Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = CensorCodeCV;
            measurementResult.QualityCodeCV = QualityCodeCV;
            measurementResult.AggregationStatisticCV = AggregationStatisticCV;

            return measurementResult;
        }
    }
}
