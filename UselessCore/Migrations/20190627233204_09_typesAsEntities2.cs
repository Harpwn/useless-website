using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class _09_typesAsEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FighterTestField",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FighterTestFight",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FighterTestField",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FighterTestFight",
                table: "Characters");
        }
    }
}
