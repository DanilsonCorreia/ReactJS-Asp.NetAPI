using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Aplication.Commands.Movies.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public CreateMovieCommandHandler(MoviesDbContext moviesDbContext) 
        { 
            _moviesDbContext = moviesDbContext;
        }
        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Category = request.Category,
                Description = request.Description,
                CreateDate = DateTime.Now.ToUniversalTime()
            };

            await _moviesDbContext.Movies.AddAsync(movie, cancellationToken);
            await _moviesDbContext.SaveChangesAsync(cancellationToken);
            return movie.Id;

        }
    }
}
