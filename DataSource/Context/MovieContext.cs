using Microsoft.EntityFrameworkCore;
using SFF.Datasource.Model;

namespace SFF.Datasource.Context
{
    public class SFFContext : DbContext
    {
        public SFFContext(DbContextOptions<SFFContext> options) : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<MovieTrivia> MovieTrivias { get; set; }
    }
}