using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class PlanObservationConfiguration : IEntityTypeConfiguration<PlanObservation>
{
    public void Configure(EntityTypeBuilder<PlanObservation> builder)
    {
        builder.ToTable("tb_plan_observations");

        builder.HasKey(po => po.Id);
        
        builder.Property(po => po.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(po => po.Id)
            .HasColumnName("id_plan_observation");

        builder.Property(po => po.PlanId)
            .HasColumnName("plan_id")
            .IsRequired();
        
        builder.Property(po => po.ObservationId)
            .HasColumnName("observation_id")
            .IsRequired();
        
        /*__Index__*/
        builder.HasIndex(po => new { po.PlanId, po.ObservationId });
        
        /*Relationships*/
        builder.HasOne(po => po.Plan)
            .WithMany(p => p.PlanObservations)
            .HasForeignKey(po => po.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(po => po.Observation)
            .WithMany(o => o.PlanObservations)
            .HasForeignKey(po => po.ObservationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}