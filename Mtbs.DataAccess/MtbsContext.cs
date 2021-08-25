using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mtbs.Models;
using Mtbs.Models.Authentication;

namespace Mtbs.DataAccess
{
    public class MtbsContext : IdentityDbContext<ApplicationUser>
    {
        public MtbsContext(DbContextOptions<MtbsContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<MovieShow> MovieShows { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
