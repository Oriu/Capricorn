using Capricorn.Util;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capricorn.Cache.Redis
{
    public partial class RedisCache
    {
        private static ConnectionMultiplexer redisConnection { get; }
        static RedisCache()
        {
            redisConnection = ConnectionMultiplexer.Connect(Config.Get("ConnectionStrings:Redis:ConnectionString"));
        }

        /// <summary>
        /// 缓存中是否存在键
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> KeyExistsAsync(string key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).KeyExistsAsync(key);
        }

        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> KeyDeleteAsync(string key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).KeyDeleteAsync(key);
        }

        /// <summary>
        /// 设置key的过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public async Task<bool> KeyExpireAsync(string key, int dbid, TimeSpan expiry)
        {
            return await redisConnection.GetDatabase(dbid).KeyExpireAsync(key, expiry);
        }

        /// <summary>
        /// 移除key的过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> KeyPersistAsync(string key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).KeyPersistAsync(key);
        }

        /// <summary>
        /// 修改key
        /// </summary>
        /// <param name="oldKey">旧键</param>
        /// <param name="newKey">新键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> KeyRenameAsync(string oldKey, string newKey, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).KeyRenameAsync(oldKey, newKey);
        }

        /// <summary>
        /// 返回key中存贮的数据类型
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisType> KeyTypeAsync(string key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).KeyTypeAsync(key);
        }

        /// <summary>
        /// 将key移至另一个redis数据库
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="olddbid">老redis数据库id</param>
        /// <param name="newdbid">新redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> KeyMoveAsync(string key, int olddbid, int newdbid)
        {
            return await redisConnection.GetDatabase(olddbid).KeyMoveAsync(key, newdbid);
        }
    }
}
