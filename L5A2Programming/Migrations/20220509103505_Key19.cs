using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class Key19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Institutions_InstitutionId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_InstitutionId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Assets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAELFk2gCzXwDD/GRvAfQ3TLMOloV2RkXfJcrLzcyF8phN70Zbjda0GBgfZWMpBBEqoA==", "0017cc60-7e3b-4ca6-811d-30098f671be9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEB/6ipkW844+rSKEw7Mk6b8C6NQWz5YW/ZklhlxdEUpsreQfv/qlOjyJ4LvjQ5DUlA==", "4734d103-92f1-4269-a49c-9a43cfb93f24" });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_InstitutionId",
                table: "Assets",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Institutions_InstitutionId",
                table: "Assets",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
