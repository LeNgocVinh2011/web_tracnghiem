using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebTracNghiem_LeNgocVinh.Areas.admin.Data;
using WebTracNghiem_LeNgocVinh.Help;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Controllers
{
    public class LoginUserController : Controller
    {
        private DBData db = new DBData();

        [HttpGet]
        public ActionResult LoginNguoiDung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginNguoiDung(string username, string password, string loginAdmin)
        {
            Md5 md = new Md5();
            loginAdmin = "admin";
            var usr = username;
            var pwd = password;
            var md5pass = md.GetMD5(password);
            var acc = db.NguoiDungs.SingleOrDefault(x => x.tenDN == usr && x.matKhau == md5pass);
            if (acc != null)
            {
                    FormsAuthentication.SetAuthCookie(acc.tenDN, false);
                    Session["NguoiDung"] = acc;
                    Session["Ten"] = acc.hoTen;
                    return RedirectToAction("Index", "Default");
            }
            else
            {
                ModelState.AddModelError("", "Kiểm tra lại tài khoản hoặc mật khẩu");
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult SignOutUser()
        {
            Session.Abandon();

            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["admin"] = null;
            return RedirectToAction("LoginNguoiDung", "LoginUser");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(NguoiDung entity)
        {
            Md5 md = new Md5();
            var passmD5 = md.GetMD5(entity.matKhau);
            NguoiDungDao dao = new NguoiDungDao();
            entity.matKhau = passmD5;
            if (dao.InsertUser(entity))
            {
                return RedirectToAction("LoginNguoiDung", "LoginUser");
            }
            else
            {
                return View(entity);
            }
        }
    }
}