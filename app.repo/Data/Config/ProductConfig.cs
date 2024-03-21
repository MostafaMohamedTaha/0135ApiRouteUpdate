using app.core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.repo.Data.Config
{
	internal class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
			builder.Property(x => x.BrandId).HasColumnType("int");
			builder.Property(x => x.TypeId).HasColumnType("int");
			builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);
			builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(x => x.TypeId);
		}
	}
}
