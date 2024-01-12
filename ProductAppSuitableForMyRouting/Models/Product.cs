using ProductAppSuitableForMyRouting.Helpers;
using ProductAppSuitableForMyRouting.Models.ViewModels;

namespace ProductAppSuitableForMyRouting.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public static async Task<Product> ProductViewModelAsync(ProductAddViewModel viewModel)
        {
            return new Product
            {
                ImageUrl = await UploadFileHelper.UploadFile(viewModel.ImageUrl),
                Title = viewModel.Title,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Price = viewModel.Price,
            };
        }
    }
}
