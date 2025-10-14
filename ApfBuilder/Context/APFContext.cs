using ApfBuilder.Criteria.Core.Interfaces;
using ApfBuilder.PowerFlow;
using ApfBuilder.Services;
using ApfBuilder.Services.Analysis;
using DataBaseModels.ApfBaseEntities;
using Exceptions.ApfBuilder;
using Serialize;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApfBuilder.Context
{
    public class APFContext : IAPFContext
    {
        private static volatile object _locker = new object();

        private APF _apf;

        private PreFaultConditions _preF;

        public APF Apf { get => _apf; set => _apf = value; }

        public PreFaultConditions PreF => _preF;

        public IPowerFlow[] PowerFlows { get; set; }

        private APFContext(IAPFContextParticipant participant)
        {
            if (participant is PreFaultConditions preF)
            {
                _preF = preF;
                _apf = new APF
                {
                    BranchGroupVsBranchGroupSchemeId =
                        _preF.BranchGroupVsBranchGroupSchemeId,
                    PreFaultConditionsId = _preF.Id,
                };
            }
            else if (participant is PostFaultConditions postF)
            {
                var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString);

                _preF = EntityProvider.GetEntity<PreFaultConditions>(context,
                    p => p.BranchGroupVsBranchGroupSchemeId == 
                        postF.BranchGroupVsBranchGroupSchemeId &&
                        p.Id == postF.PreFaultConditionsId)
                    .FirstOrDefault();

                _apf = new APF
                {
                    BranchGroupVsBranchGroupSchemeId =
                        _preF.BranchGroupVsBranchGroupSchemeId,
                    PreFaultConditionsId = _preF.Id,
                };
            }
        }

        private APFContext(PreFaultConditions preF, APF apf)
        {
            _preF = preF;
            _apf = apf;
        }

        private static IList<IAPFContext> GetContextCollections(
            IEnumerable<PreFaultConditions> preFaultCollections, 
                int maxThreads) => 
                    preFaultCollections
                    .AsParallel()
                    .WithDegreeOfParallelism(maxThreads)
                    .Select(x => (IAPFContext)
                        new APFContext(x, new APF
                            {
                                BranchGroupVsBranchGroupSchemeId = 
                                    x.BranchGroupVsBranchGroupSchemeId,
                                PreFaultConditionsId = x.Id,
                            }
                        )
                    )
                    .ToList();

        public static IAPFContext ContextInitialize(
            IAPFContextParticipant partContext) => 
                new APFContext(partContext);

        public static IList<IAPFContext> ContextInitialize(
            Expression<Func<PreFaultConditions, bool>> filter, 
            int maxThreads = 4)
        {
            using (var dbContext = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var preFs = dbContext.PreFaultConditions
                    .Where(filter)
                    .Include(b => b.BranchGroupVsBranchGroupScheme
                                   .BranchGroup)
                    .Include(p => p.ConditionsCurrent)
                    .Include(p => p.ConditionsStatic)
                    .Include(p => p.ConditionsVoltage)
                    .Include(x => x.BoundingElements)
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.AOPO))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.APNU))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.ARPM))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.AOSN))
                    .Include(p => p.PostFaultConditions
                        .Select(c => c.Conditions))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.BoundingElements))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.Disturbances))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.FrequencyPowerFlow))
                    .AsNoTracking()
                    .ToList();

                maxThreads = maxThreads > 0
                    ? Math.Min(maxThreads, Environment.ProcessorCount)
                    : Environment.ProcessorCount;

                return GetContextCollections(preFs, maxThreads);
            }
        }

        public void ExecuteBuild()
        {
            try
            {
                PowerFlows = Builder.Build(this);
                APFHandler();
            }
            catch (Exception ex)
            {
                throw new APFContextException
                    ($"Ошибка при формировании формул ДП! " +
                    $"[{this?.GetType().FullName}]", ex);
            }
        }

        public Task ExecuteBuildAsync() => Task.Run(
            () =>
            {
                try
                {
                    lock (_locker)
                    {
                        PowerFlows = Builder.Build(this);
                        APFHandler();
                        Save();
                    }
                }
                catch (Exception ex)
                {
                    throw new APFContextException
                        ($"Ошибка при формировании формул ДП! " +
                        $"[{this?.GetType().FullName}]", ex);
                }
            }
        );

        public void Save()
        {
            using (var dbContext = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var preFault = this.PreF;
                var apf = this.Apf;

                dbContext.SingleMerge(preFault);
                dbContext.SingleMerge(apf);

                dbContext.SaveChanges();
            }
        }

        public void APFHandler()
        {
            foreach (var pf in PowerFlows)
            {
                switch (pf)
                {
                    case PowerFlowStandard pfs:
                        Apf.PowerFlowStandardValue = pfs.Value;
                        Apf.PowerFlowStandardDescription = pfs.Description;
                        Apf.ControlledPowerFlowStandard = 
                            string.Join("\n", GetCriteriaNecessaryControl(pfs)
                            );
                        break;
                    case PowerFlowSafe pfs:
                        Apf.PowerFlowSafeValue = pfs.Value;
                        Apf.PowerFlowSafeDescription = pfs.Description;
                        Apf.ControlledPowerFlowSafe = 
                            string.Join("\n", GetCriteriaNecessaryControl(pfs)
                            );
                        break;
                    case PowerFlowEmergency pfe:
                        Apf.PowerFlowEmergencyValue = pfe.Value;
                        Apf.PowerFlowEmergencyDescription = pfe.Description;
                        Apf.ControlledPowerFlowEmergency = 
                            string.Join("\n", GetCriteriaNecessaryControl(pfe)
                            );
                        break;
                    case PowerFlowForcedState pffs:
                        Apf.PowerFlowForcedStateValue = pffs.Value;
                        Apf.PowerFlowForcedStateDescription = pffs.Description;
                        break;
                    default: break;
                }
            }

            var apfRef = this.GetReference();
            Apf.APFReferenceData = JsonSerializer.Serialize(apfRef);

            var apfApplied = this.GetAppliedSecondaryCriterion();
            Apf.APFAppliedCriteriaData = JsonSerializer.Serialize(apfApplied);
        }

        private IEnumerable<string> GetCriteriaNecessaryControl(
            IPowerFlow powerFlow)
        {
            foreach (var criterion in powerFlow.Criteria)
            {
                if (criterion is ISecondaryCriterion)
                {
                    if (criterion is ICurrentCriterion currentCriterion)
                    {
                        yield return $"{currentCriterion.Name} " +
                            $"{currentCriterion?.Bounding?.Number}";

                        continue;
                    }

                    yield return criterion.Name;
                }
            }
        }
    }
}
