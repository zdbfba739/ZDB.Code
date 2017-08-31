using DapperExtensions.Mapper;
using DapperExtensions.Sql;

namespace ZDB.DBRepository.Mapping
{
    public class MappingConfig
    {
        public static void Initialize()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(MappingConfig).Assembly });
        }
    }
}
