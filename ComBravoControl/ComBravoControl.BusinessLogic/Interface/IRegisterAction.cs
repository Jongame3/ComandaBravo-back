using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Interface
{
    public interface IRegisterAction
    {
        ResponseAction RegisterActionFlow(UserRegistrationDto uReg);
    }
}
