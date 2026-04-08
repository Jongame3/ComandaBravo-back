using System;
using System.Collections.Generic;
using System.Text;
using ComBravoControl.Domains.Models.User;

namespace ComBravoControl.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        object? LoginActionFlow(UserAuthAction auth);

    }
}
