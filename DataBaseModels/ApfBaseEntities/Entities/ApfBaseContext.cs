using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels.ApfBaseEntities;

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
