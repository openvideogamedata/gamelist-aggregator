using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatinumCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Platinum",
                table: "GameUserTrackers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platinum",
                table: "GameUserTrackers");
        }
    }
}
