using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Controllers
{
    public class DefaultController : CheckLoginController
    {
        private DBData db = new DBData();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrangVaoThi()
        {
            return View(db.CauHois.ToList());
        }
    }
}