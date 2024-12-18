using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalAPI___JWT_Authentication.Entities;

namespace MinimalAPI___JWT_Authentication.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserName);
            builder.Property(x => x.UserName)
                   .HasColumnName("User Name")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(35)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(40)
                   .IsRequired();

            builder.HasData([ 
                                  new() {UserName = "Abdalkreem", Password = "12121221"},
                                  new() {UserName = "Islam", Password = "121571021"},
                                  new() {UserName = "Mohammed", Password = "129763221"}
                           ]);
        }
    }
}
