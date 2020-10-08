using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _04_MoreSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                table: "FreeTextSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                table: "NumberSectionEntry");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NumberSectionEntry",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FreeTextSectionEntry",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                table: "FreeTextSectionEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                table: "NumberSectionEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                table: "FreeTextSectionEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                table: "NumberSectionEntry");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NumberSectionEntry",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FreeTextSectionEntry",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextSectionEntry_AspNetUsers_UserId",
                table: "FreeTextSectionEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumberSectionEntry_AspNetUsers_UserId",
                table: "NumberSectionEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
