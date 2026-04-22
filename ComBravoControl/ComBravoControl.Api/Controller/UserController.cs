using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserActions _user;

        public UserController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _user = bl.GetUserActions();
        }
        [HttpGet("getAll")]
        public IActionResult GetAllUsers()
        {
            var users = _user.GetAllUsersAction();
            return Ok(users);
        }
        [HttpGet("getById")]
        public IActionResult Get(int id) 
        {
            var user = _user.GetUserByIdAction(id);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UserDto user)
        {
            var status = _user.ResponseUserCreateAction(user);
            return Ok(status);
        }
        [HttpPut]
        public IActionResult Update([FromBody] UserDto user) 
        {
            var status = _user.ResponseUserUpdateAction(user);
            return Ok(status);
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var status = _user.ResponseUserDeleteAction(id);
            return Ok(status);
        }
    }
}
