using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vueling.DataAccess.DAO
{
    public class XmlFormat<T> : IFormat<T> where T : class
    {
        public string Filename { get; set; }

        public XmlFormat()
        {
            Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + typeof(T).Name + ".xml";
        }

        public T Insert(T entity)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            var group = new List<T>();
            if (File.Exists(Filename))
            {
                using (Stream reader = File.OpenRead(Filename))
                {
                    group = (List<T>)xmlSerializer.Deserialize(reader);
                }
            }
            group.Add(entity);
            using (Stream writer = File.Open(Filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(writer, group);
            }

            return Select((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
        }

        public T Select(Guid guid)
        {
            if (File.Exists(Filename))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<T>));
                List<T> group;
                using (Stream reader = File.OpenRead(Filename))
                {
                    group = (List<T>)xmlSerializer.Deserialize(reader);
                }
                return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);
            }
            return null;
        }
    }
}
