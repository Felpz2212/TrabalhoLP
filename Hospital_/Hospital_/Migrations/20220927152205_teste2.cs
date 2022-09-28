using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "quantidade",
                table: "Medicamentos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "Medicamentos");
        }
    }
}
