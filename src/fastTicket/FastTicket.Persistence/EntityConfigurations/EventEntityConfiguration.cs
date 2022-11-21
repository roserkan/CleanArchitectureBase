using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class EventEntityConfiguration : EntityConfiguration<Event>
{
    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        base.Configure(builder);

        builder.ToTable("Events", FastTicketDbContext.DEFAULT_SCHEMA);
        builder.Property(i => i.EventGroupId).IsRequired(false);


        builder.HasOne(i => i.Venue);
        builder.HasOne(i => i.EventGroup).WithMany(i => i.Events).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(i => i.Performance);
        builder.HasMany(i => i.Tickets);
        builder.HasOne(i => i.Category);
    }
}
