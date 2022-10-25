using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NukeSafety.ORM.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HalfLive = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bombs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlastYield = table.Column<double>(type: "float", nullable: false),
                    FillingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bombs_Elements_FillingId",
                        column: x => x.FillingId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BombCountry",
                columns: table => new
                {
                    BombsId = table.Column<int>(type: "int", nullable: false),
                    OnArmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombCountry", x => new { x.BombsId, x.OnArmsId });
                    table.ForeignKey(
                        name: "FK_BombCountry_Bombs_BombsId",
                        column: x => x.BombsId,
                        principalTable: "Bombs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombCountry_Countries_OnArmsId",
                        column: x => x.OnArmsId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Explosions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BombId = table.Column<int>(type: "int", nullable: false),
                    AreaOfDamage = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explosions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Explosions_Bombs_BombId",
                        column: x => x.BombId,
                        principalTable: "Bombs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BombCountry_OnArmsId",
                table: "BombCountry",
                column: "OnArmsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bombs_FillingId",
                table: "Bombs",
                column: "FillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Explosions_BombId",
                table: "Explosions",
                column: "BombId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BombCountry");

            migrationBuilder.DropTable(
                name: "Explosions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Bombs");

            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
