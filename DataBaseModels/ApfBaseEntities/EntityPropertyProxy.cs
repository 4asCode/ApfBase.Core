using System;
using System.ComponentModel;
using System.Linq;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    public interface IPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName);
    }

    #region AOPOProxy
    public partial class AOPO : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }

        [ProxyFor(nameof(SeasonsId))]
        [ProxyFor(nameof(Seasons))]
        public int? SeasonsProxy
        {
            get => SeasonsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Seasons.FirstOrDefault(
                        t => t.Id == value);

                    Seasons = temp;
                    SeasonsId = temp?.Id;

                    OnPropertyChanged(nameof(Seasons));
                    OnPropertyChanged(nameof(SeasonsId));
                    OnPropertyChanged(nameof(SeasonsProxy));
                }
            }
        }
    }
    #endregion AOPOProxy

    #region AOSNProxy
    public partial class AOSN : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }

        [ProxyFor(nameof(SeasonsId))]
        [ProxyFor(nameof(Seasons))]
        public int? SeasonsProxy
        {
            get => SeasonsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Seasons.FirstOrDefault(
                        t => t.Id == value);

                    Seasons = temp;
                    SeasonsId = temp?.Id;

                    OnPropertyChanged(nameof(Seasons));
                    OnPropertyChanged(nameof(SeasonsId));
                    OnPropertyChanged(nameof(SeasonsProxy));
                }
            }
        }
    }
    #endregion AOSNProxy

    #region APFProxy
    public partial class APF
    {
        [ProxyFor(nameof(Temperature))]
        public string TemperatureProxy =>
            PreFaultConditions?.Temperature?.Value;

        [ProxyFor(nameof(InfluencingEquipment))]
        public string InfluencingEquipmentProxy =>
            PreFaultConditions?.InfluencingEquipment?.Name;
    }
    #endregion APFProxy

    #region APNUProxy
    public partial class APNU : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }

        [ProxyFor(nameof(SeasonsId))]
        [ProxyFor(nameof(Seasons))]
        public int? SeasonsProxy
        {
            get => SeasonsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Seasons.FirstOrDefault(
                        t => t.Id == value);

                    Seasons = temp;
                    SeasonsId = temp?.Id;

                    OnPropertyChanged(nameof(Seasons));
                    OnPropertyChanged(nameof(SeasonsId));
                    OnPropertyChanged(nameof(SeasonsProxy));
                }
            }
        }
    }
    #endregion APNUProxy

    #region ARPMProxy
    public partial class ARPM : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }

        [ProxyFor(nameof(SeasonsId))]
        [ProxyFor(nameof(Seasons))]
        public int? SeasonsProxy
        {
            get => SeasonsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Seasons.FirstOrDefault(
                        t => t.Id == value);

                    Seasons = temp;
                    SeasonsId = temp?.Id;

                    OnPropertyChanged(nameof(Seasons));
                    OnPropertyChanged(nameof(SeasonsId));
                    OnPropertyChanged(nameof(SeasonsProxy));
                }
            }
        }
    }
    #endregion ARPMProxy

    #region BoundingElementsProxy
    public partial class BoundingElements : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }
    }
    #endregion BoundingElementsProxy

    #region BranchGroupProxy
    public partial class BranchGroup : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(AnnexId))]
        [ProxyFor(nameof(Annex))]
        public int? AnnexProxy
        {
            get => AnnexId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Annex.FirstOrDefault(
                        t => t.Id == value);

                    Annex = temp;
                    AnnexId = temp?.Id;

                    OnPropertyChanged(nameof(Annex));
                    OnPropertyChanged(nameof(AnnexId));
                    OnPropertyChanged(nameof(AnnexProxy));
                }
            }
        }
    }
    #endregion BranchGroupProxy

    #region BranchGroupSchemeProxy
    public partial class BranchGroupScheme : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroup))]
        public string BranchGroupProxy
        {
            get
            {
                using (var ctx = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var uids = ctx.Database
                        .SqlQuery<Guid>(
                            "SELECT BranchGroupUid " +
                            "FROM [ApfBase].[dbo].[BranchGroupVsBranchGroupScheme] " +
                            "WHERE BranchGroupSchemeUid = @p0",
                            this.Uid)
                        .ToList();
                    return string.Join(",", uids);
                }
            }
            set
            {
                var uids = string.IsNullOrWhiteSpace(value)
                    ? new Guid[0]
                    : value.Split(new[] { ',' },
                                StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => Guid.Parse(s.Trim()))
                           .Distinct()
                           .ToArray();

                using (var ctx = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                using (var tx = ctx.Database.BeginTransaction())
                {
                    ctx.Database.ExecuteSqlCommand(
                        "DELETE FROM " +
                        "[ApfBase].[dbo].[BranchGroupVsBranchGroupScheme] " +
                        "WHERE BranchGroupSchemeUid = @p0",
                        this.Uid);

                    if (uids.Length > 0)
                    {
                        foreach (var uid in uids)
                        {
                            ctx.Database.ExecuteSqlCommand(
                                "INSERT INTO " +
                                "[ApfBase].[dbo].[BranchGroupVsBranchGroupScheme] " +
                                "(BranchGroupUid, BranchGroupSchemeUid) VALUES (@p0, @p1)",
                                uid, this.Uid);
                        }
                    }

                    tx.Commit();
                }

                OnPropertyChanged(nameof(BranchGroupProxy));
                OnPropertyChanged(nameof(BranchGroup));
            }
        }
    }
    #endregion BranchGroupSchemeProxy

    #region ConditionsProxy
    public partial class Conditions : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }
    }
    #endregion ConditionsProxy

    #region DisturbancesProxy
    public partial class Disturbances : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BranchGroupUid))]
        [ProxyFor(nameof(BranchGroup))]
        public Guid? BranchGroupProxy
        {
            get => BranchGroupUid;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BranchGroup.FirstOrDefault(
                        t => t.Uid == value);

                    BranchGroup = temp;
                    BranchGroupUid = temp?.Uid;

                    OnPropertyChanged(nameof(BranchGroup));
                    OnPropertyChanged(nameof(BranchGroupUid));
                    OnPropertyChanged(nameof(BranchGroupProxy));
                }
            }
        }
    }
    #endregion DisturbancesProxy

    #region EquipmentProxy
    public partial class Equipment : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(AggregatedEquipmentId))]
        [ProxyFor(nameof(AggregatedEquipment))]
        public int? AggregatedEquipmentProxy
        {
            get => AggregatedEquipmentId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.AggregatedEquipment.FirstOrDefault(
                        t => t.Id == value);

                    AggregatedEquipment = temp;
                    AggregatedEquipmentId = temp?.Id;

                    OnPropertyChanged(nameof(AggregatedEquipment));
                    OnPropertyChanged(nameof(AggregatedEquipmentId));
                    OnPropertyChanged(nameof(AggregatedEquipmentProxy));
                }
            }
        }
    }
    #endregion EquipmentProxy

    #region FrequencyPowerFlowProxy
    public partial class FrequencyPowerFlow : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(ConditionId))]
        [ProxyFor(nameof(Conditions))]
        public int? ConditionsProxy
        {
            get => ConditionId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Id == value);

                    Conditions = temp;
                    ConditionId = temp?.Id;

                    OnPropertyChanged(nameof(Conditions));
                    OnPropertyChanged(nameof(ConditionId));
                    OnPropertyChanged(nameof(ConditionsProxy));
                }
            }
        }
    }
    #endregion FrequencyPowerFlowProxy

    #region ManagementProxy
    public partial class Management : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(ManagementTasksId))]
        [ProxyFor(nameof(ManagementTasks))]
        public int? ManagementTasksProxy
        {
            get => ManagementTasksId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.ManagementTasks.FirstOrDefault(
                        t => t.Id == value);

                    ManagementTasks = temp;
                    ManagementTasksId = temp?.Id;

                    OnPropertyChanged(nameof(ManagementTasks));
                    OnPropertyChanged(nameof(ManagementTasksId));
                    OnPropertyChanged(nameof(ManagementTasksProxy));
                }
            }
        }
    }
    #endregion ManagementProxy

    #region PreFaultConditions
    public partial class PreFaultConditions : IPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(SeasonsId))]
        [ProxyFor(nameof(Seasons))]
        public int? SeasonsProxy
        {
            get => SeasonsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Seasons.FirstOrDefault(
                        t => t.Id == value);

                    Seasons = temp;
                    SeasonsId = temp?.Id;

                    OnPropertyChanged(nameof(Seasons));
                    OnPropertyChanged(nameof(SeasonsId));
                    OnPropertyChanged(nameof(SeasonsProxy));
                }
            }
        }

        [ProxyFor(nameof(TemperatureId))]
        [ProxyFor(nameof(Temperature))]
        public int? TemperatureProxy
        {
            get => TemperatureId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Temperature.FirstOrDefault(
                        t => t.Id == value);

                    Temperature = temp;
                    TemperatureId = temp?.Id;

                    OnPropertyChanged(nameof(Temperature));
                    OnPropertyChanged(nameof(TemperatureId));
                    OnPropertyChanged(nameof(TemperatureProxy));
                }
            }
        }

        [ProxyFor(nameof(BoundingElementsId))]
        [ProxyFor(nameof(BoundingElements))]
        public int? BoundingElementsProxy
        {
            get => BoundingElementsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BoundingElements.FirstOrDefault(
                        t => t.Id == value);

                    BoundingElements = temp;
                    BoundingElementsId = temp?.Id;

                    OnPropertyChanged(nameof(BoundingElements));
                    OnPropertyChanged(nameof(BoundingElementsId));
                    OnPropertyChanged(nameof(BoundingElementsProxy));
                }
            }
        }

        [ProxyFor(nameof(InfluencingEquipmentUid))]
        [ProxyFor(nameof(InfluencingEquipment))]
        public string InfluencingEquipmentProxy
        {
            get => InfluencingEquipment?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.InfluencingEquipment.FirstOrDefault(
                        t => t.Name == value);

                    InfluencingEquipment = temp;
                    InfluencingEquipmentUid = temp?.Uid;

                    OnPropertyChanged(nameof(InfluencingEquipment));
                    OnPropertyChanged(nameof(InfluencingEquipmentUid));
                    OnPropertyChanged(nameof(InfluencingEquipmentProxy));
                }
            }
        }

        [ProxyFor(nameof(LimitPowerFlow))]
        [ProxyFor(nameof(TprPowerFlow))]
        [ProxyFor(nameof(EprPowerFlow))]
        public double? LimitPowerFlowProxy
        {
            get => LimitPowerFlow;
            set
            {
                LimitPowerFlow = value;
                TprPowerFlow = 0.8 * value;
                EprPowerFlow = 0.92 * value;

                OnPropertyChanged(nameof(LimitPowerFlow));
                OnPropertyChanged(nameof(TprPowerFlow));
                OnPropertyChanged(nameof(EprPowerFlow));
            }
        }

        [ProxyFor(nameof(ConditionsStatic))]
        [ProxyFor(nameof(ConditionsStaticId))]
        public int? ConditionsStaticProxy
        {
            get => ConditionsStaticId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Id == value);

                    ConditionsStatic = temp;
                    ConditionsStaticId = temp?.Id;

                    OnPropertyChanged(nameof(ConditionsStatic));
                    OnPropertyChanged(nameof(ConditionsStaticId));
                    OnPropertyChanged(nameof(ConditionsStaticProxy));
                }
            }
        }

        [ProxyFor(nameof(ConditionsCurrent))]
        [ProxyFor(nameof(ConditionsCurrentId))]
        public int? ConditionsCurrentProxy
        {
            get => ConditionsCurrentId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Id == value);

                    ConditionsCurrent = temp;
                    ConditionsCurrentId = temp?.Id;

                    OnPropertyChanged(nameof(ConditionsCurrent));
                    OnPropertyChanged(nameof(ConditionsCurrentId));
                    OnPropertyChanged(nameof(ConditionsCurrentProxy));
                }
            }
        }

        [ProxyFor(nameof(ConditionsVoltage))]
        [ProxyFor(nameof(ConditionsVoltageId))]
        public int? ConditionsVoltageProxy
        {
            get => ConditionsVoltageId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Id == value);

                    ConditionsVoltage = temp;
                    ConditionsVoltageId = temp?.Id;

                    OnPropertyChanged(nameof(ConditionsVoltage));
                    OnPropertyChanged(nameof(ConditionsVoltageId));
                    OnPropertyChanged(nameof(ConditionsVoltageProxy));
                }
            }
        }
    }
    #endregion PreFaultConditions

    #region PostFaultConditions
    public partial class PostFaultConditions : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(DisturbancesId))]
        [ProxyFor(nameof(Disturbances))]
        public int? DisturbancesProxy
        {
            get => DisturbancesId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Disturbances.FirstOrDefault(
                        t => t.Id == value);

                    Disturbances = temp;
                    DisturbancesId = temp?.Id;

                    OnPropertyChanged(nameof(Disturbances));
                    OnPropertyChanged(nameof(DisturbancesId));
                    OnPropertyChanged(nameof(DisturbancesProxy));
                }
            }
        }

        [ProxyFor(nameof(BoundingElementsId))]
        [ProxyFor(nameof(BoundingElements))]
        public int? BoundingElementsProxy
        {
            get => BoundingElementsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BoundingElements.FirstOrDefault(
                        t => t.Id == value);

                    BoundingElements = temp;
                    BoundingElementsId = temp?.Id;

                    OnPropertyChanged(nameof(BoundingElements));
                    OnPropertyChanged(nameof(BoundingElementsId));
                    OnPropertyChanged(nameof(BoundingElementsProxy));
                }
            }
        }

        [ProxyFor(nameof(ConditionsId))]
        [ProxyFor(nameof(Conditions))]
        public int? ConditionsProxy
        {
            get => ConditionsId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Id == value);

                    Conditions = temp;
                    ConditionsId = temp?.Id;

                    OnPropertyChanged(nameof(AOSN));
                    OnPropertyChanged(nameof(ConditionsId));
                    OnPropertyChanged(nameof(ConditionsProxy));
                }
            }
        }

        [ProxyFor(nameof(AopoId))]
        [ProxyFor(nameof(AOPO))]
        public int? AOPOProxy
        {
            get => AopoId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.AOPO.FirstOrDefault(
                        t => t.Id == value);

                    AOPO = temp;
                    AopoId = temp?.Id;

                    OnPropertyChanged(nameof(AOPO));
                    OnPropertyChanged(nameof(AopoId));
                    OnPropertyChanged(nameof(AOPOProxy));
                }
            }
        }

        [ProxyFor(nameof(ApnuId))]
        [ProxyFor(nameof(APNU))]
        public int? APNUProxy
        {
            get => ApnuId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.APNU.FirstOrDefault(
                        t => t.Id == value);

                    APNU = temp;
                    ApnuId = temp?.Id;

                    OnPropertyChanged(nameof(APNU));
                    OnPropertyChanged(nameof(ApnuId));
                    OnPropertyChanged(nameof(APNUProxy));
                }
            }
        }

        [ProxyFor(nameof(ArpmId))]
        [ProxyFor(nameof(ARPM))]
        public int? ARPMProxy
        {
            get => ArpmId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.ARPM.FirstOrDefault(
                        t => t.Id == value);

                    ARPM = temp;
                    ArpmId = temp?.Id;

                    OnPropertyChanged(nameof(ARPM));
                    OnPropertyChanged(nameof(ArpmId));
                    OnPropertyChanged(nameof(ARPMProxy));
                }
            }
        }

        [ProxyFor(nameof(AosnId))]
        [ProxyFor(nameof(AOSN))]
        public int? AOSNProxy
        {
            get => AosnId;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.AOSN.FirstOrDefault(
                        t => t.Id == value);

                    AOSN = temp;
                    AosnId = temp?.Id;

                    OnPropertyChanged(nameof(AOSN));
                    OnPropertyChanged(nameof(AosnId));
                    OnPropertyChanged(nameof(AOSNProxy));
                }
            }
        }
    }
    #endregion PostFaultConditions
}