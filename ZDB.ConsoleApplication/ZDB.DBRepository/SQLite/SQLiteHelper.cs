using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ZDB.DBRepository.SQLite
{
    public class SQLiteHelper : IDisposable
    {
        public string ConnectionString { get; private set; } = "";

        public bool InitSuccess { get; private set; }

        private bool _isModelData { get; set; }

        public string ProdID { get; private set; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        private SQLiteConnection _Conn;

        /// <summary>
        /// 事物
        /// </summary>
        private SQLiteTransaction _Transaction;

        /// <summary>
        /// 初始化帮助类
        /// </summary>
        /// <param name="prodid">产品ID</param>
        /// <param name="isCreateData">不存在时是否创建SQLite库</param>
        public SQLiteHelper(string prodid, bool isCreateData = false)
        {
            _isModelData = isCreateData;
            var password = "sjb@v3sQl";
            var dbfile = @"D:\Web\Md.Api.Down\pkg\17\0826\170826000001" + "\\db\\ProdSku.db";

            ProdID = prodid;

            if (!File.Exists(dbfile))
            {
                if (isCreateData)
                {
                    var dir = new DirectoryInfo(@"D:\Web\Md.Api.Down\pkg\17\0826\170826000001" + "\\db");
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }
                    SQLiteConnection.CreateFile(dbfile);
                }
                else
                {
                    InitSuccess = false;
                    return;
                }
            }

            InitSuccess = true;
            ConnectionString = $@"Data Source={dbfile};Initial Catalog=sqlite;Integrated Security=True;Password={password};Max Pool Size=100;";
            _Conn = new SQLiteConnection(ConnectionString);
        }

        public void BeginTran()
        {
            //连接处于关闭状态打开
            if(_Conn?.State== ConnectionState.Closed)
                _Conn.Open();
            if (_Transaction == null)
                _Conn.BeginTransaction();
        }

        public void Commit()
        {
            _Transaction?.Commit();
        }

        public void Rollback()
        {
            _Transaction?.Rollback();
        }

        #region 执行SQL语句

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        public int Execute(string sql)
        {
            return Execute(sql, null);
        }
        /// <summary>
        /// 执行指定连接的数据库操作
        /// </summary>
        public int Execute(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd,sql, parameters);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
        }
        #endregion

        #region 获取数据集

        /// <summary>
        /// 通过SQL语句返回数据集
        /// </summary>
        public DataTable Query(string sql)
        {
            return Query(sql, null);
        }
        
        /// <summary>
        /// 用其他连接获取带参数的SQL数据集合
        /// </summary>
        public DataTable Query(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd,sql, parameters);
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                    }

                    if (ds.Tables.Count > 0) return ds.Tables[0];
                    return null;
                }
            }
        }
        #endregion

        #region 获取数据的第一行第一列

        /// <summary>
        /// 通过SQL语句返回第一行第一列
        /// </summary>
        public object Single( string sql)
        {
            return Single(sql, null);
        }
        /// <summary>
        /// 通过带参数的SQL语句返回第一行第一列
        /// </summary>
        public object Single( string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                PrepareCommand(cmd, sql, parameters);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return obj;
            }
        }
        #endregion

        #region 私有函数

        /// <summary>
        /// 准备参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="trans"></param>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        void PrepareCommand(SQLiteCommand cmd,string sql, SQLiteParameter[] parameters)
        {
            if (_Conn.State != ConnectionState.Open)
                _Conn.Open();
            cmd.Connection = _Conn;
            cmd.CommandText = sql;
            if (_Transaction != null)
                cmd.Transaction = _Transaction;
            cmd.CommandType = CommandType.Text;
            if (parameters != null)
            {
                foreach (SQLiteParameter parm in parameters)
                {
                    if (parm != null)
                    {
                        if (parm.Value == null)
                        {
                            parm.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parm);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsExists(string tableName)
        {
            string sql = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='" + tableName + "'";
            int result = int.Parse(Single(sql).ToString());
            return result > 0;
        }

        /// <summary>
        /// 判断表中是否存在列
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public bool IsExists(string tableName, string columnName)
        {
            string sql = $"select COUNT(*)  from sqlite_master where name = '{tableName}' and sql like '%{columnName}%'";
            int result = int.Parse(Single(sql).ToString());
            return result > 0;
        }

        public bool Update(DataTable dt)
        {
            if (_Conn.State != ConnectionState.Open)
                _Conn.Open();
            var cmd = _Conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {dt.TableName}";
            var adapter = new SQLiteDataAdapter(cmd);
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.Update(dt);
            return true;
        }

        public bool SaveDataTable(DataTable dt, string sql = "")
        {
            if (_Conn.State != ConnectionState.Open)
                _Conn.Open();
            var cmd = _Conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {dt.TableName} ";
            var adapter = new SQLiteDataAdapter(cmd);
            new SQLiteCommandBuilder(adapter);
            adapter.Update(dt);
            return true;
        }

        public void Dispose()
        {
            if (_Conn?.State == ConnectionState.Open)
                _Conn.Close();

            _Transaction?.Dispose();

            _Conn?.Dispose();
        }

        public string ConvertTo36(int val)
        {
            const string x36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = "";
            while (val >= 36)
            {
                result = x36[val % 36] + result;
                val /= 36;
            }
            if (val >= 0) result = x36[val] + result;
            return result;
        }

        /// <summary>
        /// 36进制转换成10进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int ConvertTo10(string str)
        {
            const string X36 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = 0;
            var len = str.Length;
            for (var i = len; i > 0; i--)
            {
                result += X36.IndexOf(str[i - 1]) * Convert.ToInt32(Math.Pow(36, len - i));
            }
            return result;
        }
    }
}
