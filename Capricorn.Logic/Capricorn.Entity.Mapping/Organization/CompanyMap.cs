using Capricorn.Logic.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace STI.Application.Mapping
{
    /// <summary>
    /// 描 述：机构管理
    /// </summary>
    public class CompanyMap : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.Property(o => o.F_EnCode).HasMaxLength(12);
            builder.Property(o => o.F_CompanyId).HasMaxLength(12);
        }
    }
}
