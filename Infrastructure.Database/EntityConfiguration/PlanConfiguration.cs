using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("tb_plans");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Id)
            .HasColumnName("id_plan");
        
        builder.Property(p => p.PlanName)
            .HasColumnName("plan_name")
            .HasColumnType("varchar(150) CHARACTER SET utf8")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.InternetId)
            .HasColumnName("internet_id")
            .IsRequired();
        
        builder.Property(p => p.Value)
            .HasColumnName("value")
            .HasColumnType("decimal(6,2)")
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("tinyint(1)")
            .HasDefaultValue(true)
            .IsRequired();

        /*Relationships*/
        builder.HasOne(plan => plan.Internet)
            .WithMany(internet => internet.Plans)
            .HasForeignKey(plan => plan.InternetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}