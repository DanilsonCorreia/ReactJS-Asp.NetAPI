using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Responses;
using MediatR;

namespace Aplication.Queries.Movies.GetMovieById
{
    public record GetMovieByIdQuery(int Id) : IRequest<GetMovieByIdResponse>;
 
}
