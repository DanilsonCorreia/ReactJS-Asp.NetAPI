using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos
{
    public record MovieDto(int id, string Title, string Description, DateTime CreateDate, string Category);
    
}
