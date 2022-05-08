using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class CategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJPrkV5JGo5rU2yKLbJR8xp68Kf48TK1nA8qxgkxn/NdnuWP7l9CyiH3cBgLLii34A==", "0f644694-3475-4370-ace7-60a3ccadfaae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBW92mzp5r0hEcWN9ezKnPmeTwli+1XNlwF1jG128lYR1wPbG9/I90GBaluELR3GQA==", "d2cee469-2c4f-427e-8847-7edc7c85f5cb" });
        }
    }
}
