using ContactApp.API.Interfaces;
using ContactApp.API.Model;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Services
{
    public class RedisService : IRedisService
    {
        private IDatabase _database;
        private readonly RedisCacheOptions _redisCacheOptions;
        private readonly CustomConnectionStringOptions _connectionStringOptions;
        private static ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IOptions<CustomConnectionStringOptions> options)
        {
            _connectionStringOptions = options.Value;
            _redisCacheOptions = new RedisCacheOptions
            {
                Configuration = _connectionStringOptions.Redis
            };
            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionStringOptions.Redis);
            _database = _connectionMultiplexer.GetDatabase();
        }

        public async Task<bool> Clear()
        {
            var endpoints = _connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                server.FlushAllDatabases();
            }
            return await Task.FromResult(true);
        }

        public bool Contains(object key)
        {
            return _database.KeyExists((RedisKey)key);
        }

        public T Get<T>(string key)
        {
            using (var redisCache = new RedisCache(_redisCacheOptions))
            {
                var valueStr = redisCache.GetString(key);
                if (!string.IsNullOrEmpty(valueStr))
                {
                    var data = JsonConvert.DeserializeObject<T>(valueStr);
                    return data;
                }
                return default(T);
            }
        }

        public void Remove(object key)
        {
            using (var redisCache = new RedisCache(_redisCacheOptions))
            {
                redisCache.Remove(key.ToString());
            }
        }

        public void Set<T>(string key, T model)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(120)
            };
            using (var redisCache = new RedisCache(_redisCacheOptions))
            {
                var valueStr = JsonConvert.SerializeObject(model);
                redisCache.SetString(key, valueStr);
            }
        }
    }
}
