using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATChemistryParameters : ESDATMapperParametersBase
    {
        public ESDATChemistryParameters(IDbContext dbContext, ESDATModel esdatModel, SampleFileData sampleFileData, ChemistryFileData chemistryFileData)
        {
            DbContext = dbContext;
            DuplicateChecker = new ODM2DuplicateChecker(dbContext);
            Linker = new ODM2EntityLinker();
            
            EsdatModel = esdatModel;
            SampleFileData = sampleFileData;
            ChemistryFileData = chemistryFileData;
        }
    }
}
