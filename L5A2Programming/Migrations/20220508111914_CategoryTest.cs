using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class CategoryTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKNaf4KZOyLv4kYvrPJGTe7f8IFQ7Q/EttKrx5ltG2tz4kKIfSYMI4+KTNISTV1gOA==", "7a65b8b5-0fca-45c7-91ba-ac75d31cadd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJPrkV5JGo5rU2yKLbJR8xp68Kf48TK1nA8qxgkxn/NdnuWP7l9CyiH3cBgLLii34A==", "0f644694-3475-4370-ace7-60a3ccadfaae" });
        }
    }
}
