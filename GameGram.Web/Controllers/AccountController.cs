using GameGram.Web.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameGram.Web.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : Controller
    {
        #region RegisterByEmail
        [HttpGet, Route("register-by-email")]
        public ActionResult RegisterEmail()
        {
            return View();
        }
        

        [HttpPost, Route("register-by-email")]
        public ActionResult RegisterEmail(RegisterEmailViewModel model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("","Password and Confirm Password do not match");
                return View();
            }

            try
            {
                var regCode = RandomString(6);

                var op = GameGram.Domain.BLL.UsersBLL.RegisterByEmail(new Domain.Models.User()
                {
                    Id = Guid.NewGuid(),
                    EmailAddress = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Password = model.Password,
                    RegistrationCode = regCode
                });

                if (op.Status == Domain.Infrastructure.Enums.OperationStatus.OK)
                {
                    GameGram.Web.Mailer.MailHelper.SendNow(
                        "Welcome to GameGram!!! Please use the registration code: " + regCode + " to activate your account.",
                        model.EmailAddress,
                        op.Item.FullName,
                        "Welcome to GameGram!!!"
                    );

                    return RedirectToAction("Activate");
                }
                else
                {
                    ModelState.AddModelError("", op.Message);
                    return View();
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet, Route("activate")]
        public ActionResult Activate()
        {
            return View();
        }

        [HttpPost, Route("activate")]
        public ActionResult Activate(ActivateViewModel model)
        {
            try
            {
                var op = GameGram.Domain.BLL.UsersBLL.Activate(model.EmailAddress, model.Code);

                if(op.Status == Domain.Infrastructure.Enums.OperationStatus.OK)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", op.Message);
                    return View();
                }

            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
        #endregion


        #region LoginByEmail
        [HttpGet, Route("login")]
        public ActionResult Login()
        {
            return View();
        }
        #endregion
    }
}