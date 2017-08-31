using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZDB.DBRepository.Entity
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("UserInfo")]
    public class UserInfoEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
    }
}
