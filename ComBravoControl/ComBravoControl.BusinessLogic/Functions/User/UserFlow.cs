using ComBravoControl.BusinessLogic.Core.User;
using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.Domains.Models.Base;
using ComBravoControl.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravoControl.BusinessLogic.Functions.User
{
    public class UserFlow : UserActions, IUserActions
    {
        public List<UserDto> GetAllUsersAction()
        {
            return ExecuteGetAllUserAction();
        }

        public UserDto GetUserByIdAction(int id)
        {
            return ExecuteGetUserByIdAction(id);
        }

        public ResponseMsg ResponseUserCreateAction(UserDto user)
        {
            return ExecuteUserCreateAction(user);
        }

        public ResponseMsg ResponseUserDeleteAction(int id)
        {
            return ExecuteUserDeleteAction(id);
        }

        public ResponseMsg ResponseUserUpdateAction(UserDto user)
        {
            return ExecuteUserUpdateAction(user);
        }
    }
}
