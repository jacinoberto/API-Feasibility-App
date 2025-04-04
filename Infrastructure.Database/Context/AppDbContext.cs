﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<Address> Addresses { get; set; }
    public DbSet<ApiKey> ApiKeys { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyOperator> CompanyOperators { get; set; }
    public DbSet<Internet> Internets { get; set; }
    public DbSet<Operator> Operators { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<State> States { get; set; }
    
    public DbSet<ViabilityRule> ViabilityRules { get; set; }
    
    public DbSet<ViabilityState> ViabilityStates { get; set; }
    
    public DbSet<ViabilityCity> ViabilityCities { get; set; }
    
    
    
    public DbSet<FeasibilityType> FeasibilityTypes { get; set; }
    
    public DbSet<Feasibility> Feasibilities { get; set; }
    
    public DbSet<RegionConsultation> RegionConsultations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}