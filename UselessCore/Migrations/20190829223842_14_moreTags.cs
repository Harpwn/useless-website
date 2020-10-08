using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _14_moreTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tag_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tag_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tags_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCharacterTagEntry<Fighter>_Tag_LinkedTagId",
                table: "MainCharacterTagEntry<Fighter>",
                column: "LinkedTagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCharacterTagEntry<Hero>_Tag_LinkedTagId",
                table: "MainCharacterTagEntry<Hero>",
                column: "LinkedTagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
