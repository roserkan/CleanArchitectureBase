using Core.Security.Entities;
using FastTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FastTicket.Persistence.Contexts;

public class FastTicketDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";
    protected IConfiguration Configuration { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticator { get; set; }
    public DbSet<EventGroup> EventGroups { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticator { get; set; }
    public DbSet<Performance> Performances { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Venue> Venues { get; set; }

    public FastTicketDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Configuration.GetConnectionString("FastTicketConnectionString");
            optionsBuilder.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
