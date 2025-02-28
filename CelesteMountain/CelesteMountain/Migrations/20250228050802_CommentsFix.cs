using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelesteMountain.Migrations
{
    public partial class CommentsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_StoryPosts_StoryPostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "StoryId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "StoryPostId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_StoryPosts_StoryPostId",
                table: "Comments",
                column: "StoryPostId",
                principalTable: "StoryPosts",
                principalColumn: "StoryPostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_StoryPosts_StoryPostId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "StoryPostId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StoryId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_StoryPosts_StoryPostId",
                table: "Comments",
                column: "StoryPostId",
                principalTable: "StoryPosts",
                principalColumn: "StoryPostId");
        }
    }
}
