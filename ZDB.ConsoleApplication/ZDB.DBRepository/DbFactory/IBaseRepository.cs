using System.Collections.Generic;

namespace ZDB.DBRepository.DbFactory
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        dynamic Insert(T t);

        /// <summary>
        /// 批量增加实体
        /// </summary>
        void Insert(IEnumerable<T> tList);

        /// <summary>
        /// 更新实体：全部字段更新
        /// </summary>
        bool Update(T t);

        /// <summary>
        /// 批量更新实体：每个实体全部字段更新
        /// </summary>
        void Update(IEnumerable<T> tList);

        /// <summary>
        /// 删除单个实体：删除数据表记录
        /// </summary>
        bool DeleteDbRow(T t);

        /// <summary>
        /// 批量删除实体：删除数据表记录
        /// </summary>
        void DeleteDbRow(IEnumerable<T> tList);

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        T GetByID<KeyType>(KeyType id);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// 根据Sql查询实体列表
        /// </summary>
        IEnumerable<T> GetList(string sql, object paramValues = null);
        
    }
}
