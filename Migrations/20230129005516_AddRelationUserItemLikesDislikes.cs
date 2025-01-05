using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationUserItemLikesDislikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRequests");

            migrationBuilder.CreateTable(
                name: "UserDislikedItem",
                columns: table => new
                {
                    ItemsDislikedId = table.Column<long>(type: "bigint", nullable: false),
                    UsersDislikedId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDislikedItem", x => new { x.ItemsDislikedId, x.UsersDislikedId });
                    table.ForeignKey(
                        name: "FK_UserDislikedItem_ItemRequests_ItemsDislikedId",
                        column: x => x.ItemsDislikedId,
                        principalTable: "ItemRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDislikedItem_Users_UsersDislikedId",
                        column: x => x.UsersDislikedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikedItem",
                columns: table => new
                {
                    ItemsLikedId = table.Column<long>(type: "bigint", nullable: false),
                    UsersLikedId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedItem", x => new { x.ItemsLikedId, x.UsersLikedId });
                    table.ForeignKey(
                        name: "FK_UserLikedItem_ItemRequests_ItemsLikedId",
                        column: x => x.ItemsLikedId,
                        principalTable: "ItemRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikedItem_Users_UsersLikedId",
                        column: x => x.UsersLikedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikedItem_UsersDislikedId",
                table: "UserDislikedItem",
                column: "UsersDislikedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedItem_UsersLikedId",
                table: "UserLikedItem",
                column: "UsersLikedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDislikedItem");

            migrationBuilder.DropTable(
                name: "UserLikedItem");

            migrationBuilder.CreateTable(
                name: "GameRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dislike = table.Column<long>(type: "bigint", nullable: false),
                    Like = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRequests", x => x.Id);
                });
        }
    }
}
