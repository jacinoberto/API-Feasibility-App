using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class ViabilityCityConfiguration : IEntityTypeConfiguration<ViabilityCity>
{
    public void Configure(EntityTypeBuilder<ViabilityCity> builder)
    {
        builder.ToTable("tb_viability_cities");

        builder.HasKey(vc => vc.Id);
        
        builder.Property(vc => vc.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(vc => vc.Id)
            .HasColumnName("id_viability_city");
        
        builder.Property(vc => vc.ViabilityRuleId)
            .HasColumnName("viability_rule_id")
            .IsRequired();
        
        builder.Property(vc => vc.AddressId)
            .HasColumnName("address_id")
            .IsRequired();
        
        /*__Index__*/
        builder.HasIndex(vc =>
            new { vc.ViabilityRuleId, vc.AddressId});
        
        /*__Relationships__*/
        builder.HasOne(vc => vc.ViabilityRule)
            .WithMany(vr => vr.ViabilityCities)
            .HasForeignKey(vc => vc.ViabilityRuleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(vc => vc.Address)
            .WithMany(a => a.ViabilityCity)
            .HasForeignKey(vc => vc.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}