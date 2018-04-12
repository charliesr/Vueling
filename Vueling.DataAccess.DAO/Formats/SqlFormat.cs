using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Formats
{
    public class SqlFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Select(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<T> SelectAll()
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(RepositoryUtils.GetFilePath<T>(DataTypeAccess.sqlDB)))
                {
                    _connection.Open();
                    var queryString = "Select * from dbo.Student";
                    using (var _command = new SqlCommand(queryString, _connection))
                    {
                        var reader = _command.ExecuteReader();
                        while (reader.Read())
                        {
                           reader.
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
