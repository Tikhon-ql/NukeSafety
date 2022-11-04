using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NukeSafety.ORM.Migrations
{
    public partial class AreaOfDamageRemoving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaOfDamage",
                table: "Explosions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AreaOfDamage",
                table: "Explosions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
