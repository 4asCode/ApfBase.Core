using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBaseModels.ApfBaseEntities
{
    public enum EntityPropertyProxy
    {
        TemperatureProxy,
        SeasonProxy,
        BoundingElementsProxy,
        InfluencingEquipmentProxy,
        DisturbancesProxy,
        UsingRow,
        AOPOProxy,
        APNUProxy,
        ARPMProxy,
        AOSNProxy,
        ConditionsProxy,
        ReplacementOfProxy,
        LimitPowerFlowProxy
    }

    public interface IPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName);
    }

    public partial class Conditions : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string ReplacementOfProxy
        {
            get => ReplacementOf?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Name == value);

                    Conditions2 = temp;

                    var usedIds = context.Conditions
                        .Where(c => c.ReplacementOfConditionId != null && 
                            c.Id != this.Id)
                        .Select(c => c.ReplacementOfConditionId)
                        .ToList();

                    var selected = context.Conditions
                        .FirstOrDefault(c => c.Name == value && 
                        !usedIds.Contains(c.Id)
                        );

                    ReplacementOfConditionId = selected?.Id;
                    OnPropertyChanged(nameof(ReplacementOf));
                    OnPropertyChanged(nameof(ReplacementOfConditionId));
                    OnPropertyChanged(nameof(ReplacementOfProxy));
                }
            }
        }

        [Browsable(false)]
        public Conditions ReplacementOf => this.Conditions2;
    }

    public partial class PreFaultConditions : IPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

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

        public string TemperatureProxy
        {
            get => Temperature?.Value;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Temperature.FirstOrDefault(
                        t => t.Value == value);

                    Temperature = temp;
                    TemperatureId = temp?.Id;

                    OnPropertyChanged(nameof(Temperature));
                    OnPropertyChanged(nameof(TemperatureId));
                    OnPropertyChanged(nameof(TemperatureProxy));
                }
            }
        }

        public string SeasonProxy
        {
            get => Seasons?.Value;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Seasons.FirstOrDefault(
                        t => t.Value == value);

                    Seasons = temp;
                    SeasonId = temp?.Id;

                    OnPropertyChanged(nameof(Seasons));
                    OnPropertyChanged(nameof(SeasonId));
                    OnPropertyChanged(nameof(SeasonProxy));
                }
            }
        }

        public string BoundingElementsProxy
        {
            get => BoundingElements?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BoundingElements.FirstOrDefault(
                        t => t.Name == value);

                    BoundingElements = temp;
                    BoundingElementsId = temp?.Id;

                    OnPropertyChanged(nameof(BoundingElements));
                    OnPropertyChanged(nameof(BoundingElementsId));
                    OnPropertyChanged(nameof(BoundingElementsProxy));
                }
            }
        }

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
                    InfluencingEquipmentId = temp?.Id;

                    OnPropertyChanged(nameof(InfluencingEquipment));
                    OnPropertyChanged(nameof(InfluencingEquipmentId));
                    OnPropertyChanged(nameof(InfluencingEquipmentProxy));
                }
            }
        }
    }

    public partial class PostFaultConditions : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        public string BoundingElementsProxy
        {
            get => BoundingElements?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.BoundingElements.FirstOrDefault(
                        t => t.Name == value);

                    BoundingElements = temp;
                    BoundingElementsId = temp?.Id;

                    OnPropertyChanged(nameof(BoundingElements));
                    OnPropertyChanged(nameof(BoundingElementsId));
                    OnPropertyChanged(nameof(BoundingElementsProxy));
                }
            }
        }

        public string DisturbancesProxy
        {
            get => Disturbances?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Disturbances.FirstOrDefault(
                        t => t.Name == value);

                    Disturbances = temp;
                    DisturbancesId = temp?.Id;

                    OnPropertyChanged(nameof(Disturbances));
                    OnPropertyChanged(nameof(DisturbancesId));
                    OnPropertyChanged(nameof(DisturbancesProxy));
                }
            }
        }

        public string AOPOProxy
        {
            get => AOPO?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.AOPO.FirstOrDefault(
                        t => t.Name == value);

                    AOPO = temp;
                    AopoId = temp?.Id;

                    OnPropertyChanged(nameof(AOPO));
                    OnPropertyChanged(nameof(AopoId));
                    OnPropertyChanged(nameof(AOPOProxy));
                }
            }
        }

        public string APNUProxy
        {
            get => APNU?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.APNU.FirstOrDefault(
                        t => t.Name == value);

                    APNU = temp;
                    ApnuId = temp?.Id;

                    OnPropertyChanged(nameof(APNU));
                    OnPropertyChanged(nameof(ApnuId));
                    OnPropertyChanged(nameof(APNUProxy));
                }
            }
        }

        public string ARPMProxy
        {
            get => ARPM?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.ARPM.FirstOrDefault(
                        t => t.Name == value);

                    ARPM = temp;
                    ArpmId = temp?.Id;

                    OnPropertyChanged(nameof(ARPM));
                    OnPropertyChanged(nameof(ArpmId));
                    OnPropertyChanged(nameof(ARPMProxy));
                }
            }
        }

        public string AOSNProxy
        {
            get => AOSN?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.AOSN.FirstOrDefault(
                        t => t.Name == value);

                    AOSN = temp;
                    AosnId = temp?.Id;

                    OnPropertyChanged(nameof(AOSN));
                    OnPropertyChanged(nameof(AosnId));
                    OnPropertyChanged(nameof(AOSNProxy));
                }
            }
        }

        public string ConditionsProxy
        {
            get => Conditions?.Name;
            set
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var temp = context.Conditions.FirstOrDefault(
                        t => t.Name == value);

                    Conditions = temp;
                    ConditionsId = temp?.Id;

                    OnPropertyChanged(nameof(AOSN));
                    OnPropertyChanged(nameof(ConditionsId));
                    OnPropertyChanged(nameof(ConditionsProxy));
                }
            }
        }
    }

    public partial class APF
    {
        public string TemperatureProxy => 
            PreFaultConditions?.Temperature?.Value;

        public string InfluencingEquipmentProxy =>
            PreFaultConditions?.InfluencingEquipment?.Name;
    }
}