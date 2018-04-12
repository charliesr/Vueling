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
            try
            {
                using (SqlConnection _connection = new SqlConnection(RepositoryUtils.GetFilePath<T>(DataTypeAccess.sqlDB)))
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
                    var propertyValues = entity.GetPropertiesArray();
                    foreach (var value in propertyValues)
                    {
                        query.Append(value);
                        query.Append(propertyValues.Last().Equals(value) ? "," : ")");
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

        public T Select(Guid guid)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(RepositoryUtils.GetFilePath<T>(DataTypeAccess.sqlDB)))
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

        public List<T> SelectAll()
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(RepositoryUtils.GetFilePath<T>(DataTypeAccess.sqlDB)))
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
    }
}
