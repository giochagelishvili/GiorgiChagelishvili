using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Persistence.Migrations
{
    public partial class ConnectToDoItemUserFKPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ToDoItem_OwnerId",
                table: "ToDoItem",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItem_Users_OwnerId",
                table: "ToDoItem",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItem_Users_OwnerId",
                table: "ToDoItem");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItem_OwnerId",
                table: "ToDoItem");
        }
    }
}
