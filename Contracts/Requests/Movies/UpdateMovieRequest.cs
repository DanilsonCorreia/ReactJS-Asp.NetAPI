using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Movies
{
    public record UpdateMovieRequest(int Id, string Title, string Description, string Category);
    
}
