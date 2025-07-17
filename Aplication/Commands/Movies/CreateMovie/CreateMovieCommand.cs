using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aplication.Commands.Movies.CreateMovie
{
    public record CreateMovieCommand(string Title, string Description, string Category) : IRequest<int>;

}
