using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    DbSet<Address> Addresses { get; set; }
    DbSet<ApiKey> ApiKeys { get; set; }
    DbSet<Company> Companies { get; set; }
    DbSet<CompanyOperator> CompanyOperators { get; set; }
    DbSet<Internet> Internets { get; set; }
    DbSet<Operator> Operators { get; set; }
    DbSet<OperatorPlan> OperatorPlans { get; set; }
    DbSet<Plan> Plans { get; set; }
    DbSet<PlanFeasibility> PlanFeasibilities { get; set; }
    DbSet<State> States { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}