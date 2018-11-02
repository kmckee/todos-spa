using Microsoft.EntityFrameworkCore.Migrations;

namespace Todos.Migrations
{
    public partial class AddTodoIdToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Todos_TodoId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "TodoId",
                value: 3);

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Todos_TodoId",
                table: "Comments",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Todos_TodoId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "TodoId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Todos_TodoId",
                table: "Comments",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
