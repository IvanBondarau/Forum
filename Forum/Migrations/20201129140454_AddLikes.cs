using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class AddLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageLikes",
                columns: table => new
                {
                    LikesMessageId = table.Column<int>(type: "int", nullable: false),
                    LikesUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLikes", x => new { x.LikesMessageId, x.LikesUserId });
                    table.ForeignKey(
                        name: "FK_MessageLikes_Message_LikesMessageId",
                        column: x => x.LikesMessageId,
                        principalTable: "Message",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageLikes_User_LikesUserId",
                        column: x => x.LikesUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageLikes_LikesUserId",
                table: "MessageLikes",
                column: "LikesUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageLikes");
        }
    }
}
