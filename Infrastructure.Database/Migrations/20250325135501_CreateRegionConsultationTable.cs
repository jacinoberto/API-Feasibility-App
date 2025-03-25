using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateRegionConsultationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_tb_region_consultations_company_id",
                table: "tb_region_consultations",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_region_consultations_state_id",
                table: "tb_region_consultations",
                column: "state_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_region_consultations");
        }
    }
}
