using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testing_net_api.Models;

namespace testing_net_api.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        

        public DbSet<Book> Books { get; set; }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
