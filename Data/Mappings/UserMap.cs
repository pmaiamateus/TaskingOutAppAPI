using TaskingOutAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskingOutAppAPI.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Password)
            .HasColumnName("Password")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.Property(x => x.EmailConfirmed)
            .HasColumnName("EmailConfirmed")
            .HasColumnType("bit");

        builder.Property(x => x.Role)
            .HasColumnName("Role")
            .HasColumnType("varchar")
            .HasMaxLength(10);

        builder.Property(x => x.Membership)
            .HasColumnName("Membership")
            .HasColumnType("varchar")
            .HasMaxLength(10);
    }
}