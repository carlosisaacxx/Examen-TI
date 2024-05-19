using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenTI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesExtra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "tblClient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "tblClient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "tblClient",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "tblArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblClientArticle",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClientArticle", x => new { x.ClientId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_tblClientArticle_tblArticle_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "tblArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblClientArticle_tblClient_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblArticleStore",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblArticleStore", x => new { x.ArticleId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_tblArticleStore_tblArticle_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "tblArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblArticleStore_tblStore_StoreId",
                        column: x => x.StoreId,
                        principalTable: "tblStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblArticleStore_StoreId",
                table: "tblArticleStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClientArticle_ArticleId",
                table: "tblClientArticle",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblArticleStore");

            migrationBuilder.DropTable(
                name: "tblClientArticle");

            migrationBuilder.DropTable(
                name: "tblStore");

            migrationBuilder.DropTable(
                name: "tblArticle");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "tblClient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "tblClient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "tblClient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
