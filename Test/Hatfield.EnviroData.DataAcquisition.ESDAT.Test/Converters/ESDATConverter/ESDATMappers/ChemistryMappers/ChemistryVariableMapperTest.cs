using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ChemistryVariableMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();
            chemistry.OriginalChemName = "XYZ";

            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new ChemistryVariableMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var variable = mapper.Draft(esdatModel, chemistry);            

            Assert.AreEqual(defaultValueProvider.DefaultVariableTypeCVChemistry, variable.VariableTypeCV);
            Assert.AreEqual(chemistry.ChemCode, variable.VariableCode);

            // This is temporarily hard-coded
            Assert.AreEqual("1,1,1-Trichloroethane", variable.VariableNameCV);

            Assert.AreEqual(chemistry.OriginalChemName, variable.VariableDefinition);
            Assert.AreEqual(defaultValueProvider.DefaultVariableSpeciationCV, variable.SpeciationCV);
            Assert.AreEqual(defaultValueProvider.DefaultVariableNoDataValue, variable.NoDataValue);
        }
    }
}
