using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GradeEntityUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "Grades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Grades_OwnerUserId",
                table: "Grades",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_OwnerUserId",
                table: "Grades",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Users_OwnerUserId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_OwnerUserId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Grades");
        }
    }
}
