namespace EduzcaServer.Services.Course.DTO
{
    public class UpdateCourseDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required bool IsPublished { get; set; } = false;
        public string? TumbnailUrl { get; set; }
    }
}
