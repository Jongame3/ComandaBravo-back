using System;
using System.Collections.Generic;
using System.Text;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;

namespace ComBravo.BusinessLogic.Interface
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
