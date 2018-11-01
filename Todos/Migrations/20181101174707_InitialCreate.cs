using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TodoId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTopics_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Take out garbage" },
                    { 2, "Clean the mug" },
                    { 3, "Vacuum" },
                    { 4, "Wash the whiteboards" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Home" }
                });

            migrationBuilder.InsertData(
                table: "TodoTopics",
                columns: new[] { "Id", "TodoId", "TopicId" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 5, 4, 1 },
                    { 1, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 3, 2 },
                    { 6, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoTopics_TodoId",
                table: "TodoTopics",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTopics_TopicId",
                table: "TodoTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTopics");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
