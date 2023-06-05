using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem_LeNgocVinh.Areas.admin.Data;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Controllers
{
    public class BoLuatsController : BaseController
    {
        BoLuatDao dao = new BoLuatDao();
        // GET: admin/BoLuats
        public ActionResult LuatDuongBo(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CauHoi = sortOrder == "cauhoi_asc" ? "cauhoi_desc" : "cauhoi_asc";
            ViewBag.NgayTao = sortOrder == "ngTao_asc" ? "ngTao_desc" : "ngTao_asc";

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

            var model = from cm in dao.ListLuatDuongbo()
                        select cm;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(cm => cm.cauHoi.ToUpper().Contains(searchString.ToUpper())
                                    || cm.ngayTao.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "cauhoi_desc":
                    model = model.OrderByDescending(m => m.cauHoi);
                    break;
                case "cauhoi_asc":
                    model = model.OrderBy(m => m.cauHoi);
                    break;
                case "ngTao_desc":
                    model = model.OrderByDescending(m => m.ngayTao);
                    break;
                case "ngTao_asc":
                    model = model.OrderBy(m => m.ngayTao);
                    break;
                default:
                    model = model.OrderBy(m => m.iD_CauHoi);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            ViewBag.totalRecode = model.Count();
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult LuatDuongThuy(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CauHoi = sortOrder == "cauhoi_asc" ? "cauhoi_desc" : "cauhoi_asc";
            ViewBag.NgayTao = sortOrder == "ngTao_asc" ? "ngTao_desc" : "ngTao_asc";

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

            var model = from cm in dao.ListLuatDuongThuy()
                        select cm;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(cm => cm.cauHoi.ToUpper().Contains(searchString.ToUpper())
                                    || cm.ngayTao.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "cauhoi_desc":
                    model = model.OrderByDescending(m => m.cauHoi);
                    break;
                case "cauhoi_asc":
                    model = model.OrderBy(m => m.cauHoi);
                    break;
                case "ngTao_desc":
                    model = model.OrderByDescending(m => m.ngayTao);
                    break;
                case "ngTao_asc":
                    model = model.OrderBy(m => m.ngayTao);
                    break;
                default:
                    model = model.OrderBy(m => m.iD_CauHoi);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            ViewBag.totalRecode = model.Count();
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult LuatDuongSat(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CauHoi = sortOrder == "cauhoi_asc" ? "cauhoi_desc" : "cauhoi_asc";
            ViewBag.NgayTao = sortOrder == "ngTao_asc" ? "ngTao_desc" : "ngTao_asc";

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

            var model = from cm in dao.ListLuatDuongSat()
                        select cm;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(cm => cm.cauHoi.ToUpper().Contains(searchString.ToUpper())
                                    || cm.ngayTao.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "cauhoi_desc":
                    model = model.OrderByDescending(m => m.cauHoi);
                    break;
                case "cauhoi_asc":
                    model = model.OrderBy(m => m.cauHoi);
                    break;
                case "ngTao_desc":
                    model = model.OrderByDescending(m => m.ngayTao);
                    break;
                case "ngTao_asc":
                    model = model.OrderBy(m => m.ngayTao);
                    break;
                default:
                    model = model.OrderBy(m => m.iD_CauHoi);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            ViewBag.totalRecode = model.Count();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
    }
}