using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab24version3.Data.Migrations
{
    public partial class checkoutmovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckedOutMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIDId = table.Column<string>(nullable: true),
                    MovieIDId = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedOutMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckedOutMovies_Movies_MovieIDId",
                        column: x => x.MovieIDId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckedOutMovies_AspNetUsers_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckedOutMovies_MovieIDId",
                table: "CheckedOutMovies",
                column: "MovieIDId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckedOutMovies_UserIDId",
                table: "CheckedOutMovies",
                column: "UserIDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckedOutMovies");
        }
    }
}
