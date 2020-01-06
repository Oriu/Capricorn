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
        /// 增加一个有序集合元素,元素已存在则更新分数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="score">元素分数</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SortedSetAddAsync(RedisKey key, RedisValue value, double score, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetAddAsync(key, value, score);
        }

        /// <summary>
        /// 增加多个有序集合元素,元素已存在则更新分数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="values">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SortedSetAddAsync(RedisKey key, SortedSetEntry[] values, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetAddAsync(key, values);
        }

        /// <summary>
        /// 获取有序集合元素数量
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SortedSetLengthAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetLengthAsync(key);
        }

        /// <summary>
        /// 增加有序集合中指定元素的分数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="member">值</param>
        /// <param name="increment">增加分数</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<double> SortedSetIncrementAsync(RedisKey key, RedisValue member, double increment, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetIncrementAsync(key, member, increment);
        }

        /// <summary>
        /// 将两个有序集合进行交集、并集、差集操作，并保存到新的有序集合
        /// </summary>
        /// <param name="operation">交集、差集、并集操作</param>
        /// <param name="destination">新的有序集合</param>
        /// <param name="first">第一个有序集合</param>
        /// <param name="second">第二个有序集合</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SortedSetCombineAndStoreAsync(SetOperation operation,RedisKey destination, RedisKey first, RedisKey second, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetCombineAndStoreAsync(operation, destination, first, second);
        }

        /// <summary>
        /// 删除有序集合中指定值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<bool> SortedSetLengthByValueAsync(RedisKey key, RedisValue value, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetRemoveAsync(key, value);
        }

        /// <summary>
        /// 删除有序集合指定索引区间内的元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="min">最小索引</param>
        /// <param name="max">最大索引</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> SortedSetRemoveRangeByRankAsync(RedisKey key, long min, long max, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).SortedSetRemoveRangeByRankAsync(key, min, max);
        }
    }
}
