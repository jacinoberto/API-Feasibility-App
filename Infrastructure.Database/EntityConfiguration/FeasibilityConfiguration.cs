using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class FeasibilityConfiguration : IEntityTypeConfiguration<Feasibility>
{
    public void Configure(EntityTypeBuilder<Feasibility> builder)
    {
        builder.ToTable("tb_feasibilities");
        
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(f => f.Id)
            .HasColumnName("id_feasibility");
        
        builder.Property(f => f.OperatorId)
            .HasColumnName("operator_id");
        
        builder.Property(f => f.AddressId)
            .HasColumnName("address_id");
        
        /*__Relationships__*/
        builder.HasOne(f => f.Operator)
            .WithMany(o => o.Feasibilities)
            .HasForeignKey(f => f.OperatorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Address)
            .WithMany(a => a.Feasibilities)
            .HasForeignKey(f => f.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}