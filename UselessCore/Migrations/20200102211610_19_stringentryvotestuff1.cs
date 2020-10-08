using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _19_stringentryvotestuff1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterTipsEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTipsEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterTipsEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTipsEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTipsEntry<Hero>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTipsEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterTipsEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTipsEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryVote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterTipsEntryFighterId = table.Column<int>(name: "CharacterTipsEntry<Fighter>Id", nullable: true),
                    CharacterTipsEntryHeroId = table.Column<int>(name: "CharacterTipsEntry<Hero>Id", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryVote_CharacterTipsEntry<Fighter>_CharacterTipsEntry<Fighter>Id",
                        column: x => x.CharacterTipsEntryFighterId,
                        principalTable: "CharacterTipsEntry<Fighter>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryVote_CharacterTipsEntry<Hero>_CharacterTipsEntry<Hero>Id",
                        column: x => x.CharacterTipsEntryHeroId,
                        principalTable: "CharacterTipsEntry<Hero>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTipsEntry<Fighter>_CharacterId",
                table: "CharacterTipsEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTipsEntry<Fighter>_UserId",
                table: "CharacterTipsEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTipsEntry<Hero>_CharacterId",
                table: "CharacterTipsEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTipsEntry<Hero>_UserId",
                table: "CharacterTipsEntry<Hero>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_CharacterTipsEntry<Fighter>Id",
                table: "EntryVote",
                column: "CharacterTipsEntry<Fighter>Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_CharacterTipsEntry<Hero>Id",
                table: "EntryVote",
                column: "CharacterTipsEntry<Hero>Id");

            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_UserId",
                table: "EntryVote",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryVote");

            migrationBuilder.DropTable(
                name: "CharacterTipsEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "CharacterTipsEntry<Hero>");
        }
    }
}
