using HealthcareBackend.Authentication;
using HealthcareBackend.Models;
using Microsoft.AspNetCore.Mvc;


namespace HealthcareBackend.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : ControllerBase
        {
            private readonly AuthService _authService;
            public UserController(AuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("register")]
            public IActionResult Register([FromBody] RegisterModel model)
           {
            var user = new RegisterModel
            {
                Username = model.Username,
                Email = model.Email,
            };

            if (_authService.Register(user, model.PasswordHash))
                return Ok(new { message = "Registration successful" });

            return BadRequest(new { message = "Registration failed" });
           }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _authService.Login(model.Username, model.PasswordHash);
            if (user != null)
            {
                return Ok(new { message = "Login successful", user });
            }

            return BadRequest(new { message = "Login failed" });
        }


    }
    
}
