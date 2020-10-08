using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _03_sections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterFreeTextSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFreeTextSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFreeTextSections_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterNumberSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterNumberSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterNumberSections_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameFreeTextSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFreeTextSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameFreeTextSection_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameNumberSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameNumberSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameNumberSection_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreeTextSectionEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 800, nullable: false),
                    CharacterFreeTextSectionId = table.Column<int>(nullable: true),
                    GameFreeTextSectionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTextSectionEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTextSectionEntry_CharacterFreeTextSections_CharacterFreeTextSectionId",
                        column: x => x.CharacterFreeTextSectionId,
                        principalTable: "CharacterFreeTextSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreeTextSectionEntry_GameFreeTextSection_GameFreeTextSectionId",
                        column: x => x.GameFreeTextSectionId,
                        principalTable: "GameFreeTextSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NumberSectionEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    CharacterNumberSectionId = table.Column<int>(nullable: true),
                    GameNumberSectionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSectionEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberSectionEntry_CharacterNumberSections_CharacterNumberSectionId",
                        column: x => x.CharacterNumberSectionId,
                        principalTable: "CharacterNumberSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NumberSectionEntry_GameNumberSection_GameNumberSectionId",
                        column: x => x.GameNumberSectionId,
                        principalTable: "GameNumberSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionVote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    IsPositive = table.Column<bool>(nullable: false),
                    FreeTextSectionEntryId = table.Column<int>(nullable: true),
                    NumberSectionEntryId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionVote_FreeTextSectionEntry_FreeTextSectionEntryId",
                        column: x => x.FreeTextSectionEntryId,
                        principalTable: "FreeTextSectionEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionVote_NumberSectionEntry_NumberSectionEntryId",
                        column: x => x.NumberSectionEntryId,
                        principalTable: "NumberSectionEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFreeTextSections_CharacterId",
                table: "CharacterFreeTextSections",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterNumberSections_CharacterId",
                table: "CharacterNumberSections",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextSectionEntry_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntry",
                column: "CharacterFreeTextSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextSectionEntry_GameFreeTextSectionId",
                table: "FreeTextSectionEntry",
                column: "GameFreeTextSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextSectionEntry_UserId",
                table: "FreeTextSectionEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameFreeTextSection_GameId",
                table: "GameFreeTextSection",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameNumberSection_GameId",
                table: "GameNumberSection",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSectionEntry_CharacterNumberSectionId",
                table: "NumberSectionEntry",
                column: "CharacterNumberSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSectionEntry_GameNumberSectionId",
                table: "NumberSectionEntry",
                column: "GameNumberSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSectionEntry_UserId",
                table: "NumberSectionEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionVote_FreeTextSectionEntryId",
                table: "SectionVote",
                column: "FreeTextSectionEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionVote_NumberSectionEntryId",
                table: "SectionVote",
                column: "NumberSectionEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionVote_UserId",
                table: "SectionVote",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionVote");

            migrationBuilder.DropTable(
                name: "FreeTextSectionEntry");

            migrationBuilder.DropTable(
                name: "NumberSectionEntry");

            migrationBuilder.DropTable(
                name: "CharacterFreeTextSections");

            migrationBuilder.DropTable(
                name: "GameFreeTextSection");

            migrationBuilder.DropTable(
                name: "CharacterNumberSections");

            migrationBuilder.DropTable(
                name: "GameNumberSection");
        }
    }
}
