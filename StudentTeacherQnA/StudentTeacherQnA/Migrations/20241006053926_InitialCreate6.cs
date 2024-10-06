using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTeacherQnA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_TeacherId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_StudentId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IDCardNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Institute",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubjectSpecialization",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Questions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AskedOn",
                table: "Questions",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_StudentId",
                table: "Questions",
                newName: "IX_Questions_UserId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Answers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AnsweredOn",
                table: "Answers",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_TeacherId",
                table: "Answers",
                newName: "IX_Answers_UserId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "Role" },
                values: new object[] { 1, "admin@qna.com", "Admin", "admin123", "Moderator" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Questions",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Questions",
                newName: "AskedOn");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                newName: "IX_Questions_StudentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Answers",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Answers",
                newName: "AnsweredOn");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                newName: "IX_Answers_TeacherId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDCardNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Institute",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectSpecialization",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_TeacherId",
                table: "Answers",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_StudentId",
                table: "Questions",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
