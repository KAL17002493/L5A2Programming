using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class Victor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEB/6ipkW844+rSKEw7Mk6b8C6NQWz5YW/ZklhlxdEUpsreQfv/qlOjyJ4LvjQ5DUlA==", "4734d103-92f1-4269-a49c-9a43cfb93f24" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAENw9LHcC95rVFYK1h97SGvGcVy+ZhnNJuqwSCdboWxMETH7yp+rJQlrP7JAdvnfcAQ==", "4c96a845-f72c-43fe-97ff-a2ae494c97ab" });
        }
    }
}
