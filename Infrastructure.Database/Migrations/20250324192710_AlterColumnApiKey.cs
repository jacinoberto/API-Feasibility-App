using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnApiKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "tb_api_keys",
                type: "text",  // Altera o tipo para TEXT
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "tb_api_keys",
                type: "varchar(255)",  // Reverte o tipo para varchar(255)
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
