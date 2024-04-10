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
            #region TABLES MAPPING
            modelBuilder.ApplyConfiguration(new UserMap());
            #endregion

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
