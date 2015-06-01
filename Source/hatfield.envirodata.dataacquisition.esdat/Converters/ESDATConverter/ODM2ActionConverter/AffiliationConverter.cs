﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class AffiliationConverter : ODM2ActionConverter
    {
        public AffiliationConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Affiliation Convert(ActionBy actionBy, PersonConverter personConverter)
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