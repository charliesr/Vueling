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
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.DAO
{
    public class CrudDAO<T> : ISelectDAO<T>, IInsertDAO<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
                var typeString = string.Concat(dataTypeAccess.ToString().Substring(0, 1).ToUpper(), dataTypeAccess.ToString().Substring(1));
                switch (dataTypeAccess)
                {
                    case DataTypeAccess.sqlDB:
                    case DataTypeAccess.txt:
                        return _format.SelectAll();
                    default:
                        var foundSingleton = Assembly.Load("Vueling.DataAccess.DAO.Singletons").GetTypes().FirstOrDefault(t => t.Name.Contains(typeof(T).Name) && t.Name.Contains(typeString));
                        if (foundSingleton == null) return _format.SelectAll();
                        var singletonInstance = foundSingleton.GetMethod("GetInstance", BindingFlags.Static).Invoke(null, null);
                        return (List<T>)singletonInstance.GetType().GetMethod("GetAll").Invoke(null, null);
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
