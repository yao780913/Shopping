using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Users;

namespace Shopping.Infrastructure.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure (EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName);

        builder.Property(u => u.LastName);

        builder.Property(u => u.Email);

        builder.Property("_passwordHash")
            .HasColumnName("PasswordHash");
    }
}