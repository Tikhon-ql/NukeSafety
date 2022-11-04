using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NukeSafety.ORM.Migrations
{
    public partial class BombImagePathAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Bombs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Bombs");
        }
    }
}
