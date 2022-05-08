using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class Next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBSVnOsbaRxN00vTl2zbwqRGWgyjp46Q6xmfBprhtIRkY6Rx7O165RGCWKfyo6PzIQ==", "07aeb274-0508-46b2-bbcf-351ba9a600cc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEfSV/h3TxDguYYUtUrnNLdpMFJItK8wp6/foXuIfI0rAwSA3QZDikAlFjoSStX3nA==", "c0b6744b-b66c-433a-9a52-9bca5cf04fe2" });
        }
    }
}
