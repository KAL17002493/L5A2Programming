using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class sidelines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEfSV/h3TxDguYYUtUrnNLdpMFJItK8wp6/foXuIfI0rAwSA3QZDikAlFjoSStX3nA==", "c0b6744b-b66c-433a-9a52-9bca5cf04fe2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKNaf4KZOyLv4kYvrPJGTe7f8IFQ7Q/EttKrx5ltG2tz4kKIfSYMI4+KTNISTV1gOA==", "7a65b8b5-0fca-45c7-91ba-ac75d31cadd5" });
        }
    }
}
