using GameGram.Web.Infrastructure;
using GameGram.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameGram.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            PostsViewModel model = new PostsViewModel()
            {
                Posts = GameGram.Domain.BLL.PostBLL.Search(1, 5, ""),
                WebUser = this.WebUser
            };
            return View(model);
        }
    }
}