using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATSampleCollectionParameters : ESDATMapperParametersBase
    {
        public ESDATSampleCollectionParameters(IDbContext dbContext, ESDATModel esdatModel)
        {
            DbContext = dbContext;
            DuplicateChecker = new ODM2DuplicateChecker(dbContext);
            Linker = new ODM2EntityLinker();

            EsdatModel = esdatModel;
            SampleFileData = null;
            ChemistryFileData = null;
        }
    }
}
