using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class PlanFeasibilityConfiguration : IEntityTypeConfiguration<PlanFeasibility>
{
    public void Configure(EntityTypeBuilder<PlanFeasibility> builder)
    {
        builder.ToTable("tb_plans_feasibility");
        
        builder.HasKey(pf => pf.Id);

        builder.Property(pf => pf.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(pf => pf.Id)
            .HasColumnName("id_plan_feasibility");

        builder.Property(pf => pf.OperatorPlanId)
            .HasColumnName("operator_plan_id")
            .IsRequired();

        builder.Property(pf => pf.AddressId)
            .HasColumnName("address_id")
            .IsRequired();
        
        /*__Relationships__*/
        builder.HasOne(pf => pf.OperatorPlan)
            .WithMany(op => op.PlanFeasibility)
            .HasForeignKey(pf => pf.OperatorPlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pf => pf.Address)
            .WithMany(pf => pf.PlanFeasibility)
            .HasForeignKey(f => f.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}