﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class PinnedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pinned",
                table: "GameLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pinned",
                table: "GameLists");
        }
    }
}
