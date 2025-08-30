using ApfBuilder.Services;
using DataBaseModels.ApfBaseEntities;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Context
{
    public static class APFContextExtensions
    {
        public static void ExecuteBuild(
            this IList<IAPFContext> context)
        {
            foreach (var participant in context)
            {
                try
                {
                    participant.PowerFlows = Builder.Build(participant);
                    participant.APFHandler();
                }
                catch
                {
                    throw;
                }
            }
        }

        public static void ExecuteBuildParallel(
            this IList<IAPFContext> context,
            int maxDegreeOfParallelism = 4)
        {
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = maxDegreeOfParallelism
            };

            Parallel.ForEach(
                context, options, participant =>
                {
                    try
                    {
                        participant.PowerFlows = Builder.Build(participant);
                        participant.APFHandler();
                    }
                    catch
                    {
                        throw;
                    }
                }
            );
        }

        public static void Save(this IList<IAPFContext> apfContext)
        {
            apfContext.SqlTransactionMerge();
        }

        private static void SqlTransactionMerge(
            this IList<IAPFContext> apfContext)
        {
            string connectionString = DataBaseConnection.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createTempTableSql = @"
                    CREATE TABLE #TempPreFaultApf 
                    (
                        BranchGroupVsBranchGroupSchemeId INT,
                        Id INT,
                        BoundingElementsId INT NULL,
                        InfluencingEquipmentUid UNIQUEIDENTIFIER NULL,
                        SeasonsId INT NULL,
                        TemperatureId INT NULL,
                        ConditionsStaticId INT NULL,
                        ConditionsCurrentId INT NULL,
                        ConditionsVoltageId INT NULL,
                        UsingRow BIT NULL,
                        LimitPowerFlow FLOAT NULL,
                        TprPowerFlow FLOAT NULL,
                        EprPowerFlow FLOAT NULL,
                        CurrentPowerFlow FLOAT NULL,
                        CurrentAOPO FLOAT NULL,
                        VoltagePowerFlow FLOAT NULL,
                        IrOscExpressions INT NULL,
                        Comment NVARCHAR(MAX) NULL,

                        PowerFlowStandardValue NVARCHAR(MAX) NULL,
                        PowerFlowStandardDescription NVARCHAR(MAX) NULL,
                        PowerFlowSafeValue NVARCHAR(MAX) NULL,
                        PowerFlowSafeDescription NVARCHAR(MAX) NULL,
                        PowerFlowEmergencyValue NVARCHAR(MAX) NULL,
                        PowerFlowEmergencyDescription NVARCHAR(MAX) NULL,
                        ControlledPowerFlowStandard NVARCHAR(MAX) NULL,
                        ControlledPowerFlowSafe NVARCHAR(MAX) NULL,
                        ControlledPowerFlowEmergency NVARCHAR(MAX) NULL,
                        PowerFlowForcedStateValue NVARCHAR(MAX) NULL,
                        PowerFlowForcedStateDescription NVARCHAR(MAX) NULL,
                        PowerFlowStandardValueHandWritten NVARCHAR(MAX) NULL,
                        PowerFlowStandardDescriptionHandWritten NVARCHAR(MAX) NULL,
                        PowerFlowSafeValueHandWritten NVARCHAR(MAX) NULL,
                        PowerFlowSafeDescriptionHandWritten NVARCHAR(MAX) NULL,
                        PowerFlowEmergencyValueHandWritten NVARCHAR(MAX) NULL,
                        PowerFlowEmergencyDescriptionHandWritten NVARCHAR(MAX) NULL,
                        PowerFlowForcedStateValueHandWritten NVARCHAR(MAX) NULL,
                     PowerFlowForcedStateDescriptionHandWritten NVARCHAR(MAX) NULL,
                        PRIMARY KEY(BranchGroupVsBranchGroupSchemeId, Id)
                    );";

                using (var createCmd = new SqlCommand(
                    createTempTableSql, connection))
                {
                    createCmd.ExecuteNonQuery();
                }

                var dataTable = new DataTable();
                dataTable.Columns.Add("BranchGroupVsBranchGroupSchemeId", typeof(int));
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("BoundingElementsId", typeof(int));
                dataTable.Columns.Add("InfluencingEquipmentUid", typeof(Guid));
                dataTable.Columns.Add("SeasonsId", typeof(int));
                dataTable.Columns.Add("TemperatureId", typeof(int));
                dataTable.Columns.Add("ConditionsStaticId", typeof(int));
                dataTable.Columns.Add("ConditionsCurrentId", typeof(int));
                dataTable.Columns.Add("ConditionsVoltageId", typeof(int));
                dataTable.Columns.Add("UsingRow", typeof(bool));
                dataTable.Columns.Add("LimitPowerFlow", typeof(double));
                dataTable.Columns.Add("TprPowerFlow", typeof(double));
                dataTable.Columns.Add("EprPowerFlow", typeof(double));
                dataTable.Columns.Add("CurrentPowerFlow", typeof(double));
                dataTable.Columns.Add("CurrentAOPO", typeof(double));
                dataTable.Columns.Add("VoltagePowerFlow", typeof(double));
                dataTable.Columns.Add("IrOscExpressions", typeof(int));
                dataTable.Columns.Add("Comment", typeof(string));

                dataTable.Columns.Add(
                    "PowerFlowStandardValue", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowStandardDescription", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowSafeValue", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowSafeDescription", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowEmergencyValue", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowEmergencyDescription", typeof(string));
                dataTable.Columns.Add(
                    "ControlledPowerFlowStandard", typeof(string));
                dataTable.Columns.Add(
                    "ControlledPowerFlowSafe", typeof(string));
                dataTable.Columns.Add(
                    "ControlledPowerFlowEmergency", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowForcedStateValue", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowForcedStateDescription", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowStandardValueHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowStandardDescriptionHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowSafeValueHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowSafeDescriptionHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowEmergencyValueHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowEmergencyDescriptionHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowForcedStateValueHandWritten", typeof(string));
                dataTable.Columns.Add(
                    "PowerFlowForcedStateDescriptionHandWritten", typeof(string));

                foreach (var item in apfContext)
                {
                    var preF = item.PreF;
                    var apf = item.Apf;

                    dataTable.Rows.Add(
                        preF.BranchGroupVsBranchGroupSchemeId,
                        preF.Id,
                        preF.BoundingElementsId,
                        preF.InfluencingEquipmentUid,
                        preF.SeasonsId,
                        preF.TemperatureId,
                        preF.ConditionsStaticId,
                        preF.ConditionsCurrentId,
                        preF.ConditionsVoltageId,
                        preF.UsingRow,
                        preF.LimitPowerFlow,
                        preF.TprPowerFlow,
                        preF.EprPowerFlow,
                        preF.CurrentPowerFlow,
                        preF.CurrentAOPO,
                        preF.VoltagePowerFlow,
                        preF.IrOscExpressions,
                        preF.Comment,

                        apf.PowerFlowStandardValue,
                        apf.PowerFlowStandardDescription,
                        apf.PowerFlowSafeValue,
                        apf.PowerFlowSafeDescription,
                        apf.PowerFlowEmergencyValue,
                        apf.PowerFlowEmergencyDescription,
                        apf.ControlledPowerFlowStandard,
                        apf.ControlledPowerFlowSafe,
                        apf.ControlledPowerFlowEmergency,
                        apf.PowerFlowForcedStateValue,
                        apf.PowerFlowForcedStateDescription,
                        apf.PowerFlowStandardValueHandWritten,
                        apf.PowerFlowStandardDescriptionHandWritten,
                        apf.PowerFlowSafeValueHandWritten,
                        apf.PowerFlowSafeDescriptionHandWritten,
                        apf.PowerFlowEmergencyValueHandWritten,
                        apf.PowerFlowEmergencyDescriptionHandWritten
                    );
                }

                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "#TempPreFaultApf";
                    bulkCopy.WriteToServer(dataTable);
                }

                string mergePreFaultSql = @"
                    MERGE INTO PreFaultConditions AS Target
                    USING #TempPreFaultApf AS Source
                    ON Target.BranchGroupVsBranchGroupSchemeId = 
                        Source.BranchGroupVsBranchGroupSchemeId AND 
                        Target.Id = Source.Id
                    WHEN MATCHED THEN UPDATE SET
                        BoundingElementsId = Source.BoundingElementsId,
                        InfluencingEquipmentUid = Source.InfluencingEquipmentUid,
                        SeasonsId = Source.SeasonsId,
                        TemperatureId = Source.TemperatureId,
                        ConditionsStaticId = Source.ConditionsStaticId,
                        ConditionsCurrentId = Source.ConditionsCurrentId,
                        ConditionsVoltageId = Source.ConditionsVoltageId,
                        UsingRow = Source.UsingRow,
                        LimitPowerFlow = Source.LimitPowerFlow,
                        TprPowerFlow = Source.TprPowerFlow,
                        EprPowerFlow = Source.EprPowerFlow,
                        CurrentPowerFlow = Source.CurrentPowerFlow,
                        CurrentAOPO = Source.CurrentAOPO,
                        VoltagePowerFlow = Source.VoltagePowerFlow,
                        IrOscExpressions = Source.IrOscExpressions,
                        Comment = Source.Comment;";

                string mergeApfSql = @"
                    MERGE INTO APF AS Target
                    USING #TempPreFaultApf AS Source
                    ON Target.BranchGroupVsBranchGroupSchemeId = 
                        Source.BranchGroupVsBranchGroupSchemeId AND 
                        Target.PreFaultConditionsId = 
                            Source.Id
                    WHEN MATCHED THEN UPDATE SET
                        PowerFlowStandardValue = 
                            Source.PowerFlowStandardValue,
                        PowerFlowStandardDescription = 
                            Source.PowerFlowStandardDescription,
                        PowerFlowSafeValue = 
                            Source.PowerFlowSafeValue,
                        PowerFlowSafeDescription = 
                            Source.PowerFlowSafeDescription,
                        PowerFlowEmergencyValue = 
                            Source.PowerFlowEmergencyValue,
                        PowerFlowEmergencyDescription = 
                            Source.PowerFlowEmergencyDescription,
                        ControlledPowerFlowStandard = 
                            Source.ControlledPowerFlowStandard,
                        ControlledPowerFlowSafe = 
                            Source.ControlledPowerFlowSafe,
                        ControlledPowerFlowEmergency = 
                            Source.ControlledPowerFlowEmergency,
                        PowerFlowForcedStateValue = 
                            Source.PowerFlowForcedStateValue,
                        PowerFlowForcedStateDescription = 
                            Source.PowerFlowForcedStateDescription,
                        PowerFlowStandardValueHandWritten = 
                            Source.PowerFlowStandardValueHandWritten,
                        PowerFlowStandardDescriptionHandWritten = 
                            Source.PowerFlowStandardDescriptionHandWritten,
                        PowerFlowSafeValueHandWritten = 
                            Source.PowerFlowSafeValueHandWritten,
                        PowerFlowSafeDescriptionHandWritten = 
                            Source.PowerFlowSafeDescriptionHandWritten,
                        PowerFlowEmergencyValueHandWritten = 
                            Source.PowerFlowEmergencyValueHandWritten,
                        PowerFlowEmergencyDescriptionHandWritten = 
                            Source.PowerFlowEmergencyDescriptionHandWritten,
                        PowerFlowForcedStateValueHandWritten =
                            Source.PowerFlowForcedStateValueHandWritten,
                        PowerFlowForcedStateDescriptionHandWritten =
                            Source.PowerFlowForcedStateDescriptionHandWritten;";

                using (var mergeCmd1 = new SqlCommand(
                    mergePreFaultSql, connection))
                {
                    mergeCmd1.ExecuteNonQuery();
                }

                using (var mergeCmd2 = new SqlCommand(
                    mergeApfSql, connection))
                {
                    mergeCmd2.ExecuteNonQuery();
                }
            }
        }
    }
}

