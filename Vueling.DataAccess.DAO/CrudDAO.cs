using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Contracts;

namespace Vueling.DataAccess.DAO
{
    public class CrudDao<T> : IDelete<T>, ISelect<T>, IUpdate<T>, IInsert<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger log;
        private readonly IFormat<T> format;

        public CrudDao(IIndex<DataTypeAccess, IFormat<T>> formats, IVuelingLogger log)
        {
            this.format = formats[ConfigurationUtils.LoadFormat()];
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public T Add(T entity)
        {
            T entityResult;
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Adding)
                    .Append(typeof(T).Name)
                    .Append(DaoResources.inLiteral)
                    .Append(DaoResources.DaoLayer)
                    .ToString());
                entityResult = format.Add(entity);
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

            return entityResult;
        }

        public List<T> GetAll()
        {
            List<T> entitiesResult;
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Obtaining)
                    .Append(DaoResources.AllLiteral)
                    .Append(typeof(T).Name)
                    .Append(DaoResources.inLiteral)
                    .Append(DaoResources.DaoLayer).ToString());
                entitiesResult = format.GetAll();
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

            return entitiesResult;
        }

        public T GetByGUID(Guid guid)
        {
            T entityResult;
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Obtaining)
                    .Append(typeof(T).Name)
                    .Append(DaoResources.ByLiteral)
                    .Append(DaoResources.guid).ToString());
                entityResult = format.GetByGUID(guid);
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
            return entityResult;
        }

        public int DeleteByGuid(Guid guid)
        {
            var result = 0;
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Deleting)
                    .Append(typeof(T).Name)
                    .Append(DaoResources.ByLiteral)
                    .Append(DaoResources.guid)
                    .ToString());
                result = format.DeleteByGuid(guid);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return result;
        }

        public T Update(T entity)
        {
            T entityUpdated;
            try
            {
                log.Debug(
                    new StringBuilder(DaoResources.Update)
                    .Append(typeof(T))
                    .ToString());
                entityUpdated =  format.Update(entity);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
            return entityUpdated;
        }

        public T GetById(int id)
        {
            try
            {
                log.Debug(new StringBuilder(DaoResources.Obtaining)
                    .Append(DaoResources.ByLiteral)
                    .Append(DaoResources.id).ToString());
                log.Debug("Get by ID");
                return format.GetById(id);
            }
            catch (NotImplementedException ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public int DeleteById(int id)
        {
            try
            {
                log.Debug("Delete by ID");
                return format.DeleteById(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }
    }
}
;