using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTracNghiem_LeNgocVinh.Help;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        private DBData db = new DBData();
        // GET: admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string loginAdmin)
        {
            Md5 md = new Md5();
            loginAdmin = "admin";
            var usr = username;
            var pwd = password;
            var md5pass = md.GetMD5(password);
            var acc = db.NguoiDungs.SingleOrDefault(x => x.tenDN == usr && x.matKhau == md5pass);
            var acc1 = db.PhanQuyens.SingleOrDefault(x => x.iD_NguoiDung == acc.iD_NguoiDung && x.laAdmin == loginAdmin);
            //var acc2 = db.PhanQuyens.SingleOrDefault(x => x.iD_NguoiDung == acc.iD_NguoiDung && x.laAdmin != loginAdmin);
            if (acc != null)
            {
                if(acc1 != null)
                {
                    FormsAuthentication.SetAuthCookie(acc.tenDN, false);
                    Session["admin"] = acc;
                    Session["user"] = acc.tenDN;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Bạn không phải quản trị viên");
                    return View();
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Kiểm tra lại thông tin đăng nhập");
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult SignOut()
        {
            Session.Abandon();

            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["admin"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}