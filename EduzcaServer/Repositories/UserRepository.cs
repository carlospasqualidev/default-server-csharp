using EduzcaServer.Data;
using EduzcaServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EduzcaServer.Repositories
{
   
    public class UserRepository(DBContext dbContext) : IUserRepository
    {
        private readonly DBContext _dbContext = dbContext;

        #region CREATE
        public async Task<UserEntity> Create(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        #endregion
       
        #region UPDATE
        public async Task<UserEntity> Update(UserEntity user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        #endregion

        #region FIND
        public async Task<List<UserEntity>> FindAll() => await _dbContext.Users.ToListAsync();

        public async Task<UserEntity> FindOne(int id)
        {
            UserEntity? dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            return dbUser ?? throw new Exception("Usuário não encontrado na base de dados.");
        }
        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            UserEntity dbUser = await FindOne(id);

            _dbContext.Remove(dbUser);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
    #region INTERFACE
    public interface IUserRepository
    {
        public Task<List<UserEntity>> FindAll();
        public Task<UserEntity> FindOne(int id);
        public Task<UserEntity> Create(UserEntity user);
        public Task<UserEntity> Update(UserEntity user);
        public Task Delete(int id);
    }
    #endregion
}

