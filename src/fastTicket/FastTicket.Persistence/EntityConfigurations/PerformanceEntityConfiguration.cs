using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class PerformanceEntityConfiguration : EntityConfiguration<Performance>
{
    public override void Configure(EntityTypeBuilder<Performance> builder)
    {
        base.Configure(builder);

        builder.ToTable("Performances", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Event);
    }
}



