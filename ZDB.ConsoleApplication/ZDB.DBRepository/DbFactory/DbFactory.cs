using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using ZDB.DBRepository.Mapping;

namespace ZDB.DBRepository.DbFactory
{
    public class DbFactory
    {
        [ThreadStatic]
        static DbFactory _instance;
        static readonly string connectionString;
        IDbConnection _conn;
        IDbTransaction _transaction;
        int _transactionCount;
        bool _closeFlag;

        static DbFactory()
        {
            //创建MySql数据库连接对象
            connectionString = ConfigurationManager.ConnectionStrings["mysql_connection_str"].ConnectionString;

            //初始化映射
            MappingConfig.Initialize();
        }

        private DbFactory()
        {
            _conn = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            _conn.ConnectionString = connectionString;
        }

        /// <summary>
        /// 静态化访问对象
        /// </summary>
        public static DbFactory Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = new DbFactory();
                return _instance;
            }
        }

        /// <summary>
        /// mysql数据库的连接对象
        /// </summary>
        public IDbConnection MyConnection => _conn;

        /// <summary>
        /// 数据库事务对象
        /// </summary>
        public IDbTransaction MyTransaction => _transaction;

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            if (_transactionCount == 0)
            {
                if (_closeFlag = (ConnectionState.Closed == _conn.State))
                    _conn.Open();

                _transaction = _conn.BeginTransaction();
            }
            _transactionCount++;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            _transactionCount--;

            if (_transactionCount == 0)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;

                if (_closeFlag)
                    _conn.Close();
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction(Exception ex = null)
        {
            if (_transactionCount <= 0)
                return;

            _transactionCount = 0;
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;

            if (_closeFlag)
                _conn.Close();

            if (ex != null)
                throw ex;
        }

        public void Dispose()
        {
            _conn.Dispose();
        }
    }
}
