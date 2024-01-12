using FluentValidation;

namespace ProductAppSuitableForMyRouting.Models.ViewModels.FluentValidations
{
    public class AddCategoryFluentValidator : AbstractValidator<AddCategoryViewModel>
    {
        public AddCategoryFluentValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

            RuleFor(c => c.ImageUrlCategory)
                .NotNull().WithMessage("Image is required.")
                .Must(checkImage).WithMessage("Invalid image file.");
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
