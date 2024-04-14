namespace EduzcaServer.Services.Course.DTO
{
    public class CreateCourseDTO
    {
        public required string Name { get; set; }
        public required int OwnerId { get; set; }
        public string? TumbnailUrl { get; set; }
    }
}
