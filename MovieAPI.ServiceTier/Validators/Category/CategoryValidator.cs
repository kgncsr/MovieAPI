using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MovieAPI.ServiceTier.Validators.Category
{
    public class CategoryValidator : AbstractValidator<Entities.Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name boş geçilemez");
        }
    }
}
