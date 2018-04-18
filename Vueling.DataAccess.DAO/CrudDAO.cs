using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Formats;

namespace Vueling.DataAccess.DAO
{
    public class CrudDao<T> : IDeleteDao<T>, ISelectDao<T>, IUpdateDao<T>, IInsertDao<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IFormat<T> _format;

        public CrudDao(DataTypeAccess tipo)
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
                _format.Add(entity);
                return _format.GetByGUID(entity.Guid);
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

        public List<T> GetAll()
        {
            try
            {
                _log.Debug("Obtenemos todos " + typeof(T).ToString());
                var typeString = new StringBuilder(_format.GetFormat().ToString().First().ToString().ToUpper()).Append(_format.GetFormat().ToString().Substring(1)).ToString();
                switch (_format.GetFormat())
                {
                    case DataTypeAccess.sql:
                    case DataTypeAccess.txt:
                        return _format.GetAll();
                    default:
                        var foundSingleton = Assembly.Load("Vueling.DataAccess.DAO.Singletons").GetTypes().FirstOrDefault(t => t.Name.Contains(typeof(T).Name) && t.Name.Contains(typeString));
                        if (foundSingleton == null) return _format.GetAll();
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

        public T GetByGUID(Guid guid)
        {
            try
            {
                _log.Debug(new StringBuilder("Pedimos el ").Append(typeof(T).Name).Append(" con guid ").Append(guid.ToString()));
                return _format.GetByGUID(guid);
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

        public bool DeleteByGuid(Guid guid)
        {
            try
            {
                return _format.DeleteByGuid(guid);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public bool Update(Guid guid, T entity)
        {
            try
            {
                return _format.Update(guid, entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
