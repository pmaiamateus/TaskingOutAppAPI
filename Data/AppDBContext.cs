using TaskingOutAppAPI.Models;
using TaskingOutAppAPI.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace TaskingOutAppAPI.Data;

public class AppDBContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Checktask> Checktasks { get; set; }
    public DbSet<Checklist> Checklists { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new ChecktaskMap());
        modelBuilder.ApplyConfiguration(new ChecklistMap());
    }
}
