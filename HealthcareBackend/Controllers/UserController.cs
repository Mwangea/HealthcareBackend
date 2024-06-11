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
            public IActionResult Register([FromBody] User user, [FromBody] string password)
            {
                if (_authService.Register(user, password))
                    return Ok(new { message = "Registration successfull" });
                return BadRequest(new { message = " Registration Failed" });
            }

        }
    
}
