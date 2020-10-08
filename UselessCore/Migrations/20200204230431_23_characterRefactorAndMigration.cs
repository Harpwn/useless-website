using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _23_characterRefactorAndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_CharacterTipsEntry<Hero>_CharacterTipsEntry<Hero>Id",
                table: "EntryVote");

            migrationBuilder.RenameColumn(
                name: "CharacterTipsEntry<Hero>Id",
                table: "EntryVote",
                newName: "CharacterValueEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryVote_CharacterTipsEntry<Hero>Id",
                table: "EntryVote",
                newName: "IX_EntryVote_CharacterValueEntryId");

            migrationBuilder.AddColumn<string>(
                name: "LinkEntryTypesCsv",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringEntryTypesCsv",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagEntryTypesCsv",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueEntryTypesCsv",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterLinkEntryId",
                table: "EntryVote",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterStringEntryId",
                table: "EntryVote",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterTagEntryId",
                table: "EntryVote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IconImageId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Images_IconImageId",
                        column: x => x.IconImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkEntries_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkEntries_Characters_LinkedCharacterId",
                        column: x => x.LinkedCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StringEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringEntries_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StringEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    LinkedTagId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagEntries_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagEntries_Tags_LinkedTagId",
                        column: x => x.LinkedTagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValueEntries_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValueEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../../UselessCore/Scripts/23_HeroReworkMigration.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));

            migrationBuilder.DropTable(
                name: "CharacterTierEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "CharacterTipsEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "CounteredByCharacterLinkEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "MainCharacterTagEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "SimilarToInGameCharacterLinkEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "SimilarToInGenreCharacterLinkEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "StrongAgainstCharacterLinkEntry<Hero>");
            
            migrationBuilder.DropTable(
                name: "Heros");
            
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Games");
            
            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_CharacterLinkEntryId",
                table: "EntryVote",
                column: "CharacterLinkEntryId");
            
            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_CharacterStringEntryId",
                table: "EntryVote",
                column: "CharacterStringEntryId");
            
            migrationBuilder.CreateIndex(
                name: "IX_EntryVote_CharacterTagEntryId",
                table: "EntryVote",
                column: "CharacterTagEntryId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameId",
                table: "Characters",
                column: "GameId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Characters_IconImageId",
                table: "Characters",
                column: "IconImageId");
            
            migrationBuilder.CreateIndex(
                name: "IX_LinkEntries_CharacterId",
                table: "LinkEntries",
                column: "CharacterId");
            
            migrationBuilder.CreateIndex(
                name: "IX_LinkEntries_LinkedCharacterId",
                table: "LinkEntries",
                column: "LinkedCharacterId");
            
            migrationBuilder.CreateIndex(
                name: "IX_LinkEntries_UserId",
                table: "LinkEntries",
                column: "UserId");
            
            migrationBuilder.CreateIndex(
                name: "IX_StringEntries_CharacterId",
                table: "StringEntries",
                column: "CharacterId");
            
            migrationBuilder.CreateIndex(
                name: "IX_StringEntries_UserId",
                table: "StringEntries",
                column: "UserId");
            
            migrationBuilder.CreateIndex(
                name: "IX_TagEntries_CharacterId",
                table: "TagEntries",
                column: "CharacterId");
            
            migrationBuilder.CreateIndex(
                name: "IX_TagEntries_LinkedTagId",
                table: "TagEntries",
                column: "LinkedTagId");
            
            migrationBuilder.CreateIndex(
                name: "IX_TagEntries_UserId",
                table: "TagEntries",
                column: "UserId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ValueEntries_CharacterId",
                table: "ValueEntries",
                column: "CharacterId");
            
            migrationBuilder.CreateIndex(
                name: "IX_ValueEntries_UserId",
                table: "ValueEntries",
                column: "UserId");
            
            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_LinkEntries_CharacterLinkEntryId",
                table: "EntryVote",
                column: "CharacterLinkEntryId",
                principalTable: "LinkEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_StringEntries_CharacterStringEntryId",
                table: "EntryVote",
                column: "CharacterStringEntryId",
                principalTable: "StringEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_TagEntries_CharacterTagEntryId",
                table: "EntryVote",
                column: "CharacterTagEntryId",
                principalTable: "TagEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_ValueEntries_CharacterValueEntryId",
                table: "EntryVote",
                column: "CharacterValueEntryId",
                principalTable: "ValueEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_LinkEntries_CharacterLinkEntryId",
                table: "EntryVote");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_StringEntries_CharacterStringEntryId",
                table: "EntryVote");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_TagEntries_CharacterTagEntryId",
                table: "EntryVote");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_ValueEntries_CharacterValueEntryId",
                table: "EntryVote");

            migrationBuilder.DropTable(
                name: "LinkEntries");

            migrationBuilder.DropTable(
                name: "StringEntries");

            migrationBuilder.DropTable(
                name: "TagEntries");

            migrationBuilder.DropTable(
                name: "ValueEntries");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_EntryVote_CharacterLinkEntryId",
                table: "EntryVote");

            migrationBuilder.DropIndex(
                name: "IX_EntryVote_CharacterStringEntryId",
                table: "EntryVote");

            migrationBuilder.DropIndex(
                name: "IX_EntryVote_CharacterTagEntryId",
                table: "EntryVote");

            migrationBuilder.DropColumn(
                name: "LinkEntryTypesCsv",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StringEntryTypesCsv",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TagEntryTypesCsv",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ValueEntryTypesCsv",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CharacterLinkEntryId",
                table: "EntryVote");

            migrationBuilder.DropColumn(
                name: "CharacterStringEntryId",
                table: "EntryVote");

            migrationBuilder.DropColumn(
                name: "CharacterTagEntryId",
                table: "EntryVote");

            migrationBuilder.RenameColumn(
                name: "CharacterValueEntryId",
                table: "EntryVote",
                newName: "CharacterTipsEntry<Hero>Id");

            migrationBuilder.RenameIndex(
                name: "IX_EntryVote_CharacterValueEntryId",
                table: "EntryVote",
                newName: "IX_EntryVote_CharacterTipsEntry<Hero>Id");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Games",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    IconImageId = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    MobaTestField = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heros_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heros_Images_IconImageId",
                        column: x => x.IconImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTierEntry<Hero>",
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

            migrationBuilder.CreateTable(
                name: "CharacterTipsEntry<Hero>",
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
                name: "CounteredByCharacterLinkEntry<Hero>",
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
                name: "MainCharacterTagEntry<Hero>",
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
                    table.PrimaryKey("PK_MainCharacterTagEntry<Hero>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Hero>_Heros_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Heros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Hero>_Tags_LinkedTagId",
                        column: x => x.LinkedTagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCharacterTagEntry<Hero>_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimilarToInGameCharacterLinkEntry<Hero>",
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
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LinkedCharacterId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "StrongAgainstCharacterLinkEntry<Hero>",
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
                name: "IX_CharacterTierEntry<Hero>_CharacterId",
                table: "CharacterTierEntry<Hero>",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTierEntry<Hero>_UserId",
                table: "CharacterTierEntry<Hero>",
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
                name: "IX_Heros_GameId",
                table: "Heros",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_IconImageId",
                table: "Heros",
                column: "IconImageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_CharacterTipsEntry<Hero>_CharacterTipsEntry<Hero>Id",
                table: "EntryVote",
                column: "CharacterTipsEntry<Hero>Id",
                principalTable: "CharacterTipsEntry<Hero>",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
