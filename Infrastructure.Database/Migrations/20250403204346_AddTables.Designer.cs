﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250403204346_AddTables")]
    partial class AddTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_address");

                    b.Property<string>("Area")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("area");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<int?>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("char(36)")
                        .HasColumnName("state_id");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("ZipCode", "City", "StateId");

                    b.ToTable("tb_addresses", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ApiKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_api_key");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("key");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("tb_api_keys", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_company");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(true)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("company_code");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150) CHARACTER SET utf8")
                        .HasColumnName("company_name");

                    b.Property<string>("FinancialContact")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("financial_contact");

                    b.Property<string>("FinancialEmail")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("financial_email");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("ResponsibleContact")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("responsible_contact");

                    b.Property<string>("ResponsibleEmail")
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("responsible_email");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.HasIndex("CompanyCode", "ResponsibleEmail", "FinancialEmail")
                        .IsUnique();

                    b.ToTable("tb_companies", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CompanyOperator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_company_operator");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)")
                        .HasColumnName("company_id");

                    b.Property<Guid>("OperatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("operator_id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OperatorId");

                    b.ToTable("tb_companies_operators", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Feasibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_feasibility");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)")
                        .HasColumnName("address_id");

                    b.Property<Guid>("OperatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("operator_id");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OperatorId");

                    b.ToTable("tb_feasibilities", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FeasibilityType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_feasibility_type");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("tb_feasibility_types", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Internet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_internet");

                    b.Property<int>("InternetSpeed")
                        .HasColumnType("int")
                        .HasColumnName("internet_speed");

                    b.Property<string>("SpeedType")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasColumnName("speed_type");

                    b.HasKey("Id");

                    b.ToTable("tb_internets", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Observation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_observation");

                    b.Property<string>("PlanObservation")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("plan_observation");

                    b.HasKey("Id");

                    b.ToTable("tb_observations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Operator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_operator");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150) CHARACTER SET utf8")
                        .HasColumnName("operator_name");

                    b.HasKey("Id");

                    b.ToTable("tb_operators", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_plan");

                    b.Property<Guid>("InternetId")
                        .HasColumnType("char(36)")
                        .HasColumnName("internet_id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150) CHARACTER SET utf8")
                        .HasColumnName("plan_name");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("InternetId");

                    b.ToTable("tb_plans", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PlanObservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_plan_observation");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ObservationId")
                        .HasColumnType("char(36)")
                        .HasColumnName("observation_id");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("char(36)")
                        .HasColumnName("plan_id");

                    b.HasKey("Id");

                    b.HasIndex("ObservationId");

                    b.HasIndex("PlanId", "ObservationId");

                    b.ToTable("tb_plan_observations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RegionConsultation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_region_consultation");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)")
                        .HasColumnName("company_id");

                    b.Property<Guid>("StateId")
                        .HasColumnType("char(36)")
                        .HasColumnName("state_id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StateId");

                    b.ToTable("tb_region_consultations", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_state");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("char(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.HasIndex("Uf");

                    b.ToTable("tb_states", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ViabilityCity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_viability_city");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)")
                        .HasColumnName("address_id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<Guid>("ViabilityRuleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("viability_rule_id");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ViabilityRuleId", "AddressId");

                    b.ToTable("tb_viability_cities", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ViabilityRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_viability_rule");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)")
                        .HasColumnName("company_id");

                    b.Property<Guid>("FeasibilityTypeId")
                        .HasColumnType("char(36)")
                        .HasColumnName("feasibility_type_id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("char(36)")
                        .HasColumnName("plan_id");

                    b.HasKey("Id");

                    b.HasIndex("FeasibilityTypeId");

                    b.HasIndex("PlanId");

                    b.HasIndex("CompanyId", "PlanId", "FeasibilityTypeId");

                    b.ToTable("tb_viability_rules", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ViabilityState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id_viability_state");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<Guid>("StateId")
                        .HasColumnType("char(36)")
                        .HasColumnName("state_id");

                    b.Property<Guid>("ViabilityRuleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("viability_rule_id");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("ViabilityRuleId", "StateId");

                    b.ToTable("tb_viability_states", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany("Addresses")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domain.Entities.ApiKey", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("ApiKeys")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.CompanyOperator", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("CompanyOperators")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Operator", "Operator")
                        .WithMany("CompaniesOperators")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Domain.Entities.Feasibility", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Feasibilities")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Operator", "Operator")
                        .WithMany("Feasibilities")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Domain.Entities.Plan", b =>
                {
                    b.HasOne("Domain.Entities.Internet", "Internet")
                        .WithMany("Plans")
                        .HasForeignKey("InternetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Internet");
                });

            modelBuilder.Entity("Domain.Entities.PlanObservation", b =>
                {
                    b.HasOne("Domain.Entities.Observation", "Observation")
                        .WithMany("PlanObservations")
                        .HasForeignKey("ObservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Plan", "Plan")
                        .WithMany("PlanObservations")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Observation");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Domain.Entities.RegionConsultation", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("RegionConsultations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany("RegionConsultations")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domain.Entities.ViabilityCity", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("ViabilityCity")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ViabilityRule", "ViabilityRule")
                        .WithMany("ViabilityCities")
                        .HasForeignKey("ViabilityRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("ViabilityRule");
                });

            modelBuilder.Entity("Domain.Entities.ViabilityRule", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("ViabilityRules")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.FeasibilityType", "FeasibilityType")
                        .WithMany("ViabilityRules")
                        .HasForeignKey("FeasibilityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Plan", "Plan")
                        .WithMany("ViabilityRules")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("FeasibilityType");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Domain.Entities.ViabilityState", b =>
                {
                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany("ViabilityStates")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ViabilityRule", "ViabilityRule")
                        .WithMany("ViabilityStates")
                        .HasForeignKey("ViabilityRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("ViabilityRule");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("Feasibilities");

                    b.Navigation("ViabilityCity");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Navigation("ApiKeys");

                    b.Navigation("CompanyOperators");

                    b.Navigation("RegionConsultations");

                    b.Navigation("ViabilityRules");
                });

            modelBuilder.Entity("Domain.Entities.FeasibilityType", b =>
                {
                    b.Navigation("ViabilityRules");
                });

            modelBuilder.Entity("Domain.Entities.Internet", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("Domain.Entities.Observation", b =>
                {
                    b.Navigation("PlanObservations");
                });

            modelBuilder.Entity("Domain.Entities.Operator", b =>
                {
                    b.Navigation("CompaniesOperators");

                    b.Navigation("Feasibilities");
                });

            modelBuilder.Entity("Domain.Entities.Plan", b =>
                {
                    b.Navigation("PlanObservations");

                    b.Navigation("ViabilityRules");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("RegionConsultations");

                    b.Navigation("ViabilityStates");
                });

            modelBuilder.Entity("Domain.Entities.ViabilityRule", b =>
                {
                    b.Navigation("ViabilityCities");

                    b.Navigation("ViabilityStates");
                });
#pragma warning restore 612, 618
        }
    }
}
