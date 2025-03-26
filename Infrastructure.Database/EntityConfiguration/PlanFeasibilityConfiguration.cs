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

        builder.Property(pf => pf.PlanId)
            .HasColumnName("plan_id")
            .IsRequired();

        builder.Property(pf => pf.PlanId)
            .HasColumnName("feasibility_id")
            .IsRequired();

        builder.Property(pf => pf.FeasibilityId)
            .HasColumnName("feasibility_type_id")
            .IsRequired();
        
        /*__Relationships__*/
        builder.HasOne(pf => pf.Plan)
            .WithMany(p => p.PlanFeasibilities)
            .HasForeignKey(pf => pf.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(pf => pf.Feasibility)
            .WithMany(f => f.PlanFeasibilities)
            .HasForeignKey(pf => pf.FeasibilityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pf => pf.FeasibilityType)
            .WithMany(ft => ft.PlanFeasibilities)
            .HasForeignKey(f => f.FeasibilityTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}