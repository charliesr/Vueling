using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO;

namespace Vueling.Business.Logic
{
    public class CrudBL<T> : IReadBL<T>, ISaveBL<T>, IDropBL<T>, IReplaceBL<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISelectDao<T> _selectDao = new CrudDao<T>(EnumsHelper.StringToDataTypeAccess(ConfigurationUtils.LoadFormat()));
        private readonly IUpdateDao<T> _updateDAO = new CrudDao<T>(EnumsHelper.StringToDataTypeAccess(ConfigurationUtils.LoadFormat()));
        private readonly IDeleteDao<T> _deleteDAO = new CrudDao<T>(EnumsHelper.StringToDataTypeAccess(ConfigurationUtils.LoadFormat()));
        private readonly IInsertDao<T> _insertDaoO = new CrudDao<T>(EnumsHelper.StringToDataTypeAccess(ConfigurationUtils.LoadFormat()));

        public T Add(T entity)
        {
            try
            {
                _log.Debug("Llamado método add del BL");
                return _insertDaoO.Add(entity);
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
            catch (OverflowException ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                _log.Debug("Llamado método GetAll del BL");
                return _selectDao.GetAll();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public void ChangeFormat(DataTypeAccess dataTypeAccess)
        {
            _log.Debug("Cambiamos el formato de la factory (formato del archivo a) " + dataTypeAccess.ToString());
            _selectDao.ChangeFormat(dataTypeAccess);
            _updateDAO.ChangeFormat(dataTypeAccess);
            _deleteDAO.ChangeFormat(dataTypeAccess);
            _insertDaoO.ChangeFormat(dataTypeAccess);
        }

        public T GetByGUID(Guid guid)
        {
            try
            {
                return _selectDao.GetByGUID(guid);

            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public int DropByGUID(Guid guid)
        {
            try
            {
                return _deleteDAO.DeleteByGuid(guid);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public T Replace(T entity)
        {
            try
            {
                return _updateDAO.Update(entity);
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
                return _selectDao.GetById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public int DropById(int id)
        {
            try
            {
                return _deleteDAO.DeleteById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
