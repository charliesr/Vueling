using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.Business.Logic
{
    public class CrudBL<T> : IReplaceBL<T>, ISaveBL<T>, IDropBL<T>, IReadBL<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISelect<T> _selectDao = new CrudDao<T>();
        private readonly IUpdate<T> _updateDAO = new CrudDao<T>();
        private readonly IDelete<T> _deleteDAO = new CrudDao<T>();
        private readonly IInsert<T> _insertDaoO = new CrudDao<T>();

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
