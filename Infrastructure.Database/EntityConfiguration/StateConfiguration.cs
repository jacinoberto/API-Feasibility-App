using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class StateConfiguration: IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("tb_states");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Id)
            .HasColumnName("id_state");

        builder.Property(s => s.Uf)
            .HasColumnName("uf")
            .HasColumnType("char(2)")
            .HasMaxLength(2);
    }
}