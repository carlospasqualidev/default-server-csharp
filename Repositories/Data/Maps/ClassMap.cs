using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EduzcaServer.Entities;

namespace EduzcaServer.Data.Maps
{
    public class ClassMap : IEntityTypeConfiguration<ClassEntity>
    {
        public void Configure(EntityTypeBuilder<ClassEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Order).IsRequired();
            builder.Property(x => x.Text);
            builder.Property(x => x.VideoUrl);
            builder.Property(x => x.CourseId).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();  
        }
    }
}




