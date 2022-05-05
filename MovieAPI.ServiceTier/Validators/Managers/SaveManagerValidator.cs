using FluentValidation;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Validators.Managers
{
    public class SaveManagerValidator : AbstractValidator<SaveManagerDto>
    {
        public SaveManagerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Manager name boş geçilemez");
        }
    }
}
