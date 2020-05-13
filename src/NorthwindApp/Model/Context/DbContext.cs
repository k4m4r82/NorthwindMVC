using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace NorthwindApp.Model.Context
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Conn { get; }
    }

    public class DbContext : IDbContext
    {
        private IDbConnection _conn;

        private readonly string _providerName = "MySql.Data.MySqlClient";
        private readonly string _connectionString;

        public DbContext()
        {
            var server = ConfigurationManager.AppSettings["server"];
            var dbName = ConfigurationManager.AppSettings["dbName"];

            var dbUser = "root";
            var dbUserPass = "ILSoDPUGLxBsVjVWc";

            _connectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};Port=3306",
                server, dbName, dbUser, dbUserPass);
        }

        public IDbConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection(_providerName, _connectionString)); }
        }

        private IDbConnection GetOpenConnection(string providerName, string connectionString)
        {
            IDbConnection conn = null;

            try
            {
                var provider = DbProviderFactories.GetFactory(providerName);
                conn = provider.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
            }
            catch
            {
            }

            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
