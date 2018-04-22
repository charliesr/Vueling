using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public class RedisFormat<T> : IFormat<T> where T : IVuelingModelObject
    {
        private readonly IVuelingLogger _log = ConfigurationUtils.LoadLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly StackExchangeRedisCacheClient redis;
        public RedisFormat()
        {
            var redisConfig = new RedisConfiguration()
            {
                AbortOnConnectFail = true,
                KeyPrefix = "Charlio",
                Hosts = new RedisHost[] { new RedisHost() { Host = "192.168.99.100", Port = 6379 } },
                ConnectTimeout = 3000,
                Database = 0
            };
            var redis = new StackExchangeRedisCacheClient(new NewtonsoftSerializer(), redisConfig);
        }

        public T Add(T entity)
        {
            try
            {
                _log.Debug("Adding a student in Redis");
                redis.Add(GetNextKeyOrdinal(typeof(T).Name),entity);
                return GetByGUID(entity.Guid);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        private string GetNextKeyOrdinal(string entityName)
        {
            var keys = redis.SearchKeys("entityName" + "*");
            if (keys.Count() == 0) return entityName + "1";
            List<int> keysOrdinal = new List<int>();
            foreach (var key in keys)
            {
                keysOrdinal.Add(Convert.ToInt32(key.Remove(0, entityName.Count())));
            }
            keysOrdinal.Sort();
            return entityName + (keysOrdinal.Last() + 1).ToString();
        }

        public T GetByGUID(Guid guid)
        {
            try
            {
                _log.Debug(new StringBuilder("Acquiring ").Append(typeof(T).Name).Append(" from redis by guid").ToString());
                return GetAll().First(entity => entity.Guid == guid);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                _log.Debug(new StringBuilder("Acquiring all ").Append(typeof(T).Name).Append(" from redis by guid").ToString());
                return redis.GetAll<T>(redis.SearchKeys(typeof(T).Name)).Values.ToList();
            }

            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        public int DeleteByGuid(Guid guid)
        {
            try
            {
                _log.Debug(new StringBuilder("Deleting ").Append(typeof(T).Name).Append(" from redis by guid").ToString());
                var keyToDelete = redis.GetAll<T>(redis.SearchKeys(typeof(T).Name)).FirstOrDefault(kvp => kvp.Value.Guid == guid).Key;
                return redis.Remove(keyToDelete) ? 1 : 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
         
        }

        public DataTypeAccess GetFormat()
        {
            return DataTypeAccess.json;
        }

        public T GetById(int id)
        {
            try
            {
                _log.Debug(new StringBuilder("Acquiring ").Append(typeof(T).Name).Append(" from redis by id").ToString());
                return GetAll().First(entity => (int)typeof(T).GetProperty("id").GetValue(entity) == id);
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
                _log.Debug(new StringBuilder("Deleting ").Append(typeof(T).Name).Append(" from redis by id").ToString());
                var keyToDelete = redis.GetAll<T>(redis.SearchKeys(typeof(T).Name)).FirstOrDefault(kvp => (int)typeof(T).GetProperty("id").GetValue(kvp.Value) == id).Key;
                return redis.Remove(keyToDelete) ? 1 : 0;
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
                _log.Debug(new StringBuilder("Updating ").Append(typeof(T).Name).Append(" in redis").ToString());
                return Add(entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }

        }
    }
}
