using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class Ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecfbe7ad-bb6b-49e6-ac2b-6359a73fbf02",
                column: "Name",
                value: "Institution Manager");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEH0Y4oiYO6EK/LnNuZDAssetzkZvfJC6kz7qJR6UUXDerkBHP8a1dUVrCs59RJVpLQ==", "edb859f4-f1fb-4a96-a74e-86c73d992aaa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecfbe7ad-bb6b-49e6-ac2b-6359a73fbf02",
                column: "Name",
                value: "Institution manager");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEBQ3URvt7GGNlNwMjpgSlv26q0Y9s6Cakpq3hY/w6yOl6bC8nrrvQqXa1k8tPKQIw==", "59b7d8a4-0c65-4a53-8918-038205608588" });
        }
    }
}
