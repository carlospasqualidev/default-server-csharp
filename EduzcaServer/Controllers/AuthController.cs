using EduzcaServer.Models;
using EduzcaServer.Services.Auth;
using EduzcaServer.Services.Auth.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;


        #region LOGIN
        [HttpPost("Login")]
        public async Task<ActionResult<UserEntity>> Login(LoginDTO data)
        {
            try
            {
                UserEntity user = await _authService.Login(data);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion


        #region REGISTER
        [HttpPost("Register")]
        public async Task<ActionResult<UserEntity>> Register(RegisterDTO data)
        {
            try
            {
                UserEntity user = await _authService.Register(data);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

    }
}
