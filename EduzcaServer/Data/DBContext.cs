using EduzcaServer.DataContext.Maps;
using EduzcaServer.Models;
using Microsoft.EntityFrameworkCore;
namespace EduzcaServer.Data

{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             //add-migration NAME
             //update-database

            #region TABLE MAPPING
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            #endregion

            modelBuilder.HasDefaultSchema("public"); // schema configuration
            base.OnModelCreating(modelBuilder);
        }
    }
}
