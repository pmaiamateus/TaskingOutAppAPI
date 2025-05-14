using TaskingOutAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskingOutAppAPI.Data.Mappings;

public class ChecktaskMap : IEntityTypeConfiguration<Checktask>
{
    public void Configure(EntityTypeBuilder<Checktask> builder)
    {
        builder.ToTable("Checktasks");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Index)
            .HasColumnName("Index")
            .HasColumnType("int");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(150);

        builder.Property(x => x.IsChecked)
            .IsRequired()
            .HasColumnName("IsChecked")
            .HasColumnType("bit");

        builder.Property(x => x.IsHidden)
            .IsRequired()
            .HasColumnName("IsHidden")
            .HasColumnType("bit");
    }
}
