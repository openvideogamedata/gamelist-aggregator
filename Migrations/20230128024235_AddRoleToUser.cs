using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "NameIdentifier",
                keyValue: "113305493029026011009",
                column: "Role",
                value: "admin" 
            );
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "NameIdentifier",
                keyValue: "105263319681031680790",
                column: "Role",
                value: "admin" 
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
