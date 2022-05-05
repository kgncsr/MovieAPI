using FluentValidation;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Validators.Movies
{
    public class SaveMovieValidator : AbstractValidator<MovieDto>
    {
        public SaveMovieValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Lütfen film ismini giriniz.").MaximumLength(100)
                .MinimumLength(3).WithMessage("Lütfen film adını 3 ile 100 karakter arasında giriniz.");
        }
    }
}
