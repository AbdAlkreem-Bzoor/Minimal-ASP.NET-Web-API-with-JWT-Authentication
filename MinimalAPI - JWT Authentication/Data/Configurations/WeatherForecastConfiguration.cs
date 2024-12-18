using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalAPI___JWT_Authentication.Entities;

namespace MinimalAPI___JWT_Authentication.Data.Configurations
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasNoKey();

            builder.Property(x => x.Date)
                   .HasColumnType("DATE")
                   .IsRequired();

            builder.Property(x => x.Summary)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(350);

            builder.Property(x => x.TemperatureC)
                   .HasColumnType("DECIMAL(5, 2)")
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Ignore(x => x.TemperatureF);
        }
    }
}

