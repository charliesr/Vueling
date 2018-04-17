using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.DAO
{
    public class JsonFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public T Add(T entity)
        {
            try
            {
                _log.Debug("Añadiendo un/a nuevo/a " + typeof(T).Name);
                var group = File.Exists(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json)) ? JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json))) : new List<T>();
                group.Add(entity);
                File.WriteAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json), JsonConvert.SerializeObject(group));
                return GetByGUID((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public T GetByGUID(Guid guid)
        {
            try
            {
                _log.Debug("Select " + typeof(T).Name + "con Guid " + guid.ToString());
                if (!File.Exists(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json))) return default(T);
                var group = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json)));
                return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                _log.Debug("Obtenemos todos los/las " + typeof(T).Name);
                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.json)));
            }
            catch (FileNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error(ex);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public DataTypeAccess GetFormat()
        {
            return DataTypeAccess.json;
        }

        public bool Update(Guid guid, T entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
