using Core.Security.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class EmailAuthenticatorEntityConfiguration : EntityConfiguration<EmailAuthenticator>
{
    public override void Configure(EntityTypeBuilder<EmailAuthenticator> builder)
    {
        base.Configure(builder);

        builder.ToTable("EmailAuthenticators", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(e => e.User);
    }
}
