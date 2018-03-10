using GameGram.Web.Infrastructure;
using GameGram.Web.ViewModels.Home;
using GameGram.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameGram.Web.Controllers
{
    [RoutePrefix("posts")]
    public class PostsController : BaseController
    {
        // GET: Posts
        public ActionResult Index()
        {
            PostsViewModel model = new PostsViewModel()
            {
                Posts = GameGram.Domain.BLL.PostBLL.Search(1, 5, ""),
                WebUser = this.WebUser
            };
            return View(model);
        }

        [Route("edit/{id}")]
        public ActionResult Edit(Guid? id)
        {
            var post = GameGram.Domain.BLL.PostBLL.Find(id);

            if(post != null) { 
                UpdatePostViewModel model = new UpdatePostViewModel()
                {
                    Id = post.Id,
                    Caption = post.Caption,
                    Content = post.Content
                };
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost, Route("edit")]
        public ActionResult Edit(UpdatePostViewModel model)
        {
            var post = GameGram.Domain.BLL.PostBLL.Find(model.Id);

            if (post != null)
            {
                post.Caption = model.Caption;
                post.Content = model.Content;
                GameGram.Domain.BLL.PostBLL.Update(post);
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Route("add")]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost, Route("add")]
        public ActionResult Add(CreatePostViewModel model)
        {
            GameGram.Domain.BLL.PostBLL.Create(new Domain.Models.Post()
            {
                Content = model.Content,
                Caption = model.Caption,
                //UserId = this.WebUser.Id
            });
            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        public ActionResult Delete(Guid? id)
        {
            try
            {
                GameGram.Domain.BLL.PostBLL.Delete(id);
            }
            catch(Exception ex)
            {

            }

            return RedirectToAction("Index");
        }
    }
}