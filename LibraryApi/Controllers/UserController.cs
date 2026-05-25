using LibraryApplication.DTO.User;
using LibraryApplication.Service;
using LibraryApplication.Service.Interfaces;
using LibraryDomain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticate _authenticate;

        public UserController(IUserService userService, IAuthenticate authenticate)
        {
            _userService = userService;
            _authenticate = authenticate; ;
        }

        [HttpPost]
        public async Task<ActionResult<List<UserGetDTO>>> CreateUser(UserPostDTO userPostDTO)
        {
            var allUsers = await _userService.CreateUser(userPostDTO);
            return Ok(allUsers);
        }

        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserGetDTO>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string email, string password)
        {
            var token = await _userService.Login(email, password);
            if (token == null)
                return Unauthorized("Invalid email or password.");

            return Ok(token);
        }
    }
}