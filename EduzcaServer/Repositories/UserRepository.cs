using EduzcaServer.Data;
using EduzcaServer.Models;
using EduzcaServer.Services.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace EduzcaServer.Repositories
{
   
    public class UserRepository(DBContext dbContext) : IUserRepository
    {
        private readonly DBContext _dbContext = dbContext;

        #region CREATE
        public async Task<UserEntity> Create(UserEntity user)
        {
            IsValidEmail(user.Email);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        #endregion
       
        #region UPDATE
        public async Task<UserEntity> Update(UserEntity user)
        {
            IsValidEmail(user.Email);

            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        #endregion

        #region FIND
        public async Task<List<UserEntity>> FindAll() => await _dbContext.Users.ToListAsync();

        public async Task<UserEntity> FindOne(int id)
        {
           // UserEntity? dbUser = await _dbContext.Users.Include(course=> course.Courses).FirstOrDefaultAsync(user => user.Id == id);
            UserEntity? dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            return dbUser ?? throw new Exception("Usuário não encontrado na base de dados.");
        }

        public async Task<UserEntity> FindOneByEmail(string email)
        {
            UserEntity? dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);

            return dbUser ?? throw new Exception("Usuário não encontrado na base de dados.");
        }

        public async Task<UserEntity> FindToLogin(LoginDTO data)
        {
            UserEntity? dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == data.Email);

            if (dbUser == null || !BCrypt.Net.BCrypt.Verify(data.Password, dbUser.Password))
                throw new Exception("Credenciais de acesso inválidas.");

            return dbUser;
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


        #region VALIDATE
        static void IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, pattern)) throw new Exception("Formato de email inválido.");
        }


        public async Task CheckUserAlreadyExists(string email)
        {
            UserEntity? dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);

            if (dbUser != null)
                throw new Exception("Usuário já cadastrado na base de dados.");
        }

        public async Task CheckUserAlreadyExists(int id)
        {
            UserEntity? dbUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (dbUser != null)
                throw new Exception("Usuário já cadastrado na base de dados.");
        }

        #endregion
    }
    #region INTERFACE
    public interface IUserRepository
    {
        public Task<List<UserEntity>> FindAll();
        public Task<UserEntity> FindOne(int id);
        public Task<UserEntity> FindOneByEmail(string email);
        public Task<UserEntity> FindToLogin(LoginDTO data);
        public Task<UserEntity> Create(UserEntity user);
        public Task<UserEntity> Update(UserEntity user);
        public Task Delete(int id);
        public Task CheckUserAlreadyExists(int id);
        public Task CheckUserAlreadyExists(string email);
    }
    #endregion
}

