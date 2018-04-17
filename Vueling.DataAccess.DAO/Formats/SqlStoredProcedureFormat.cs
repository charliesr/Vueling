using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.DAO.Formats
{
    public class SqlStoredProcedureFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public T Add(T entity)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                using (SqlCommand _comm = new SqlCommand("AddStudent", _conn))
                {

                    _comm.CommandType = CommandType.StoredProcedure;
                    _comm.Parameters.Add(new SqlParameter("@studentTvp", entity.GetObjectWithoutId()));
                    _conn.Open();
                    _comm.ExecuteNonQuery();
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public bool DeleteByGuid(Guid guid)
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
            using (SqlCommand _comm = new SqlCommand("DeleteStudent", _conn))
            {
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.Add("@guid", SqlDbType.UniqueIdentifier);
                _conn.Open();
                return _comm.ExecuteNonQuery() > 0;
            }
        }

        public List<T> GetAll()
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
            using (SqlCommand _comm = new SqlCommand("SelectAllStudents", _conn))
            {
                _comm.CommandType = CommandType.StoredProcedure;
                var returnParameter = _comm.Parameters.Add(new SqlParameter("@ReturnValue", new List<T>()));
                returnParameter.Direction = ParameterDirection.ReturnValue;
                _conn.Open();
                _comm.ExecuteNonQuery();
                return (List<T>)returnParameter.Value;

            }
        }

        public T GetByGUID(Guid guid)
        {
            var classInstance = Activator.CreateInstance(typeof(T));
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
            using (SqlCommand _comm = new SqlCommand("SelectByGuid", _conn))
            {
                _comm.CommandType = CommandType.StoredProcedure;
                var returnParameter = _comm.Parameters.Add(new SqlParameter("@ReturnValue", classInstance));
                returnParameter.Direction = ParameterDirection.ReturnValue;
                _conn.Open();
                return (T)returnParameter.Value;
            }
        }

        public DataTypeAccess GetFormat()
        {
            return DataTypeAccess.sqlStoredProcedure;
        }

        public bool Update(Guid guid, T entity)
        {
            using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
            using (SqlCommand _comm = new SqlCommand("UpdateStudent", _conn))
            {
                _comm.Parameters.Add("@guid", SqlDbType.UniqueIdentifier);
                _comm.Parameters.Add(new SqlParameter("@studentTvp", entity.GetObjectWithoutId()));
                _conn.Open();
                return _comm.ExecuteNonQuery() > 0;

            }
        }
    }
}
