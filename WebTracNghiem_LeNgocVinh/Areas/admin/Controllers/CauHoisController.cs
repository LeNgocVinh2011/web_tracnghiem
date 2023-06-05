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
    public class CauHoisController : BaseController
    {
        CauHoiDao dao = new CauHoiDao();
        // GET: admin/CauHois
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page, string filterQuestion)
        {
            var model = from m in dao.listAll()
                        select m;
            var dmuc = from dm in model.Select(
                i => new
                    {
                        iD_DanhMuc = i.iD_DanhMuc,
                        tenDanhMuc = i.DanhMucLuat.tenDanhMuc
                    }
                ).Distinct()
                select dm;
            ViewBag.filterQuestion = new SelectList(dmuc, "iD_DanhMuc", "tenDanhMuc");
            if (!String.IsNullOrEmpty(filterQuestion))
            {
                int _iDDanhMuc = Int32.Parse(filterQuestion);
                model = model.Where(m => m.iD_DanhMuc == _iDDanhMuc);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(q => q.cauHoi.ToUpper().Contains(searchString.ToUpper())
                                || q.ngayTao.Contains(searchString)
                                || q.NguoiDung.hoTen.ToUpper().Contains(searchString.ToUpper())
                    );
            }

            ViewBag.CauHoi_Admin = sortOrder == "ad_asc" ? "ad_desc" : "ad_asc";
            ViewBag.NgayTao = sortOrder == "ngTao_asc" ? "ngTao_desc" : "ngTao_asc";
            ViewBag.NgaySua = sortOrder == "ngSua_asc" ? "ngSua_desc" : "ngSua_asc";
            switch (sortOrder)
            {
                case "ad_desc":
                    model = model.OrderByDescending(m => m.NguoiDung.hoTen);
                    break;
                case "ad_asc":
                    model = model.OrderBy(m => m.NguoiDung.hoTen);
                    break;
                case "ngTao_desc":
                    model = model.OrderByDescending(m => m.ngayTao);
                    break;
                case "ngTao_asc":
                    model = model.OrderBy(m => m.ngayTao);
                    break;
                case "ngSua_desc":
                    model = model.OrderByDescending(m => m.ngaySua);
                    break;
                case "ngSua_asc":
                    model = model.OrderBy(m => m.ngaySua);
                    break;
                default:
                    model = model.OrderBy(m => m.iD_CauHoi);
                    break;

            }
            if(page == null)
            {
                page = 1;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1 );

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.pageCurren = page;
            ViewBag.CurrentFilter = currentFilter;
            ViewBag.FilterSort = filterQuestion;
            ViewBag.currentSort = sortOrder;
            ViewBag.totalRecord = model.Count();
            return View(model.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Details(int iD_CauHoi)
        {
            return View(dao.getById(iD_CauHoi));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var dmuc = new DanhMucDao();
            var user = new NguoiDungDao();
            ViewBag.iD_DanhMuc = new SelectList(dmuc.ListDanhMuc(), "iD_DanhMuc", "tenDanhMuc");
            ViewBag.iD_NguoiDung = new SelectList(user.ListAdmin(), "iD_NguoiDung", "hoTen");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CauHois entity)
        {
            var dmuc = new DanhMucDao();
            var user = new NguoiDungDao();
            ViewBag.iD_DanhMuc = new SelectList(dmuc.ListDanhMuc(), "iD_DanhMuc", "tenDanhMuc", entity.iD_DanhMuc);
            ViewBag.iD_NguoiDung = new SelectList(user.ListAdmin(), "iD_NguoiDung", "hoTen", entity.iD_NguoiDung);
            if (dao.inSertCauHoi(entity))
            {
                return RedirectToAction("Index", "CauHois");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int iD_CauHoi)
        {
            var model = dao.getById(iD_CauHoi);
            var dmuc = new DanhMucDao();
            var user = new NguoiDungDao();
            ViewBag.iD_DanhMuc = new SelectList(dmuc.ListDanhMuc(), "iD_DanhMuc", "tenDanhMuc", model.iD_DanhMuc);
            ViewBag.iD_NguoiDung = new SelectList(user.ListAdmin(), "iD_NguoiDung", "hoTen", model.iD_NguoiDung);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CauHois entity)
        {
            var dmuc = new DanhMucDao();
            var user = new NguoiDungDao();
            ViewBag.iD_DanhMuc = new SelectList(dmuc.ListDanhMuc(), "iD_DanhMuc", "tenDanhMuc", entity.iD_DanhMuc);
            ViewBag.iD_NguoiDung = new SelectList(user.ListAdmin(), "iDNguoiDung", "hoTen", entity.iD_NguoiDung);
            if (dao.upDate(entity))
            {
                return RedirectToAction("Index", "CauHois");
            }
            else
            {
                return View(entity);
            }
        }
        [HttpGet]
        public ActionResult Delete(int iD_CauHoi)
        {
            var model = dao.getById(iD_CauHoi);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Delete(CauHois entity)
        {
            var model = dao.getById(entity.iD_CauHoi);
            if (model != null)
            {
                if (dao.Delete(model))
                {
                    return RedirectToAction("Index", "CauHois");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Index", "CauHois");
            }
        }
    }
}