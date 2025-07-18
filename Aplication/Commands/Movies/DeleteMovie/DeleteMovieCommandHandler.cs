using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Commands.Movies.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public DeleteMovieCommandHandler(MoviesDbContext moviesDbContext) 
        {
            _moviesDbContext = moviesDbContext;
        }  
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToDelete = await _moviesDbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (movieToDelete is null) 
            {
                throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {request.Id} was not found in database");
            }

            _moviesDbContext.Movies.Remove(movieToDelete);
            await _moviesDbContext.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
