using Microsoft.EntityFrameworkCore.Migrations;

namespace SFF.Datasource.Migrations
{
    public partial class FixedBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieStudioId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieStudioId",
                table: "Movies",
                column: "MovieStudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieStudios_MovieStudioId",
                table: "Movies",
                column: "MovieStudioId",
                principalTable: "MovieStudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieStudios_MovieStudioId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieStudioId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieStudioId",
                table: "Movies");
        }
    }
}