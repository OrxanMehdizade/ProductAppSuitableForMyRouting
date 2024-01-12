using FluentValidation;

namespace ProductAppSuitableForMyRouting.Models.ViewModels.FluentValidations
{
    public class ProductUpdateFluentValidator : AbstractValidator<ProductUpdateViewModel>
    {
        public ProductUpdateFluentValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");



            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price is required.")
                .Must(check).WithMessage("Price must be a numeric value.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(p => p.ImageUrl)
                .NotNull().WithMessage("Image is required.")
                .Must(checkImage).WithMessage("Invalid image file.");
        }
        private bool check(decimal value)
        {
            return true;
        }

        private bool checkImage(IFormFile formFile)
        {
            if (formFile == null)
            {
                return false;
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var file = System.IO.Path.GetExtension(formFile.FileName);
            return allowedExtensions.Contains(file, StringComparer.OrdinalIgnoreCase);
        }
    }
}
