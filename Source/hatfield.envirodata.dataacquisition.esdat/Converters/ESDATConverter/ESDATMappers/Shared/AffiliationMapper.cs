using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class AffiliationMapper : AffiliationMapperBase
    {
        protected ESDATMapperParametersBase _parameters;

        public AffiliationMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override Affiliation Map()
        {
            var entity = Scaffold();

            return entity;
        }

        public override Affiliation Scaffold()
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;

            return affiliation;
        }
    }
}
