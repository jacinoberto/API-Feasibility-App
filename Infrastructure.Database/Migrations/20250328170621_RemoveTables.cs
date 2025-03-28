using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_plans_feasibility");

            migrationBuilder.DropTable(
                name: "tb_operators_plans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    feasibility_type_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FeasibilityTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    feasibility_id = table.Column<Guid>(type: "char(36)", nullable: false),
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
                name: "IX_tb_operators_plans_operator_id",
                table: "tb_operators_plans",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_operators_plans_plan_id",
                table: "tb_operators_plans",
                column: "plan_id");

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
        }
    }
}
