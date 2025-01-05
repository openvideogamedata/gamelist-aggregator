using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class StatusDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackStatusDate",
                table: "GameUserTrackers",
                newName: "StatusDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "GameUserTrackers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "GameUserTrackers");

            migrationBuilder.RenameColumn(
                name: "StatusDate",
                table: "GameUserTrackers",
                newName: "TrackStatusDate");
        }
    }
}
