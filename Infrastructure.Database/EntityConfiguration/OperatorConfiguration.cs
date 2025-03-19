using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
{
    public void Configure(EntityTypeBuilder<Operator> builder)
    {
        builder.ToTable("tb_operators");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(o => o.Id)
            .HasColumnName("id_operator");

        builder.Property(o => o.OperatorName)
            .HasColumnName("operator_name")
            .HasColumnType("varchar(150) CHARACTER SET utf8")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(o => o.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(true)
            .IsRequired();
    }
}