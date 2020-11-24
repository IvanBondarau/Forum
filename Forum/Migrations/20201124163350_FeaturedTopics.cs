using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class FeaturedTopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFeaturedTopics",
                columns: table => new
                {
                    FeaturedTopicId = table.Column<int>(type: "int", nullable: false),
                    FeaturedUsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeaturedTopics", x => new { x.FeaturedTopicId, x.FeaturedUsersUserId });
                    table.ForeignKey(
                        name: "FK_UserFeaturedTopics_Topic_FeaturedTopicId",
                        column: x => x.FeaturedTopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeaturedTopics_User_FeaturedUsersUserId",
                        column: x => x.FeaturedUsersUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFeaturedTopics_FeaturedUsersUserId",
                table: "UserFeaturedTopics",
                column: "FeaturedUsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFeaturedTopics");
        }
    }
}
