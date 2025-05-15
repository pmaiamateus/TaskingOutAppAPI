using TaskingOutAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskingOutAppAPI.Data.Mappings;

public class ChecklistMap : IEntityTypeConfiguration<Checklist>
{
    public void Configure(EntityTypeBuilder<Checklist> builder)
    {
        builder.ToTable("CheckLists");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar")
            .HasMaxLength(300);

        builder.HasMany(x => x.CheckTasks)
            .WithOne(x => x.Checklist);
    }
}
