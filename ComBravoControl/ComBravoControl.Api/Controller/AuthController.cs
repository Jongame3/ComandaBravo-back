using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/session")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthActions _auth;

        public AuthController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }

        [HttpGet("status")]
        [AllowAnonymous]
        public IActionResult Get() 
        {
            return Ok("Session is active");
        }
        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Auth([FromBody] UserAuthDto data)
        {
            var authStatus = _auth.LoginActionFlow(data);

            if (authStatus.IsSucces == false) 
            {
                return Unauthorized(authStatus.Message);
            }
            return Ok(authStatus);
        }
    }
}
