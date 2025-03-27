using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class ViabilityStateConfiguration : IEntityTypeConfiguration<ViabilityState>
{
    public void Configure(EntityTypeBuilder<ViabilityState> builder)
    {
        builder.ToTable("tb_viability_states");

        builder.HasKey(vs => vs.Id);
        
        builder.Property(vs => vs.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(vs => vs.Id)
            .HasColumnName("id_viability_state");
        
        builder.Property(vs => vs.ViabilityRuleId)
            .HasColumnName("viability_rule_id")
            .IsRequired();
        
        builder.Property(vs => vs.StateId)
            .HasColumnName("state_id")
            .IsRequired();
        
        /*__Index__*/
        builder.HasIndex(vs =>
            new { vs.ViabilityRuleId, vs.StateId});
        
        /*__Relationships__*/
        builder.HasOne(vs => vs.ViabilityRule)
            .WithMany(vr => vr.ViabilityStates)
            .HasForeignKey(vs => vs.ViabilityRuleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(vs => vs.State)
            .WithMany(s => s.ViabilityStates)
            .HasForeignKey(vs => vs.StateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}