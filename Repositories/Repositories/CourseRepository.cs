using EduzcaServer.Data;
using EduzcaServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EduzcaServer.Repositories
{
    public class CourseRepository(DBContext dbContext) : ICourseRepository
    {
        private readonly DBContext _dbContext = dbContext;

        #region CREATE
        public async Task<CourseEntity> Create(CourseEntity course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return course;
        }
        #endregion

        #region UPDATE
        public async Task<CourseEntity> Update(CourseEntity course)
        {
            _dbContext.Update(course);
            await _dbContext.SaveChangesAsync();

            return course;
        }
        #endregion

        #region FIND
        public async Task<List<CourseEntity>> FindAll() => await _dbContext.Courses.Include(user=> user.Owner).ToListAsync();

        public async Task<CourseEntity> FindOne(int id)
        {
            CourseEntity? course = await _dbContext.Courses.FirstOrDefaultAsync(course => course.Id == id);

            return course ?? throw new Exception("Curso não encontrado na base de dados.");
        }
        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            CourseEntity course = await FindOne(id);

            _dbContext.Remove(course);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

    }

    #region INTERFACE
    public interface ICourseRepository
    {
        public Task<List<CourseEntity>> FindAll();
        public Task<CourseEntity> FindOne(int id);
        public Task<CourseEntity> Create(CourseEntity user);
        public Task<CourseEntity> Update(CourseEntity user);
        public Task Delete(int id);
    }
    #endregion
}
