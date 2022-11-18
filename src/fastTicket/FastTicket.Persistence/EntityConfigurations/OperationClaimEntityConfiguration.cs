using Core.Security.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class OperationClaimEntityConfiguration : EntityConfiguration<OperationClaim>
{
    public override void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        base.Configure(builder);

        builder.ToTable("OperationClaims", FastTicketDbContext.DEFAULT_SCHEMA);
    }
}









