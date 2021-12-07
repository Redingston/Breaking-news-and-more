using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class deleteUserInNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakingNews_AspNetUsers_UserId",
                table: "BreakingNews");

            migrationBuilder.DropIndex(
                name: "IX_BreakingNews_UserId",
                table: "BreakingNews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BreakingNews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BreakingNews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreakingNews_UserId",
                table: "BreakingNews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakingNews_AspNetUsers_UserId",
                table: "BreakingNews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
