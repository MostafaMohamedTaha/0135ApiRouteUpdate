using app.core.entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace app.repo.Data
{
	public class AppContext1 : DbContext
	{
		public AppContext1(DbContextOptions<AppContext1> opt) : base(opt)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.ApplyConfiguration(new ProductConfig()); //fluent api
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Brand> Brands { get; set; }
	}
}
