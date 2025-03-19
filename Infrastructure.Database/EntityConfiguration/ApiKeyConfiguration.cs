using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.ToTable("tb_api_keys");
        
        builder.HasKey(x => x.Id);

        builder.Property(ak => ak.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(ak => ak.Id)
            .HasColumnName("id_api_key");

        builder.Property(ak => ak.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();
        
        builder.Property(ak => ak.Key)
            .HasColumnName("key")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsUnicode()
            .IsRequired();

        builder.Property(ak => ak.Created)
            .HasColumnName("created")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(ak => ak.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(true)
            .IsRequired();
        
        /*__Relationships__*/
        builder.HasOne(apiKey => apiKey.Company)
            .WithMany(company => company.ApiKeys)
            .HasForeignKey(apiKey => apiKey.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}