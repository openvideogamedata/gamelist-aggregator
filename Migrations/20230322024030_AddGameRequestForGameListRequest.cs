using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddGameRequestForGameListRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameListRequests_Games_GameId",
                table: "GameListRequests");

            migrationBuilder.DropIndex(
                name: "IX_GameListRequests_GameId",
                table: "GameListRequests");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameListRequests");

            migrationBuilder.DropColumn(
                name: "GameTitle",
                table: "GameListRequests");

            migrationBuilder.CreateTable(
                name: "GameRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    GameTitle = table.Column<string>(type: "text", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameListRequestId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRequests_GameListRequests_GameListRequestId",
                        column: x => x.GameListRequestId,
                        principalTable: "GameListRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRequests_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRequests_GameId",
                table: "GameRequests",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRequests_GameListRequestId",
                table: "GameRequests",
                column: "GameListRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRequests");

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "GameListRequests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "GameTitle",
                table: "GameListRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GameListRequests_GameId",
                table: "GameListRequests",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameListRequests_Games_GameId",
                table: "GameListRequests",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
