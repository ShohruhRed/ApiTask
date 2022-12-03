using API.Data;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<List<User>> GetUsersList(int from, int to)
        {
            if (from != 0 && to != 0 && from > 0 && to > 0)
                return await _userService.GetPart(from, to);


            /* if one of the fields is zero, return all users */
            return await _userService.GetAllUsers();
        }
    }
}
