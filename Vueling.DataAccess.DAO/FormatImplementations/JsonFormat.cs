using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Contracts;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public class JsonFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger log;

        public JsonFormat(IVuelingLogger log)
        {
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public T Add(T entity)
        {
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Obtaining)
                    .Append(typeof(T).Name)
                    .ToString());
                var group = File.Exists(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json)) ? 
                    JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json))) : 
                    new List<T>();
                group.Add(entity);
                File.WriteAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json), JsonConvert.SerializeObject(group));
                return GetByGUID((Guid)typeof(T).GetProperty(DaoResources.guid).GetValue(entity));
            }
            catch (ArgumentNullException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public T GetByGUID(Guid guid)
        {
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Obtaining)
                    .Append(typeof(T).Name)
                    .Append(DaoResources.ByLiteral)
                    .Append(DaoResources.guid)
                    .Append(guid.ToString())
                    .ToString());
                if (!File.Exists(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json))) return default(T);
                var group = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json)));
                return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty(DaoResources.guid).GetValue(i) == guid);
            }
            catch (ArgumentNullException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Obtaining)
                    .Append(DaoResources.AllLiteral)
                    .Append(typeof(T).Name)
                    .ToString());
                return JsonConvert.DeserializeObject<List<T>>(
                    File.ReadAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json)));
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
