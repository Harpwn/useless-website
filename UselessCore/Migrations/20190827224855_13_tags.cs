using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _13_tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FighterTestFight",
                table: "Fighters",
                newName: "FighterTestField");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCharacterTagEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    LinkedTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCharacterTagEntry<Fighter>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Fighter>_Fighters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Fighter>_Tag_LinkedTagId",
                        column: x => x.LinkedTagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainCharacterTagEntry<Hero>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    LinkedTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCharacterTagEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Hero>_Tag_LinkedTagId",
                        column: x => x.LinkedTagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainCharacterTagEntry<Fighter>_CharacterId",
                table: "MainCharacterTagEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCharacterTagEntry<Fighter>_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>",
                column: "LinkedTagId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCharacterTagEntry<Fighter>_UserId",
                table: "MainCharacterTagEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCharacterTagEntry<Hero>_CharacterId",
                table: "MainCharacterTagEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCharacterTagEntry<Hero>_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>",
                column: "LinkedTagId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCharacterTagEntry<Hero>_UserId",
                table: "MainCharacterTagEntry<Hero>",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainCharacterTagEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "MainCharacterTagEntry<Hero>");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.RenameColumn(
                name: "FighterTestField",
                table: "Fighters",
                newName: "FighterTestFight");
        }
    }
}
