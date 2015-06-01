using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToAffiliation : ESDATConverterToODMAction
    {
        public ESDATConverterToAffiliation(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Affiliation Convert(ActionBy actionBy, ESDATConverterToPerson personConverter)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;
            affiliation.ActionBies.Add(actionBy);
            affiliation.Person = personConverter.Convert(affiliation);

            return affiliation;
        }
    }
}
