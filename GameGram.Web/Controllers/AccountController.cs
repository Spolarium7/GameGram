using GameGram.Domain.Models.Enums;
using GameGram.Web.ViewModels.Account;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameGram.Web.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : Controller
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #region EmailAuthorization
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

                    var op = GameGram.Domain.BLL.UsersBLL.Register(new Domain.Models.User()
                    {
                        Id = Guid.NewGuid(),
                        Status = LoginStatus.Unconfirmed,
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

            [HttpGet, Route("login")]
            public ActionResult Login()
            {
                return View();
            }
        #endregion

        #region LinkedInAuthorization
            [HttpGet, Route("register-by-linkedin")]
            public ActionResult RegisterLinkedIn()
            {
                var randomCode = RandomString(6);

                System.Web.HttpContext.Current.Session["sessionCode"] = randomCode;
                var clientId = ConfigurationManager.AppSettings["LinkedInClientId"].ToString();
                return Redirect("https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=" + clientId +"&redirect_uri=http://localhost:60573/account/get-linkedin-access-token&state=register-" + randomCode + "&scope=r_basicprofile%20r_emailaddress&format=json");
            }

            [HttpGet, Route("get-linkedin-access-token")]
            public ActionResult GetLinkedInAccessToken(string code, string state)
            {
                string accessTokenUrl = "https://www.linkedin.com/oauth/v2/accessToken";
                string clientId = ConfigurationManager.AppSettings["LinkedInClientId"].ToString();
                string clientSecret = ConfigurationManager.AppSettings["LinkedInClientSecret"].ToString();

                var client = new RestClient(accessTokenUrl);

                //Access Token
                var request = new RestRequest("", Method.POST);
                request.AddParameter("grant_type", "authorization_code");
                request.AddParameter("code", code);
                request.AddParameter("redirect_uri", "http://localhost:60573/account/get-linkedin-access-token");
                request.AddParameter("client_id", clientId);
                request.AddParameter("client_secret", clientSecret);

                IRestResponse response = client.Post(request);
                if(response.StatusCode == System.Net.HttpStatusCode.OK) { 
                    var token = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

                    //Account Information (Id,FirstName,LastName,EmailAddress //<LinkedIn has no Gender>)
                    client = new RestClient("https://api.linkedin.com/v1/people/~:(id,first-name,last-name,email-address)?format=json&oauth2_access_token=" + token["access_token"]);
                    request = new RestRequest("", Method.GET);
                    request.AddHeader("format", "json");
                    request.AddHeader("oauth2_access_token", token["access_token"]);

                    response = client.Get(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var linkedInUser = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
                        var sessionCode = state.Split('-');
                        if (sessionCode[1].ToString() == (string)(System.Web.HttpContext.Current.Session["sessionCode"]))
                        {
                            if (state.Contains("register"))
                            {
                            
                                var op = GameGram.Domain.BLL.UsersBLL.Register(new Domain.Models.User()
                                {
                                    Id = Guid.NewGuid(),
                                    Status = LoginStatus.Active,
                                    EmailAddress = linkedInUser["emailAddress"],
                                    FirstName = linkedInUser["firstName"],
                                    LastName = linkedInUser["lastName"],
                                    Password = RandomString(6)
                                });

                                return RedirectToAction("change-password");
                            }
                            else if (state.Contains("login"))
                            {
                                //Login with emailAddress from LinkedIn
                            };
                        };
                    };
                }
                
                return RedirectToAction("Login");
            }
        #endregion

        #region FaceBookAuthorization
        [HttpGet, Route("register-by-facebook")]
        public ActionResult RegisterFacebook()
        {
            var randomCode = RandomString(6);
            System.Web.HttpContext.Current.Session["sessionCode"] = randomCode;
            var appId = ConfigurationManager.AppSettings["FaceBookAppId"].ToString();
            return Redirect("https://www.facebook.com/v2.12/dialog/oauth?client_id=" + appId + "&redirect_uri=http://localhost:60573/account/get-facebook-access-token&state=register-" + randomCode + "&scope=public_profile,email");
        }

        [HttpGet, Route("get-facebook-access-token")]
        public ActionResult GetFacebookAccessToken(string code, string state)
        {
            string accessTokenUrl = "https://graph.facebook.com/v2.12/oauth/access_token";
            string clientId = ConfigurationManager.AppSettings["FaceBookAppId"].ToString();
            string clientSecret = ConfigurationManager.AppSettings["FaceBookAppSecret"].ToString();

            var client = new RestClient(accessTokenUrl);

            //Access Token
            var request = new RestRequest("", Method.POST);
            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", "http://localhost:60573/account/get-facebook-access-token");
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);

            IRestResponse response = client.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var token = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

                //Account Information (Id,FirstName,LastName,EmailAddress //<LinkedIn has no Gender>)
                client = new RestClient("https://graph.facebook.com/v2.12/me?fields=id,email,first_name,last_name,gender&access_token=" + token["access_token"]);
                request = new RestRequest("", Method.GET);
                request.AddHeader("access_token", token["access_token"]);

                response = client.Get(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var facebookUser = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
                    var sessionCode = state.Split('-');
                    if (sessionCode[1].ToString() == (string)(System.Web.HttpContext.Current.Session["sessionCode"]))
                    {
                        if (state.Contains("register"))
                        {
                            var op = GameGram.Domain.BLL.UsersBLL.Register(new Domain.Models.User()
                            {
                                Id = Guid.NewGuid(),
                                Status = LoginStatus.Active,
                                EmailAddress = facebookUser["email"],
                                FirstName = facebookUser["first_name"],
                                LastName = facebookUser["last_name"],
                                Gender = (facebookUser["gender"].ToLower() == "female" ? Gender.Female : Gender.Male),
                                Password = RandomString(6)
                            });

                            return RedirectToAction("change-password");
                        }
                        else if (state.Contains("login"))
                        {
                            //Login with emailAddress from LinkedIn
                        };
                    };
                }

            }



            return View();
        }
        #endregion
    }
}