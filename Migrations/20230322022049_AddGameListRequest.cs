using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddGameListRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Sources_SourceId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserContributedId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDislikedItem_ItemRequests_ItemsDislikedId",
                table: "UserDislikedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedItem_ItemRequests_ItemsLikedId",
                table: "UserLikedItem");

            migrationBuilder.DropTable(
                name: "ItemRequests");

            migrationBuilder.DropIndex(
                name: "IX_Items_SourceId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserContributedId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SourceListUrl",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserContributedId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Pinned",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "GameLists");

            migrationBuilder.RenameColumn(
                name: "ItemsLikedId",
                table: "UserLikedItem",
                newName: "GameListRequestsLikedId");

            migrationBuilder.RenameColumn(
                name: "ItemsDislikedId",
                table: "UserDislikedItem",
                newName: "GameListRequestsDislikedId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "GameLists",
                newName: "SourceListUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "GameLists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "FinalGameListId",
                table: "GameLists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "GameLists",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserContributedId",
                table: "GameLists",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinalGameLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    Pinned = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalGameLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameListRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameTitle = table.Column<string>(type: "text", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    SourceListUrl = table.Column<string>(type: "text", nullable: false),
                    SourceName = table.Column<string>(type: "text", nullable: false),
                    HostUrl = table.Column<string>(type: "text", nullable: false),
                    FinalGameListId = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserPostedId = table.Column<long>(type: "bigint", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameListRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameListRequests_FinalGameLists_FinalGameListId",
                        column: x => x.FinalGameListId,
                        principalTable: "FinalGameLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameListRequests_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameListRequests_Users_UserPostedId",
                        column: x => x.UserPostedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameLists_FinalGameListId",
                table: "GameLists",
                column: "FinalGameListId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLists_SourceId",
                table: "GameLists",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_GameLists_UserContributedId",
                table: "GameLists",
                column: "UserContributedId");

            migrationBuilder.CreateIndex(
                name: "IX_GameListRequests_FinalGameListId",
                table: "GameListRequests",
                column: "FinalGameListId");

            migrationBuilder.CreateIndex(
                name: "IX_GameListRequests_GameId",
                table: "GameListRequests",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameListRequests_UserPostedId",
                table: "GameListRequests",
                column: "UserPostedId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLists_FinalGameLists_FinalGameListId",
                table: "GameLists",
                column: "FinalGameListId",
                principalTable: "FinalGameLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLists_Sources_SourceId",
                table: "GameLists",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameLists_Users_UserContributedId",
                table: "GameLists",
                column: "UserContributedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDislikedItem_GameListRequests_GameListRequestsDislikedId",
                table: "UserDislikedItem",
                column: "GameListRequestsDislikedId",
                principalTable: "GameListRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedItem_GameListRequests_GameListRequestsLikedId",
                table: "UserLikedItem",
                column: "GameListRequestsLikedId",
                principalTable: "GameListRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameLists_FinalGameLists_FinalGameListId",
                table: "GameLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLists_Sources_SourceId",
                table: "GameLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GameLists_Users_UserContributedId",
                table: "GameLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDislikedItem_GameListRequests_GameListRequestsDislikedId",
                table: "UserDislikedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedItem_GameListRequests_GameListRequestsLikedId",
                table: "UserLikedItem");

            migrationBuilder.DropTable(
                name: "GameListRequests");

            migrationBuilder.DropTable(
                name: "FinalGameLists");

            migrationBuilder.DropIndex(
                name: "IX_GameLists_FinalGameListId",
                table: "GameLists");

            migrationBuilder.DropIndex(
                name: "IX_GameLists_SourceId",
                table: "GameLists");

            migrationBuilder.DropIndex(
                name: "IX_GameLists_UserContributedId",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "FinalGameListId",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "GameLists");

            migrationBuilder.DropColumn(
                name: "UserContributedId",
                table: "GameLists");

            migrationBuilder.RenameColumn(
                name: "GameListRequestsLikedId",
                table: "UserLikedItem",
                newName: "ItemsLikedId");

            migrationBuilder.RenameColumn(
                name: "GameListRequestsDislikedId",
                table: "UserDislikedItem",
                newName: "ItemsDislikedId");

            migrationBuilder.RenameColumn(
                name: "SourceListUrl",
                table: "GameLists",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceListUrl",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserContributedId",
                table: "Items",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Pinned",
                table: "GameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "GameLists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "GameLists",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameListId = table.Column<long>(type: "bigint", nullable: false),
                    UserPostedId = table.Column<long>(type: "bigint", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GameTitle = table.Column<string>(type: "text", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    HostUrl = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    SourceListUrl = table.Column<string>(type: "text", nullable: false),
                    SourceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRequests_GameLists_GameListId",
                        column: x => x.GameListId,
                        principalTable: "GameLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequests_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequests_Users_UserPostedId",
                        column: x => x.UserPostedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SourceId",
                table: "Items",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserContributedId",
                table: "Items",
                column: "UserContributedId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequests_GameId",
                table: "ItemRequests",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequests_GameListId",
                table: "ItemRequests",
                column: "GameListId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequests_UserPostedId",
                table: "ItemRequests",
                column: "UserPostedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Sources_SourceId",
                table: "Items",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserContributedId",
                table: "Items",
                column: "UserContributedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDislikedItem_ItemRequests_ItemsDislikedId",
                table: "UserDislikedItem",
                column: "ItemsDislikedId",
                principalTable: "ItemRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedItem_ItemRequests_ItemsLikedId",
                table: "UserLikedItem",
                column: "ItemsLikedId",
                principalTable: "ItemRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
