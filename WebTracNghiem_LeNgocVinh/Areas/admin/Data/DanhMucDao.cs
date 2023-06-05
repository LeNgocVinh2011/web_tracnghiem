using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Data
{
    public class DanhMucDao
    {
        private DBData dbDT = new DBData();
        public List<DanhMucLuat> ListDanhMuc()
        {
            return dbDT.DanhMucLuats.OrderByDescending(x => x.iD_DanhMuc).ToList();
        }

        public DanhMucLuat getListDM(int iD_DanhMuc)
        {
            return dbDT.DanhMucLuats.Find(iD_DanhMuc);
        }

        public bool InsertDM(DanhMucLuat entity)
        {
            try
            {
                dbDT.DanhMucLuats.Add(entity);
                dbDT.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDM(DanhMucLuat entity)
        {
            try
            {
                var model = dbDT.DanhMucLuats.Find(entity.iD_DanhMuc);
                if (model != null)
                {
                    model.tenDanhMuc = entity.tenDanhMuc;
                    dbDT.SaveChanges();
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

        public bool Delete(DanhMucLuat entity)
        {
            try
            {
                var model = dbDT.DanhMucLuats.Find(entity.iD_DanhMuc);
                if (model != null)
                {
                    dbDT.DanhMucLuats.Remove(model);
                    dbDT.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}