namespace Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public required int OwnerId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsPublished { get; set; } = false;
        public string? TumbnailUrl { get; set; }
        public UserEntity? Owner { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
