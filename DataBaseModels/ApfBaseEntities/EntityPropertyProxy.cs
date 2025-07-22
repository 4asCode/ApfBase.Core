using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

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
        LimitPowerFlowProxy
    }

    public interface IPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName);
    }

    public partial class PreFaultConditions : IPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(LimitPowerFlow))]
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

        [ProxyFor(nameof(TemperatureId))]
        [ProxyFor(nameof(Temperature))]
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

        [ProxyFor(nameof(SeasonId))]
        [ProxyFor(nameof(Seasons))]
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

        [ProxyFor(nameof(BoundingElementsId))]
        [ProxyFor(nameof(BoundingElements))]
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
    }

    public partial class PostFaultConditions : IPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
                );

        [ProxyFor(nameof(BoundingElementsId))]
        [ProxyFor(nameof(BoundingElements))]
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

        [ProxyFor(nameof(DisturbancesId))]
        [ProxyFor(nameof(Disturbances))]
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

        [ProxyFor(nameof(AopoId))]
        [ProxyFor(nameof(AOPO))]
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

        [ProxyFor(nameof(ApnuId))]
        [ProxyFor(nameof(APNU))]
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

        [ProxyFor(nameof(ArpmId))]
        [ProxyFor(nameof(ARPM))]
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

        [ProxyFor(nameof(AosnId))]
        [ProxyFor(nameof(AOSN))]
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

        [ProxyFor(nameof(ConditionsId))]
        [ProxyFor(nameof(Conditions))]
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
        [ProxyFor(nameof(Temperature))]
        public string TemperatureProxy => 
            PreFaultConditions?.Temperature?.Value;

        [ProxyFor(nameof(InfluencingEquipment))]
        public string InfluencingEquipmentProxy =>
            PreFaultConditions?.InfluencingEquipment?.Name;
    }
}