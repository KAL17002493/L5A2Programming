using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ecfbe7ad-bb6b-49e6-ac2b-6359a73fbf02", "68144efc-092a-403e-a7fe-3c276de06a72", "Institution manager", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEEGKoqlkzcj/YpOcj6IMl1im+iaL2tJEP/dtv462ozhHI5/GCzv6VI2nH5P3vImLg==", "bddad282-5daa-4080-a4f5-c999054a4f4a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecfbe7ad-bb6b-49e6-ac2b-6359a73fbf02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEM75vdXX8bo4hXSqjemQtovKA4A6tBGFnDO+/yv8tY9o5hyLtFxYxI3CamDmaVHG7w==", "0942475b-ed10-4832-ba9b-2cd56987f5de" });
        }
    }
}
