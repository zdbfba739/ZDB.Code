using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ZDB.Redis
{
    /// <summary>
    /// 设置Redis值成功后的回调
    /// </summary>
    public delegate void SetRedisCallback<T>(T t);

    /// <summary>
    /// 数据缓存
    /// </summary>
    public static class Redis
    {
        static ConnectionMultiplexer _redis;
        static readonly object RedisLock = new object();

        [ThreadStatic]
        static IDatabase _db;

        private static string GetConnStr()
        {
            var conn = ConfigurationManager.AppSettings["redis_connection_str"];
            return conn;
        }

        /// <summary>
        /// 连接Redis
        /// </summary>
        static ConnectionMultiplexer GetRedis()
        {
            if (_redis != null && _redis.IsConnected)
            {
                return _redis;
            }

            lock (RedisLock)
            {
                if (_redis != null && _redis.IsConnected)
                {
                    return _redis;
                }
                try
                {
                    string redisConnStr = GetConnStr();
                    _redis = ConnectionMultiplexer.Connect(redisConnStr);
                }
                catch (Exception)
                {
                    _redis = null;
                }
                return _redis;
            }
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        static IDatabase GetDatabase()
        {
            _redis = GetRedis();

            if (_redis != null)
            {
                if (_db != null)
                {
                    return _db;
                }
                _db = _redis.GetDatabase();

                return _db;
            }
            return null;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        public static T Get<T>(string key, T defaultValue = default(T))
        {
            var db = GetDatabase();

            if (db != null && db.KeyExists(key))
            {
                var value = db.StringGet(key);

                if (value.HasValue)
                {
                    return JsonConvert.DeserializeObject<T>(value);
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// 采用管道技术批量获取redis中的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="keys">关键字</param>
        /// <returns></returns>
        public static Dictionary<string, T> Get<T>(List<string> keys)
        {
            var result = new Dictionary<string, T>(keys.Count);
            var db = GetDatabase();
            var batch = db.CreateBatch();
            var tasks = new Dictionary<string, Task<RedisValue>>(keys.Count);

            keys.ForEach(c =>
            {
                tasks.Add(c, batch.StringGetAsync(c));
            });
            batch.Execute();

            foreach (var item in tasks)
            {
                if (item.Value.Result.HasValue)
                {
                    result.Add(item.Key, JsonConvert.DeserializeObject<T>(item.Value.Result));
                }
            }
            return result;
        }

        /// <summary>
        /// 根据关键字，批量从缓存中读取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyEnumerable"></param>
        /// <returns></returns>
        public static List<T> Get<T>(IEnumerable<string> keyEnumerable)
        {
            var keys = keyEnumerable.ToList();
            var result = new List<T>(keys.Count);
            var db = GetDatabase();
            var batch = db.CreateBatch();
            var tasks = new Dictionary<string, Task<RedisValue>>(keys.Count);

            keys.ForEach(c =>
            {
                tasks.Add(c, batch.StringGetAsync(c));
            });
            batch.Execute();

            result.AddRange(from item in tasks where item.Value.Result.HasValue select JsonConvert.DeserializeObject<T>(item.Value.Result));

            return result;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        public static void Set<T>(string key, T value, TimeSpan? expiry = null, SetRedisCallback<T> callback = null)
        {
            var db = GetDatabase();

            db?.StringSetAsync(key, JsonConvert.SerializeObject(value), expiry);

            callback?.Invoke(value);
        }

        /// <summary>
        /// 采用管道批量向Redis中添加数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">数据集合</param>
        /// <param name="expiry">过期时间</param>
        /// <param name="callback">回调函数</param>
        public static void Set<T>(Dictionary<string, T> data, TimeSpan? expiry = null, SetRedisCallback<Dictionary<string, T>> callback = null)
        {
            var db = GetDatabase();
            var batch = db.CreateBatch();

            var rows = 0;
            foreach (var item in data)
            {
                rows++;
                if (rows % 1000 == 0)
                {
                    batch.Execute();
                    //数量超过一千，重新开启一个管道
                    batch = db.CreateBatch();
                }
                batch?.StringSetAsync(item.Key, JsonConvert.SerializeObject(item.Value), expiry);
            }
            batch.Execute();

            callback?.Invoke(data);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        public static void Del(string key)
        {
            var db = GetDatabase();

            db?.KeyDeleteAsync(key);
        }
    }
}
