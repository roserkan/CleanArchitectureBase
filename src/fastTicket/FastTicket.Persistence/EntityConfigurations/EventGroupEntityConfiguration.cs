using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class EventGroupEntityConfiguration : EntityConfiguration<EventGroup>
{
    public override void Configure(EntityTypeBuilder<EventGroup> builder)
    {
        base.Configure(builder);

        builder.ToTable("EventGroups", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasMany(i => i.Events);
    }
}