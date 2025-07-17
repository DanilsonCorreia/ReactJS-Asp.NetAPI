using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;

namespace Aplication.Queries.Movies.GetMovieById
{
    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
    {
        public GetMovieByIdQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage($"{nameof(Movie.Id)} cannot be empty");
        }
    }
}
