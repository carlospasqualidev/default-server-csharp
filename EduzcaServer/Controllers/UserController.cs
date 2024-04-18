using EduzcaServer.Models;
using EduzcaServer.Services.User.DTO;
using EduzcaServer.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<UserEntity>> Update(UpdateUserDTO user)
        {
            try
            {
                await _userService.Update(user);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region FIND 
        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> FindAll()
        {
            try
            {
                List<UserEntity> users = await _userService.FindAll();

                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserEntity>>> FindOne(int id)
        {
            try
            {
                UserEntity user = await _userService.FindOne(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserEntity>>> Delete(int id)
        {
            try
            {
                await _userService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }  
        }
        #endregion
    }
}
