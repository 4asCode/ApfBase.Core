using ApfBuilder.Services;
using DataBaseModels.ApfBaseEntities;
using Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ApfBuilder.Context
{
    public static class APFContextExtensions
    {
        private static readonly object _saveLock = new object();

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
                catch (Exception ex)
                {
                    throw new APFContextException
                        ($"Ошибка при формировании формул ДП! " +
                        $"[{participant?.ToString()}]", ex);
                }
            }
        }

        public static void ExecuteBuildParallel(
            this IList<IAPFContext> context,
            int maxDegreeOfParallelism = 4)
        {
            var opts = new ParallelOptions
            {
                MaxDegreeOfParallelism = maxDegreeOfParallelism > 0
                    ? maxDegreeOfParallelism
                    : Environment.ProcessorCount
            };

            Parallel.ForEach(
                context, opts, participant =>
                {
                    try
                    {
                        participant.PowerFlows = Builder.Build(participant);
                        participant.APFHandler();
                    }
                    catch (Exception ex)
                    {
                        throw new APFContextException
                            ($"Ошибка при формировании формул ДП! " +
                            $"[{participant?.ToString()}]", ex);
                    }
                }
            );
        }

        public static void Save(this IList<IAPFContext> apfContext)
        {
            lock (_saveLock)
            {
                apfContext.SqlTransactionMerge();
            }
        }

        private static void SqlTransactionMerge(
            this IList<IAPFContext> apfContext)
        {
            string cs = DataBaseConnection.ConnectionString;

            using (var connection = new SqlConnection(cs))
            {
                connection.Open();
                using (var tx = connection.BeginTransaction())
                {
                    string createTempTableSql = @"
                        CREATE TABLE #TempApfUpsert 
                        (
                            BranchGroupVsBranchGroupSchemeId INT NOT NULL,
                            PreFaultConditionsId INT NOT NULL,

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

                            APFReferenceData NVARCHAR(MAX) NULL,
                            APFAppliedCriteriaData NVARCHAR(MAX) NULL,

                            PRIMARY KEY(BranchGroupVsBranchGroupSchemeId, PreFaultConditionsId)
                        );";

                    using (var createCmd = new SqlCommand(
                        createTempTableSql, connection, tx))
                    {
                        createCmd.ExecuteNonQuery();
                    }

                    var dt = new DataTable();
                    dt.Columns.Add("BranchGroupVsBranchGroupSchemeId", typeof(int));
                    dt.Columns.Add("PreFaultConditionsId", typeof(int));

                    dt.Columns.Add("PowerFlowStandardValue", typeof(string));
                    dt.Columns.Add("PowerFlowStandardDescription", typeof(string));
                    dt.Columns.Add("PowerFlowSafeValue", typeof(string));
                    dt.Columns.Add("PowerFlowSafeDescription", typeof(string));
                    dt.Columns.Add("PowerFlowEmergencyValue", typeof(string));
                    dt.Columns.Add("PowerFlowEmergencyDescription", typeof(string));
                    dt.Columns.Add("ControlledPowerFlowStandard", typeof(string));
                    dt.Columns.Add("ControlledPowerFlowSafe", typeof(string));
                    dt.Columns.Add("ControlledPowerFlowEmergency", typeof(string));
                    dt.Columns.Add("PowerFlowForcedStateValue", typeof(string));
                    dt.Columns.Add("PowerFlowForcedStateDescription", typeof(string));

                    dt.Columns.Add("PowerFlowStandardValueHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowStandardDescriptionHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowSafeValueHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowSafeDescriptionHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowEmergencyValueHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowEmergencyDescriptionHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowForcedStateValueHandWritten", typeof(string));
                    dt.Columns.Add("PowerFlowForcedStateDescriptionHandWritten", typeof(string));

                    dt.Columns.Add("APFReferenceData", typeof(string));
                    dt.Columns.Add("APFAppliedCriteriaData", typeof(string));

                    foreach (var ctx in apfContext)
                    {
                        var preF = ctx.PreF;
                        var apf = ctx.Apf;

                        dt.Rows.Add(
                            preF.BranchGroupVsBranchGroupSchemeId,
                            preF.Id,

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
                            apf.PowerFlowEmergencyDescriptionHandWritten,
                            apf.PowerFlowForcedStateValueHandWritten,
                            apf.PowerFlowForcedStateDescriptionHandWritten,

                            apf.APFReferenceData,
                            apf.APFAppliedCriteriaData
                        );
                    }

                    using (var bulkCopy = new SqlBulkCopy(
                        connection, SqlBulkCopyOptions.TableLock, tx))
                    {
                        bulkCopy.DestinationTableName = "#TempApfUpsert";
                        bulkCopy.BatchSize = 5000;

                        foreach (DataColumn col in dt.Columns)
                            bulkCopy.ColumnMappings.Add(
                                col.ColumnName, col.ColumnName);

                        bulkCopy.WriteToServer(dt);
                    }

                    string mergeApfSql = @"
                        MERGE INTO APF AS Target
                        USING #TempApfUpsert AS Source
                        ON Target.BranchGroupVsBranchGroupSchemeId = Source.BranchGroupVsBranchGroupSchemeId
                           AND Target.PreFaultConditionsId = Source.PreFaultConditionsId
                        WHEN MATCHED THEN UPDATE SET
                              PowerFlowStandardValue = Source.PowerFlowStandardValue
                            , PowerFlowStandardDescription = Source.PowerFlowStandardDescription
                            , PowerFlowSafeValue = Source.PowerFlowSafeValue
                            , PowerFlowSafeDescription = Source.PowerFlowSafeDescription
                            , PowerFlowEmergencyValue = Source.PowerFlowEmergencyValue
                            , PowerFlowEmergencyDescription = Source.PowerFlowEmergencyDescription
                            , ControlledPowerFlowStandard = Source.ControlledPowerFlowStandard
                            , ControlledPowerFlowSafe = Source.ControlledPowerFlowSafe
                            , ControlledPowerFlowEmergency = Source.ControlledPowerFlowEmergency
                            , PowerFlowForcedStateValue = Source.PowerFlowForcedStateValue
                            , PowerFlowForcedStateDescription = Source.PowerFlowForcedStateDescription
                            , PowerFlowStandardValueHandWritten = Source.PowerFlowStandardValueHandWritten
                            , PowerFlowStandardDescriptionHandWritten = Source.PowerFlowStandardDescriptionHandWritten
                            , PowerFlowSafeValueHandWritten = Source.PowerFlowSafeValueHandWritten
                            , PowerFlowSafeDescriptionHandWritten = Source.PowerFlowSafeDescriptionHandWritten
                            , PowerFlowEmergencyValueHandWritten = Source.PowerFlowEmergencyValueHandWritten
                            , PowerFlowEmergencyDescriptionHandWritten = Source.PowerFlowEmergencyDescriptionHandWritten
                            , PowerFlowForcedStateValueHandWritten = Source.PowerFlowForcedStateValueHandWritten
                            , PowerFlowForcedStateDescriptionHandWritten = Source.PowerFlowForcedStateDescriptionHandWritten
                            , APFReferenceData = Source.APFReferenceData
                            , APFAppliedCriteriaData = Source.APFAppliedCriteriaData
                        WHEN NOT MATCHED THEN INSERT
                            ( BranchGroupVsBranchGroupSchemeId
                            , PreFaultConditionsId
                            , PowerFlowStandardValue
                            , PowerFlowStandardDescription
                            , PowerFlowSafeValue
                            , PowerFlowSafeDescription
                            , PowerFlowEmergencyValue
                            , PowerFlowEmergencyDescription
                            , ControlledPowerFlowStandard
                            , ControlledPowerFlowSafe
                            , ControlledPowerFlowEmergency
                            , PowerFlowForcedStateValue
                            , PowerFlowForcedStateDescription
                            , PowerFlowStandardValueHandWritten
                            , PowerFlowStandardDescriptionHandWritten
                            , PowerFlowSafeValueHandWritten
                            , PowerFlowSafeDescriptionHandWritten
                            , PowerFlowEmergencyValueHandWritten
                            , PowerFlowEmergencyDescriptionHandWritten
                            , PowerFlowForcedStateValueHandWritten
                            , PowerFlowForcedStateDescriptionHandWritten
                            , APFReferenceData
                            , APFAppliedCriteriaData)
                        VALUES
                            ( Source.BranchGroupVsBranchGroupSchemeId
                            , Source.PreFaultConditionsId
                            , Source.PowerFlowStandardValue
                            , Source.PowerFlowStandardDescription
                            , Source.PowerFlowSafeValue
                            , Source.PowerFlowSafeDescription
                            , Source.PowerFlowEmergencyValue
                            , Source.PowerFlowEmergencyDescription
                            , Source.ControlledPowerFlowStandard
                            , Source.ControlledPowerFlowSafe
                            , Source.ControlledPowerFlowEmergency
                            , Source.PowerFlowForcedStateValue
                            , Source.PowerFlowForcedStateDescription
                            , Source.PowerFlowStandardValueHandWritten
                            , Source.PowerFlowStandardDescriptionHandWritten
                            , Source.PowerFlowSafeValueHandWritten
                            , Source.PowerFlowSafeDescriptionHandWritten
                            , Source.PowerFlowEmergencyValueHandWritten
                            , Source.PowerFlowEmergencyDescriptionHandWritten
                            , Source.PowerFlowForcedStateValueHandWritten
                            , Source.PowerFlowForcedStateDescriptionHandWritten
                            , Source.APFReferenceData
                            , Source.APFAppliedCriteriaData
                            );";

                    using (var mergeCmd = new SqlCommand(mergeApfSql, connection, tx))
                        mergeCmd.ExecuteNonQuery();

                    tx.Commit();
                }
            }
        }
    }
}

