using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class ZipCodeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("tb_zip_codes");
        
        builder.HasKey(z => z.Id);
        
        builder.Property(z => z.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(z => z.Id)
            .HasColumnName("id_zip_code");

        builder.Property(z => z.ZipCode)
            .HasColumnName("zip_code")
            .IsRequired();
        
        builder.Property(z => z.ZipCode)
            .HasColumnName("street")
            .IsRequired();
        
        builder.Property(z => z.ZipCode)
            .HasColumnName("area")
            .IsRequired();
        
        builder.Property(z => z.ZipCode)
            .HasColumnName("city")
            .IsRequired();
        
        builder.Property(z => z.ZipCode)
            .HasColumnName("state")
            .IsRequired();
    }
}