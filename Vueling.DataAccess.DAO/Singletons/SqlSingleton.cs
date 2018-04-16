using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO.Singletons
{
    public class SqlSingleton
    {
        private static object syncLock = new object();
        private static string connectionString = ConfigurationUtils.GetConnecionString();
        private static SqlSingleton instance;
        private readonly SqlConnection sqlCon;

        private SqlSingleton()
        {
            sqlCon = new SqlConnection(connectionString);
        }

        public static SqlSingleton GetInstance()
        {
            if(instance == null )
            {
                lock (syncLock)
                {
                    if (instance == null) instance = new SqlSingleton();
                }
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return sqlCon;
        }

    }
}
