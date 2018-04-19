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

        public CrudDao()
        {
            ChangeFormat(EnumsHelper.StringToDataTypeAccess(ConfigurationUtils.LoadFormat()));
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
                return _format.Add(entity);
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
                return _format.GetAll();
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

        public int DeleteByGuid(Guid guid)
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

        public T Update(T entity)
        {
            try
            {
                _log.Debug("Update");
                return _format.Update(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                _log.Debug("Get by ID");
                return _format.GetById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public int DeleteById(int id)
        {
            try
            {
                return _format.DeleteById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
