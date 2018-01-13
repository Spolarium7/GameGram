using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Domain.Infrastructure
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataAccess>
    {
        protected override void Seed(DataAccess db)
        {
            #region Users
            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jace",
                    LastName = "Beleren",
                    Password = "Accord605",
                    EmailAddress = "jbeleren@mailinator.com",
                    Gender = Models.Enums.Gender.Male,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Liliana",
                    LastName = "Vess",
                    Password = "Accord605",
                    EmailAddress = "lvess@mailinator.com",
                    Gender = Models.Enums.Gender.Female,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Gideon",
                    LastName = "Jura",
                    Password = "Accord605",
                    EmailAddress = "gjura@mailinator.com",
                    Gender = Models.Enums.Gender.Male,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Nissa",
                    LastName = "Revane",
                    Password = "Accord605",
                    EmailAddress = "nrevane@mailinator.com",
                    Gender = Models.Enums.Gender.Female,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Chandra",
                    LastName = "Nalaar",
                    Password = "Accord605",
                    EmailAddress = "cnalaar@mailinator.com",
                    Gender = Models.Enums.Gender.Female,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();
            #endregion
        }
    }
}
