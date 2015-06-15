using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MethodMapper : ESDATMapper
    {
        // Sample Collection Constants
        private const string MethodTypeCVSampleCollection = "fieldActivity";
        private const string MethodNameSampleCollection = "Sample Collection";

        // Chemistry Constants
        private const string MethodTypeCVChemistry = "specimenAnalysis";

        public MethodMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public Method Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(entity);

            return entity;
        }

        public Method Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);
            entity = GetDuplicate(entity);

            return entity;
        }

        public Method Scaffold(ESDATModel esdatModel)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = MethodNameSampleCollection;

            return method;
        }

        public Method Scaffold(ChemistryFileData chemistry)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVChemistry;
            method.MethodCode = string.Empty;
            method.MethodName = chemistry.MethodName;

            return method;
        }

        public Method GetDuplicate(Method entity)
        {
            return GetDuplicate(entity, x =>
                x.MethodTypeCV.Equals(entity.MethodTypeCV) &&
                x.MethodName.Equals(entity.MethodName)
            );
        }
    }
}
