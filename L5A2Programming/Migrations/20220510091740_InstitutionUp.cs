using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class InstitutionUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Institutions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Institutions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAENcBqSNtQS9U4hX9wqIeka2l4Q4QsTUjmKXCT6HeSM53WAIU8mKnrpV/VLRUVGFaIQ==", "d8d7a3e3-c8b3-43d8-91e4-ef9e8006c82a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Institutions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEZlHrZ0Z7EiR6XQvq6m1lDh2jidyHmIkAa1wQk3KdjobywesbSA5FHY8Gyj6aQbMA==", "9a271f2e-59ea-444d-a252-621b2c565137" });
        }
    }
}
