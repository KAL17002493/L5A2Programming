using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L5A2Programming.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_AspNetUsers_customUserId",
                table: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "customUserId",
                table: "CommentModel",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_customUserId",
                table: "CommentModel",
                newName: "IX_CommentModel_UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CommentModel",
                newName: "customUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_UserId",
                table: "CommentModel",
                newName: "IX_CommentModel_customUserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "143d3180-1104-46f0-8646-62d630056f42",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKFO7xclI+R0L4l7GqPmc5DRqcKbjZ21N2lZDAGBtMutR4hIlRs0lzCaoHfUdNz78g==", "ebce78ee-586f-4ff4-a71f-d7fd087a56be" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_AspNetUsers_customUserId",
                table: "CommentModel",
                column: "customUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
