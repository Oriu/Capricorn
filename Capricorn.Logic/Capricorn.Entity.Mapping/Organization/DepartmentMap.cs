using Capricorn.Logic.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STI.Application.Mapping
{
    /// <summary>
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentMap : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            
        }
    }
}
