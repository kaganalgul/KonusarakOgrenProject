using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KonusarakOgrenProject.Core.Filters
{
    public class LoggedUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userId = filterContext.HttpContext.Session.GetString("userId");

            if (userId == null)
            {
                string routePath = filterContext.HttpContext.Request.Path;
                filterContext.Result = new RedirectToActionResult("Login", "Auth", new { yonlen = routePath });
            }
        }
    }
}
