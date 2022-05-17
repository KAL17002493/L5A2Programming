using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class Inst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEINHMunAzLMw6VqoXfcfkp/XRWI/06czbe9lea/sRjYhPr21pMz/E0+K6F9rQD7F3w==", "18447612-fcdf-4d45-8f98-eec55c334eda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEGoFFpzUKPLY3muGIXO0t/Ud4VyYbP5iLCCYrj1GOSpC3s1FXFN05dKmTqfi3Iha7w==", "5b6da102-9024-4f3a-b3e6-0416404b92cd" });
        }
    }
}
