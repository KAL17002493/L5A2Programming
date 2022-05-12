using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Issue_TicketModelId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Assets_AssetId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Institutions_InstitutionId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Rooms_RoomId",
                table: "Issue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Issue",
                table: "Issue");

            migrationBuilder.RenameTable(
                name: "Issue",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_RoomId",
                table: "Tickets",
                newName: "IX_Tickets_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_InstitutionId",
                table: "Tickets",
                newName: "IX_Tickets_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_AssetId",
                table: "Tickets",
                newName: "IX_Tickets_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKidhUyaHx7ns/iUGG9htJbegef3ZFcDSJIfJHxasevuVd/uPjlDINXUjV1FqpPEqA==", "aa4cc223-8e8d-407c-927f-91e0063af43b" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Tickets_TicketModelId",
                table: "CommentModel",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Assets_AssetId",
                table: "Tickets",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Institutions_InstitutionId",
                table: "Tickets",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rooms_RoomId",
                table: "Tickets",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Tickets_TicketModelId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Assets_AssetId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Institutions_InstitutionId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rooms_RoomId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Issue");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_RoomId",
                table: "Issue",
                newName: "IX_Issue_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_InstitutionId",
                table: "Issue",
                newName: "IX_Issue_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_AssetId",
                table: "Issue",
                newName: "IX_Issue_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issue",
                table: "Issue",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDVlV0YvxkOCy9U5AQ31uYOCJkYa07kk9jUvhKAVoC/WM8xWCTRSH66tNTvKx1I7rw==", "75436c3c-97cd-4ffe-a6a9-caee225a514b" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Issue_TicketModelId",
                table: "CommentModel",
                column: "TicketModelId",
                principalTable: "Issue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Assets_AssetId",
                table: "Issue",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Institutions_InstitutionId",
                table: "Issue",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Rooms_RoomId",
                table: "Issue",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
