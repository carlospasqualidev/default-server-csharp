using EduzcaServer.DataContext.Maps;
using EduzcaServer.Models;
using Microsoft.EntityFrameworkCore;
namespace EduzcaServer.Data
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TABLE MAPPING
            modelBuilder.ApplyConfiguration(new UserMap());
            #endregion

            modelBuilder.HasDefaultSchema("public"); // schema configuration
            base.OnModelCreating(modelBuilder);
        }
    }
}
