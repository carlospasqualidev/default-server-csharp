using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduzcaServer.DataContext.Maps
{
    public class CourseMap : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.HasKey(course => course.Id);
            builder.Property(course => course.OwnerId);
            builder.Property(course => course.Name).IsRequired();
            builder.Property(course => course.TumbnailUrl);
            builder.Property(course => course.Description);
            builder.Property(course => course.IsPublished).IsRequired();
            builder.Property(course => course.UpdatedAt).IsRequired();
            builder.Property(course => course.CreatedAt).IsRequired();
            builder.Property(course => course.GradeAvg);
            builder.Property(course => course.TotalFeedbacks);
            builder.HasOne(course => course.Owner)
            .WithMany()
            .HasForeignKey(course => course.OwnerId);
            builder.HasMany(course => course.Feedbacks)
            .WithOne()
            .HasForeignKey(feedback => feedback.CourseId);
        }
    }
}


