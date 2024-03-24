using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Persistence.Migrations
{
    public partial class ConnectSubtaskToDoItemPKFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TargetCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subtask_ToDoItemId",
                table: "Subtask",
                column: "ToDoItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtask_ToDoItem_ToDoItemId",
                table: "Subtask",
                column: "ToDoItemId",
                principalTable: "ToDoItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtask_ToDoItem_ToDoItemId",
                table: "Subtask");

            migrationBuilder.DropTable(
                name: "ToDoItem");

            migrationBuilder.DropIndex(
                name: "IX_Subtask_ToDoItemId",
                table: "Subtask");
        }
    }
}
