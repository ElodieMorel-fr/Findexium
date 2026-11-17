using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services;
using System.Security.Cryptography;

namespace P7CreateRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
     
            _userService = userService;
        }
        

        [HttpPost]        
        public async Task<IActionResult> AddUser([FromBody] UserRequest userRequest)
        {
            UserResponse newUser = await _userService.CreateAsync(userRequest);
            return Ok(newUser);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            UserResponse? user = await _userService.FindByIdAsync(id);
            if (user == null)
                return NotFound("Invalid user Id:" + id);
            else
                return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequest userRequest)
        {
            UserResponse? user = await _userService.UpdateAsync(id, userRequest);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /*[HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _userRepository.FindById(id);
            
            if (user == null)
                throw new ArgumentException("Invalid user Id:" + id);

            return Ok();
        }

        [HttpGet]
        [Route("/secure/article-details")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
        {
            return Ok();
        }*/
    }
}