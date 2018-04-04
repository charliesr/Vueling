using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public class JsonFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        public string Filename { get; set; }

        public JsonFormat()
        {
            Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + typeof(T).Name + ".json";
        }

        public T Insert(T entity)
        {
            var group = File.Exists(Filename) ? JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Filename)) : new List<T>();
            group.Add(entity);
            File.WriteAllText(Filename, JsonConvert.SerializeObject(group));
            return Select((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
        }

        public T Select(Guid guid)
        {
            if (!File.Exists(Filename)) return default(T);
            var group = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Filename));
            return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);
        }

        public List<T> SelectAll()
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Filename));
        }
    }
}
