using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Xml.Serialization;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public class XmlFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger log;

        public XmlFormat(IVuelingLogger log)
        {
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public T Add(T entity)
        {
            try
            {
                log.Debug("Añadiendo un/a nuevo/a " + typeof(T).Name);
                var xmlSerializer = new XmlSerializer(typeof(List<T>));
                var group = GetAll();
                using (Stream writer = File.Open(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.xml), FileMode.OpenOrCreate, FileAccess.Write))
                {
                    xmlSerializer.Serialize(writer, group);
                }
                return GetByGUID((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
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

        public T GetByGUID(Guid guid)
        {
            try
            {
                log.Debug("Select " + typeof(T).Name + "con Guid " + guid.ToString());
                if (File.Exists(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.xml)))
                {
                    var xmlSerializer = new XmlSerializer(typeof(List<T>));
                    List<T> group;
                    using (Stream reader = File.OpenRead(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.xml)))
                    {
                        group = (List<T>)xmlSerializer.Deserialize(reader);
                    }
                    return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);
                }
                return default(T);
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

        public List<T> GetAll()
        {
            try
            {
                log.Debug("Obtenemos todos los/las " + typeof(T).Name);
                if (File.Exists(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.xml)))
                {
                    using (Stream reader = File.OpenRead(ConfigurationUtils.GetFilePath<T>(DataTypeAccess.xml)))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(List<T>));
                        return (List<T>)xmlSerializer.Deserialize(reader);
                    }
                }
                return new List<T>();
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
