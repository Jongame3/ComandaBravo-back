using System;
using System.Collections.Generic;
using System.Text;
using ComBravoControl.Domains.Models.User;
using ComBravoControl.Domains.Entities.User;
using ComBravoControl.DataAccess.Context;
using ComBravoControl.Domains.Models.Base;

namespace ComBravoControl.BusinessLogic.Core.User
{
    public class UserActions
    {
        protected List<UserDto> ExecuteGetAllUserAction()
        {
            var users = new List<UserDto>();
            List<UserData> uData;

            using (var db = new UserContext())
            {
                uData = db.Users.ToList();
            }

            foreach (var user in uData)
            {
                var user_ = new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Contacts = user.Contacts,
                    Email = user.Email,
                    DOB = user.DOB
                };
                users.Add(user_);
            }
            return users;
        }

        protected UserDto? ExecuteGetUserByIdAction (int id)
        {
            UserData? uData;

            using (var db = new UserContext())
            {
                uData = db.Users.FirstOrDefault(x => x.Id == id);
            }

            if (uData == null)
            {
                return null;
            }

            return new UserDto()
            {
                Id = uData.Id,
                Username = uData.Username,
                Password = uData.Password,
                Contacts = uData.Contacts,
                Email = uData.Email,
                DOB = uData.DOB
            };
        }

        protected ResponseMsg ExecuteUserUpdateAction(UserDto user)
        {
            using (var db = new UserContext())
            {
                var uData = db.Users.FirstOrDefault(x => x.Id == user.Id);

                if(uData == null)
                {
                    return new ResponseMsg { IsSucces=false , Message = "vaflz"};
                }

                uData.Username = user.Username;
                uData.Password = user.Password;
                uData.Contacts = user.Contacts;
                uData.Email = user.Email;

                db.SaveChanges();
            }

            return new ResponseMsg { IsSucces = true, Message = "Succesfully updated user" };
        }

        protected ResponseMsg ExecuteUserDeleteAction(int id)
        {
            using (var db = new UserContext())
            {
                var uData = db.Users.FirstOrDefault(x => x.Id == id);

                if (uData == null)
                {
                    return new ResponseMsg { IsSucces = false, Message = "There's no user with this id" };
                }

                db.Users.Remove(uData);
                db.SaveChanges();
            }
            return new ResponseMsg { IsSucces = true, Message = "Succesfully deleted the user" };
        }

        protected ResponseMsg ExecuteUserCreateAction(UserDto user)
        {
            UserData uData;
            using(var db = new UserContext())
            {
                uData = db.Users.FirstOrDefault(x => x.Username.Equals(user.Username));
            }

            if(uData != null)
            {
                return new ResponseMsg { IsSucces = false, Message = "There's already user with the same Username" };
            }

            var uLocalData = new UserData()
            {
                Username = user.Username,
                Password = user.Password,
                Contacts = user.Contacts,
                Email = user.Email,
                DOB = user.DOB
            };

            using (var db = new UserContext())
            {
                db.Users.Add(uLocalData);
                db.SaveChanges();
            }

            return new ResponseMsg { IsSucces = true, Message = "User was succesfully Created" };
        }
    }
}
