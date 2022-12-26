using ErpSystem.core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ErpSystem.infra.Common
{
    public class DbContext : IDbContext
    {
        private DbConnection _connection;
        private readonly IConfiguration confirgraton;
        public DbContext(IConfiguration confirgraton)
        {
            this.confirgraton = confirgraton;
        }
        public DbConnection connection
        {
            get
            {
                if(_connection == null)
                {
                    _connection = new OracleConnection(confirgraton[("ConnectionStrings:DBConnectionString")]);
                }
                else if(_connection.State!= ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }


    }
}
