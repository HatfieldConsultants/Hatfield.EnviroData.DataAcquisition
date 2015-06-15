using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATMapperInput
    {
        ActionBy ActionBy { get; set; }
        Core.Action Action { get; set; }
        Affiliation Affiliation { get; set; }
        Dataset Dataset { get; set; }
        DatasetsResult DatasetsResult { get; set; }
        FeatureAction FeatureAction { get; set; }
        MeasurementResult MeasurementResult { get; set; }
        MeasurementResultValue MeasurementResultValue { get; set; }
        Method Method { get; set; }
        Organization Organization { get; set; }
        Person Person { get; set; }
        ProcessingLevel ProcessingLevel { get; set; }
        RelatedAction RelatedAction { get; set; }
        Result Result { get; set; }
        SamplingFeature SamplingFeature { get; set; }
        Unit Unit { get; set; }
        Variable Variable { get; set; }
    }
}
