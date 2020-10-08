using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _12_newSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CounteredByCharacterLinkEntry<Fighter>",
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
                    table.PrimaryKey("PK_CounteredByCharacterLinkEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounteredByCharacterLinkEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounteredByCharacterLinkEntry<Fighter>_Fighters_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CounteredByCharacterLinkEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CounteredByCharacterLinkEntry<Hero>",
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
                    table.PrimaryKey("PK_CounteredByCharacterLinkEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounteredByCharacterLinkEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounteredByCharacterLinkEntry<Hero>_Heros_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CounteredByCharacterLinkEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrongAgainstCharacterLinkEntry<Fighter>",
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
                    table.PrimaryKey("PK_StrongAgainstCharacterLinkEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrongAgainstCharacterLinkEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrongAgainstCharacterLinkEntry<Fighter>_Fighters_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrongAgainstCharacterLinkEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrongAgainstCharacterLinkEntry<Hero>",
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
                    table.PrimaryKey("PK_StrongAgainstCharacterLinkEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrongAgainstCharacterLinkEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrongAgainstCharacterLinkEntry<Hero>_Heros_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrongAgainstCharacterLinkEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CounteredByCharacterLinkEntry<Fighter>_CharacterId",
                table: "CounteredByCharacterLinkEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CounteredByCharacterLinkEntry<Fighter>_LinkedCharacterId",
                table: "CounteredByCharacterLinkEntry<Fighter>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CounteredByCharacterLinkEntry<Fighter>_UserId",
                table: "CounteredByCharacterLinkEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CounteredByCharacterLinkEntry<Hero>_CharacterId",
                table: "CounteredByCharacterLinkEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CounteredByCharacterLinkEntry<Hero>_LinkedCharacterId",
                table: "CounteredByCharacterLinkEntry<Hero>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CounteredByCharacterLinkEntry<Hero>_UserId",
                table: "CounteredByCharacterLinkEntry<Hero>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StrongAgainstCharacterLinkEntry<Fighter>_CharacterId",
                table: "StrongAgainstCharacterLinkEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrongAgainstCharacterLinkEntry<Fighter>_LinkedCharacterId",
                table: "StrongAgainstCharacterLinkEntry<Fighter>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrongAgainstCharacterLinkEntry<Fighter>_UserId",
                table: "StrongAgainstCharacterLinkEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StrongAgainstCharacterLinkEntry<Hero>_CharacterId",
                table: "StrongAgainstCharacterLinkEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrongAgainstCharacterLinkEntry<Hero>_LinkedCharacterId",
                table: "StrongAgainstCharacterLinkEntry<Hero>",
                column: "LinkedCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_StrongAgainstCharacterLinkEntry<Hero>_UserId",
                table: "StrongAgainstCharacterLinkEntry<Hero>",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CounteredByCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "CounteredByCharacterLinkEntry<Hero>");

            migrationBuilder.DropTable(
                name: "StrongAgainstCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "StrongAgainstCharacterLinkEntry<Hero>");
        }
    }
}
