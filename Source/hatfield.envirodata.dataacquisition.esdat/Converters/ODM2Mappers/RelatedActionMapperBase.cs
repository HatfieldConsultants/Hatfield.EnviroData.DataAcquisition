using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class RelatedActionMapperBase : IODM2Mapper<RelatedAction>
    {
        public abstract RelatedAction Scaffold();
        public abstract RelatedAction Map();

        public abstract void SetRelationship(Core.Action action, string relationshipTypeCV, Core.Action action1);
    }
}
