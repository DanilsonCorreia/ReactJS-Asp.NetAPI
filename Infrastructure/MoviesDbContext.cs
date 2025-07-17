using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options) { }



    }
}
