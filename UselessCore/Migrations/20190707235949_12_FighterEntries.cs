using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _12_FighterEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimilarToInGameCharacterLinkEntry<Fighter>",
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
                    table.PrimaryKey("PK_SimilarToInGameCharacterLinkEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarToInGameCharacterLinkEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimilarToInGameCharacterLinkEntry<Fighter>_Fighters_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SimilarToInGameCharacterLinkEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimilarToInGenreCharacterLinkEntry<Fighter>",
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
                    table.PrimaryKey("PK_SimilarToInGenreCharacterLinkEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarToInGenreCharacterLinkEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimilarToInGenreCharacterLinkEntry<Fighter>_Fighters_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SimilarToInGenreCharacterLinkEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGameCharacterLinkEntry<Fighter>_CharacterId",
                table: "SimilarToInGameCharacterLinkEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGameCharacterLinkEntry<Fighter>_LinkedCharacterId",
                table: "SimilarToInGameCharacterLinkEntry<Fighter>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGameCharacterLinkEntry<Fighter>_UserId",
                table: "SimilarToInGameCharacterLinkEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGenreCharacterLinkEntry<Fighter>_CharacterId",
                table: "SimilarToInGenreCharacterLinkEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGenreCharacterLinkEntry<Fighter>_LinkedCharacterId",
                table: "SimilarToInGenreCharacterLinkEntry<Fighter>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarToInGenreCharacterLinkEntry<Fighter>_UserId",
                table: "SimilarToInGenreCharacterLinkEntry<Fighter>",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarToInGameCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "SimilarToInGenreCharacterLinkEntry<Fighter>");
        }
    }
}
