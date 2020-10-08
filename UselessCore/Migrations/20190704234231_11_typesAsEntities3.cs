using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _11_typesAsEntities3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimilarToInGameCharacterLinkEntry<Hero>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarToInGameCharacterLinkEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarToInGameCharacterLinkEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimilarToInGameCharacterLinkEntry<Hero>_Heros_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SimilarToInGameCharacterLinkEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimilarToInGenreCharacterLinkEntry<Hero>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarToInGenreCharacterLinkEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarToInGenreCharacterLinkEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimilarToInGenreCharacterLinkEntry<Hero>_Heros_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SimilarToInGenreCharacterLinkEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGameCharacterLinkEntry<Hero>_CharacterId",
                table: "SimilarToInGameCharacterLinkEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGameCharacterLinkEntry<Hero>_LinkedCharacterId",
                table: "SimilarToInGameCharacterLinkEntry<Hero>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGameCharacterLinkEntry<Hero>_UserId",
                table: "SimilarToInGameCharacterLinkEntry<Hero>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGenreCharacterLinkEntry<Hero>_CharacterId",
                table: "SimilarToInGenreCharacterLinkEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGenreCharacterLinkEntry<Hero>_LinkedCharacterId",
                table: "SimilarToInGenreCharacterLinkEntry<Hero>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGenreCharacterLinkEntry<Hero>_UserId",
                table: "SimilarToInGenreCharacterLinkEntry<Hero>",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarToInGameCharacterLinkEntry<Hero>");

            migrationBuilder.DropTable(
                name: "SimilarToInGenreCharacterLinkEntry<Hero>");
        }
    }
}
