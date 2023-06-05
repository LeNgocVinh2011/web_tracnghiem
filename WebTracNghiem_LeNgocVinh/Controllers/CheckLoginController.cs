using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTracNghiem_LeNgocVinh.Controllers
{
    public class CheckLoginController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["NguoiDung"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "LoginUser", Action = "LoginNguoiDung" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}