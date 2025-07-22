using ApfBuilder.Criteria;
using ApfBuilder.PowerFlow;
using ApfBuilder.Services;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
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

        private APFContext(IAPFContextParticipant entity)
        {
            if (entity is PreFaultConditions preF)
            {
                _preF = preF;
                _apf = preF?.APF;
            }
            else if (entity is PostFaultConditions postF)
            {
                postF.Save();

                var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString);

                _preF = EntityProvider.GetEntity<PreFaultConditions>(context,
                    p => p.BranchGroupSchemeUid == 
                        postF.BranchGroupSchemeUid &&
                        p.Id == postF.PreFaultConditionsId)
                    .FirstOrDefault();

                _apf = postF.PreFaultConditions?.APF;
            }
        }

        public static IAPFContext ContextInitialize(
            IAPFContextParticipant partContext)
        {
            var context = new APFContext(partContext);

            if (context.Apf == null)
            {
                context.Apf = new APF
                {
                    BranchGroupSchemeUid = context.PreF.BranchGroupSchemeUid,
                    PreFaultConditionsId = context.PreF.Id,
                };
            }

            return context;
        }

        public static IEnumerable<IAPFContext> ContextInitialize(
            IEnumerable<IAPFContextParticipant> partContextCollection) => 
            partContextCollection.Select(
                partContext =>
                {
                    var context = new APFContext(partContext);

                    if (context.Apf == null)
                    {
                        context.Apf = new APF
                        {
                            BranchGroupSchemeUid = 
                                context.PreF.BranchGroupSchemeUid,
                            PreFaultConditionsId = context.PreF.Id,
                        };
                    }

                    return context;
                }
            );

        public static IEnumerable<IAPFContext> InitializeParallelBuildContext(
            Expression<Func<PreFaultConditions, bool>> filter)
        {
            using (var dbContext = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var listPreF = dbContext.PreFaultConditions
                    .Where(filter)
                    .Include(p => p.PostFaultConditions
                        .Select(c => c.Conditions))
                    .Include(x => x.APF)
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
                        .Select(pf => pf.BoundingElements))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.Disturbances))
                    .Include(p => p.PostFaultConditions
                        .Select(pf => pf.Conditions))
                    .AsNoTracking()
                    .ToList();

                listPreF.Cast<IAPFContextParticipant>().ToList();

                return ContextInitialize(listPreF);
            }
        }

        public void ExecuteBuild()
        {
            PowerFlows = Builder.Build(this);
            APFHandler();
        }

        public Task ExecuteBuildAsync() => Task.Run(
            () =>
            {
                lock (_locker)
                {
                    PowerFlows = Builder.Build(this);
                    APFHandler();
                    Save();
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
