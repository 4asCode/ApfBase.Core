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
                yield return new[]
                {
                    Current.Create(postF),
                    CurrentAOPO.Create(postF),
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
                CurrentSecondary.Create(_context.PreF),
                VoltageSecondary.Create(_context.PreF),
                StaticBaseCaseTPR.Create(_context.PreF),
                StaticBaseCaseEPR.CreateStandard(_context.PreF)
            };
        }

        private ICriterion[] CreateForsedStateCriteria()
        {
            var criterionList = new List<ICriterion>()
            {
                CurrentSecondary.Create(_context.PreF),
                StaticBaseCaseEPR.CreateForcedState(_context.PreF)
            };

            foreach (var postF in _context.PreF.PostFaultConditions)
            {
                criterionList.Add(
                    Current.Create(postF)
                    );
                criterionList.Add(
                    CurrentAOPO.Create(postF)
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

        #region CriterionBase
        private abstract class CriterionBase : ICriterion
        {
            public string Name { get; protected set; }

            public double? Value { get; protected set; }

            public double? MinValue { get; protected set; }

            public double? MaxValue { get; protected set; }

            public abstract CriterionType Type { get; }

            protected CriterionBase() { }

            protected CriterionBase(double? baseValue) : this()
            {
                Value = baseValue.Round();

                MinValue = Value;

                MaxValue = Value;
            }

            protected CriterionBase(
                double? baseValue, 
                Conditions conditions
                )
                : this(baseValue)
            {
                MinValue = conditions?.MinValue == null
                    ? Value
                    : Value + conditions.MinValue.Round();

                MaxValue = conditions?.MaxValue == null
                    ? Value
                    : Value + conditions.MaxValue.Round();
            }
        }
        #endregion CriterionBase

        #region Current
        [AllowablePF]
        [CriterionPriority(1)]
        private sealed class Current : CriterionBase, ICurrentCriterion, IEmergencyResponceCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                 => new Current(postF);

            public override CriterionType Type => CriterionType.Current;

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public BoundingElements Bounding { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private Current(PostFaultConditions postF)
                : base
                (
                    postF.CurrentPowerFlow -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.CurrentPowerFlow,
                    postF.Conditions
                )
            {
                Name = "АДТН";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                Bounding = postF.BoundingElements;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(this.Type, postF.AOPO);
                
                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }
            }
        }
        #endregion Current

        #region CurrentAOPO
        [AllowablePF]
        [CriterionPriority(1)]
        private sealed class CurrentAOPO : CriterionBase, ICurrentCriterion, IEmergencyResponceCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                 => new CurrentAOPO(postF);

            public override CriterionType Type => CriterionType.CurrentAOPO;

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public BoundingElements Bounding { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private CurrentAOPO(PostFaultConditions postF)
                : base
                (
                    postF.CurrentAOPO -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.CurrentAOPO,
                    postF.Conditions
                )
            {
                Name = "ДТН";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                Bounding = postF.BoundingElements;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(this.Type, postF.AOPO);

                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }
            }
        }
        #endregion CurrentAOPO

        #region Dynamic
        [AllowablePF]
        [CriterionPriority(2)]
        private sealed class Dynamic : CriterionBase, IEmergencyResponceCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                => new Dynamic(postF);

            public override CriterionType Type => CriterionType.Dynamic;

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private Dynamic(PostFaultConditions postF)
                : base
                (
                      postF.DynamicPowerFlow -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.DynamicPowerFlow,
                      postF.Conditions
                )
            {
                Name = "ДУ";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(this.Type, postF.APNU, postF.ARPM);

                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }
            }
        }
        #endregion Dynamic

        #region Static
        [AllowablePF]
        [CriterionPriority(3)]
        private sealed class Static : CriterionBase, IEmergencyResponceCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                => new Static(postF);

            public override CriterionType Type => CriterionType.Static;

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private Static(PostFaultConditions postF)
                : base
                (
                      postF.EprPowerFlow -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.EprPowerFlow,
                      postF.Conditions
                )
            {
                Name = "8% P";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(this.Type, postF.APNU, postF.ARPM);

                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }
            }
        }
        #endregion Static

        #region Voltage
        [AllowablePF]
        [CriterionPriority(4)]
        private sealed class Voltage : CriterionBase, IEmergencyResponceCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                => new Voltage(postF);

            public override CriterionType Type => CriterionType.Voltage;

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private Voltage(PostFaultConditions postF)
                : base
                (
                      postF.VoltagePowerFlow -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.VoltagePowerFlow,
                      postF.Conditions
                )
            {
                Name = "10% U";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(this.Type, postF.AOSN);

                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }
            }
        }
        #endregion Voltage

        #region Frequency
        [AllowablePF]
        private sealed class Frequency : CriterionBase, IFrequencyCriterion, IEmergencyResponceCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                 => new Frequency(postF);

            public override CriterionType Type => CriterionType.Frequency;

            public (string Value, string Description) FullValue { get; }

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private Frequency(PostFaultConditions postF) : base()
            {
                //MinValue = postF?.FrequencyPowerFlow?
                //    .MinValue;

                //MaxValue = postF?.FrequencyPowerFlow?
                //    .MaxValue;

                //Name = postF?.FrequencyPowerFlow?.PowerConsumptionDescription;

                //Value = postF?.FrequencyPowerFlow?.PowerConsumptionFactor;

                //FullValue = 
                //(
                //    $"{postF?.Disturbances?.PowerConsumptionFactor}" +
                //    $"*{Name} - ΔPнк", 
                //    $"{postF?.Disturbances?.PowerConsumptionFactor * 100}" +
                //    $"% {Name} - ΔPнк"
                //);

                //Condition = postF.Conditions;
                //Disturbance = postF.Disturbances;
                //EmergencyResponse = EmergencyResponseHandler.
                //    ProcessHandler(this.Type, postF.APNU);

                //MinValueER = MinValue;
                //MaxValueER = MaxValue;
                //foreach (var e in EmergencyResponse)
                //{
                //    MinValueER += e.MinValue;
                //    MaxValueER += e.MaxValue;
                //}
            }
        }
        #endregion Frequency

        #region FrequencyAlternate
        private sealed class FrequencyAlternate : CriterionBase, IFrequencyAlternateCriterion
        {
            public static ICriterion Create(PostFaultConditions postF)
                 => new FrequencyAlternate(postF);

            public override CriterionType Type => CriterionType.FrequencyAlternate;

            public IEmergencyResponceCriterion StaticCriterion { get; }

            public double? LimitPowerFlow { get; }

            public double? LimitPowerFlowByEmergency { get; }

            public int? IrOscExpressions { get; }

            public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

            public Conditions Condition { get; }

            public Disturbances Disturbance { get; }

            public double? MinValueER { get; }

            public double? MaxValueER { get; }

            private FrequencyAlternate(PostFaultConditions postF) : base()
            {
                //StaticCriterion = Static.Create(postF) 
                //    as IEmergencyResponceCriterion;
                //LimitPowerFlow = postF?.PreFaultConditions?.LimitPowerFlow;
                //IrOscExpressions = postF.PreFaultConditions?.IrOscExpressions;
                //LimitPowerFlowByEmergency = StaticCriterion?.Value != null && 
                //    IrOscExpressions != null 
                //    ? StaticCriterion.Value + IrOscExpressions 
                //    : null;

                //Value = double.MaxValue;
                //Name = postF.Disturbances?.PowerConsumptionDescription;

                //Condition = postF.Conditions;
                //Disturbance = postF.Disturbances;
                //EmergencyResponse = EmergencyResponseHandler.
                //    ProcessHandler(this.Type, postF.APNU);
            }
        }
        #endregion FrequencyAlternate

        #region CurrentSecondary
        [SecondaryAllowablePF]
        private sealed class CurrentSecondary : CriterionBase, ICurrentCriterion, ISecondaryCriterion
        {
            public static ICriterion Create(PreFaultConditions preF)
                 => new CurrentSecondary(preF);

            public override CriterionType Type 
                => CriterionType.CurrentSecondary;

            public BoundingElements Bounding { get; }

            public string Postfix { get; }

            private CurrentSecondary(PreFaultConditions preF)
                : base
                (
                      preF.CurrentPowerFlow - preF.IrOscExpressions 
                        ?? preF.CurrentPowerFlow
                )
            {
                Name = "ДДТН";
                Postfix = "*";
                Bounding = preF.BoundingElements;
            }
        }
        #endregion CurrentSecondary

        #region VoltageSecondary
        [SecondaryAllowablePF]
        private sealed class VoltageSecondary : CriterionBase, ISecondaryCriterion
        {
            public static ICriterion Create(PreFaultConditions preF)
                 => new VoltageSecondary(preF);

            public override CriterionType Type 
                => CriterionType.VoltageSecondary;

            public string Postfix { get; }

            private VoltageSecondary(PreFaultConditions preF) 
                : base
                (
                      preF.VoltagePowerFlow - preF.IrOscExpressions 
                        ?? preF.VoltagePowerFlow
                )
            {
                Name = "15% U";
                Postfix = "*";
            }
        }
        #endregion VoltageSecondary

        #region StaticBaseCaseTPR
        [AllowablePF]
        private sealed class StaticBaseCaseTPR : CriterionBase, IBaseCaseCriterion
        {
            public static ICriterion Create(PreFaultConditions preF)
                 => new StaticBaseCaseTPR(preF);

            public override CriterionType Type 
                => CriterionType.StaticBaseCaseTPR;

            private StaticBaseCaseTPR(PreFaultConditions preF) 
                : base
                (
                      preF.TprPowerFlow - preF.IrOscExpressions 
                        ?? preF.TprPowerFlow
                )
            {
                Name = "20% P, исходная схема";
            }
        }
        #endregion StaticBaseCaseTPR

        #region StaticBaseCaseEPR
        [EmergencyPF]
        private sealed class StaticBaseCaseEPR : CriterionBase, IBaseCaseCriterion
        {
            public static ICriterion CreateStandard(
                PreFaultConditions preF)
            {
                return new StaticBaseCaseEPR
                    (
                        preF.EprPowerFlow - preF.IrOscExpressions
                            ?? preF.EprPowerFlow
                    );
            }

            public static ICriterion CreateForcedState(
                PreFaultConditions preF)
            {
                return new StaticBaseCaseEPR
                    (
                        preF.IrOscExpressions != null
                            ? preF.EprPowerFlow - preF.IrOscExpressions * 2
                            : preF.EprPowerFlow
                    );
            }

            public override CriterionType Type 
                => CriterionType.StaticBaseCaseEPR;

            private StaticBaseCaseEPR(double? value)
                : base(value)
            {
                Name = "8% P, исходная схема";
            }
        }
        #endregion StaticBaseCaseEPR
    }
}
