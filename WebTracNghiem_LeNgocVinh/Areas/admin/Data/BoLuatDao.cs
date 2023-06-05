using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Data
{
    public class BoLuatDao
    {
        private DBData dbDT = new DBData();
        public List<CauHois> ListLuatDuongbo()
        {
            return dbDT.CauHois.OrderByDescending(x => x.iD_DanhMuc).Where(x => x.DanhMucLuat.tenDanhMuc == "Luật giao thông đường bộ").ToList();
        }

        public List<CauHois> ListLuatDuongThuy()
        {
            return dbDT.CauHois.OrderByDescending(x => x.iD_DanhMuc).Where(x => x.DanhMucLuat.tenDanhMuc == "Luật giao thông đường thuỷ").ToList();
        }

        public List<CauHois> ListLuatDuongSat()
        {
            return dbDT.CauHois.OrderByDescending(x => x.iD_DanhMuc).Where(x => x.DanhMucLuat.tenDanhMuc == "Luật giao thông đường sắt").ToList();
        }
    }
}