using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _15_tagslink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>",
                column: "LinkedTagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>",
                column: "LinkedTagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>",
                column: "LinkedTagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>",
                column: "LinkedTagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
