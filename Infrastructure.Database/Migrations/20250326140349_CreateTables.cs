using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
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
                    key = table.Column<string>(type: "text", maxLength: 400, nullable: false),
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
                name: "tb_region_consultations",
                columns: table => new
                {
                    id_region_consultation = table.Column<Guid>(type: "char(36)", nullable: false),
                    company_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    state_id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_region_consultations", x => x.id_region_consultation);
                    table.ForeignKey(
                        name: "FK_tb_region_consultations_tb_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "tb_companies",
                        principalColumn: "id_company",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_region_consultations_tb_states_state_id",
                        column: x => x.state_id,
                        principalTable: "tb_states",
                        principalColumn: "id_state",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_feasibility_types",
                columns: table => new
                {
                    id_feasibility_type = table.Column<Guid>(type: "char(36)", nullable: false),
                    type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PlanId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_feasibility_types", x => x.id_feasibility_type);
                    table.ForeignKey(
                        name: "FK_tb_feasibility_types_tb_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "tb_plans",
                        principalColumn: "id_plan");
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
                name: "tb_feasibilities",
                columns: table => new
                {
                    id_feasibility = table.Column<Guid>(type: "char(36)", nullable: false),
                    operator_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    address_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PlanId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_feasibilities", x => x.id_feasibility);
                    table.ForeignKey(
                        name: "FK_tb_feasibilities_tb_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "tb_addresses",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_feasibilities_tb_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "tb_operators",
                        principalColumn: "id_operator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_feasibilities_tb_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "tb_plans",
                        principalColumn: "id_plan");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_plans_feasibility",
                columns: table => new
                {
                    id_plan_feasibility = table.Column<Guid>(type: "char(36)", nullable: false),
                    feasibility_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    feasibility_type_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FeasibilityTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OperatorPlanId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plans_feasibility", x => x.id_plan_feasibility);
                    table.ForeignKey(
                        name: "FK_tb_plans_feasibility_tb_feasibilities_feasibility_type_id",
                        column: x => x.feasibility_type_id,
                        principalTable: "tb_feasibilities",
                        principalColumn: "id_feasibility",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_plans_feasibility_tb_feasibility_types_FeasibilityTypeId",
                        column: x => x.FeasibilityTypeId,
                        principalTable: "tb_feasibility_types",
                        principalColumn: "id_feasibility_type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_plans_feasibility_tb_operators_plans_OperatorPlanId",
                        column: x => x.OperatorPlanId,
                        principalTable: "tb_operators_plans",
                        principalColumn: "id_operator_plan");
                    table.ForeignKey(
                        name: "FK_tb_plans_feasibility_tb_plans_feasibility_id",
                        column: x => x.feasibility_id,
                        principalTable: "tb_plans",
                        principalColumn: "id_plan",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_addresses_state_id",
                table: "tb_addresses",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_addresses_zip_code_city_state_id",
                table: "tb_addresses",
                columns: new[] { "zip_code", "city", "state_id" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_api_keys_company_id",
                table: "tb_api_keys",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_companies_company_code_responsible_email_financial_email",
                table: "tb_companies",
                columns: new[] { "company_code", "responsible_email", "financial_email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_companies_company_name",
                table: "tb_companies",
                column: "company_name");

            migrationBuilder.CreateIndex(
                name: "IX_tb_companies_operators_company_id",
                table: "tb_companies_operators",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_companies_operators_operator_id",
                table: "tb_companies_operators",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_feasibilities_address_id",
                table: "tb_feasibilities",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_feasibilities_operator_id",
                table: "tb_feasibilities",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_feasibilities_PlanId",
                table: "tb_feasibilities",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_feasibility_types_PlanId",
                table: "tb_feasibility_types",
                column: "PlanId");

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
                name: "IX_tb_plans_feasibility_feasibility_id",
                table: "tb_plans_feasibility",
                column: "feasibility_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plans_feasibility_feasibility_type_id",
                table: "tb_plans_feasibility",
                column: "feasibility_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plans_feasibility_FeasibilityTypeId",
                table: "tb_plans_feasibility",
                column: "FeasibilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plans_feasibility_OperatorPlanId",
                table: "tb_plans_feasibility",
                column: "OperatorPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_region_consultations_company_id",
                table: "tb_region_consultations",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_region_consultations_state_id",
                table: "tb_region_consultations",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_states_uf",
                table: "tb_states",
                column: "uf");
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
                name: "tb_region_consultations");

            migrationBuilder.DropTable(
                name: "tb_feasibilities");

            migrationBuilder.DropTable(
                name: "tb_feasibility_types");

            migrationBuilder.DropTable(
                name: "tb_operators_plans");

            migrationBuilder.DropTable(
                name: "tb_companies");

            migrationBuilder.DropTable(
                name: "tb_addresses");

            migrationBuilder.DropTable(
                name: "tb_operators");

            migrationBuilder.DropTable(
                name: "tb_plans");

            migrationBuilder.DropTable(
                name: "tb_states");

            migrationBuilder.DropTable(
                name: "tb_internets");
        }
    }
}
