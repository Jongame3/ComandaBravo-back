using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/reg")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterAction _userReg;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _userReg = bl.GetRegisterAction();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegistrationDto user)
        {
            var result = _userReg.RegisterActionFlow(user);

            if (result.IsSucces == false)
            {
                return BadRequest(result.Message);
            }

            return Ok(new {id = result.Id, message  = result.Message});
        }

    }
}
