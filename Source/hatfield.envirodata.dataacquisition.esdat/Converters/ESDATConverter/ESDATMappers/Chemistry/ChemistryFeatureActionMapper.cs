using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryFeatureActionMapper : FeatureActionMapperBase, IESDATChemistryMapper<FeatureAction>
    {
        public ChemistryFeatureActionMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public FeatureAction Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);

            return entity;
        }

        public FeatureAction Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            return new FeatureAction();
        }
    }
}
