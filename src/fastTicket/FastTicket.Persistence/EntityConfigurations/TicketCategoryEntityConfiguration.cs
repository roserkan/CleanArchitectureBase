using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class TicketCategoryEntityConfiguration : EntityConfiguration<TicketCategory>
{
    public override void Configure(EntityTypeBuilder<TicketCategory> builder)
    {
        base.Configure(builder);

        builder.ToTable("TicketCategories", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Ticket);
    }
}

