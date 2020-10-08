using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _10_typesAsEntities3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Games_GameId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Images_IconImageId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Images_ProfileImageId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FighterTestFight",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Heros");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_ProfileImageId",
                table: "Heros",
                newName: "IX_Heros_ProfileImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_IconImageId",
                table: "Heros",
                newName: "IX_Heros_IconImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_GameId",
                table: "Heros",
                newName: "IX_Heros_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heros",
                table: "Heros",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProfileImageId = table.Column<int>(nullable: true),
                    IconImageId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    FighterTestFight = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Fighters_Images_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_GameId",
                table: "Fighters",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_IconImageId",
                table: "Fighters",
                column: "IconImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_ProfileImageId",
                table: "Fighters",
                column: "ProfileImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Games_GameId",
                table: "Heros",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Images_IconImageId",
                table: "Heros",
                column: "IconImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Images_ProfileImageId",
                table: "Heros",
                column: "ProfileImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Games_GameId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Images_IconImageId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Images_ProfileImageId",
                table: "Heros");

            migrationBuilder.DropTable(
                name: "Fighters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heros",
                table: "Heros");

            migrationBuilder.RenameTable(
                name: "Heros",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_ProfileImageId",
                table: "Characters",
                newName: "IX_Characters_ProfileImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_IconImageId",
                table: "Characters",
                newName: "IX_Characters_IconImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Heros_GameId",
                table: "Characters",
                newName: "IX_Characters_GameId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Characters",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FighterTestFight",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Games_GameId",
                table: "Characters",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Images_IconImageId",
                table: "Characters",
                column: "IconImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Images_ProfileImageId",
                table: "Characters",
                column: "ProfileImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
