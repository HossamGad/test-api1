using Microsoft.EntityFrameworkCore.Migrations;

namespace SFF.Datasource.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfMaxSimultaneouslyRented = table.Column<int>(nullable: false),
                    IsRented = table.Column<bool>(nullable: false),
                    NumberOfCurrentlyRented = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieStudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTrivias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieStudioId = table.Column<int>(nullable: true),
                    MovieId = table.Column<int>(nullable: true),
                    ReviewSummary = table.Column<string>(nullable: true),
                    ReviewScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTrivias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTrivias_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieTrivias_MovieStudios_MovieStudioId",
                        column: x => x.MovieStudioId,
                        principalTable: "MovieStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTrivias_MovieId",
                table: "MovieTrivias",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTrivias_MovieStudioId",
                table: "MovieTrivias",
                column: "MovieStudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTrivias");

            migrationBuilder.DropTable(
                name: "MovieStudios");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}