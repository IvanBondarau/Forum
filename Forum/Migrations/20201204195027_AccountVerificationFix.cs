using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class AccountVerificationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Virified",
                table: "User",
                newName: "Verified");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Verified",
                table: "User",
                newName: "Virified");
        }
    }
}
