using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATConverter
    {
        private IDbContext _dbContext;

        public ESDATConverter(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Converts an ESDATModel to a Core.Action
        /// See https://github.com/HatfieldConsultants/Hatfield.EnviroData.Core/wiki/Loading-ESDAT-data-into-ODM2 for mapping details
        /// <returns>An EnviroData.Core.Action based on the current ESDATModel</returns>
        public Core.Action ConvertToODMAction(ESDATModel dataModel)
        {
            return null;
        }
    }
}
