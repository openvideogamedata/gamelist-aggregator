using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddTopWinners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopWinners",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    GameTitle = table.Column<string>(type: "text", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameListId = table.Column<long>(type: "bigint", nullable: false),
                    FinalGameListId = table.Column<long>(type: "bigint", nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Citations = table.Column<int>(type: "integer", nullable: false),
                    PorcentageOfCitations = table.Column<int>(type: "integer", nullable: false),
                    FirstReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "text", nullable: false),
                    ByUser = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopWinners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopWinners_FinalGameLists_FinalGameListId",
                        column: x => x.FinalGameListId,
                        principalTable: "FinalGameLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TopWinners_GameLists_GameListId",
                        column: x => x.GameListId,
                        principalTable: "GameLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopWinners_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopWinners_FinalGameListId",
                table: "TopWinners",
                column: "FinalGameListId");

            migrationBuilder.CreateIndex(
                name: "IX_TopWinners_GameId",
                table: "TopWinners",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TopWinners_GameListId",
                table: "TopWinners",
                column: "GameListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopWinners");
        }
    }
}
