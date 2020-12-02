using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class LabelsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Label_Topic_TopicId",
                table: "Label");

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Topic_TopicId",
                table: "Label",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Label_Topic_TopicId",
                table: "Label");

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Topic_TopicId",
                table: "Label",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
