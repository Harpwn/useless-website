using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _17_removeUselessProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fighters_Images_ProfileImageId",
                table: "Fighters");

            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Images_ProfileImageId",
                table: "Heros");

            migrationBuilder.DropIndex(
                name: "IX_Heros_ProfileImageId",
                table: "Heros");

            migrationBuilder.DropIndex(
                name: "IX_Fighters_ProfileImageId",
                table: "Fighters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fighters");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "Fighters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Heros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileImageId",
                table: "Heros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fighters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileImageId",
                table: "Fighters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heros_ProfileImageId",
                table: "Heros",
                column: "ProfileImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Fighters_ProfileImageId",
                table: "Fighters",
                column: "ProfileImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fighters_Images_ProfileImageId",
                table: "Fighters",
                column: "ProfileImageId",
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
    }
}
