using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controllers.Migrations
{
    /// <inheritdoc />
    public partial class AddGraceAvgAndTotalFeedbacksOnCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "GradeAvg",
                schema: "public",
                table: "Courses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TotalFeedbacks",
                schema: "public",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeAvg",
                schema: "public",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TotalFeedbacks",
                schema: "public",
                table: "Courses");
        }
    }
}
