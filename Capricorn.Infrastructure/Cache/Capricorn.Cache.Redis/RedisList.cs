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
        /// 向列表左端添加一个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns>列表长度</returns>
        public async Task ListLeftPushAsync(RedisKey key, RedisValue value, int dbid)
        {
            await redisConnection.GetDatabase(dbid).ListLeftPushAsync(key, value);
        }

        /// <summary>
        /// 向列表左端添加多个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="values">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns>列表长度</returns>
        public async Task ListLeftPushAsync(RedisKey key, RedisValue[] values, int dbid)
        {
            await redisConnection.GetDatabase(dbid).ListLeftPushAsync(key, values);
        }

        /// <summary>
        /// 向列表右端添加一个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns>列表长度</returns>
        public async Task ListRightPushAsync(RedisKey key, RedisValue value, int dbid)
        {
            await redisConnection.GetDatabase(dbid).ListRightPushAsync(key, value);
        }

        /// <summary>
        /// 向列表右端添加多个元素
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="values">值</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns>列表长度</returns>
        public async Task ListRightPushAsync(RedisKey key, RedisValue[] values, int dbid)
        {
            await redisConnection.GetDatabase(dbid).ListRightPushAsync(key, values);
        }

        /// <summary>
        /// 移出并获取列表左侧的第一个元素， 如果列表没有元素会阻塞列表直到等待超时或发现可弹出元素为止。
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue> ListLeftPopAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).ListLeftPopAsync(key);
        }

        /// <summary>
        /// 移出并获取列表右侧的第一个元素， 如果列表没有元素会阻塞列表直到等待超时或发现可弹出元素为止。
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue> ListRightPopAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).ListRightPopAsync(key);
        }

        /// <summary>
        /// 获取列表长度
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<long> ListLengthAsync(RedisKey key, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).ListLengthAsync(key);
        }

        /// <summary>
        /// 获取列表中指定索引的数据
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="index">索引</param>
        /// <param name="dbid">redis数据库id</param>
        /// <returns></returns>
        public async Task<RedisValue> List(RedisKey key, long index, int dbid)
        {
            return await redisConnection.GetDatabase(dbid).ListGetByIndexAsync(key, index);
        }
    }
}
