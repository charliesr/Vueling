using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public class TxtFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger log;

        public TxtFormat(IVuelingLogger log)
        {
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public T Add(T entity)
        {
            var content = string.Empty;
            Type type;
            try
            {
                log.Debug("Añadiendo un/a nuevo/a " + typeof(T).Name);
                var assembly = Assembly.Load("Vueling.Common.Logic");
                type = assembly.GetType(typeof(T).FullName);
                var methodToString = type.GetMethod("ToString");
                object[] propValues = new object[type.GetProperties().Length];
                for (int i = 0; i < type.GetProperties().Length; i++)
                {
                    propValues[i] = type.GetProperties()[i].GetValue(entity);
                }
                var classInstance = Activator.CreateInstance(type, propValues);
                content = (string)methodToString.Invoke(classInstance, null);
                File.AppendAllText(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.txt), content + "\r\n");
                return GetByGUID((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
            }
            catch (ArgumentException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (TargetInvocationException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (FileNotFoundException ex)
            {
                log.Error(ex);
                throw;
            }

        }

        public T GetByGUID(Guid guid)
        {
            try
            {
                log.Debug("Select " + typeof(T).Name + "con Guid " + guid.ToString());
                var entityString = string.Empty;
                using (TextReader reader = new StreamReader(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.txt)))
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
                if (entityString == string.Empty) return default(T);
                var propValues = entityString.Split(',');
                object entity;
                entity = Activator.CreateInstance(typeof(T), propValues);
                return (T)entity;
            }
            catch (ArgumentException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (TargetInvocationException ex)
            {
                log.Error(ex);
                throw;
            }

        }

        public List<T> GetAll()
        {
            try
            {
                log.Debug("Obtenemos todos los/las " + typeof(T).Name);
                var groupOfEntity = new List<T>();
                using (TextReader reader = new StreamReader(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.txt)))
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

        public DataTypeAccess GetFormat()
        {
            return DataTypeAccess.json;
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
