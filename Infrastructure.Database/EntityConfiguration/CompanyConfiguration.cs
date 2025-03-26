using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("tb_companies");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(c => c.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(c=> c.Id)
            .HasColumnName("id_company");
        
        builder.Property(c => c.CompanyName)
            .HasColumnName("company_name")
            .HasColumnType("varchar(150) CHARACTER SET utf8")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(c => c.CompanyCode)
            .HasColumnName("company_code")
            .HasColumnType("varchar(14)")
            .HasMaxLength(14)
            .IsUnicode()
            .IsRequired();
        
        builder.Property(c => c.ResponsibleContact)
            .HasColumnName("responsible_contact")
            .HasColumnType("varchar(11)").
            HasMaxLength(11)
            .IsRequired(false);
        
        builder.Property(c => c.FinancialContact)
            .HasColumnName("financial_contact")
            .HasColumnType("varchar(11)")
            .HasMaxLength(11)
            .IsRequired(false);
        
        builder.Property(c => c.ResponsibleEmail)
            .HasColumnName("responsible_email")
            .HasColumnType("varchar(255)").
            HasMaxLength(255)
            .IsUnicode()
            .IsRequired(false);
        
        builder.Property(c => c.FinancialEmail)
            .HasColumnName("financial_email")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsUnicode()
            .IsRequired(false);
        
        builder.Property(c => c.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(true)
            .IsRequired();
        
        /*__Index__*/
        builder.HasIndex(co =>
                new { co.CompanyCode, co.ResponsibleEmail, co.FinancialEmail })
            .IsUnique();

        builder.HasIndex(co => co.CompanyName);
    }
}