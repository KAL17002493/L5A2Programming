using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class Next2 : Migration
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
                values: new object[] { "AQAAAAEAACcQAAAAEEMcUMdIW739rKFPFZNuB8d7Zw+eBp1Z5g9IxTRWTHwbUq4+u8GLS9Q+y6+6Seg7jw==", "c59eb395-327d-4514-9419-a8dd2f1cdeb4" });
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
                values: new object[] { "AQAAAAEAACcQAAAAEBSVnOsbaRxN00vTl2zbwqRGWgyjp46Q6xmfBprhtIRkY6Rx7O165RGCWKfyo6PzIQ==", "07aeb274-0508-46b2-bbcf-351ba9a600cc" });

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
