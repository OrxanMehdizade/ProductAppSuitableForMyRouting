namespace ProductAppSuitableForMyRouting.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
