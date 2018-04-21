using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public class SqlFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SqlFormat()
        {

        }

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
                        if (property.Name == "ID") continue;
                        query.Append(property.Name);
                        query.Append(!typeof(T).GetProperties().Last().Equals(property) ? "," : ")");
                    }
                    query.Append(" VALUES ('");
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (property.Name == "ID") continue;
                        query.Append(property.GetValue(entity));
                        query.Append(!typeof(T).GetProperties().Last().Equals(property) ? "','" : "')");
                    }


                    _log.Debug("Sql statement: " + query);

                    using (var _command = new SqlCommand(query.ToString(), _connection))
                    {
                        _command.ExecuteNonQuery();
                    }



                    //using (var _command = new SqlCommand(query.ToString(), _connection))
                    //{
                    //    var reader = _command.ExecuteReader();
                    //    while (reader.Read())
                    //    {
                    //        var properties = new object[typeof(T).GetProperties().Length];
                    //        for (int i = 0; i < properties.Length; i++)
                    //        {
                    //            properties[i] = reader.GetValue(i);
                    //        }
                    //        entity = (T)Activator.CreateInstance(typeof(T), properties);

                    //    }
                    //}
                }
                return GetByGUID(entity.Guid);
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
                using (SqlConnection _connection = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    T entity = default(T);
                    _connection.Open();
                    var queryString = new StringBuilder("Select * from dbo.Students where GUID = '").Append(guid).Append("'").ToString();
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
                using (SqlConnection _connection = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    var results = new List<T>();
                    _connection.Open();
                    var queryString = "Select * from dbo.Students";
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

        public int DeleteByGuid(Guid guid)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    var query = new StringBuilder("DELETE FROM ").Append(typeof(T).Name).Append("WHERE GUID = '").Append(guid).Append("'").ToString();
                    _conn.Open();
                    using (SqlCommand _comm = new SqlCommand(query.ToString(),_conn))
                    {
                        return _comm.ExecuteNonQuery();
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

        public T GetById(int id)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    T entity = default(T);
                    _conn.Open();
                    var queryString = new StringBuilder("Select * from dbo.Students where id = '").Append(id).Append("'").ToString();
                    using (var _command = new SqlCommand(queryString, _conn))
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

        public int DeleteById(int id)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    var query = new StringBuilder("DELETE FROM dbo.Students WHERE id = ").Append(id).ToString();
                    _conn.Open();
                    using (SqlCommand _comm = new SqlCommand(query.ToString(), _conn))
                    {
                        return _comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(ConfigurationUtils.GetConnecionString()))
                {
                    var query = new StringBuilder();
                    query.Append("UPDATE dbo.Students SET ");
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (property.Name == "ID") continue;
                        if (property.Name == "GUID") continue;
                        query.Append(property.Name).Append(" = '");
                        query.Append(property.GetValue(entity)).Append("' ");
                        query.Append(!typeof(T).GetProperties().Last().Equals(property) ? ", " : "");
                    }
                    query.Append(" WHERE dbo.Students.GUID = ").Append("'").Append(entity.Guid).Append("'");
                    _connection.Open();
                    using (SqlCommand _comm = new SqlCommand(query.ToString(), _connection))
                    {
                        _comm.ExecuteNonQuery();
                    }
                }
                return GetByGUID(entity.Guid);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }

        }
    }
}
