using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capricorn.Cache.Redis
{
    public partial class RedisCache
    {
        /// <summary>
        /// 设置指定key得值(key存在则替换,不存在则创建)
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <param name="expiry">过期时间</param>
        public async Task<bool> SetStringAsync(string key, string value, int dbid, TimeSpan? expiry = null)
        {
            return await redisConnection.GetDatabase(dbid).StringSetAsync(key, value, expiry);
        }

        /// <summary>
        /// 设置多个key-value进入缓存
        /// </summary>
        /// <param name="values">key-value</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SetStringsAsync(KeyValuePair<RedisKey, RedisValue>[] values, int dbid)
        {         
            return await redisConnection.GetDatabase().StringSetAsync(values);
        }

        /// <summary>
        /// 获取指定key得值(key不存在返回null)
        /// </summary>
        /// <param name="key">键</param>
        public async Task<string> GetStringAsync(string key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).StringGetAsync(key);
        }

        /// <summary>
        /// 获取多个key值
        /// </summary>
        /// <param name="keys">键数组</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<string[]> StringGetsAsync(string[] keys, int dbid)
        {
            if (keys.Length == 0)
                return new string[] { };
            List<RedisKey> redisKeys = new List<RedisKey>();
            foreach (var key in keys)
            {
                redisKeys.Add(key);
            }
            RedisValue[] redisValues = await redisConnection.GetDatabase(dbid).StringGetAsync(redisKeys.ToArray());
            return redisValues.ToStringArray();
        }

        /// <summary>
        /// 追加字符串缓存(键不存在，则新增)
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        public async Task<bool> StringAppendAsync(string key, string value, int dbid)
        {
            var length = await redisConnection.GetDatabase(dbid).StringAppendAsync(key, value);
            return length > 0;
        }

        /// <summary>
        /// 获取指定key的值的字符串子串(键不存在，返回空字符串)
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="start">开始位置</param>
        /// <param name="end">结束位置</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<string> StringGetRangeAsync(string key, int start, int end, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).StringGetRangeAsync(key, start, end);
        }

        /// <summary>
        /// 获取指定key存储的字符串长度
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        public async Task<long> StringLengthAsync(string key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).StringLengthAsync(key);
        }


    }
}
