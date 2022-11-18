using Core.Security.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class RefreshTokenEntityConfiguration : EntityConfiguration<RefreshToken>
{
    public override void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        base.Configure(builder);

        builder.ToTable("RefreshTokens", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.User);
    }
}






