using DapperExtensions.Mapper;
using ZDB.DBRepository.Entity;

namespace ZDB.DBRepository.Mapping
{
    public sealed class UserDBMapper : ClassMapper<UserInfoEntity>
    {
        public UserDBMapper()
        {
            Table("UserInfo");
            Map(x => x.ID).Column("ID").Key(KeyType.Identity);
            AutoMap();
        }
    }
}
