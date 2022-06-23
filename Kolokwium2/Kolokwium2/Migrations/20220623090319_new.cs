using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Teams_TeamdID",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_TeamdID",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "TeamdID",
                table: "Memberships");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_TeamID",
                table: "Memberships",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Teams_TeamID",
                table: "Memberships",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Teams_TeamID",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_TeamID",
                table: "Memberships");

            migrationBuilder.AddColumn<int>(
                name: "TeamdID",
                table: "Memberships",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_TeamdID",
                table: "Memberships",
                column: "TeamdID");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Teams_TeamdID",
                table: "Memberships",
                column: "TeamdID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
