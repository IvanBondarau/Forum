using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class AccountVerification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerificationString",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Virified",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationString",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Virified",
                table: "User");
        }
    }
}
