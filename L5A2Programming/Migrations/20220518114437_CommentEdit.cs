using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class CommentEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEM/sG9aYox10chxwbPfaMa+27eZVOnPNwW4OB8fIP5Dw9gPDVMS4/pCiSnv5HBq7zQ==", "d20b2905-20ce-4905-9405-28d9c84b52cf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEL+8bD5ChS//igI/1GpkCsjSBkaEkD4kDK30tADBXWhWtS469F7od8OUBJmraTdaEQ==", "4c8f1d1b-983e-45ce-9fae-2c943321674a" });
        }
    }
}
