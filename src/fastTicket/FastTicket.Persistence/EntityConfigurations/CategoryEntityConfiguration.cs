using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class CategoryEntityConfiguration : EntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("Categories", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasMany(i => i.SubCategories);
        builder.HasMany(i => i.Events);
        builder.HasMany(i => i.EventGroups);
    }
}
