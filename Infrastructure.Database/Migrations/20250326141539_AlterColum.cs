using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_feasibility_types_tb_plans_PlanId",
                table: "tb_feasibility_types");

            migrationBuilder.DropIndex(
                name: "IX_tb_feasibility_types_PlanId",
                table: "tb_feasibility_types");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "tb_feasibility_types");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "tb_feasibility_types",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_feasibility_types_PlanId",
                table: "tb_feasibility_types",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_feasibility_types_tb_plans_PlanId",
                table: "tb_feasibility_types",
                column: "PlanId",
                principalTable: "tb_plans",
                principalColumn: "id_plan");
        }
    }
}
