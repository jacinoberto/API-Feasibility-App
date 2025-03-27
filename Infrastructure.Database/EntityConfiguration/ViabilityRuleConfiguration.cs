using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class ViabilityRuleConfiguration : IEntityTypeConfiguration<ViabilityRule>
{
    public void Configure(EntityTypeBuilder<ViabilityRule> builder)
    {
        builder.ToTable("tb_viability_rules");

        builder.HasKey(vr => vr.Id);

        builder.Property(vr => vr.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(vr => vr.Id)
            .HasColumnName("id_viability_rule");

        builder.Property(vr => vr.PlanId)
            .HasColumnName("plan_id")
            .IsRequired();

        builder.Property(vr => vr.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

        builder.Property(vr => vr.FeasibilityTypeId)
            .HasColumnName("feasibility_type_id")
            .IsRequired();

        builder.Property(vr => vr.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(true)
            .IsRequired();
        
        /*__Index__*/
        builder.HasIndex(vr =>
            new { vr.CompanyId, vr.PlanId, vr.FeasibilityTypeId });
        
        /*_Relationships_*/
        builder.HasOne(vr => vr.Plan)
            .WithMany(p => p.ViabilityRules)
            .HasForeignKey(vr => vr.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(vr => vr.Company)
            .WithMany(p => p.ViabilityRules)
            .HasForeignKey(vr => vr.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(vr => vr.FeasibilityType)
            .WithMany(p => p.ViabilityRules)
            .HasForeignKey(vr => vr.FeasibilityTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}