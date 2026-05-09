using ComBravo.Domains.Entities.User;
using ComBravo.Domains.Models.User;
using ComBravo.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;
using ComBravo.BusinessLogic.Structure;

namespace ComBravo.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        internal UserData? ValidateLogin(UserAuthDto data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
                return null;

            var passwordHash = PasswordHasher.Hash(data.Password);

            using( var db = new UserContext())
            {
                return db.Users.FirstOrDefault(x => (x.Username == data.Login || x.Email == data.Login) && x.Password == passwordHash);
            }
        }

        internal string GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.Username, user.Role.ToString());
        }
    }
}
