using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelesteMountain.Migrations
{
    public partial class userStorys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "StoryPosts");

            migrationBuilder.AddColumn<string>(
                name: "PosterId",
                table: "StoryPosts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StoryPosts_PosterId",
                table: "StoryPosts",
                column: "PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryPosts_AspNetUsers_PosterId",
                table: "StoryPosts",
                column: "PosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoryPosts_AspNetUsers_PosterId",
                table: "StoryPosts");

            migrationBuilder.DropIndex(
                name: "IX_StoryPosts_PosterId",
                table: "StoryPosts");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "StoryPosts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StoryPosts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
