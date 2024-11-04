using FitnessTracker.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(
            userId => userId.Value.ToString(),
            userId => new UserId());
        builder.Property(u => u.Email).HasConversion(
            email => email.Value,
            email => Email.Create(email).Value);
        builder.ComplexProperty(u => u.Name);
    }
}