using ComBravo.Domains.Entities.User;
using ComBravo.Domains.Models.User;
using ComBravo.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        internal bool ValidateLogin(UserAuthAction data)
        {
            UserData? local;
            using (var db = new UserContext())
            {
                local = db.Users.FirstOrDefault(u => u.Username == data.Login && u.Password == data.Password);
            }

            if (string.IsNullOrEmpty(data.Login) && string.IsNullOrEmpty(data.Password))
                return false;
            return true;
        }

        internal string GenToken(UserAuthAction data)
        {
            return "TOKEN";
        }
    }
}
