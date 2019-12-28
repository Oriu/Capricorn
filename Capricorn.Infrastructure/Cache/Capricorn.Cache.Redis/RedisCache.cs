using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capricorn.Cache.Redis
{
    public class RedisCache
    {
        private static ConnectionMultiplexer redisConnection { get; }
        static RedisCache()
        {
            redisConnection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public async Task SetStringAsync(string key, string value)
        {
            await redisConnection.GetDatabase().StringSetAsync(key, value, TimeSpan.FromSeconds(20));
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键</param>
        public async Task<string> GetStringAsync(string key)
        {
            return await redisConnection.GetDatabase().StringGetAsync(key); 
        }

    }
}
