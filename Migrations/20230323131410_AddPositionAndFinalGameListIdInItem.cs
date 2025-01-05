using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionAndFinalGameListIdInItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FinalGameListId",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_FinalGameListId",
                table: "Items",
                column: "FinalGameListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FinalGameLists_FinalGameListId",
                table: "Items",
                column: "FinalGameListId",
                principalTable: "FinalGameLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_FinalGameLists_FinalGameListId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_FinalGameListId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FinalGameListId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Items");
        }
    }
}
