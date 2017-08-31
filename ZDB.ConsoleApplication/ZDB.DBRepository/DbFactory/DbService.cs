using System;
using System.Collections.Generic;
using Dapper;

namespace ZDB.DBRepository.DbFactory
{
    public static class DbService
    {
        /// <summary>
        /// 开启事务
        /// </summary>
        public static void BeginTransaction()
        {
            DbFactory.Instance.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public static void CommitTransaction()
        {
            DbFactory.Instance.CommitTransaction();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public static void RollbackTransaction(Exception ex)
        {
            DbFactory.Instance.RollbackTransaction(ex);
        }

        public static dynamic Insert<T>(T t, int userId) where T : class
        {
            return BaseRepository<T>.Instance.Insert(t);
        }

        public static void Insert<T>(IEnumerable<T> tList, int userId) where T : class
        {
            BaseRepository<T>.Instance.Insert(tList);
        }

        /// <summary>
        /// 批量插入非BaseEntity的表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public static void Insert<T>(IEnumerable<T> tList) where T : class
        {
            BaseRepository<T>.Instance.Insert(tList);
        }

        public static bool Update<T>(T t, int userId) where T : class
        {
            return BaseRepository<T>.Instance.Update(t);
        }

        public static void Update<T>(IEnumerable<T> tList, int userId) where T : class
        {
            BaseRepository<T>.Instance.Update(tList);
        }

        public static T GetByID<T>(int id) where T : class
        {
            return BaseRepository<T>.Instance.GetByID(id);
        }

        public static T GetByID<T>(string id) where T : class
        {
            return BaseRepository<T>.Instance.GetByID(id);
        }

        /// <summary>
        /// 获取第一个值
        /// </summary>
        public static SingleType GetSingle<SingleType>(string sql, object paramValues = null)
        {
            return BaseRepository<dynamic>.Instance.GetSingle<SingleType>(sql, paramValues);
        }

        /// <summary>
        /// 假删
        /// </summary>
        public static bool Delete<T>(T t, int userId) where T : class
        {
            return BaseRepository<T>.Instance.Update(t);
        }

        /// <summary>
        /// 假删
        /// </summary>
        public static void Delete<T>(IEnumerable<T> tList, int userId) where T : class
        {
            BaseRepository<T>.Instance.Update(tList);
        }

        /// <summary>
        /// 真实删除
        /// </summary>
        public static bool DeleteDbRow<T>(T t) where T : class
        {
            return BaseRepository<T>.Instance.DeleteDbRow(t);
        }

        /// <summary>
        /// 真实删除
        /// </summary>
        public static void DeleteDbRow<T>(IEnumerable<T> tList) where T : class
        {
            BaseRepository<T>.Instance.DeleteDbRow(tList);
        }

        public static IEnumerable<T> GetAll<T>() where T : class
        {
            return BaseRepository<T>.Instance.GetAll();
        }

        public static IEnumerable<T> GetList<T>(string sql, object paramValues = null) where T : class
        {
            return BaseRepository<T>.Instance.GetList(sql, paramValues);
        }

        /// <summary>
        /// 执行sql 返回影响行数（非万不得已，不准使用该方法）
        /// </summary>
        public static int Execute<T>(string sql, object paramValues = null) where T : class
        {
            return BaseRepository<T>.Instance.Execute(sql, paramValues);
        }

        /// <summary>
        /// 返回多个结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static SqlMapper.GridReader QueryMultiple(string sql, object paramValues = null)
        {
            return DbFactory.Instance.MyConnection.QueryMultiple(sql, paramValues);
        }
        
    }
}
