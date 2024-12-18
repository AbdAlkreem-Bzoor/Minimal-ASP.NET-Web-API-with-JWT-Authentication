using Microsoft.EntityFrameworkCore;
using MinimalAPI___JWT_Authentication.Entities;

namespace MinimalAPI___JWT_Authentication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    var configuration = new ConfigurationBuilder()
        //                        .AddJsonFile("appsettings.json")
        //                        .Build();
        //    var connection = configuration["Databases:ConnectionStrings:SqlServer"];

        //    optionsBuilder.UseSqlServer(connection);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
