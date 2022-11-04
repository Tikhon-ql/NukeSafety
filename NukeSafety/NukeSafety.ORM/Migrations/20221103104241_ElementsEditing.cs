using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NukeSafety.ORM.Migrations
{
    public partial class ElementsEditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HalfLive",
                table: "Elements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "Shortname",
                table: "Elements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shortname",
                table: "Elements");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HalfLive",
                table: "Elements",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
