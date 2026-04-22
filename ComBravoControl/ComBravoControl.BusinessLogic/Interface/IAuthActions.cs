using System;
using System.Collections.Generic;
using System.Text;
using ComBravo.Domains.Models.User;

namespace ComBravo.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        object? LoginActionFlow(UserAuthAction auth);

    }
}
