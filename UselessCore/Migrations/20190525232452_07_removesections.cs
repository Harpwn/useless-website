using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _07_removesections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionVote");

            migrationBuilder.DropTable(
                name: "FreeTextSectionEntries");

            migrationBuilder.DropTable(
                name: "NumberSectionEntries");

            migrationBuilder.DropTable(
                name: "CharacterFreeTextSections");

            migrationBuilder.DropTable(
                name: "GameFreeTextSection");

            migrationBuilder.DropTable(
                name: "CharacterNumberSections");

            migrationBuilder.DropTable(
                name: "GameNumberSection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterFreeTextSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
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
                    CharacterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
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
                    GameId = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
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
                    GameId = table.Column<int>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
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
                name: "FreeTextSectionEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterFreeTextSectionId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    GameFreeTextSectionId = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 800, nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTextSectionEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTextSectionEntries_CharacterFreeTextSections_CharacterFreeTextSectionId",
                        column: x => x.CharacterFreeTextSectionId,
                        principalTable: "CharacterFreeTextSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreeTextSectionEntries_GameFreeTextSection_GameFreeTextSectionId",
                        column: x => x.GameFreeTextSectionId,
                        principalTable: "GameFreeTextSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FreeTextSectionEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberSectionEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterNumberSectionId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    GameNumberSectionId = table.Column<int>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSectionEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberSectionEntries_CharacterNumberSections_CharacterNumberSectionId",
                        column: x => x.CharacterNumberSectionId,
                        principalTable: "CharacterNumberSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NumberSectionEntries_GameNumberSection_GameNumberSectionId",
                        column: x => x.GameNumberSectionId,
                        principalTable: "GameNumberSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NumberSectionEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionVote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FreeTextSectionEntryId = table.Column<int>(nullable: true),
                    IsPositive = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    NumberSectionEntryId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionVote_FreeTextSectionEntries_FreeTextSectionEntryId",
                        column: x => x.FreeTextSectionEntryId,
                        principalTable: "FreeTextSectionEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionVote_NumberSectionEntries_NumberSectionEntryId",
                        column: x => x.NumberSectionEntryId,
                        principalTable: "NumberSectionEntries",
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
                name: "IX_FreeTextSectionEntries_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntries",
                column: "CharacterFreeTextSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextSectionEntries_GameFreeTextSectionId",
                table: "FreeTextSectionEntries",
                column: "GameFreeTextSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextSectionEntries_UserId",
                table: "FreeTextSectionEntries",
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
                name: "IX_NumberSectionEntries_CharacterNumberSectionId",
                table: "NumberSectionEntries",
                column: "CharacterNumberSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSectionEntries_GameNumberSectionId",
                table: "NumberSectionEntries",
                column: "GameNumberSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSectionEntries_UserId",
                table: "NumberSectionEntries",
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
    }
}
