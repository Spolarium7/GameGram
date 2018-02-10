using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameGram.Web.Infrastructure
{
    public class WebUser
    {
        public Guid? Id
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserId"] != null)
                {
                    return (Guid.Parse(System.Web.HttpContext.Current.Session["UserId"].ToString()));
                }

                return null;
            }
            set { System.Web.HttpContext.Current.Session["UserId"] = value.ToString(); }
        }

        public string Name
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserName"] != null)
                {
                    return (System.Web.HttpContext.Current.Session["UserName"].ToString());
                }

                return null;
            }
            set { System.Web.HttpContext.Current.Session["UserName"] = value.ToString(); }
        }

    }
}