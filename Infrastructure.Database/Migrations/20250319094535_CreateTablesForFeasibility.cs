using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesForFeasibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_companies",
                columns: table => new
                {
                    id_company = table.Column<Guid>(type: "char(36)", nullable: false),
                    company_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    company_code = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    responsible_contact = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    financial_contact = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    responsible_email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    financial_email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_companies", x => x.id_company);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_internets",
                columns: table => new
                {
                    id_internet = table.Column<Guid>(type: "char(36)", nullable: false),
                    internet_speed = table.Column<int>(type: "int", nullable: false),
                    speed_type = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_internets", x => x.id_internet);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_operators",
                columns: table => new
                {
                    id_operator = table.Column<Guid>(type: "char(36)", nullable: false),
                    operator_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_operators", x => x.id_operator);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_states",
                columns: table => new
                {
                    id_state = table.Column<Guid>(type: "char(36)", nullable: false),
                    uf = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_states", x => x.id_state);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_api_keys",
                columns: table => new
                {
                    id_api_key = table.Column<Guid>(type: "char(36)", nullable: false),
                    company_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    key = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_api_keys", x => x.id_api_key);
                    table.ForeignKey(
                        name: "FK_tb_api_keys_tb_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "tb_companies",
                        principalColumn: "id_company",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_plans",
                columns: table => new
                {
                    id_plan = table.Column<Guid>(type: "char(36)", nullable: false),
                    internet_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    plan_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    value = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plans", x => x.id_plan);
                    table.ForeignKey(
                        name: "FK_tb_plans_tb_internets_internet_id",
                        column: x => x.internet_id,
                        principalTable: "tb_internets",
                        principalColumn: "id_internet",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_companies_operators",
                columns: table => new
                {
                    id_company_operator = table.Column<Guid>(type: "char(36)", nullable: false),
                    company_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    operator_id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_companies_operators", x => x.id_company_operator);
                    table.ForeignKey(
                        name: "FK_tb_companies_operators_tb_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "tb_companies",
                        principalColumn: "id_company",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_companies_operators_tb_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "tb_operators",
                        principalColumn: "id_operator",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_addresses",
                columns: table => new
                {
                    id_address = table.Column<Guid>(type: "char(36)", nullable: false),
                    state_id = table.Column<Guid>(type: "char(36)", nullable: true),
                    zip_code = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    area = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_addresses", x => x.id_address);
                    table.ForeignKey(
                        name: "FK_tb_addresses_tb_states_state_id",
                        column: x => x.state_id,
                        principalTable: "tb_states",
                        principalColumn: "id_state",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_operators_plans",
                columns: table => new
                {
                    id_operator_plan = table.Column<Guid>(type: "char(36)", nullable: false),
                    operator_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    plan_id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_operators_plans", x => x.id_operator_plan);
                    table.ForeignKey(
                        name: "FK_tb_operators_plans_tb_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "tb_operators",
                        principalColumn: "id_operator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_operators_plans_tb_plans_plan_id",
                        column: x => x.plan_id,
                        principalTable: "tb_plans",
                        principalColumn: "id_plan",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_plans_feasibility",
                columns: table => new
                {
                    id_plan_feasibility = table.Column<Guid>(type: "char(36)", nullable: false),
                    operator_plan_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    address_id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plans_feasibility", x => x.id_plan_feasibility);
                    table.ForeignKey(
                        name: "FK_tb_plans_feasibility_tb_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "tb_addresses",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_plans_feasibility_tb_operators_plans_operator_plan_id",
                        column: x => x.operator_plan_id,
                        principalTable: "tb_operators_plans",
                        principalColumn: "id_operator_plan",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_addresses_state_id",
                table: "tb_addresses",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_api_keys_company_id",
                table: "tb_api_keys",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_companies_operators_company_id",
                table: "tb_companies_operators",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_companies_operators_operator_id",
                table: "tb_companies_operators",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_operators_plans_operator_id",
                table: "tb_operators_plans",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_operators_plans_plan_id",
                table: "tb_operators_plans",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plans_internet_id",
                table: "tb_plans",
                column: "internet_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plans_feasibility_address_id",
                table: "tb_plans_feasibility",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plans_feasibility_operator_plan_id",
                table: "tb_plans_feasibility",
                column: "operator_plan_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_api_keys");

            migrationBuilder.DropTable(
                name: "tb_companies_operators");

            migrationBuilder.DropTable(
                name: "tb_plans_feasibility");

            migrationBuilder.DropTable(
                name: "tb_companies");

            migrationBuilder.DropTable(
                name: "tb_addresses");

            migrationBuilder.DropTable(
                name: "tb_operators_plans");

            migrationBuilder.DropTable(
                name: "tb_states");

            migrationBuilder.DropTable(
                name: "tb_operators");

            migrationBuilder.DropTable(
                name: "tb_plans");

            migrationBuilder.DropTable(
                name: "tb_internets");
        }
    }
}
