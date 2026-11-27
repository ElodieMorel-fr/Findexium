using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]        
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            string? token = await _loginService.LoginAsync(loginModel);
            if (token == null)
                return Unauthorized("Identifiant ou mot de passe incorrect.");
            return Ok(new { token });
        }            
    }
}