using EduzcaServer.Models;
using EduzcaServer.Repositories;
using EduzcaServer.Services.User.DTO;

namespace EduzcaServer.Services.User
{
    public class UserService(IUserRepository userRepository): IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        #region CREATE
        public async Task<UserEntity> Create(CreateUserDTO user)
        {
            UserEntity userData = new()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

             await _userRepository.Create(userData);

            return userData;
        }
        #endregion

        #region UPDATE
        public async Task<UserEntity> Update(UpdateUserDTO user)
        {
            UserEntity userData = await _userRepository.FindOne(user.Id);
            userData.Name = user.Name;
            userData.Email = user.Email;
            userData.Password = user.Password;

            await _userRepository.Update(userData);

            return userData;
        }
        #endregion

        #region FIND
        public async Task<List<UserEntity>> FindAll()
        {
            List<UserEntity> users = await _userRepository.FindAll();

            return users;
        }

        public async Task<UserEntity> FindOne(int id)
        {
            UserEntity user = await _userRepository.FindOne(id);

            return user;
        }
        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
        #endregion
    }

    #region INTERFACE
    public interface IUserService
    {
        public Task<UserEntity> Create(CreateUserDTO user);
        public Task<UserEntity> Update(UpdateUserDTO user);
        public Task<List<UserEntity>> FindAll();
        public Task<UserEntity> FindOne(int id);
        public Task Delete(int id);
    }
    #endregion
}
