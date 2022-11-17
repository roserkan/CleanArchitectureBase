using Core.Security.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class OtpAuthenticatorEntityConfiguration : EntityConfiguration<OtpAuthenticator>
{
    public override void Configure(EntityTypeBuilder<OtpAuthenticator> builder)
    {
        base.Configure(builder);

        builder.ToTable("OtpAuthenticator", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.User);
    }
}






