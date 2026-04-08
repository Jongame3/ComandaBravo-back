using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.Domains.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravoControl.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        internal IAuthActions _auth;

        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }

        [HttpGet("status")]
        public IActionResult Get() 
        {
            return Ok("Session is active");
        }

        [HttpPost("auth")]
        public IActionResult Post([FromBody] UserAuthAction data)
        {
            var authStatus = _auth.LoginActionFlow(data);

            string token = "";
            return Ok(token);
        }
    }
}
