using System.ComponentModel;

namespace EduzcaServer.Services.Auth.DTO
{
    public class RegisterDTO
    {
        [DefaultValue("Carlos Pasquali")]
        public required string Name { get; set; }
        [DefaultValue("carlos.pasquali.dev@gmail.com")]
        public required string Email { get; set; }
        [DefaultValue("123123123")]
        public required string Password { get; set; }
    }
}
