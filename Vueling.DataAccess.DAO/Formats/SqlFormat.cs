using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Singletons;

namespace Vueling.DataAccess.DAO.Formats
{
    public class SqlFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler<DataTypeAccess> ChangeFormatPetition;

        public T Add(T entity)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    _connection.Open();
                    var query = new StringBuilder();
                    query.Append("INSERT INTO dbo.Students (");
                    foreach (var property in typeof(T).GetProperties())
                    {
                        query.Append(property.Name);
                        query.Append(!typeof(T).GetProperties().Last().Equals(property) ? "," : ")");
                    }
                    query.Append(" VALUES (");
                    foreach (var property in typeof(T).GetProperties())
                    {
                        query.Append(property.GetValue(entity));
                        query.Append(typeof(T).GetProperties().Last().Equals(property) ? "," : ")");
                    }


                    using (var _command = new SqlCommand(query.ToString(), _connection))
                    {
                        var reader = _command.ExecuteReader();
                        while (reader.Read())
                        {
                            var properties = new object[typeof(T).GetProperties().Length];
                            for (int i = 0; i < properties.Length; i++)
                            {
                                properties[i] = reader.GetValue(i);
                            }
                            entity = (T)Activator.CreateInstance(typeof(T), properties);

                        }
                    }
                    return entity;
                }
            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public T GetByGUID(Guid guid)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.sqlDB)))
                {
                    T entity = default(T);
                    _connection.Open();
                    var queryString = "Select * from dbo.Student where dbo.Student.GlobalUnitID = " + guid;
                    using (var _command = new SqlCommand(queryString, _connection))
                    {
                        var reader = _command.ExecuteReader();
                        while (reader.Read())
                        {
                            var properties = new object[typeof(T).GetProperties().Length];
                            for (int i = 0; i < properties.Length; i++)
                            {
                                properties[i] = reader.GetValue(i);
                            }
                            entity = (T)Activator.CreateInstance(typeof(T), properties);
                            
                        }
                    }
                    return entity;
                }
            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.sqlDB)))
                {
                    var results = new List<T>();
                    _connection.Open();
                    var queryString = "Select * from dbo.Student";
                    using (var _command = new SqlCommand(queryString, _connection))
                    {
                        var reader = _command.ExecuteReader();
                        while (reader.Read())
                        {
                            var properties = new object[typeof(T).GetProperties().Length];
                            for (int i = 0; i < properties.Length; i++)
                            {
                                properties[i] = reader.GetValue(i);
                            }
                            var entity = Activator.CreateInstance(typeof(T), properties);
                            results.Add((T)entity);
                        }
                    }
                    return results;
                }
            }
            catch (SqlException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public bool Update(Guid guid, T entity)
        {
            var entityToUpdate = GetByGUID(guid);
            if (entity.Equals(entityToUpdate)) return false;
            DeleteByGuid(guid);
            Add(entity);
            return true;
        }

        public bool DeleteByGuid(Guid guid)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    var query = new StringBuilder("DELETE FROM ").Append(typeof(T).Name).Append("WHERE GUID = ").Append(guid);
                    using (SqlCommand _comm = new SqlCommand(query.ToString(),_conn))
                    {
                        return _comm.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
         
        }

        public DataTypeAccess GetFormat()
        {
            return DataTypeAccess.json;
        }

    }
}
