using System;
using System.Collections.Generic;
using System.Linq;
using static DataBaseModels.ApfBaseEntities.Entities.EntityMap.EntityFieldDefinition;

namespace DataBaseModels.ApfBaseEntities.Entities.EntityMap
{
    public class EntityFieldMap : IMap<EntityFieldDefinition>
    {
        private IReadOnlyDictionary<Type,
            IReadOnlyList<FieldDefinition>> _map =
                    new Dictionary<Type,
                        IReadOnlyList<FieldDefinition>>()
                        {
                            #region AggregatedEquipment
                            {
                                typeof(AggregatedEquipment),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Equipment",
                                        FieldName = "Equipment",
                                        DataType = typeof(ICollection<Equipment>),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion AggregatedEquipment
                            #region Annex
                            {
                                typeof(Annex),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование приложения",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование приложения",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "TableName",
                                        FieldName = "Наименование таблицы приложения",
                                        DataType = typeof(string),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Description",
                                        FieldName = "Описание",
                                        DataType = typeof(string),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AnnexVsBranchGroup",
                                        FieldName = "AnnexVsBranchGroup",
                                        DataType = typeof(ICollection<AnnexVsBranchGroup>),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion Annex
                            #region AOPO
                            {
                                typeof(AOPO),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsId",
                                        FieldName = "SeasonsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlValuePowerFlow",
                                        FieldName = "Объём УВ",
                                        DataType = typeof(double?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Coefficient",
                                        FieldName = "Коэффициент",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Seasons",
                                        FieldName = "Seasons",
                                        DataType = typeof(Seasons),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsProxy",
                                        FieldName = "Сезон",
                                        DataType = typeof(int?),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion AOPO
                            #region AOSN
                            {
                                typeof(AOSN),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsId",
                                        FieldName = "SeasonsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlValuePowerFlow",
                                        FieldName = "Объём УВ",
                                        DataType = typeof(double?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Coefficient",
                                        FieldName = "Коэффициент",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Seasons",
                                        FieldName = "Seasons",
                                        DataType = typeof(Seasons),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsProxy",
                                        FieldName = "Сезон",
                                        DataType = typeof(int?),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion AOSN
                            #region APF
                            {
                                typeof(APF),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupVsBranchGroupSchemeId",
                                        FieldName = "BranchGroupVsBranchGroupSchemeId",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditionsId",
                                        FieldName = "PreFaultConditionsId",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowStandardValue",
                                        FieldName = "МДП без ПА",
                                        DataType = typeof(string),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowStandardDescription",
                                        FieldName = "Критерий определения МДП без ПА",
                                        DataType = typeof(string),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowSafeValue",
                                        FieldName = "МДП с ПА",
                                        DataType = typeof(string),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowSafeDescription",
                                        FieldName = "Критерий определения МДП с ПА",
                                        DataType = typeof(string),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowEmergencyValue",
                                        FieldName = "АДП",
                                        DataType = typeof(string),
                                        Index = 7,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowEmergencyDescription",
                                        FieldName = "Критерий определения АДП",
                                        DataType = typeof(string),
                                        Index = 8,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlledPowerFlowStandard",
                                        FieldName = "Контроль МДП без ПА",
                                        DataType = typeof(string),
                                        Index = 9,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlledPowerFlowSafe",
                                        FieldName = "Контроль МДП с ПА",
                                        DataType = typeof(string),
                                        Index = 10,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlledPowerFlowEmergency",
                                        FieldName = "Контроль АДП",
                                        DataType = typeof(string),
                                        Index = 11,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowForcedStateValue",
                                        FieldName = "ВДП",
                                        DataType = typeof(string),
                                        Index = 12,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowForcedStateDescription",
                                        FieldName = "Критерий определения ВДП",
                                        DataType = typeof(string),
                                        Index = 13,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowStandardValueHandWritten",
                                        FieldName = "МДП без ПА (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 14,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowStandardDescriptionHandWritten",
                                        FieldName = "Критерий определения МДП без ПА (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 15,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowSafeValueHandWritten",
                                        FieldName = "МДП с ПА (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 16,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowSafeDescriptionHandWritten",
                                        FieldName = "Критерий определения МДП с ПА (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 17,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowEmergencyValueHandWritten",
                                        FieldName = "АДП (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 18,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowEmergencyDescriptionHandWritten",
                                        FieldName = "Критерий определения АДП (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 19,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowForcedStateValueHandWritten",
                                        FieldName = "ВДП (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 20,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerFlowForcedStateDescriptionHandWritten",
                                        FieldName = "Критерий определения ВДП (ручной ввод)",
                                        DataType = typeof(string),
                                        Index = 21,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditions",
                                        FieldName = "PreFaultConditions",
                                        DataType = typeof(PreFaultConditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APFReferenceData",
                                        FieldName = "APFReferenceData",
                                        DataType = typeof(string),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APFAppliedCriteriaData",
                                        FieldName = "APFAppliedCriteriaData",
                                        DataType = typeof(string),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "InfluencingEquipmentProxy",
                                        FieldName = "Влияющее оборудование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "TemperatureProxy",
                                        FieldName = "Температура",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion APF
                            #region APNU
                            {
                                typeof(APNU),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsId",
                                        FieldName = "SeasonsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlValuePowerFlow",
                                        FieldName = "Объём УВ",
                                        DataType = typeof(double?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "StaticsCoefficient",
                                        FieldName = "Коэффициент (СУ)",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "DynamicsCoefficient",
                                        FieldName = "Коэффициент (ДУ)",
                                        DataType = typeof(double?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "CurrentCoefficient",
                                        FieldName = "Коэффициент (Ток)",
                                        DataType = typeof(double?),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Seasons",
                                        FieldName = "Seasons",
                                        DataType = typeof(Seasons),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 7,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsProxy",
                                        FieldName = "Сезон",
                                        DataType = typeof(int?),
                                        Index = 8,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion APNU
                            #region ARPM
                            {
                                typeof(ARPM),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsId",
                                        FieldName = "SeasonsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ControlValuePowerFlow",
                                        FieldName = "Объём УВ",
                                        DataType = typeof(double?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Coefficient",
                                        FieldName = "Коэффициент",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Seasons",
                                        FieldName = "Seasons",
                                        DataType = typeof(Seasons),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsProxy",
                                        FieldName = "Сезон",
                                        DataType = typeof(int?),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion ARPM
                            #region BoundingElements
                            {
                                typeof(BoundingElements),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Number",
                                        FieldName = "Номер",
                                        DataType = typeof(int?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditions",
                                        FieldName = "PreFaultConditions",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion BoundingElements
                            #region BranchGroup
                            {
                                typeof(BranchGroup),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Uid",
                                        FieldName = "Uid",
                                        DataType = typeof(Guid),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Number",
                                        FieldName = "Номер",
                                        DataType = typeof(int?),
                                        Visible = true,
                                        Index = 1,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "RoundValue",
                                        FieldName = "Коэффициент округления",
                                        DataType = typeof(int?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOPO",
                                        FieldName = "AOPO",
                                        DataType = typeof(ICollection<AOPO>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOSN",
                                        FieldName = "AOSN",
                                        DataType = typeof(ICollection<AOSN>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APNU",
                                        FieldName = "APNU",
                                        DataType = typeof(ICollection<APNU>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ARPM",
                                        FieldName = "ARPM",
                                        DataType = typeof(ICollection<ARPM>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElements",
                                        FieldName = "BoundingElements",
                                        DataType = typeof(ICollection<BoundingElements>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Conditions",
                                        FieldName = "Conditions",
                                        DataType = typeof(ICollection<Conditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Disturbances",
                                        FieldName = "Disturbances",
                                        DataType = typeof(ICollection<Disturbances>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AnnexVsBranchGroup",
                                        FieldName = "AnnexVsBranchGroup",
                                        DataType = typeof(ICollection<AnnexVsBranchGroup>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupVsBranchGroupScheme",
                                        FieldName = "BranchGroupVsBranchGroupScheme",
                                        DataType = typeof(ICollection<BranchGroupVsBranchGroupScheme>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AnnexProxy",
                                        FieldName = "Приложения",
                                        DataType = typeof(string),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion BranchGroup
                            #region BranchGroupScheme
                            {
                                typeof(BranchGroupScheme),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Uid",
                                        FieldName = "Uid",
                                        DataType = typeof(Guid),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Number",
                                        FieldName = "Номер",
                                        DataType = typeof(double?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupVsBranchGroupScheme",
                                        FieldName = "BranchGroupVsBranchGroupScheme",
                                        DataType = typeof(BranchGroupVsBranchGroupScheme),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(string),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion BranchGroupScheme
                            #region Conditions
                            {
                                typeof(Conditions),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "MinValue",
                                        FieldName = "Минимальное значение",
                                        DataType = typeof(double?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "MaxValue",
                                        FieldName = "Максимальное значение",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FrequencyPowerFlow",
                                        FieldName = "FrequencyPowerFlow",
                                        DataType = typeof(ICollection<FrequencyPowerFlow>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditionsCurrent",
                                        FieldName = "PreFaultConditionsCurrent",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditionsStatic",
                                        FieldName = "PreFaultConditionsStatic",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditionsVoltage",
                                        FieldName = "PreFaultConditionsVoltage",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion Conditions
                            #region Disturbances
                            {
                                typeof(Disturbances),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupUid",
                                        FieldName = "BranchGroupUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Number",
                                        FieldName = "Номер",
                                        DataType = typeof(int?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FormalName",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroup",
                                        FieldName = "BranchGroup",
                                        DataType = typeof(BranchGroup),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupProxy",
                                        FieldName = "Сечения",
                                        DataType = typeof(Guid?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion Disturbances
                            #region Equipment
                            {
                                typeof(Equipment),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AggregatedEquipmentId",
                                        FieldName = "AggregatedEquipmentId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AggregatedEquipment",
                                        FieldName = "AggregatedEquipment",
                                        DataType = typeof(AggregatedEquipment),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "EquipmentVsInfluencingEquipment",
                                        FieldName = "EquipmentVsInfluencingEquipment",
                                        DataType = typeof(ICollection<EquipmentVsInfluencingEquipment>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AggregatedEquipmentProxy",
                                        FieldName = "Станции/Транзиты",
                                        DataType = typeof(int?),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                }
                            },
                            #endregion Equipment
                            #region EquipmentVsInfluencingEquipment
                            {
                                typeof(EquipmentVsInfluencingEquipment),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "EquipmentId",
                                        FieldName = "EquipmentId",
                                        DataType = typeof(int),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "InfluencingEquipmentUid",
                                        FieldName = "InfluencingEquipmentUid",
                                        DataType = typeof(Guid),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Equipment",
                                        FieldName = "Equipment",
                                        DataType = typeof(Equipment),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "InfluencingEquipment",
                                        FieldName = "InfluencingEquipment",
                                        DataType = typeof(InfluencingEquipment),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion EquipmentVsInfluencingEquipment
                            #region FrequencyPowerFlow
                            {
                                typeof(FrequencyPowerFlow),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionId",
                                        FieldName = "ConditionId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerConsumptionFactor",
                                        FieldName = "Коэффициент потребления",
                                        DataType = typeof(double?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PowerConsumptionName",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "MinValue",
                                        FieldName = "Минимальное значение",
                                        DataType = typeof(double?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "MaxValue",
                                        FieldName = "Максимальное значение",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Conditions",
                                        FieldName = "Conditions",
                                        DataType = typeof(Conditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsProxy",
                                        FieldName = "Переменные",
                                        DataType = typeof(int?),
                                        Index = 5,
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FrequencyFormalNameProxy",
                                        FieldName = "Формальное наименование",
                                        DataType = typeof(string),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion FrequencyPowerFlow
                            #region InfluencingEquipment
                            {
                                typeof(InfluencingEquipment),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Uid",
                                        FieldName = "Uid",
                                        DataType = typeof(Guid),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Наименование",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "EquipmentVsInfluencingEquipment",
                                        FieldName = "EquipmentVsInfluencingEquipment",
                                        DataType = typeof(ICollection<EquipmentVsInfluencingEquipment>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditions",
                                        FieldName = "PreFaultConditions",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion InfluencingEquipment
                            #region Management
                            {
                                typeof(Management),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ManagementTasksId",
                                        FieldName = "ManagementTasksId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Using",
                                        FieldName = "Использовать",
                                        DataType = typeof(bool?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "ФИО",
                                        DataType = typeof(string),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Position",
                                        FieldName = "Должность",
                                        DataType = typeof(string),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Priority",
                                        FieldName = "Приоритет",
                                        DataType = typeof(int?),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ManagementTasks",
                                        FieldName = "ManagementTasks",
                                        DataType = typeof(ManagementTasks),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ManagementTasksProxy",
                                        FieldName = "Задачи",
                                        DataType = typeof(int?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    }
                                }
                            },
                            #endregion Management
                            #region ManagementTasks
                            {
                                typeof(ManagementTasks),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Index = 1,
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Name",
                                        FieldName = "Задача",
                                        DataType = typeof(string),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Management",
                                        FieldName = "Management",
                                        DataType = typeof(ICollection<Management>),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion ManagementTasks
                            #region PreFaultConditions
                            {
                                typeof(PreFaultConditions),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupVsBranchGroupSchemeId",
                                        FieldName = "BranchGroupVsBranchGroupSchemeId",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElementsId",
                                        FieldName = "BoundingElementsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "InfluencingEquipmentUid",
                                        FieldName = "InfluencingEquipmentUid",
                                        DataType = typeof(Guid?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsId",
                                        FieldName = "SeasonsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "TemperatureId",
                                        FieldName = "TemperatureId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsStaticId",
                                        FieldName = "ConditionsStaticId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsCurrentId",
                                        FieldName = "ConditionsCurrentId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsVoltageId",
                                        FieldName = "ConditionsVoltageId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "UsingApf",
                                        FieldName = "Использовать (МДП)",
                                        DataType = typeof(bool?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "UsingFSpf",
                                        FieldName = "Использовать (ВДП)",
                                        DataType = typeof(bool?),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "SeasonsProxy",
                                        FieldName = "Сезон",
                                        DataType = typeof(int?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "TemperatureProxy",
                                        FieldName = "Температура",
                                        DataType = typeof(int?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElementsProxy",
                                        FieldName = "Ограничивающий элемент",
                                        DataType = typeof(int?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "InfluencingEquipmentProxy",
                                        FieldName = "Влияющее оборудование",
                                        DataType = typeof(Guid?),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "LimitPowerFlowProxy",
                                        FieldName = "Предельно допустимый переток по СУ",
                                        DataType = typeof(double?),
                                        Index = 7,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "LimitPowerFlow",
                                        FieldName = "LimitPowerFlow",
                                        DataType = typeof(double?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "TprPowerFlow",
                                        FieldName = "80% ДП по СУ",
                                        DataType = typeof(double?),
                                        Index = 8,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "EprPowerFlow",
                                        FieldName = "92% ДП по СУ",
                                        DataType = typeof(double?),
                                        Index = 9,
                                        Visible = true,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsStaticProxy",
                                        FieldName = "Переменные (СУ)",
                                        DataType = typeof(int?),
                                        Index = 10,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "CurrentPowerFlow",
                                        FieldName = "ДП по току",
                                        DataType = typeof(double?),
                                        Index = 11,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "CurrentAOPO",
                                        FieldName = "ДП по току (АОПО)",
                                        DataType = typeof(double?),
                                        Index = 12,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsCurrentProxy",
                                        FieldName = "Переменные (Ток)",
                                        DataType = typeof(int?),
                                        Index = 13,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "VoltagePowerFlow",
                                        FieldName = "ДП по напряжению",
                                        DataType = typeof(double?),
                                        Index = 14,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsVoltageProxy",
                                        FieldName = "Переменные (Напряжение)",
                                        DataType = typeof(int?),
                                        Index = 15,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "IrOscExpressions",
                                        FieldName = "Нерегулярные колебания",
                                        DataType = typeof(int?),
                                        Index = 16,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Comment",
                                        FieldName = "Комментарий",
                                        DataType = typeof(string),
                                        Index = 17,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APF",
                                        FieldName = "APF",
                                        DataType = typeof(APF),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElements",
                                        FieldName = "BoundingElements",
                                        DataType = typeof(BoundingElements),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupVsBranchGroupScheme",
                                        FieldName = "BranchGroupVsBranchGroupScheme",
                                        DataType = typeof(BranchGroupVsBranchGroupScheme),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsCurrent",
                                        FieldName = "ConditionsCurrent",
                                        DataType = typeof(Conditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsStatic",
                                        FieldName = "ConditionsStatic",
                                        DataType = typeof(Conditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsVoltage",
                                        FieldName = "ConditionsVoltage",
                                        DataType = typeof(Conditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "InfluencingEquipment",
                                        FieldName = "InfluencingEquipment",
                                        DataType = typeof(InfluencingEquipment),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PostFaultConditions",
                                        FieldName = "PostFaultConditions",
                                        DataType = typeof(ICollection<PostFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Seasons",
                                        FieldName = "Seasons",
                                        DataType = typeof(Seasons),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Temperature",
                                        FieldName = "Temperature",
                                        DataType = typeof(Temperature),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion PreFaultConditions
                            #region PostFaultConditions
                            {
                                typeof(PostFaultConditions),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "BranchGroupVsBranchGroupSchemeId",
                                        FieldName = "BranchGroupVsBranchGroupSchemeId",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditionsId",
                                        FieldName = "PreFaultConditionsId",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "DisturbancesId",
                                        FieldName = "DisturbancesId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElementsId",
                                        FieldName = "BoundingElementsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AopoId",
                                        FieldName = "AopoId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ApnuId",
                                        FieldName = "ApnuId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ArpmId",
                                        FieldName = "ArpmId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AosnId",
                                        FieldName = "AosnId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsId",
                                        FieldName = "ConditionsId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FrequencyPowerFlowId",
                                        FieldName = "FrequencyPowerFlowId",
                                        DataType = typeof(int?),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Using",
                                        FieldName = "Использовать",
                                        DataType = typeof(bool?),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "DisturbancesProxy",
                                        FieldName = "Возмущение",
                                        DataType = typeof(int?),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElementsProxy",
                                        FieldName = "Ограничивающий элемент",
                                        DataType = typeof(int?),
                                        Index = 3,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "EprPowerFlow",
                                        FieldName = "92% ДП по СУ",
                                        DataType = typeof(double?),
                                        Index = 4,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "DynamicPowerFlow",
                                        FieldName = "ДП по ДУ",
                                        DataType = typeof(double?),
                                        Index = 5,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "CurrentPowerFlow",
                                        FieldName = "ДП по току",
                                        DataType = typeof(double?),
                                        Index = 6,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "CurrentAOPO",
                                        FieldName = "ДП по току (АОПО)",
                                        DataType = typeof(double?),
                                        Index = 7,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "VoltagePowerFlow",
                                        FieldName = "ДП по напряжению",
                                        DataType = typeof(double?),
                                        Index = 8,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FrequencyPowerFlowProxy",
                                        FieldName = "ДП по частоте",
                                        DataType = typeof(int?),
                                        Index = 9,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ConditionsProxy",
                                        FieldName = "Переменные",
                                        DataType = typeof(int?),
                                        Index = 10,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOPOProxy",
                                        FieldName = "АОПО",
                                        DataType = typeof(int?),
                                        Index = 11,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APNUProxy",
                                        FieldName = "АПНУ",
                                        DataType = typeof(int?),
                                        Index = 12,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ARPMProxy",
                                        FieldName = "АРПМ",
                                        DataType = typeof(int?),
                                        Index = 13,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOSNProxy",
                                        FieldName = "АОСН",
                                        DataType = typeof(int?),
                                        Index = 14,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Comment",
                                        FieldName = "Комментарий",
                                        DataType = typeof(string),
                                        Index = 15,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOPO",
                                        FieldName = "AOPO",
                                        DataType = typeof(AOPO),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOSN",
                                        FieldName = "AOSN",
                                        DataType = typeof(AOSN),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APNU",
                                        FieldName = "APNU",
                                        DataType = typeof(APNU),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ARPM",
                                        FieldName = "ARPM",
                                        DataType = typeof(ARPM),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "BoundingElements",
                                        FieldName = "BoundingElements",
                                        DataType = typeof(BoundingElements),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Conditions",
                                        FieldName = "Conditions",
                                        DataType = typeof(Conditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Disturbances",
                                        FieldName = "Disturbances",
                                        DataType = typeof(Disturbances),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "FrequencyPowerFlow",
                                        FieldName = "FrequencyPowerFlow",
                                        DataType = typeof(FrequencyPowerFlow),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditions",
                                        FieldName = "PreFaultConditions",
                                        DataType = typeof(PreFaultConditions),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion PostFaultConditions
                            #region Seasons
                            {
                                typeof(Seasons),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Value",
                                        FieldName = "Значение",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOPO",
                                        FieldName = "AOPO",
                                        DataType = typeof(ICollection<AOPO>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "AOSN",
                                        FieldName = "AOSN",
                                        DataType = typeof(ICollection<AOSN>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "APNU",
                                        FieldName = "APNU",
                                        DataType = typeof(ICollection<APNU>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "ARPM",
                                        FieldName = "ARPM",
                                        DataType = typeof(ICollection<ARPM>),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditions",
                                        FieldName = "PreFaultConditions",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion Seasons
                            #region Temperature
                            {
                                typeof(Temperature),
                                new List<FieldDefinition>()
                                {
                                    new FieldDefinition()
                                    {
                                        Name = "Id",
                                        FieldName = "Id",
                                        DataType = typeof(int),
                                        Visible = false,
                                        IsReadOnly = true
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Value",
                                        FieldName = "Значение",
                                        DataType = typeof(string),
                                        Index = 1,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "Priority",
                                        FieldName = "Приоритет",
                                        DataType = typeof(int?),
                                        Index = 2,
                                        Visible = true,
                                        IsReadOnly = false
                                    },
                                    new FieldDefinition()
                                    {
                                        Name = "PreFaultConditions",
                                        FieldName = "PreFaultConditions",
                                        DataType = typeof(ICollection<PreFaultConditions>),
                                        Visible = false,
                                        IsReadOnly = true
                                    }
                                }
                            },
                            #endregion Temperature
                        };

        public EntityFieldDefinition[] Map { get; }

        public EntityFieldMap()
        {
            Map = GetFieldMap();
        }

        private EntityFieldDefinition[] GetFieldMap() => 
            _map.Select(
                kvp =>
                {
                    var type = kvp.Key;
                    var fields = kvp.Value;

                    return new EntityFieldDefinition
                    {
                        EntityType = type,
                        Fields = fields
                    };
                }
            ).ToArray();
    }
}
