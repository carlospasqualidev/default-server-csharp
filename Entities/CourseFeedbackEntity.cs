namespace Entities
{
    public class CourseFeedbackEntity
    {
        public int Id { get; set; }
        public required int CourseId { get; set; }
        public required int UserId { get; set; }
        public required int Grade { get; set; }
        public string? Commentary { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
