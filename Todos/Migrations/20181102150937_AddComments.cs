using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todos.Migrations
{
    public partial class AddComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TodoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text", "TodoId" },
                values: new object[] { 1, new DateTime(2018, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacuuming is the worst!", null });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TodoId",
                table: "Comments",
                column: "TodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
