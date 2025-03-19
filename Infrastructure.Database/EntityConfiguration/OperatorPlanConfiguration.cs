using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class OperatorPlanConfiguration : IEntityTypeConfiguration<OperatorPlan>
{
    public void Configure(EntityTypeBuilder<OperatorPlan> builder)
    {
        builder.ToTable("tb_operators_plans");
        
        builder.HasKey(op => op.Id);
        
        builder.Property(op => op.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(op => op.Id)
            .HasColumnName("id_operator_plan");

        builder.Property(op => op.OperatorId)
            .HasColumnName("operator_id")
            .IsRequired();

        builder.Property(op => op.PlanId)
            .HasColumnName("plan_id")
            .IsRequired();
        
        /*__Relationships__*/
        builder.HasOne(op => op.Operator)
            .WithMany(o => o.OperatorPlans)
            .HasForeignKey(op => op.OperatorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(op => op.Plan)
            .WithMany(plan => plan.OperatorPlans)
            .HasForeignKey(op => op.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}