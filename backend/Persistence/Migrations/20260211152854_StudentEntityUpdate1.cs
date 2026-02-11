using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentEntityUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassGroups_GroupId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Students",
                newName: "OwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                newName: "IX_Students_OwnerUserId");

            migrationBuilder.CreateTable(
                name: "GroupsStudents",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsStudents", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GroupsStudents_ClassGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ClassGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupsStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsStudents_StudentId",
                table: "GroupsStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_OwnerUserId",
                table: "Students",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_OwnerUserId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "GroupsStudents");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Students",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_OwnerUserId",
                table: "Students",
                newName: "IX_Students_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassGroups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "ClassGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
