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

namespace Vueling.DataAccess.DAO
{
    public class XmlFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public T Insert(T entity)
        {
            try
            {
                _log.Debug("Añadiendo un/a nuevo/a " + typeof(T).Name);
                var xmlSerializer = new XmlSerializer(typeof(List<T>));
                var group = SelectAll();
                using (Stream writer = File.Open(RepositoryUtils.GetFilePath<T>(DataTypeAccess.xml), FileMode.OpenOrCreate, FileAccess.Write))
                {
                    xmlSerializer.Serialize(writer, group);
                }
                return Select((Guid)typeof(T).GetProperty("Guid").GetValue(entity));
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

        public T Select(Guid guid)
        {
            try
            {
                _log.Debug("Select " + typeof(T).Name + "con Guid " + guid.ToString());
                if (File.Exists(RepositoryUtils.GetFilePath<T>(DataTypeAccess.xml)))
                {
                    var xmlSerializer = new XmlSerializer(typeof(List<T>));
                    List<T> group;
                    using (Stream reader = File.OpenRead(RepositoryUtils.GetFilePath<T>(DataTypeAccess.xml)))
                    {
                        group = (List<T>)xmlSerializer.Deserialize(reader);
                    }
                    return group.FirstOrDefault(i => (Guid)typeof(T).GetProperty("Guid").GetValue(i) == guid);
                }
                return default(T);
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

        public List<T> SelectAll()
        {
            try
            {
                _log.Debug("Obtenemos todos los/las " + typeof(T).Name);
                if (File.Exists(RepositoryUtils.GetFilePath<T>(DataTypeAccess.xml)))
                {
                    using (Stream reader = File.OpenRead(RepositoryUtils.GetFilePath<T>(DataTypeAccess.xml)))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(List<T>));
                        return (List<T>)xmlSerializer.Deserialize(reader);
                    }
                }
                return new List<T>();
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
    }
}
