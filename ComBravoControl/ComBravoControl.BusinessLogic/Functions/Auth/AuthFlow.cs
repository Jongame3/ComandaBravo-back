using ComBravo.BusinessLogic.Core.Auth;
using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Functions.Auth
{
    internal class AuthFlow : AuthActions ,IAuthActions 
    {
        public object? LoginActionFlow(UserAuthAction auth)
        {
            var isValid = ValidateLogin(auth);
            return isValid ? GenToken(auth) : null; 
        }
    }
}
