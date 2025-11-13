using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressionEvaluator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expressions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpressionString = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Result = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expressions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expressions_Result",
                table: "Expressions",
                column: "Result");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expressions");
        }
    }
}
