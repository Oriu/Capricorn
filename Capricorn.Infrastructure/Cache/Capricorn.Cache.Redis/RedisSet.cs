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
        /// 向集合添加一个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SetAddAsync(RedisKey key, RedisValue value, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetAddAsync(key, value);
        }

        /// <summary>
        /// 向集合添加多个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="values">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns>成功添加个数</returns>
        public async Task<long> SetAddAsync(RedisKey key, RedisValue[] values, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetAddAsync(key, values);
        }

        /// <summary>
        /// 在集合中删除一个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SetRemoveAsync(RedisKey key, RedisValue value, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetRemoveAsync(key, value);
        }

        /// <summary>
        /// 在集合中删除多个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="values">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns>成功删除个数</returns>
        public async Task<long> SetRemoveAsync(RedisKey key, RedisValue[] values, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetRemoveAsync(key, values);
        }

        /// <summary>
        /// 获取集合长度
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SetLengthAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetLengthAsync(key);
        }

        /// <summary>
        /// 对两个集合进行交集、差集、并集操作
        /// </summary>
        /// <param name="first">第一个集合键</param>
        /// <param name="second">第二个集合键</param>
        /// <param name="operation">交集、差集、并集操作</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue[]> SetCombineAsync(RedisKey first, RedisKey second, SetOperation operation, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetCombineAsync(operation, first, second);
        }

        /// <summary>
        /// 对多个集合进行交集、差集、并集操作
        /// </summary>
        /// <param name="keys">多个集合键</param>
        /// <param name="operation">交集、差集、并集操作</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue[]> SetCombineAsync(RedisKey[] keys, SetOperation operation, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetCombineAsync(operation, keys);
        }

        /// <summary>
        /// 对两个集合进行交集、差集、并集操作,并保存到另一个集合中
        /// </summary>
        /// <param name="first">第一个集合键</param>
        /// <param name="second">第二个集合键</param>
        /// <param name="operation">交集、差集、并集操作</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SetCombineAndStoreAsync(RedisKey destination, RedisKey first, RedisKey second, SetOperation operation, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetCombineAndStoreAsync(operation, destination, first, second);
        }

        /// <summary>
        /// 对多个集合进行交集、差集、并集操作,并保存到另一个集合中
        /// </summary>
        /// <param name="keys">多个集合键</param>
        /// <param name="operation">交集、差集、并集操作</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SetCombineAndStoreAsync(RedisKey destination, RedisKey[] keys, SetOperation operation, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetCombineAndStoreAsync(operation, destination, keys);
        }

        /// <summary>
        /// 集合中是否有指定元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SetContainsAsync(RedisKey key, RedisValue value, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetContainsAsync(key, value);
        }

        /// <summary>
        /// 将指定元素从一个集合转移到另一个集合
        /// </summary>
        /// <param name="source">原集合键</param>
        /// <param name="destination">目标集合键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SetMoveAsync(RedisKey source, RedisKey destination, RedisValue value, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetMoveAsync(source, destination, value);
        }

        /// <summary>
        /// 返回集合中的所有元素
        /// </summary>
        /// <param name="key">集合键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue[]> SetMembersAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetMembersAsync(key);
        }

        /// <summary>
        /// 随机返回指定数量的集合内元素
        /// </summary>
        /// <param name="key">集合键</param>
        /// <param name="count">返回数量</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue[]> SetRandomMembersAsync(RedisKey key, long count, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetRandomMembersAsync(key, count);
        }

        /// <summary>
        /// 随机移除并返回一个元素
        /// </summary>
        /// <param name="key">集合键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue> SetPopAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SetPopAsync(key);
        }
    }
}
