using FluentValidation;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Validation
{
    public class ProductValidator : AbstractValidator<CreateProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(a=>a.Title).NotEmpty().WithMessage("Product name is requierd")
                .MaximumLength(5).WithMessage("Max length is 5");
            RuleFor(d => d.Description).NotEmpty().WithMessage("dessription is requiered");
        }
    }
}
