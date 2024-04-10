using EduzcaServer.Data;
using EduzcaServer.Models;
using EduzcaServer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduzcaServer.Repositories
{
    public class UserRepository(DBContext dbContext) : IUserRepository
    {
        private readonly DBContext _dbContext = dbContext;

        public async Task<List<UserEntity>> FindAll() => await _dbContext.Users.ToListAsync();

        public async Task<UserEntity> FindOne(int id)
        {
            UserEntity?  dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            
            return dbUser ?? throw new Exception("Usuário não encontrado na base de dados.");
        }

        public async Task<UserEntity> Create(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserEntity> Update(int id, UserEntity user)
        {
            UserEntity dbUser = await FindOne(id);

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.Password = user.Password;

            _dbContext.Update(dbUser);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            UserEntity dbUser = await FindOne(id);

            _dbContext.Remove(dbUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}

