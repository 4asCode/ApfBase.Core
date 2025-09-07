using ApfBuilder.Criteria;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Context;
using ApfBuilder.Services;
using static ApfBuilder.Criteria.CriterionAttribute;
using System.Runtime.Remoting.Contexts;
using Extensions;
using ApfBuilder.Criteria.Core;
using ApfBuilder.Criteria.Core.Interfaces;

namespace ApfBuilder.Criteria
{
    public class CriterionFactory : ICriterionFactory
    {
        private readonly IAPFContext _context;

        private readonly CriterionSelector _selector;

        public ICriterion[] BaseStateCriteria { get; }

        public ICriterion[] ForcedStateCriteria { get; }

        public ICriterion[] AlternateCriteria { get; }

        public CriterionFactory(IAPFContext context)
        {
            _context = context;
            _selector = new CriterionSelector();
            
            BaseStateCriteria = GetSelectedCriteria(
                CreateSimpleCriteria(),
                CreateComplexCriteria()
                )
            .ToArray();

            ForcedStateCriteria = _selector.GetSimpleSelector(
                CreateForsedStateCriteria()
                )
            .ToArray();

            AlternateCriteria = _selector.GetAlternateSelector(
                CreateAlternateCriteria()
                )
            .ToArray();
        }

        private IEnumerable<ICriterion> GetSelectedCriteria(
            IEnumerable<ICriterion> simpleCriteria,
            IEnumerable<ICriterion[]> complexCriteria)
                => _selector.GetSimpleSelector(simpleCriteria)
                    .Concat(_selector.GetComplexSelector(complexCriteria)
                    );

        private IEnumerable<ICriterion[]> CreateComplexCriteria()
        {
            foreach (var postF in _context.PreF.PostFaultConditions)
            {
                if (!(postF.Using ?? false)) continue;

                yield return new[]
                {
                    Current.CreateStandard(postF),
                    Current.CreateAOPO(postF),
                    Dynamic.Create(postF),
                    Static.Create(postF),
                    Voltage.Create(postF),
                    Frequency.Create(postF)
                };
            }
        }

        private ICriterion[] CreateSimpleCriteria()
        {
            return new[]
            {
                CurrentSecondary.CreateStandard(_context.PreF),
                CurrentSecondary.CreateAOPO(_context.PreF),
                VoltageSecondary.Create(_context.PreF),
                StaticBaseCaseTPR.Create(_context.PreF),
                StaticBaseCaseEPR.CreateStandard(_context.PreF)
            };
        }

        private ICriterion[] CreateForsedStateCriteria()
        {
            var criterionList = new List<ICriterion>()
            {
                CurrentSecondary.CreateStandard(_context.PreF),
                CurrentSecondary.CreateAOPO(_context.PreF),
                StaticBaseCaseEPR.CreateForcedState(_context.PreF)
            };

            foreach (var postF in _context.PreF.PostFaultConditions)
            {
                criterionList.Add(
                    Current.CreateStandard(postF)
                    );
                criterionList.Add(
                    Current.CreateAOPO(postF)
                    );
            }

            return criterionList.ToArray();
        }

        private IEnumerable<ICriterion> CreateAlternateCriteria()
        {
            foreach (var postF in _context.PreF.PostFaultConditions)
            {
                yield return FrequencyAlternate.Create(postF);
            }
        }
    }
}
