﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.EntityConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("tb_addresses");
        
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();
        
        builder.Property(a => a.Id)
            .HasColumnName("id_address");
        
        builder.Property(a => a.StateId)
            .HasColumnName("state_id")
            .IsRequired(false);

        builder.Property(a => a.ZipCode)
            .HasColumnName("zip_code")
            .HasMaxLength(8)
            .IsRequired(false);
        
        builder.Property(a => a.Street)
            .HasColumnName("street")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(a => a.Number)
            .HasColumnName("number")
            .IsRequired(false);
            
        builder.Property(a => a.Area)
            .HasColumnName("area")
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.Property(a => a.City)
            .HasColumnName("city")
            .HasMaxLength(50)
            .IsRequired(false);
        
        /*__Index__*/
        builder.HasIndex(a =>
            new { a.ZipCode, a.City, a.StateId });
        
        /*__Relationship__*/
        builder.HasOne(address => address.State)
            .WithMany(state => state.Addresses)
            .HasForeignKey(address => address.StateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}