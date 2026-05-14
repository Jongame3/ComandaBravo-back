using ComBravo.BusinessLogic.Structure;
using ComBravo.DataAccess.Context;
using ComBravo.Domains.Entities.User;
using ComBravo.Domains.Enums;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.User;


namespace ComBravo.BusinessLogic.Core.Auth
{
    public class RegistrationActions
    {
        internal ResponseAction ExecuteRegisterUser(UserRegistrationDto uReg)
        {
            if(string.IsNullOrEmpty(uReg.Username) || string.IsNullOrEmpty(uReg.Password) || string.IsNullOrEmpty(uReg.Email))
            {
                return new ResponseAction()
                {
                    IsSucces = false,
                    Message = "Username, Password and Email are required."
                };
            }

            UserData? existing;
            using(var db  = new UserContext())
            {
                existing = db.Users.FirstOrDefault(u => u.Username == uReg.Username || u.Email == uReg.Email);
            }
             
            if(existing != null)
            {
                return new ResponseAction()
                {
                    IsSucces = false,
                    Message = "User with same username, or Email already exists"
                };
            }

            var uData = new UserData()
            {
                Username = uReg.Username,
                Password = PasswordHasher.Hash(uReg.Password),
                Email = uReg.Email,
                Contacts = uReg.Contacts,
                DOB = DateTime.UtcNow,
                Role = UserRole.User
            };

            using (var db = new UserContext())
            {
                db.Users.Add(uData);
                db.SaveChanges();
            }

            return new ResponseAction()
            {
                IsSucces = true,
                Message = "User registration succesfull.",
                Id = uData.Id
            };
        }

    }
}
