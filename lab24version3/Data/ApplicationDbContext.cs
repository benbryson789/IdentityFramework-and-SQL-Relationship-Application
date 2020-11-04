using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lab24version3.Models;

namespace lab24version3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<CheckedOutMovies> CheckedOutMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movies>(i =>
            {
                i.HasKey(k => k.Id);
                i.HasData(
             

                    new Movies { Id = 1, Title = "King Kong", Genre = "Action", Runtime = 60 },
                    new Movies { Id = 2, Title = "Designated Survivor", Genre = "Drama", Runtime = 180 },
                    new Movies { Id = 3, Title = "Angel Has Fallen", Genre = "Action", Runtime = 60 },
                    new Movies { Id = 4, Title = "Drive", Genre = "Action", Runtime = 60 },
                    new Movies { Id = 5, Title = "Lovebirds", Genre = "Romance", Runtime = 90 },
                    new Movies { Id = 6, Title = "Possession", Genre = "Romance", Runtime = 120 },

                    new Movies { Id = 7, Title = "Help", Genre = "Drama", Runtime = 60 },
                    new Movies { Id = 8, Title = "Firm", Genre = "Drama", Runtime = 80 },
                    new Movies { Id = 9, Title = "Burning", Genre = "Drama", Runtime = 60 },
                    new Movies { Id = 10, Title = "There Will Be Blood", Genre = "Drama", Runtime = 60 }

                );


            } );

            base.OnModelCreating(modelBuilder);

               
            
        }

        public DbSet<lab24version3.Models.MoviesModel> MoviesModel { get; set; }
    }
}
