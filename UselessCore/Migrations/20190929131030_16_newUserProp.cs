using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _16_newUserProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvatarIconId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarIconId",
                table: "AspNetUsers");
        }
    }
}
