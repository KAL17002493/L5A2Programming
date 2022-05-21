using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class dataasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJJdNcGSwVKFe1WrFjVOTxtkLG2IXk2VFKTMljCCxCDVNqH4koEl7KWz2rHVri1eug==", "6b30e706-faa5-4ce9-b7eb-c427d2fc4fc3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEGFMaJFBAPsDlnHAREsZt8y88tcH96HUMKIbgJLVu7v6rXnbLzz3iG1U1OszyjeARg==", "8e430ad7-1b4b-4a74-8e1f-9e4809314fc1" });
        }
    }
}
