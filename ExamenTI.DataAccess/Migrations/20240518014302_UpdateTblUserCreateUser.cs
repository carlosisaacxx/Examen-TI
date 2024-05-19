using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenTI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblUserCreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblClient_clientId",
                table: "tblUser");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_clientId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "clientId",
                table: "tblUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateUser",
                table: "tblUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "tblUser");

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "tblUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_clientId",
                table: "tblUser",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblClient_clientId",
                table: "tblUser",
                column: "clientId",
                principalTable: "tblClient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
