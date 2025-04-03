using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class ObservationConfiguration : IEntityTypeConfiguration<Observation>
{
    public void Configure(EntityTypeBuilder<Observation> builder)
    {
        builder.ToTable("tb_observations");
        
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(o => o.Id)
            .HasColumnName("id_observation");
        
        builder.Property(o => o.PlanObservation)
            .HasColumnName("plan_observation")
            .HasColumnType("VARCHAR(150)");
    }
}