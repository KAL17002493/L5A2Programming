using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class DbSet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEFn4z+P8wo0MW1Iw52ziO0WBgkrUBeLvN1wsGiuRjoXxdups6AvMGhoQy+9xvOtNvA==", "c0735dea-60ba-4925-bbbb-786f14de8714" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEP8BpUBsL+AFsbZMjQjzOhfTVdsPtRh3bbxTV5xl0G+mZ7B+mklh7Iyc2vJDjWagRA==", "2a2c1134-39f5-468d-810d-3ba820b60a3e" });
        }
    }
}
