using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _08_typesAsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Games",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobaTestField",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Characters",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobaTestField",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MobaTestField",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MobaTestField",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }
    }
}
