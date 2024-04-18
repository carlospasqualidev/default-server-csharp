namespace EduzcaServer.Entities
{
    public class ClassEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Order { get; set; }
        public string? Text { get; set; }
        public string? VideoUrl { get; set; }
        public int CourseId { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
