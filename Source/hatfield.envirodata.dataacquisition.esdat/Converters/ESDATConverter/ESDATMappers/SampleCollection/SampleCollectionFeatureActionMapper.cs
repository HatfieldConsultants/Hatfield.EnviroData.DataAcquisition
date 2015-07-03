using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionFeatureActionMapper : FeatureActionMapperBase
    {
        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionFeatureActionMapper(ESDATSampleCollectionParameters parameters)
        {
            _parameters = parameters;
        }

        public override FeatureAction Map()
        {
            var entity = Scaffold();

            return entity;
        }

        public override FeatureAction Scaffold()
        {
            return new FeatureAction();
        }
    }
}
