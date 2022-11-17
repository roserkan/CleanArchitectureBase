using Core.Security.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class UserOperationClaimEntityConfiguration : EntityConfiguration<UserOperationClaim>
{
    public override void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        base.Configure(builder);

        builder.ToTable("UserOperationClaims", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.User);
        builder.HasOne(i => i.OperationClaim);
    }
}

