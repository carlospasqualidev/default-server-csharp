using EduzcaServer.Models;
using EduzcaServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpPost]
        public async Task<ActionResult<UserEntity>> Create(UserEntity user)
        {
          UserEntity userData =   await _userRepository.Create(user);
            
          return Ok(userData);
        }

        [HttpPut]
        public async Task<ActionResult<UserEntity>> Update(int id, UserEntity user)
        {
            UserEntity userData = await _userRepository.Update(id, user);

            return Ok(userData);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> FindAll()
        {
            List<UserEntity> users = await _userRepository.FindAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserEntity>>> FindOne(int id)
        {
            UserEntity user = await _userRepository.FindOne(id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> Delete(int id)
        {
             await _userRepository.Delete(id);

            return Ok();
        }


    }
}
