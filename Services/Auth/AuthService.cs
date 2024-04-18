using Entities;
using Repositories;
using Services.Auth.DTO;

namespace Services.Auth
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserEntity> Login(LoginDTO data)
        {
            UserEntity user = await _userRepository.FindToLogin(data.Email, data.Password);

            return user;
        }

        public async Task<UserEntity> Register(RegisterDTO data)
        {
            await _userRepository.CheckUserAlreadyExists(data.Email);

            UserEntity user = new()
            {
                Name = data.Name,
                Email = data.Email.ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password)
            };

            await _userRepository.Create(user);

            return user;
        }
    }


    #region INTERFACE

    public interface IAuthService
    {
        Task<UserEntity> Login(LoginDTO data);
        Task<UserEntity> Register(RegisterDTO data);
    }
    #endregion
}
