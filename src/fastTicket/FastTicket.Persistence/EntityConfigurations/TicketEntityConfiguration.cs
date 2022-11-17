using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class TicketEntityConfiguration : EntityConfiguration<Ticket>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);

        builder.ToTable("Tickets", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Event);
        builder.HasMany(i => i.TicketCategories);
    }
}