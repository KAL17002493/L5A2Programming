using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneralTicketModelId",
                table: "Comments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "generalTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Resolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    InstitutionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_generalTickets_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEGFMaJFBAPsDlnHAREsZt8y88tcH96HUMKIbgJLVu7v6rXnbLzz3iG1U1OszyjeARg==", "8e430ad7-1b4b-4a74-8e1f-9e4809314fc1" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GeneralTicketModelId",
                table: "Comments",
                column: "GeneralTicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_generalTickets_InstitutionId",
                table: "generalTickets",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_generalTickets_GeneralTicketModelId",
                table: "Comments",
                column: "GeneralTicketModelId",
                principalTable: "generalTickets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_generalTickets_GeneralTicketModelId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "generalTickets");

            migrationBuilder.DropIndex(
                name: "IX_Comments_GeneralTicketModelId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "GeneralTicketModelId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEH0Y4oiYO6EK/LnNuZDAssetzkZvfJC6kz7qJR6UUXDerkBHP8a1dUVrCs59RJVpLQ==", "edb859f4-f1fb-4a96-a74e-86c73d992aaa" });
        }
    }
}
