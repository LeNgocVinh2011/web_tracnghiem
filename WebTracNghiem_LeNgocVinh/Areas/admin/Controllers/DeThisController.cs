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
    public class DeThisController : BaseController
    {
            DeThiDao dao = new DeThiDao();
            public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.ngayThi = sortOrder == "ngThi_asc" ? "ngThi_desc" : "ngThi_asc";

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

                var model = from cm in dao.ListTest()
                            select cm;

                if (!String.IsNullOrEmpty(searchString))
                {
                    model = model.Where(cm => cm.ngayThi.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "ngThi_desc":
                        model = model.OrderByDescending(m => m.ngayThi);
                        break;
                    case "ngThi_asc":
                        model = model.OrderBy(m => m.ngayThi);
                        break;
                    default:
                        model = model.OrderBy(m => m.iD_De);
                        break;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);

                ViewBag.totalRecode = model.Count();
                return View(model.ToPagedList(pageNumber, pageSize));
            }

        public ActionResult Details(int iD_De)
        {

            return View(dao.getListTest(iD_De));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeThi entity)
        {
            if (dao.InsertTest(entity))
            {
                return RedirectToAction("Index", "DeThis");
            }
            else
            {
                return View(entity);
            }
        }

        [HttpGet]
        public ActionResult Edit(int iD_De)
        {
            var model = dao.getListTest(iD_De);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DeThi entity)
        {
            if (dao.UpdateTest(entity) == true)
            {
                return RedirectToAction("Index", "DeThis");
            }

            else
            {
                return View(entity);
            }
        }

        [HttpGet]
        public ActionResult Delete(int iD_De)
        {
            var model = dao.getListTest(iD_De);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(DeThi entity)
        {
            var model = dao.getListTest(entity.iD_De);
            if (model != null)
            {
                if (dao.Delete(entity) == true)
                {
                    return RedirectToAction("Index", "DeThis");
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