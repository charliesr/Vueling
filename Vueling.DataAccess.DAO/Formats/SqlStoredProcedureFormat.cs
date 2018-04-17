using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO.Formats
{
    public class SqlStoredProcedureFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        public T Add(T entity)
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString())
            {

            }
        }

        public bool DeleteByGuid(Guid guid)
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString())
            {

            }
        }

        public List<T> GetAll()
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString())
            {

            }
        }

        public T GetByGUID(Guid guid)
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString())
            {

            }
        }

        public DataTypeAccess GetFormat()
        {
            return DataTypeAccess.sqlStoredProcedure;
        }

        public bool Update(Guid guid, T entity)
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString())
            {

            }
        }
    }
}
