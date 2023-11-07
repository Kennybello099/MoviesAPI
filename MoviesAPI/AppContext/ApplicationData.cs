using Microsoft.EntityFrameworkCore;
using MoviesAPI.Model;
using System.Reflection.Emit;

namespace MoviesAPI.Migration
{
    public class ApplicationData : DbContext
    {
        public ApplicationData(DbContextOptions<ApplicationData> options) : base(options)
        {

        }
        public DbSet<Movies>? Movies { get; set; }
        public DbSet<Genre>? Genre { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movies>()
                .Property(p => p.TicketPrice)
                .HasColumnType("decimal(18,4)");

         

        }


    }
}
