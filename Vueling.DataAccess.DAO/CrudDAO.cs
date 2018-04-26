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
using Vueling.DataAccess.DAO.FormatImplementations;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO
{
    public class CrudDao<T> : IDelete<T>, ISelect<T>, IUpdate<T>, IInsert<T> , ISelectStudentWebApi<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger log;
        private readonly IFormat<T> format;
        private readonly IConnection<T> webApiInitCache;

        public CrudDao(IIndex<DataTypeAccess, IFormat<T>> formats, IVuelingLogger log, IConnection<T> webApiInitCache)
        {
            this.format = formats[ConfigurationUtils.LoadFormat()];
            this.webApiInitCache = webApiInitCache;
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);

        }

        public T Add(T entity)
        {
            try
            {
                log.Debug("Añadiendo " + typeof(T).Name);
                return format.Add(entity);
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
                log.Debug("Obtenemos todos " + typeof(T).ToString());
                return format.GetAll();
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
                log.Debug(new StringBuilder("Pedimos el ").Append(typeof(T).Name).Append(" con guid ").Append(guid.ToString()));
                return format.GetByGUID(guid);
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

        public int DeleteByGuid(Guid guid)
        {
            try
            {
                return format.DeleteByGuid(guid);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                log.Debug("Update");
                return format.Update(entity);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
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

        public Student InitStudent()
        {
            return this.webApiInitCache.InitCache();
        }
    }
}
;