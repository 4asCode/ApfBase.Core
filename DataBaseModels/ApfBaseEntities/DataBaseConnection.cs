﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public class DataBaseConnection
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get => _connectionString;
            private set => _connectionString = value;
        }

        public DataBaseConnection(ApfBaseContext context, 
            string connectionString)
        {
            context.Database.Connection.ConnectionString = connectionString;

            _connectionString = connectionString;
        }
    }
}
