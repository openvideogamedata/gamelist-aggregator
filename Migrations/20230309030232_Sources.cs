using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class Sources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceName",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "SourceUrl",
                table: "Items",
                newName: "SourceListUrl");

            migrationBuilder.RenameColumn(
                name: "SourceUrl",
                table: "ItemRequests",
                newName: "SourceListUrl");

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HostUrl = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SourceId",
                table: "Items",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Sources_SourceId",
                table: "Items",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Sources_SourceId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropIndex(
                name: "IX_Items_SourceId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "SourceListUrl",
                table: "Items",
                newName: "SourceUrl");

            migrationBuilder.RenameColumn(
                name: "SourceListUrl",
                table: "ItemRequests",
                newName: "SourceUrl");

            migrationBuilder.AddColumn<string>(
                name: "SourceName",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
