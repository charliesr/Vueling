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
            Type type;
            try
            {
                var assembly = Assembly.Load("Vueling.Common.Logic");
                type = assembly.GetType(typeof(T).FullName);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            var methodToString = type.GetMethod("ToString");
            object[] propValues = new object[type.GetProperties().Length];
            for (int i = 0; i < type.GetProperties().Length; i++)
            {
                propValues[i] = type.GetProperties()[i].GetValue(entity);
            }
            try
            {
                var classInstance = Activator.CreateInstance(type, propValues);
                content = (string)methodToString.Invoke(classInstance, null);
                File.AppendAllText(Filename, content + "\r\n");
                return Select((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (NotSupportedException)
            {
                throw;
            }
            catch (TargetInvocationException)
            {
                throw;
            }

        }

        public T Select(Guid guid)
        {
            var entityString = string.Empty;
            try
            {
                using (TextReader reader = new StreamReader(Filename))
                {
                    StringBuilder word = new StringBuilder();
                    while (reader.Peek() > -1)
                    {
                        word.Append((char)reader.Read());
                        if ((char)reader.Peek() != ',') continue;
                        if (guid.ToString() == word.ToString())
                        {
                            entityString = guid.ToString() + reader.ReadLine();
                        }
                        else
                        {
                            reader.ReadLine();
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            if (entityString == string.Empty) return default(T);
            var propValues = entityString.Split(',');
            object entity;
            try
            {
                entity = Activator.CreateInstance(typeof(T), propValues);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (NotSupportedException)
            {
                throw;
            }
            catch (TargetInvocationException)
            {
                throw;
            }
            return (T)entity;
        }

        public List<T> SelectAll()
        {
            try
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
                    return groupOfEntity;
                }
            }
            catch (IOException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
