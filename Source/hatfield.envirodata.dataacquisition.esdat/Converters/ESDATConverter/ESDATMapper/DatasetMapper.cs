using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetMapper : ESDATMapper
    {
        // Constants
        private const string DatasetTypeCV = "other";

        public DatasetMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public Dataset Map(DatasetsResult DatasetsResult, ESDATModel esdatModel)
        {
            return Scaffold(DatasetsResult, esdatModel);
        }

        public Dataset Map(DatasetsResult DatasetsResult, ChemistryFileData chemistry)
        {
            return Scaffold(DatasetsResult, chemistry);
        }

        public Dataset Scaffold(DatasetsResult DatasetsResult, ESDATModel esdatModel)
        {
            Dataset Dataset = new Dataset();

            Dataset.DatasetUUID = ToGuid(esdatModel.SDGID);
            Dataset.DatasetTypeCV = DatasetTypeCV;
            Dataset.DatasetCode = string.Empty;
            Dataset.DatasetTitle = string.Empty;
            Dataset.DatasetAbstract = string.Empty;
            Dataset.DatasetsResults.Add(DatasetsResult);

            return Dataset;
        }

        public Dataset Scaffold(DatasetsResult DatasetsResult, ChemistryFileData chemistry)
        {
            Dataset Dataset = new Dataset();

            Dataset.DatasetTypeCV = DatasetTypeCV;
            Dataset.DatasetCode = string.Empty;
            Dataset.DatasetTitle = string.Empty;
            Dataset.DatasetAbstract = string.Empty;
            Dataset.DatasetsResults.Add(DatasetsResult);

            return Dataset;
        }

        public Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
