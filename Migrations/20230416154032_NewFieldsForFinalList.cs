using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsForFinalList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllTime",
                table: "FinalGameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsByYear",
                table: "FinalGameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConsole",
                table: "FinalGameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNintendoConsole",
                table: "FinalGameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlaystationConsole",
                table: "FinalGameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsXboxConsole",
                table: "FinalGameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAllTime",
                table: "FinalGameLists");

            migrationBuilder.DropColumn(
                name: "IsByYear",
                table: "FinalGameLists");

            migrationBuilder.DropColumn(
                name: "IsConsole",
                table: "FinalGameLists");

            migrationBuilder.DropColumn(
                name: "IsNintendoConsole",
                table: "FinalGameLists");

            migrationBuilder.DropColumn(
                name: "IsPlaystationConsole",
                table: "FinalGameLists");

            migrationBuilder.DropColumn(
                name: "IsXboxConsole",
                table: "FinalGameLists");
        }
    }
}
