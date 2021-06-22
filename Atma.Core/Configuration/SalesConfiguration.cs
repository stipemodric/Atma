using Atma.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atma.DataAccess
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.ToTable(schema: "Sales", name: "Sales");
            builder.HasKey(p => p.Id);

            builder.Property(x => x.ArticleNumber);
            builder.Property(x => x.SalesPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Revenue)
                .HasColumnType("decimal(18,2)");
                //.HasComputedColumnSql("[SalesPrice]*[NumberSold]", true)
                //.ValueGeneratedOnAddOrUpdate();

            builder.HasQueryFilter(p => p.IsDeleted == false);
        }
    }
}
