using Capricorn.Logic.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STI.Application.Mapping
{
    /// <summary>
    /// 描 述：用户数据库实体映射
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            
        }
    }
}
