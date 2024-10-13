using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoLayer.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "LeaveDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveDetails_RoleId",
                table: "LeaveDetails",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveDetails_Roles_RoleId",
                table: "LeaveDetails",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveDetails_Roles_RoleId",
                table: "LeaveDetails");

            migrationBuilder.DropIndex(
                name: "IX_LeaveDetails_RoleId",
                table: "LeaveDetails");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "LeaveDetails");
        }
    }
}
