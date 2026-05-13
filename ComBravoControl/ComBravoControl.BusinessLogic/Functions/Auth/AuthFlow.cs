
using ComBravo.BusinessLogic.Core.Auth;
using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;


namespace ComBravo.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions ,IAuthActions 
    {
        public AuthResponse LoginActionFlow(UserAuthDto auth)
        {
            var user = ValidateLogin(auth);
            if (user == null) 
            {
                return new AuthResponse()
                {
                    IsSucces = false,
                    Message = "Invalid username or password"
                };
            }

            var token = GenerateUserToken(user);

            return new AuthResponse()
            {
                IsSucces = true,
                Message = token,
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
                
            };
        }
    }
}
