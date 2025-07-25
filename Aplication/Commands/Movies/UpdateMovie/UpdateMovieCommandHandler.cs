﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Commands.Movies.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public UpdateMovieCommandHandler(MoviesDbContext moviesDbContext) 
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _moviesDbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (movieToUpdate is null)
            {
                throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {request.Id} was not found in database");
            }

            movieToUpdate.Title = request.Title;
            movieToUpdate.Description = request.Description;
            movieToUpdate.Category = request.Category;

            _moviesDbContext.Movies.Update(movieToUpdate);
            await _moviesDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
