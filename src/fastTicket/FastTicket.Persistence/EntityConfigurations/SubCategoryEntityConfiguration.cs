using FastTicket.Domain.Entities;
using FastTicket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTicket.Persistence.EntityConfigurations;

public class SubCategoryEntityConfiguration : EntityConfiguration<SubCategory>
{
    public override void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        base.Configure(builder);

        builder.ToTable("SubCategories", FastTicketDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Category);
    }
}



