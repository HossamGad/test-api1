using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SFF_Api_App.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trivias_Movies_MovieId",
                table: "Trivias");

            migrationBuilder.DropIndex(
                name: "IX_Trivias_MovieId",
                table: "Trivias");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Trivias");

            migrationBuilder.AddColumn<bool>(
                name: "MaxStock",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxStudios",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TriviasId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRented = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    StudioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "DateRented", "MovieId", "StudioId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Grade", "MovieId" },
                values: new object[,]
                {
                    { 1, 5, 2 },
                    { 2, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trivias",
                columns: new[] { "Id", "ReviewId", "Title" },
                values: new object[,]
                {
                    { 1, null, "Trivias 1" },
                    { 2, null, "Trivias 2" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxStudios", "ReviewId", "TriviasId" },
                values: new object[] { 5, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxStudios", "ReviewId", "TriviasId" },
                values: new object[] { 5, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxStudios", "ReviewId", "TriviasId" },
                values: new object[] { 5, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TriviasId",
                table: "Movies",
                column: "TriviasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MovieId",
                table: "Rentals",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_StudioId",
                table: "Rentals",
                column: "StudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Trivias_TriviasId",
                table: "Movies",
                column: "TriviasId",
                principalTable: "Trivias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Trivias_TriviasId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Movies_TriviasId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trivias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trivias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "MaxStock",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MaxStudios",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TriviasId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Trivias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trivias_MovieId",
                table: "Trivias",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trivias_Movies_MovieId",
                table: "Trivias",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
