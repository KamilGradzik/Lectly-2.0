using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ClassSessionUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "ClassSessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_OwnerUserId",
                table: "ClassSessions",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSessions_Users_OwnerUserId",
                table: "ClassSessions",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSessions_Users_OwnerUserId",
                table: "ClassSessions");

            migrationBuilder.DropIndex(
                name: "IX_ClassSessions_OwnerUserId",
                table: "ClassSessions");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "ClassSessions");
        }
    }
}
