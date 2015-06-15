using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetsResultMapper : ESDATMapper
    {
        // Mappers
        private DatasetMapper _datasetMapper;

        public DatasetsResultMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _datasetMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Dataset)) as DatasetMapper;
        }

        public DatasetsResult Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);

            var dataset = _datasetMapper.Map(entity, chemistry);
            _linker.Link(entity, dataset);

            return entity;
        }

        public DatasetsResult Scaffold(ChemistryFileData chemistry)
        {
            return new DatasetsResult();
        }
    }
}
