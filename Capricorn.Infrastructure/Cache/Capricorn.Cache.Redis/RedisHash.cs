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
        /// 设置key的hash对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="hashEntry">存储的hash对象</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task HashSetAsync(RedisKey key,HashEntry[] hashEntry,int dbid)
        {
            await redisConnection.GetDatabase(dbid).HashSetAsync(key, hashEntry);
        }

        /// <summary>
        /// 查看哈希表 key 中，指定的字段是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="field">hash对象中的字段</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> HashExistsAsync(RedisKey key, RedisValue field, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashExistsAsync(key, field);
        }

        /// <summary>
        /// 删除key的hash表中一个字段
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="field">hash对象中的字段</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> HashDeleteAsync(RedisKey key, RedisValue field, int dbid)
        {
            bool isExist = await HashDeleteAsync(key, field, dbid);
            if (!isExist)
                return true;
            return await redisConnection.GetDatabase(dbid).HashDeleteAsync(key, field);
        }

        /// <summary>
        /// 删除key的hash表中多个字段
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="fields">hash对象中的多个字段</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> HashDeleteAsync(RedisKey key, RedisValue[] fields, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashDeleteAsync(key, fields);
        }

        /// <summary>
        /// 获取存储在哈希表中指定字段的值。
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="field">hash对象中的字段</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue> HashGetAsync(RedisKey key, RedisValue field, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashGetAsync(key, field);
        }

        /// <summary>
        /// 获取存储在哈希表中指定字段的值。
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="fields">hash对象中的字段</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue[]> HashGetAsync(RedisKey key, RedisValue[] fields, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashGetAsync(key, fields);
        }

        /// <summary>
        /// 获取在哈希表中指定 key 的所有字段和值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<HashEntry[]> HashGetAllAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashGetAllAsync(key);
        }

        /// <summary>
        /// 获取在哈希表中指定 key 的所有字段
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue[]> HashKeysAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashKeysAsync(key);
        }

        /// <summary>
        /// 获取在哈希表中指定 key 的字段数量
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> HashLengthAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashLengthAsync(key);
        }

        /// <summary>
        /// 将哈希表 key 中的字段 field 的值设为 value
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="field">字段</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync(RedisKey key, RedisValue field,RedisValue value,int dbid)
        {
            return await redisConnection.GetDatabase(dbid).HashSetAsync(key, field, value);
        }
    }
}
