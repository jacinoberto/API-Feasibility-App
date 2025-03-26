using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class FeasibilityTypeConfiguration : IEntityTypeConfiguration<FeasibilityType>
{
    public void Configure(EntityTypeBuilder<FeasibilityType> builder)
    {
        builder.ToTable("tb_feasibility_types");
        
        builder.HasKey(ft => ft.Id);

        builder.Property(ft => ft.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(ft => ft.Id)
            .HasColumnName("id_feasibility_type");
        
        builder.Property(ft => ft.Type)
            .HasColumnName("type")
            .HasColumnType("varchar(10)")
            .HasMaxLength(10)
            .IsRequired();
    }
}