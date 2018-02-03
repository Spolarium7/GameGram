using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGram.Domain.Infrastructure;
using GameGram.Domain.Models;
using GameGram.Domain.Models.Enums;

namespace GameGram.Domain.BLL
{
    public static class UsersBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public static BLLOperation<User> RegisterByEmail(User model)
        {
            User duplicateUser = db.Users.FirstOrDefault(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower());

            if(duplicateUser == null)
            {
                model.Status = LoginStatus.Unconfirmed;
                db.Users.Add(model);
                db.SaveChanges();

                return new BLLOperation<User>()
                {
                    Status = Infrastructure.Enums.OperationStatus.OK,
                    Message = "Success",
                    Item = model
                };
            }
            else
            {
                return new BLLOperation<User>()
                {
                    Status = Infrastructure.Enums.OperationStatus.Error,
                    Message = "Email Address already used."
                };
            }
        }

        public static BLLOperation<User> Activate(string emailAddress, string registrationCode)
        {
            User user = db.Users.FirstOrDefault(u => u.EmailAddress.ToLower() == emailAddress.ToLower());

            if(user != null)
            {
                if(user.RegistrationCode == registrationCode)
                {

                    user.Status = LoginStatus.Active;
                    db.SaveChanges();

                    return new BLLOperation<User>()
                    {
                        Status = Infrastructure.Enums.OperationStatus.OK,
                        Message = "Success",
                        Item = user
                    };
                }
            }

            return new BLLOperation<User>()
            {
                Status = Infrastructure.Enums.OperationStatus.Error,
                Message = "User not found."
            };
        }
    }
}
