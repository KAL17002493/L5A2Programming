using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDyloPJLY5IJ3xfhniw9fwMgNJ3TtDDJc7R3Nprkfl0LV2WT6MY0g7L0Idt4+rfWdA==", "00409f47-1249-4f75-b8ef-1e46ac8c443e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEsCcv9sZ4K721Qp7vuCvQxcNRoSap0Wti2OH1kPTG9L/fDYeKkf1AuD91ZuOgTkrQ==", "4e0b2872-f36a-4e08-bd4e-391107ce72c7" });
        }
    }
}
