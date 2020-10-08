using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _18_enumSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterTierEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTierEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterTierEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTierEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTierEntry<Hero>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTierEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterTierEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTierEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Fighter>_CharacterId",
                table: "CharacterTierEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Fighter>_UserId",
                table: "CharacterTierEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Hero>_CharacterId",
                table: "CharacterTierEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Hero>_UserId",
                table: "CharacterTierEntry<Hero>",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterTierEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "CharacterTierEntry<Hero>");
        }
    }
}
