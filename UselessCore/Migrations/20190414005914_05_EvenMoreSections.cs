using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _05_EvenMoreSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntry_CharacterFreeTextSections_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntry_GameFreeTextSection_GameFreeTextSectionId",
                table: "FreeTextSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                table: "FreeTextSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntry_CharacterNumberSections_CharacterNumberSectionId",
                table: "NumberSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntry_GameNumberSection_GameNumberSectionId",
                table: "NumberSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                table: "NumberSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionVote_FreeTextSectionEntry_FreeTextSectionEntryId",
                table: "SectionVote");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionVote_NumberSectionEntry_NumberSectionEntryId",
                table: "SectionVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberSectionEntry",
                table: "NumberSectionEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeTextSectionEntry",
                table: "FreeTextSectionEntry");

            migrationBuilder.RenameTable(
                name: "NumberSectionEntry",
                newName: "NumberSectionEntries");

            migrationBuilder.RenameTable(
                name: "FreeTextSectionEntry",
                newName: "FreeTextSectionEntries");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSectionEntry_UserId",
                table: "NumberSectionEntries",
                newName: "IX_NumberSectionEntries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSectionEntry_GameNumberSectionId",
                table: "NumberSectionEntries",
                newName: "IX_NumberSectionEntries_GameNumberSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSectionEntry_CharacterNumberSectionId",
                table: "NumberSectionEntries",
                newName: "IX_NumberSectionEntries_CharacterNumberSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextSectionEntry_UserId",
                table: "FreeTextSectionEntries",
                newName: "IX_FreeTextSectionEntries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextSectionEntry_GameFreeTextSectionId",
                table: "FreeTextSectionEntries",
                newName: "IX_FreeTextSectionEntries_GameFreeTextSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextSectionEntry_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntries",
                newName: "IX_FreeTextSectionEntries_CharacterFreeTextSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberSectionEntries",
                table: "NumberSectionEntries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeTextSectionEntries",
                table: "FreeTextSectionEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntries_CharacterFreeTextSections_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntries",
                column: "CharacterFreeTextSectionId",
                principalTable: "CharacterFreeTextSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntries_GameFreeTextSection_GameFreeTextSectionId",
                table: "FreeTextSectionEntries",
                column: "GameFreeTextSectionId",
                principalTable: "GameFreeTextSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntries_AspNetUsers_UserId",
                table: "FreeTextSectionEntries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntries_CharacterNumberSections_CharacterNumberSectionId",
                table: "NumberSectionEntries",
                column: "CharacterNumberSectionId",
                principalTable: "CharacterNumberSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntries_GameNumberSection_GameNumberSectionId",
                table: "NumberSectionEntries",
                column: "GameNumberSectionId",
                principalTable: "GameNumberSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntries_AspNetUsers_UserId",
                table: "NumberSectionEntries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionVote_FreeTextSectionEntries_FreeTextSectionEntryId",
                table: "SectionVote",
                column: "FreeTextSectionEntryId",
                principalTable: "FreeTextSectionEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionVote_NumberSectionEntries_NumberSectionEntryId",
                table: "SectionVote",
                column: "NumberSectionEntryId",
                principalTable: "NumberSectionEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntries_CharacterFreeTextSections_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntries_GameFreeTextSection_GameFreeTextSectionId",
                table: "FreeTextSectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntries_AspNetUsers_UserId",
                table: "FreeTextSectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntries_CharacterNumberSections_CharacterNumberSectionId",
                table: "NumberSectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntries_GameNumberSection_GameNumberSectionId",
                table: "NumberSectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntries_AspNetUsers_UserId",
                table: "NumberSectionEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionVote_FreeTextSectionEntries_FreeTextSectionEntryId",
                table: "SectionVote");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionVote_NumberSectionEntries_NumberSectionEntryId",
                table: "SectionVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberSectionEntries",
                table: "NumberSectionEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeTextSectionEntries",
                table: "FreeTextSectionEntries");

            migrationBuilder.RenameTable(
                name: "NumberSectionEntries",
                newName: "NumberSectionEntry");

            migrationBuilder.RenameTable(
                name: "FreeTextSectionEntries",
                newName: "FreeTextSectionEntry");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSectionEntries_UserId",
                table: "NumberSectionEntry",
                newName: "IX_NumberSectionEntry_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSectionEntries_GameNumberSectionId",
                table: "NumberSectionEntry",
                newName: "IX_NumberSectionEntry_GameNumberSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_NumberSectionEntries_CharacterNumberSectionId",
                table: "NumberSectionEntry",
                newName: "IX_NumberSectionEntry_CharacterNumberSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextSectionEntries_UserId",
                table: "FreeTextSectionEntry",
                newName: "IX_FreeTextSectionEntry_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextSectionEntries_GameFreeTextSectionId",
                table: "FreeTextSectionEntry",
                newName: "IX_FreeTextSectionEntry_GameFreeTextSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextSectionEntries_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntry",
                newName: "IX_FreeTextSectionEntry_CharacterFreeTextSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberSectionEntry",
                table: "NumberSectionEntry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeTextSectionEntry",
                table: "FreeTextSectionEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntry_CharacterFreeTextSections_CharacterFreeTextSectionId",
                table: "FreeTextSectionEntry",
                column: "CharacterFreeTextSectionId",
                principalTable: "CharacterFreeTextSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntry_GameFreeTextSection_GameFreeTextSectionId",
                table: "FreeTextSectionEntry",
                column: "GameFreeTextSectionId",
                principalTable: "GameFreeTextSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                table: "FreeTextSectionEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntry_CharacterNumberSections_CharacterNumberSectionId",
                table: "NumberSectionEntry",
                column: "CharacterNumberSectionId",
                principalTable: "CharacterNumberSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntry_GameNumberSection_GameNumberSectionId",
                table: "NumberSectionEntry",
                column: "GameNumberSectionId",
                principalTable: "GameNumberSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                table: "NumberSectionEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionVote_FreeTextSectionEntry_FreeTextSectionEntryId",
                table: "SectionVote",
                column: "FreeTextSectionEntryId",
                principalTable: "FreeTextSectionEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionVote_NumberSectionEntry_NumberSectionEntryId",
                table: "SectionVote",
                column: "NumberSectionEntryId",
                principalTable: "NumberSectionEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
