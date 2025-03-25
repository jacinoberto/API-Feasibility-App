using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class RegionConsultationConfiguration : IEntityTypeConfiguration<RegionConsultation>
{
    public void Configure(EntityTypeBuilder<RegionConsultation> builder)
    {
        builder.ToTable("tb_region_consultations");
        
        builder.HasKey(rc => rc.Id);

        builder.Property(rc => rc.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(rc => rc.Id)
            .HasColumnName("id_region_consultation");

        builder.Property(rc => rc.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();
        
        builder.Property(rc => rc.StateId)
            .HasColumnName("state_id")
            .IsRequired();
        
        /*__Relationships__*/
        builder.HasOne(rc => rc.Company)
            .WithMany(c => c.RegionConsultations)
            .HasForeignKey(rc => rc.CompanyId);

        builder.HasOne(rc => rc.State)
            .WithMany(s => s.RegionConsultations)
            .HasForeignKey(c => c.StateId);
    }
}