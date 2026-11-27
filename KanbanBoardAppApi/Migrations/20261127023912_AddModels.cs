using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanbanBoardAppApi.Migrations;

/// <inheritdoc />
public partial class _20261127023912_AddModels : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Boards",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Boards", x => x.Id);
                table.ForeignKey(
                    name: "FK_Boards_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Columns",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Position = table.Column<double>(type: "float", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Columns", x => x.Id);
                table.ForeignKey(
                    name: "FK_Columns_Boards_BoardId",
                    column: x => x.BoardId,
                    principalTable: "Boards",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BoardTasks",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                Position = table.Column<double>(type: "float", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BoardTasks", x => x.Id);
                table.ForeignKey(
                    name: "FK_BoardTasks_Columns_ColumnId",
                    column: x => x.ColumnId,
                    principalTable: "Columns",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Subtasks",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                BoardTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                Position = table.Column<double>(type: "float", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Subtasks", x => x.Id);
                table.ForeignKey(
                    name: "FK_Subtasks_BoardTasks_BoardTaskId",
                    column: x => x.BoardTaskId,
                    principalTable: "BoardTasks",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Boards_UserId",
            table: "Boards",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_BoardTasks_ColumnId_Position",
            table: "BoardTasks",
            columns: new[] { "ColumnId", "Position" });

        migrationBuilder.CreateIndex(
            name: "IX_Columns_BoardId_Position",
            table: "Columns",
            columns: new[] { "BoardId", "Position" });

        migrationBuilder.CreateIndex(
            name: "IX_Subtasks_BoardTaskId_Position",
            table: "Subtasks",
            columns: new[] { "BoardTaskId", "Position" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Subtasks");

        migrationBuilder.DropTable(
            name: "BoardTasks");

        migrationBuilder.DropTable(
            name: "Columns");

        migrationBuilder.DropTable(
            name: "Boards");
    }
}
