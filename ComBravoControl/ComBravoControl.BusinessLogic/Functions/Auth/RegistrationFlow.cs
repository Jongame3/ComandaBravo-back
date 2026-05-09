using ComBravo.BusinessLogic.Core.Auth;
using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Functions.Auth
{
    public class RegistrationFlow : RegistrationActions, IRegisterAction
    {
        public ResponseAction RegisterActionFlow(UserRegistrationDto uReg)
        {
            return ExecuteRegisterUser(uReg);
        }
    }
}
