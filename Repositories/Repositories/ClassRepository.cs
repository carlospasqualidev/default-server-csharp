using EduzcaServer.Data;
using EduzcaServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduzcaServer.Repositories
{
    public class ClassRepository(DBContext dbContext) : IClassRepository
    {
        private readonly DBContext _dbContext = dbContext;

        #region CREATE
        public async Task<ClassEntity> Create(ClassEntity classData)
        {
  
            await _dbContext.Classes.AddAsync(classData);
            await _dbContext.SaveChangesAsync();

             return classData;
        }
        #endregion

        #region UPDATE
        public async Task<ClassEntity> Update(ClassEntity classData)
        {
            _dbContext.Update(classData);
            await _dbContext.SaveChangesAsync();

            return classData;
        }
        #endregion

        #region FIND
        public async Task<ClassEntity> FindOne(int id)
        {
            ClassEntity? course = await _dbContext.Classes.FirstOrDefaultAsync(classData => classData.Id == id);

            return course ?? throw new Exception("Aula não encontrada na base de dados.");
        }
        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            ClassEntity classData = await FindOne(id);

            _dbContext.Remove(classData);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

    }

    #region INTERFACE
    public interface IClassRepository
    {
        public Task<ClassEntity> FindOne(int id);
        public Task<ClassEntity> Create(ClassEntity classData);
        public Task<ClassEntity> Update(ClassEntity classData);
        public Task Delete(int id);
    }
    #endregion
}
