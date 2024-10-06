using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTeacherQnA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "Role" },
                values: new object[] { 1, "admin@qna.com", "Admin", "admin123", "Moderator" });
        }
    }
}
