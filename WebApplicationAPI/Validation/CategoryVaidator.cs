using FluentValidation;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Validation
{
    public class CategoryVaidator : AbstractValidator<CreateCategoryDTO>
    {
        public CategoryVaidator()
        {
             RuleFor(n=>n.Name).NotEmpty().WithMessage("Shorkan");
             RuleFor(p => p.ParentId).Must(a => a.Length > 0).WithMessage("must be greater than zero");
        }
    }
}
