using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMeasurementResultMapper : MeasurementResultMapperBase
    {
        // Constants
        private const string CensorCodeCV = "Not censored";
        private const string QualityCodeCV = "Unknown";
        private const string AggregationStatisticCV = "Unknown";

        protected ESDATChemistryParameters _parameters;

        public ChemistryMeasurementResultMapper(ESDATChemistryParameters parameters)
        {
            _parameters = parameters;
        }

        public override MeasurementResult Map()
        {
            var entity = Scaffold();

            return entity;
        }

        public override MeasurementResult Scaffold()
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = CensorCodeCV;
            measurementResult.QualityCodeCV = QualityCodeCV;
            measurementResult.AggregationStatisticCV = AggregationStatisticCV;

            return measurementResult;
        }
    }
}
