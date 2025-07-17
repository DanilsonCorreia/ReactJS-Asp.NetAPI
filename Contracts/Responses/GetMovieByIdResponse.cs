using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Dtos;

namespace Contracts.Responses
{
    public record GetMovieByIdResponse(MovieDto MovieDto);
   
}
