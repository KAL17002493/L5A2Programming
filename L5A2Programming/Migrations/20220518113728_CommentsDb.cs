using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class CommentsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Tickets_TicketModelId",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_TicketModelId",
                table: "Comments",
                newName: "IX_Comments_TicketModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEL+8bD5ChS//igI/1GpkCsjSBkaEkD4kDK30tADBXWhWtS469F7od8OUBJmraTdaEQ==", "4c8f1d1b-983e-45ce-9fae-2c943321674a" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketModelId",
                table: "Comments",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketModelId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentModel");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "CommentModel",
                newName: "IX_CommentModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TicketModelId",
                table: "CommentModel",
                newName: "IX_CommentModel_TicketModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEHy2n3E9w+jJYci98g8seEmMLJXpOAYmFe6MqgJhaOtaaCrvPRMUPtU/FKfv8yWMgA==", "3f69db73-af82-4110-be00-a51dfc29a649" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Tickets_TicketModelId",
                table: "CommentModel",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
