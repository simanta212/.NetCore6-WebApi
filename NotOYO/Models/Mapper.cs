using Microsoft.EntityFrameworkCore;

namespace NotOYO.Models
{
    public class Mapper : DbContext
    {
        public Mapper(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = 2,
                        Name = "India",
                        ShortName = "Ind",
                    }
                );
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
