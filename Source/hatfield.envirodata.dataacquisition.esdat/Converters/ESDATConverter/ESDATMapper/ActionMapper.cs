using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionMapper : ESDATMapper
    {
        // Sample Collection Constants
        private const string ActionTypeCVSampleCollection = "specimenCollection";
        private const string isRelatedToCV = "isRelatedTo";

        // Chemistry Constants
        private const string ActionTypeCVChemistry = "specimenAnalysis";
        private const string isChildOfCV = "isChildOf";

        // Mappers
        private FeatureActionMapper _featureActionMapper;
        private ActionByMapper _actionByMapper;
        private MethodMapper _methodMapper;
        private RelatedActionMapper _relatedActionMapper;

        public ActionMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _featureActionMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(FeatureAction)) as FeatureActionMapper;
            _actionByMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(ActionBy)) as ActionByMapper;
            _methodMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Method)) as MethodMapper;
            _relatedActionMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(RelatedAction)) as RelatedActionMapper;
        }

        public Core.Action Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            // Feature Actions
            var featureAction = _featureActionMapper.Map(esdatModel);
            _linker.Link(entity, featureAction);

            // Action Bies
            ActionBy actionBy = _actionByMapper.Map();
            _linker.Link(entity, actionBy);

            // Method
            var method = _methodMapper.Map(esdatModel);
            _linker.Link(entity, method);

            // Related Actions
            foreach (ChemistryFileData chemistry in esdatModel.ChemistryData)
            {
                Core.Action chemistryAction = Map(chemistry, esdatModel, entity);

                RelatedAction relatedAction = _relatedActionMapper.Map(entity, isRelatedToCV, chemistryAction);

                _linker.Link(entity, relatedAction);
            }

            return entity;
        }

        public Core.Action Map(ChemistryFileData chemistry, ESDATModel esdatModel, Core.Action parentAction)
        {
            var entity = Scaffold(chemistry);

            // Feature Actions
            var featureAction = _featureActionMapper.Map(chemistry);
            _linker.Link(entity, featureAction);

            // Action Bies
            ActionBy actionBy = _actionByMapper.Map();
            _linker.Link(entity, actionBy);

            // Method
            var method = _methodMapper.Map(chemistry);
            _linker.Link(entity, method);

            // Related Actions
            if (parentAction != null)
            {
                RelatedAction relatedAction = _relatedActionMapper.Map(entity, isChildOfCV, parentAction);

                _linker.Link(entity, relatedAction);
            }

            return entity;
        }

        public Core.Action Scaffold(ESDATModel esdatModel)
        {
            Core.Action action = new Core.Action();

            action.ActionTypeCV = ActionTypeCVSampleCollection;
            action.BeginDateTime = esdatModel.DateReported;

            return action;
        }

        public Core.Action Scaffold(ChemistryFileData chemistry)
        {
            var entity = new Core.Action();

            entity.ActionTypeCV = ActionTypeCVChemistry;
            entity.BeginDateTime = chemistry.AnalysedDate;

            return entity;
        }
    }
}
