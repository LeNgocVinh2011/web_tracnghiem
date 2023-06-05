using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem_LeNgocVinh.Areas.admin.Data;
using WebTracNghiem_LeNgocVinh.Help;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Controllers
{
    public class NguoiDungsController : BaseController
    {
        NguoiDungDao dao = new NguoiDungDao();
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            var model = from u in dao.ListUsers()
                        select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(u => u.tenDN.ToUpper().Contains(searchString.ToUpper())
                || u.hoTen.ToUpper().Contains(searchString.ToUpper())
                || u.eMail.ToUpper().Contains(searchString.ToUpper())
                );
            }

            ViewBag.NguoiDung_TenDN = sortOrder == "tk_asc" ? "tk_desc" : "tk_asc";
            ViewBag.NguoiDung_HoTen = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.NguoiDung_Email = sortOrder == "email_asc" ? "email_desc" : "email_asc";

            switch (sortOrder)
            {
                case "tk_desc":
                    model = model.OrderByDescending(u => u.tenDN);
                    break;
                case "tk_asc":
                    model = model.OrderBy(u => u.tenDN);
                    break;
                case "name_desc":
                    model = model.OrderByDescending(u => u.hoTen);
                    break;
                case "name_asc":
                    model = model.OrderBy(u => u.hoTen);
                    break;
                case "email_desc":
                    model = model.OrderByDescending(u => u.eMail);
                    break;
                case "email_asc":
                    model = model.OrderBy(m => m.eMail);
                    break;
                default:
                    model = model.OrderBy(u => u.iD_NguoiDung);
                    break;
            }

            if (page == null) page = 1;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.pageCurren = page;
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.totalRecode = model.Count();

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int iD_NguoiDung)
        {

            return View(dao.getListUser(iD_NguoiDung));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NguoiDung entity)
        {
            Md5 md = new Md5();
            var passmD5 = md.GetMD5(entity.matKhau);
            entity.matKhau = passmD5;
            if (dao.InsertUser(entity))
            {
                return RedirectToAction("Index", "NguoiDungs");
            }
            else
            {
                return View(entity);
            }
        }

        [HttpGet]
        public ActionResult Edit(int iD_NguoiDung)
        {
            var model = dao.getListUser(iD_NguoiDung);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(NguoiDung entity)
        {
            if (dao.UpdateUsers(entity) == true)
            {
                return RedirectToAction("Index", "NguoiDungs");
            }

            else
            {
                return View(entity);
            }
        }


        public ActionResult Delete(int iD_NguoiDung)
        {
            var model = dao.getListUser(iD_NguoiDung);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(NguoiDung entity)
        {
            var model = dao.getListUser(entity.iD_NguoiDung);
            if (model != null)
            {
                if (dao.Delete(entity) == true)
                {
                    return RedirectToAction("Index", "NguoiDungs");
                }

                else
                {
                    return View(entity);
                }
            }
            return View(entity);
        }
    }
}