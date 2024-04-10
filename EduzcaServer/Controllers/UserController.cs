using EduzcaServer.Models;
using EduzcaServer.Services.User.DTO;
using EduzcaServer.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        #region CREATE
        [HttpPost]
        public async Task<ActionResult<UserEntity>> Create(CreateUserDTO user)
        {
          UserEntity userData = await _userService.Create(user);
            
          return Ok(userData);
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<UserEntity>> Update(UpdateUserDTO user)
        {
            await _userService.Update(user);

            return Ok(user);
        }
        #endregion

        #region FIND 
        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> FindAll()
        {
            List<UserEntity> users = await _userService.FindAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserEntity>>> FindOne(int id)
        {
            UserEntity user = await _userService.FindOne(id);

            return Ok(user);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> Delete(int id)
        {
             await _userService.Delete(id);

            return Ok();
        }
        #endregion
    }
}
