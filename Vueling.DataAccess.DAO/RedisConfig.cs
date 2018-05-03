using StackExchange.Redis;
using System;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO
{
    public static class RedisConfiguration
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;
        static RedisConfiguration()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { ConfigurationUtils.GetRedisEndpoint() }
            };
            LazyConnection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(configurationOptions));
        }
        public static ConnectionMultiplexer Connection => LazyConnection.Value;
    
        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
