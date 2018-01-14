using GameGram.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameGram.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PostsViewModel model = new PostsViewModel()
            {
                Posts = GameGram.Domain.BLL.PostBLL.Search(1, 5, "")
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}