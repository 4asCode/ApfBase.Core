namespace DataBaseModels.ApfBaseEntities.Proxy
{
    using System.Collections.Generic;
    using System.Linq;

    public static class LinkSyncService
    {
        public static void SyncLinks<TKey>(
            ApfBaseContext ctx,
            string tableName,
            string leftColumn,
            string rightColumn,
            object leftValue,
            IEnumerable<TKey> desiredKeys)
        {
            var desired = new HashSet<TKey>(desiredKeys ?? 
                Enumerable.Empty<TKey>());

            var sql = $@"
                SELECT {rightColumn} AS [Key], IsActive
                FROM [ApfBase].[dbo].[{tableName}]
                WHERE {leftColumn} = @p0";

            var rows = ctx.Database.SqlQuery<Row<TKey>>(
                sql, leftValue).ToList();
            var currentMap = rows.ToDictionary(
                r => r.Key, r => r);

            using (var tx = ctx.Database.BeginTransaction())
            {
                foreach (var key in desired)
                {
                    if (currentMap.ContainsKey(key))
                    {
                        if (!currentMap[key].IsActive)
                        {
                            ctx.Database.ExecuteSqlCommand(
                                $@"UPDATE [ApfBase].[dbo].[{tableName}]
                                  SET IsActive = 1
                                WHERE {leftColumn} = @p0 AND 
                                        {rightColumn} = @p1",
                                leftValue, key);
                        }
                    }
                    else
                    {
                        ctx.Database.ExecuteSqlCommand(
                            $@"INSERT INTO [ApfBase].[dbo].[{tableName}]
                              ({leftColumn}, {rightColumn}, IsActive)
                          VALUES (@p0, @p1, 1)",
                            leftValue, key);
                    }
                }

                foreach (var row in rows.Where(
                    r => r.IsActive && !desired.Contains(r.Key)))
                {
                    ctx.Database.ExecuteSqlCommand(
                        $@"UPDATE [ApfBase].[dbo].[{tableName}]
                          SET IsActive = 0
                        WHERE {leftColumn} = @p0 AND {rightColumn} = @p1",
                        leftValue, row.Key);
                }

                tx.Commit();
            }
        }

        public static IList<TKey> GetActiveLinks<TKey>(
            ApfBaseContext ctx,
            string tableName,
            string leftColumn,
            string rightColumn,
            object leftValue)
        {
            var sql = $@"
                SELECT {rightColumn}
                FROM [ApfBase].[dbo].[{tableName}]
                WHERE {leftColumn} = @p0 AND IsActive = 1";

            return ctx.Database.SqlQuery<TKey>(sql, leftValue).ToList();
        }

        private sealed class Row<TKey>
        {
            public TKey Key { get; set; }

            public bool IsActive { get; set; }
        }
    }
}
