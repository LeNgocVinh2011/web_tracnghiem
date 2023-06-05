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
    public class DanhMucsController : BaseController
    {
        DanhMucDao dao = new DanhMucDao();
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.tenDanhMucParam = sortOrder == "tcm_asc" ? "tcm_desc" : "tcm_asc";

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

            var model = from cm in dao.ListDanhMuc()
                        select cm;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(cm => cm.tenDanhMuc.ToUpper().Contains(searchString.ToUpper()));
                model = model.Where(m => m.tenDanhMuc.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "tcm_desc":
                    model = model.OrderByDescending(m => m.tenDanhMuc);
                    break;
                case "tcm_asc":
                    model = model.OrderBy(m => m.tenDanhMuc);
                    break;
                default:
                    model = model.OrderBy(m => m.tenDanhMuc);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            ViewBag.totalRecode = model.Count();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int iD_DanhMuc)
        {

            return View(dao.getListDM(iD_DanhMuc));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMucLuat entity)
        {
            if (dao.InsertDM(entity))
            {
                return RedirectToAction("Index", "DanhMucs");
            }
            else
            {
                return View(entity);
            }
        }
        [HttpGet]
        public ActionResult Edit(int iD_DanhMuc)
        {
            var model = dao.getListDM(iD_DanhMuc);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DanhMucLuat entity)
        {
            if (dao.UpdateDM(entity) == true)
            {
                return RedirectToAction("Index", "DanhMucs");
            }

            else
            {
                return View(entity);
            }
        }

        [HttpGet]
        public ActionResult Delete(int iD_DanhMuc)
        {
            var model = dao.getListDM(iD_DanhMuc);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(DanhMucLuat entity)
        {
            var model = dao.getListDM(entity.iD_DanhMuc);
            if (model != null)
            {
                if (dao.Delete(entity) == true)
                {
                    return RedirectToAction("Index", "DanhMucs");
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