using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumFeasibilityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_feasibilities_tb_plans_PlanId",
                table: "tb_feasibilities");

            migrationBuilder.DropIndex(
                name: "IX_tb_feasibilities_PlanId",
                table: "tb_feasibilities");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "tb_feasibilities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "tb_feasibilities",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_feasibilities_PlanId",
                table: "tb_feasibilities",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_feasibilities_tb_plans_PlanId",
                table: "tb_feasibilities",
                column: "PlanId",
                principalTable: "tb_plans",
                principalColumn: "id_plan");
        }
    }
}
