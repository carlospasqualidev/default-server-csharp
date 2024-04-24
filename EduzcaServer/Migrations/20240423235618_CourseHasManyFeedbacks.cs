using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controllers.Migrations
{
    /// <inheritdoc />
    public partial class CourseHasManyFeedbacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseFeedbacks_CourseId",
                schema: "public",
                table: "CourseFeedbacks",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFeedbacks_Courses_CourseId",
                schema: "public",
                table: "CourseFeedbacks",
                column: "CourseId",
                principalSchema: "public",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseFeedbacks_Courses_CourseId",
                schema: "public",
                table: "CourseFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_CourseFeedbacks_CourseId",
                schema: "public",
                table: "CourseFeedbacks");
        }
    }
}
