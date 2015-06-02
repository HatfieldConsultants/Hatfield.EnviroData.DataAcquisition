using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class AffiliationConverter : ODM2ConverterBase
    {
        public AffiliationConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Affiliation Convert(ActionBy actionBy, IESDATDataConverterFactory converterFactory)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;
            affiliation.ActionBies.Add(actionBy);

            var personConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Person)) as PersonConverter;
            affiliation.Person = personConverter.Convert(affiliation);

            return affiliation;
        }

        public Affiliation Convert(Organization organization, IESDATDataConverterFactory converterFactory)
        {
            Affiliation affiliation = new Affiliation();
            
            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;
            affiliation.OrganizationID = organization.OrganizationID;
            affiliation.Organization = organization;

            var personConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Person)) as PersonConverter;
            affiliation.Person = personConverter.Convert(affiliation);

            return affiliation;
        }
    }
}
