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
            UserEntity user = await _authService.Login(data);

            return Ok(user);
        }
        #endregion


        #region REGISTER
        [HttpPost("Register")]
        public async Task<ActionResult<UserEntity>> Register(RegisterDTO data)
        {
            UserEntity user = await _authService.Register(data);

            return Ok(user);
        }
        #endregion

    }
}
