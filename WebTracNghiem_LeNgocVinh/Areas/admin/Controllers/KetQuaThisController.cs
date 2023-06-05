using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Controllers
{
    public class KetQuaThisController : BaseController
    {
        DBData db = new DBData();
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ketQua = sortOrder == "tcm_asc" ? "tcm_desc" : "tcm_asc";
            ViewBag.SoCau = sortOrder == "soLuong_asc" ? "soLuong_desc" : "soLuong_asc";

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

            var model = from cm in db.KetQuas.OrderByDescending(x => x.iD_NguoiDung).ToList()
                        select cm;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(cm => cm.NguoiDung.hoTen.ToUpper().Contains(searchString.ToUpper())
                            || cm.DeThi.ngayThi.Contains(searchString)
                    );
            }

            switch (sortOrder)
            {
                case "tcm_desc":
                    model = model.OrderByDescending(m => m.ketQua1);
                    break;
                case "tcm_asc":
                    model = model.OrderBy(m => m.ketQua1);
                    break;

                case "soLuong_desc":
                    model = model.OrderByDescending(m => m.soCauDung);
                    break;
                case "soLuong_asc":
                    model = model.OrderBy(m => m.soCauDung);
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
    }
}