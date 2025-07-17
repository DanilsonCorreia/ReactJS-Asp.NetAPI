using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Responses;
using Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Queries.Movies.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public GetMovieByIdQueryHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }
        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _moviesDbContext.Movies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (movie is null)
            {
                throw new Exception();
            }

            return movie.Adapt<GetMovieByIdResponse>();

        }
    }
}
