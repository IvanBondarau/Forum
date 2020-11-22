using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
