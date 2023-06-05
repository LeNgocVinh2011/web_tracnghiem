using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem_LeNgocVinh.Areas.admin.Data;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Controllers
{
    public class PhanQuyensController : BaseController
    {
        PhanQuyenDao dao = new PhanQuyenDao();
        // GET: admin/PhanQuyens
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.tenNguoiDung = sortOrder == "name_asc" ? "name_desc" : "name_asc";

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

            var model = from q in dao.ListPhanQuyen()
                        select q;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(q => q.NguoiDung.hoTen.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    model = model.OrderByDescending(m => m.NguoiDung.hoTen);
                    break;
                case "name_asc":
                    model = model.OrderBy(m => m.NguoiDung.hoTen);
                    break;
                default:
                    model = model.OrderBy(m => m.iD_NguoiDung);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            ViewBag.totalRecode = model.Count();
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int iD_NguoiDung)
        {

            return View(dao.getListPQ(iD_NguoiDung));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = new NguoiDungDao();
            ViewBag.iD_NguoiDung = new SelectList(user.ListUsers(), "iD_NguoiDung", "hoTen");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhanQuyen entity)
        {
            var user = new NguoiDungDao();
            ViewBag.iD_NguoiDung = new SelectList(user.ListUsers(), "iD_NguoiDung", "hoTen", entity.iD_NguoiDung);
            if (dao.InsertQuyen(entity))
            {
                return RedirectToAction("Index", "PhanQuyens");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int iD_NguoiDung)
        {
            var model = dao.getListPQ(iD_NguoiDung);
            var user = new NguoiDungDao();
            ViewBag.iD_NguoiDung = new SelectList(user.ListUsers(), "iD_NguoiDung", "hoTen", model.iD_NguoiDung);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(PhanQuyen entity)
        {
            var user = new NguoiDungDao();
            ViewBag.iD_NguoiDung = new SelectList(user.ListUsers(), "iDNguoiDung", "hoTen", entity.iD_NguoiDung);
            if (dao.UpdateQuyen(entity))
            {
                return RedirectToAction("Index", "PhanQuyens");
            }
            else
            {
                return View(entity);
            }
        }
    }
}