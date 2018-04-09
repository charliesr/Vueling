using Newtonsoft.Json;
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
    public class CrudDAO<T> : ISelectDAO<T>, IInsertDAO<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IFormat<T> _format;

        public CrudDAO(DataTypeAccess tipo)
        {
            ChangeFormat(tipo);

        }

        public void ChangeFormat(DataTypeAccess dataTypeAccess)
        {
            _format = FormatFactory<T>.GetFormat(dataTypeAccess);
        }

        public T Add(T entity)
        {
            try
            {
                _log.Debug("Añadiendo " + typeof(T).Name);
                _format.Insert(entity);
                return _format.Select(entity.Guid);
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

        public List<T> GetAll(DataTypeAccess dataTypeAccess)
        {
            try
            {
                _log.Debug("Obtenemos todos " + typeof(T).ToString());
                switch (dataTypeAccess)
                {
                    case DataTypeAccess.json:
                        var foundJsonSingleton = Assembly.Load("Vueling.DataAccess.DAO.Singletons").GetTypes().FirstOrDefault(t => t.Name.Contains(typeof(T).Name) && t.Name.Contains("Json"));
                        if (foundJsonSingleton == null) return _format.SelectAll();
                        var jsonSingletonInstance = foundJsonSingleton.GetMethod("GetInstance", BindingFlags.Static).Invoke(null, null);
                        return (List<T>)jsonSingletonInstance.GetType().GetMethod("GetAll").Invoke(null, null);
                    case DataTypeAccess.xml:
                        var foundXmlSingleton = Assembly.Load("Vueling.DataAccess.DAO.Singletons").GetTypes().FirstOrDefault(t => t.Name.Contains(typeof(T).Name) && t.Name.Contains("Xml"));
                        if (foundXmlSingleton == null) return _format.SelectAll();
                        var xmlSingletonInstance = foundXmlSingleton.GetMethod("GetInstance", BindingFlags.Static).Invoke(null, null);
                        return (List<T>)xmlSingletonInstance.GetType().GetMethod("GetAll").Invoke(null, null);
                    default:
                        return _format.SelectAll();
                }
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
