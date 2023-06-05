using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Data
{
    public class PhanQuyenDao
    {
        private DBData db = new DBData();
        public List<PhanQuyen> ListPhanQuyen()
        {
            var phanQuyens = db.PhanQuyens.Include(x => x.NguoiDung);
            return phanQuyens.OrderByDescending(x => x.iD_NguoiDung).ToList();
        }

        public PhanQuyen getListPQ(int iD_NguoiDung)
        {
            return db.PhanQuyens.Find(iD_NguoiDung);
        }

        public bool InsertQuyen(PhanQuyen entity)
        {
            try
            {
                db.PhanQuyens.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateQuyen(PhanQuyen entity)
        {
            try
            {
                var model = db.PhanQuyens.Find(entity.iD_NguoiDung);
                if (model != null)
                {
                    model.iD_NguoiDung = entity.iD_NguoiDung;
                    model.laAdmin = entity.laAdmin;
                    model.laUser = entity.laUser;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}