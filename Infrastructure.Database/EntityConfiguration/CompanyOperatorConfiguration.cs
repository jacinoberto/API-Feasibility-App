using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class CompanyOperatorConfiguration : IEntityTypeConfiguration<CompanyOperator>
{
    public void Configure(EntityTypeBuilder<CompanyOperator> builder)
    {
        builder.ToTable("tb_companies_operators");
        
        builder.HasKey(cp => cp.Id);

        builder.Property(cp => cp.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(cp => cp.Id)
            .HasColumnName("id_company_operator");

        builder.Property(cp => cp.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

        builder.Property(cp => cp.OperatorId)
            .HasColumnName("operator_id")
            .IsRequired();
        
        /*__Index__*/
        builder.HasIndex(cp => cp.CompanyId);
        
        /*__Relationships__*/
        builder.HasOne(cp => cp.Company)
            .WithMany(company => company.CompanyOperators)
            .HasForeignKey(cp => cp.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cp => cp.Operator)
            .WithMany(op => op.CompaniesOperators)
            .HasForeignKey(cp => cp.OperatorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}