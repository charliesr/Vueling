using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public class TxtFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        public string Filename { get; set; }

        public TxtFormat()
        {
            Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + typeof(T).Name + ".txt";
        }

        public T Insert(T entity)
        {
            var content = string.Empty;
            var assembly = Assembly.Load("Vueling.Common.Logic");
            var type = assembly.GetType(typeof(T).FullName);
            var methodToString = type.GetMethod("ToString");
            object[] propValues = new object[type.GetProperties().Length];
            for (int i = 0; i < type.GetProperties().Length; i++)
            {
                propValues[i] = type.GetProperties()[i].GetValue(entity);
            }
            var classInstance = Activator.CreateInstance(type, propValues);
            content = (string)methodToString.Invoke(classInstance, null);
            File.AppendAllText(Filename, content + "\r\n");
            return Select((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
        }

        public T Select(Guid guid)
        {
            if (!File.Exists(Filename)) return default(T);
            var entityString = string.Empty;
            using (TextReader reader = new StreamReader(Filename))
            {
                StringBuilder word = new StringBuilder();
                while (reader.Peek() > -1)
                {
                    word.Append((char)reader.Read());
                    if ((char)reader.Peek() != ',') continue;
                    if(guid.ToString() == word.ToString())
                    {
                        entityString = guid.ToString() + reader.ReadLine();
                    } else {
                        reader.ReadLine();
                    }
                }
            }
            if (entityString == string.Empty) return default(T);
            var propValues = entityString.Split(',');
            var entity = Activator.CreateInstance(typeof(T), propValues);
            return (T)entity;
        }

        public List<T> SelectAll()
        {
            var groupOfEntity = new List<T>();
            using (TextReader reader = new StreamReader(Filename))
            {
                while (reader.Peek() > -1)
                {
                    var line = reader.ReadLine();
                    var propValues = line.Split(',');
                    var entity = Activator.CreateInstance(typeof(T), propValues);
                    groupOfEntity.Add((T)entity);

                }
            }
            return groupOfEntity;
        }
    }
}
