using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace Repositories.Data.Maps
{
    public class CourseFeedbackMap: IEntityTypeConfiguration<CourseFeedbackEntity>
    {
        public void Configure(EntityTypeBuilder<CourseFeedbackEntity> builder)
        {
            builder.HasKey(courseFeedback => courseFeedback.Id);
            builder.Property(courseFeedback => courseFeedback.CourseId).IsRequired();
            builder.Property(courseFeedback => courseFeedback.UserId).IsRequired();
            builder.Property(courseFeedback => courseFeedback.UserId).IsRequired();
            builder.Property(courseFeedback => courseFeedback.Grade).IsRequired();
            builder.Property(courseFeedback => courseFeedback.Commentary);
            builder.Property(courseFeedback => courseFeedback.UpdatedAt).IsRequired();
            builder.Property(courseFeedback => courseFeedback.CreatedAt).IsRequired();
        }
    }
}
