using Microsoft.EntityFrameworkCore.Migrations;

namespace lab24version3.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Runtime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "Runtime", "Title" },
                values: new object[,]
                {
                    { 1, "Action", 60.0, "King Kong" },
                    { 2, "Drama", 180.0, "Designated Survivor" },
                    { 3, "Action", 60.0, "Angel Has Fallen" },
                    { 4, "Action", 60.0, "Drive" },
                    { 5, "Romance", 90.0, "Lovebirds" },
                    { 6, "Romance", 120.0, "Possession" },
                    { 7, "Drama", 60.0, "Help" },
                    { 8, "Drama", 80.0, "Firm" },
                    { 9, "Drama", 60.0, "Burning" },
                    { 10, "Drama", 60.0, "There Will Be Blood" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
