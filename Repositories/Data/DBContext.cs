using EduzcaServer.Data.Maps;
using EduzcaServer.DataContext.Maps;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Data.Maps;
namespace EduzcaServer.Data

{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<CourseFeedbackEntity> CourseFeedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             //add-migration NAME
             //update-database

            #region TABLE MAPPING
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new CourseFeedbackMap());
            #endregion

            modelBuilder.HasDefaultSchema("public"); // schema configuration
            base.OnModelCreating(modelBuilder);
        }
    }
}
