using app.core.entities;
using System.Text.Json;

namespace app.repo.Data
{
	public static class AppSeeding
	{
		public static async Task SeedAsync(AppContext1 context)
		{
			#region brand
			if (!context.Brands.Any())
			{
				var brandsData = File.ReadAllText("../app.repo/Data/seeding/brands.json");
				var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
				if (brands is not null && brands.Count > 0)
				{

					foreach (var brand in brands)
					{
						await context.Set<Brand>().AddAsync(brand);
					}
					await context.SaveChangesAsync();
				}
			}
			#endregion

			#region type
			if (!context.ProductTypes.Any())
			{
				var typesData = File.ReadAllText("../app.repo/Data/seeding/types.json");
				var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
				if (types is not null && types.Count > 0)
				{
					foreach (var type in types)
					{
						await context.Set<ProductType>().AddAsync(type);
					}
					await context.SaveChangesAsync();
				}
			}
			#endregion

			#region product
			if (!context.Products.Any())
			{
				var productsData = File.ReadAllText("../app.repo/Data/seeding/products.json");
				var products = JsonSerializer.Deserialize<List<Product>>(productsData);
				if (products is not null && products.Count > 0)
				{

					foreach (var product in products)
					{
						await context.Set<Product>().AddAsync(product);
					}
					await context.SaveChangesAsync();
				}
			}
			#endregion
		}
	}
}
