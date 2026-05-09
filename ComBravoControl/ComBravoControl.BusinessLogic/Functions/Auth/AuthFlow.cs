
using ComBravo.BusinessLogic.Core.Auth;
using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;


namespace ComBravo.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions ,IAuthActions 
    {
        public ResponseAction LoginActionFlow(UserAuthDto auth)
        {
            var user = ValidateLogin(auth);
            if (user == null) 
            {
                return new ResponseAction()
                {
                    IsSucces = false,
                    Message = "Invalid username or password"
                };
            }

            var token = GenerateUserToken(user);

            return new ResponseAction()
            {
                IsSucces = true,
                Message = token,
                Id = user.Id
            };
        }
    }
}
