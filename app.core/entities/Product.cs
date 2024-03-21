namespace app.core.entities
{
	public class Product : Base
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string PictureUrl { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

		#region brand on to many

		public int BrandId { get; set; }
		public Brand Brand { get; set; }
		#endregion

		#region type one to many
		public int TypeId { get; set; }
		public ProductType ProductType { get; set; }
		#endregion
	}
}
