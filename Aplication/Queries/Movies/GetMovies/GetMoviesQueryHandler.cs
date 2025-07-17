
using Contracts.Responses;
using Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Queries.Movies.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, GetMoviesRespose>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public GetMoviesQueryHandler(MoviesDbContext moviesDbContext) 
        {
            _moviesDbContext = moviesDbContext;
        }
        public async Task<GetMoviesRespose> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _moviesDbContext.Movies.ToListAsync(cancellationToken);
            return movies.Adapt<GetMoviesRespose>();
        }
    }
}
