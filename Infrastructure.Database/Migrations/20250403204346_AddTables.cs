using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_observations",
                columns: table => new
                {
                    id_observation = table.Column<Guid>(type: "char(36)", nullable: false),
                    plan_observation = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_observations", x => x.id_observation);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_plan_observations",
                columns: table => new
                {
                    id_plan_observation = table.Column<Guid>(type: "char(36)", nullable: false),
                    plan_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    observation_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plan_observations", x => x.id_plan_observation);
                    table.ForeignKey(
                        name: "FK_tb_plan_observations_tb_observations_observation_id",
                        column: x => x.observation_id,
                        principalTable: "tb_observations",
                        principalColumn: "id_observation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_plan_observations_tb_plans_plan_id",
                        column: x => x.plan_id,
                        principalTable: "tb_plans",
                        principalColumn: "id_plan",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plan_observations_observation_id",
                table: "tb_plan_observations",
                column: "observation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plan_observations_plan_id_observation_id",
                table: "tb_plan_observations",
                columns: new[] { "plan_id", "observation_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_plan_observations");

            migrationBuilder.DropTable(
                name: "tb_observations");
        }
    }
}
