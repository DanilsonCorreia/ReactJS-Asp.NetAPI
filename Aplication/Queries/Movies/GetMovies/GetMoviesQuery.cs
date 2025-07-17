using Contracts.Responses;
using MediatR;

namespace Aplication.Queries.Movies.GetMovies
{
    public record GetMoviesQuery() : IRequest<GetMoviesRespose>;
}
