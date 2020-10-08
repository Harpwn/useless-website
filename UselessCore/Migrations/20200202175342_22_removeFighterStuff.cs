using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _22_removeFighterStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_CharacterTipsEntry<Fighter>_CharacterTipsEntry<Fighter>Id",
                table: "EntryVote");

            migrationBuilder.DropTable(
                name: "CharacterTierEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "CharacterTipsEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "CounteredByCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "MainCharacterTagEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "SimilarToInGameCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "SimilarToInGenreCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "StrongAgainstCharacterLinkEntry<Fighter>");

            migrationBuilder.DropTable(
                name: "Fighters");

            migrationBuilder.DropIndex(
                name: "IX_EntryVote_CharacterTipsEntry<Fighter>Id",
                table: "EntryVote");

            migrationBuilder.DropColumn(
                name: "FighterTestField",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MobaTestField",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CharacterTipsEntry<Fighter>Id",
                table: "EntryVote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FighterTestField",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobaTestField",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterTipsEntry<Fighter>Id",
                table: "EntryVote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FighterTestField = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    IconImageId = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fighters_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fighters_Images_IconImageId",
                        column: x => x.IconImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTierEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
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
                name: "CharacterTipsEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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
                name: "CounteredByCharacterLinkEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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
                name: "MainCharacterTagEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LinkedTagId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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
                        name: "FK_MainCharacterTagEntry<Fighter>_Tags_LinkedTagId",
                        column: x => x.LinkedTagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Fighter>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimilarToInGameCharacterLinkEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "StrongAgainstCharacterLinkEntry<Fighter>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_CharacterTipsEntry<Fighter>Id",
                table: "EntryVote",
                column: "CharacterTipsEntry<Fighter>Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Fighter>_CharacterId",
                table: "CharacterTierEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Fighter>_UserId",
                table: "CharacterTierEntry<Fighter>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTipsEntry<Fighter>_CharacterId",
                table: "CharacterTipsEntry<Fighter>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTipsEntry<Fighter>_UserId",
                table: "CharacterTipsEntry<Fighter>",
                column: "UserId");

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
                name: "IX_Fighters_GameId",
                table: "Fighters",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_IconImageId",
                table: "Fighters",
                column: "IconImageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_CharacterTipsEntry<Fighter>_CharacterTipsEntry<Fighter>Id",
                table: "EntryVote",
                column: "CharacterTipsEntry<Fighter>Id",
                principalTable: "CharacterTipsEntry<Fighter>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
