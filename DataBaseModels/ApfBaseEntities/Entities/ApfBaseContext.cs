using System.Data.Entity;

namespace DataBaseModels.ApfBaseEntities
{
    public partial class ApfBaseContext : DbContext
    {
        public ApfBaseContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
    }
}
