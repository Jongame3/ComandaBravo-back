using System;
using System.Collections.Generic;
using System.Text;
using ComBravoControl.Domains.Models.Base;
using ComBravoControl.Domains.Models.User;

namespace ComBravoControl.BusinessLogic.Interface
{
    public interface IUserActions
    {
        List<UserDto> GetAllUsersAction();
        UserDto GetUserByIdAction(int id);
        ResponseMsg ResponseUserCreateAction(UserDto user);
        ResponseMsg ResponseUserDeleteAction(int id);
        ResponseMsg ResponseUserUpdateAction(UserDto user);
    }
}
