using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskingOutAppAPI.Models;

namespace TaskingOutAppAPI.Data.Mappings;

public class ChecktaskMap : IEntityTypeConfiguration<Checktask>
{
    public void Configure(EntityTypeBuilder<Checktask> builder)
    {
        throw new NotImplementedException();
    }
}
