using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Persistence.Migrations
{
    public partial class AddPKFKUserComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_AuthorId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comment");
        }
    }
}
