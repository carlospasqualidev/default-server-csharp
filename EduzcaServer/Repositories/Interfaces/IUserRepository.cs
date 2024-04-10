using EduzcaServer.Models;

namespace EduzcaServer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserEntity>> FindAll();
        public Task<UserEntity> FindOne(int id);
        public Task<UserEntity> Create(UserEntity user);
        public Task<UserEntity> Update(int id, UserEntity user);
        public Task Delete(int id);
    }
}
