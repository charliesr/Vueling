using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public class JsonFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public JsonFormat()
        {
        }

        public T Insert(T entity)
        {
            try
            {
                var group = File.Exists(FileUtils.GetFilePath<T>(DataTypeAccess.json)) ? JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileUtils.GetFilePath<T>(DataTypeAccess.json))) : new List<T>();
                group.Add(entity);
                File.WriteAllText(FileUtils.GetFilePath<T>(DataTypeAccess.json), JsonConvert.SerializeObject(group));
                return Select((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
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

        public T Select(Guid guid)
        {
            if (!File.Exists(FileUtils.GetFilePath<T>(DataTypeAccess.json))) return default(T);
            var group = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileUtils.GetFilePath<T>(DataTypeAccess.json)));
            return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);
        }

        public List<T> SelectAll()
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileUtils.GetFilePath<T>(DataTypeAccess.json)));
        }
    }
}
