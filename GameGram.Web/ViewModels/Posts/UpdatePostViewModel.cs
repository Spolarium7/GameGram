using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameGram.Web.ViewModels.Posts
{
    public class UpdatePostViewModel
    {
        public Guid? Id { get; set; }

        public string Content { get; set; }

        public string Caption { get; set; }
    }
}