﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddAutomaticallyGivenToBadges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutomaticallyGiven",
                table: "Badges",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutomaticallyGiven",
                table: "Badges");
        }
    }
}
