using GameGram.Domain.CustomModels;
using GameGram.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameGram.Web.ViewModels.Home
{
    public class PostsViewModel
    {
        public Page<CompletePost> Posts { get; set; }
    }
}