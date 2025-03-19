using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class InternetConfiguration : IEntityTypeConfiguration<Internet>
{
    public void Configure(EntityTypeBuilder<Internet> builder)
    {
        builder.ToTable("tb_internets");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(i => i.Id)
            .HasColumnName("id_internet");

        builder.Property(i => i.InternetSpeed)
            .HasColumnName("internet_speed")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.SpeedType)
            .HasColumnName("speed_type")
            .HasColumnType("char(2)")
            .IsRequired();
    }
}