using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aplication.Commands.Movies.DeleteMovie
{
    public record DeleteMovieCommand(int Id) : IRequest<int>;
    
}
