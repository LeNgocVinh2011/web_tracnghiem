using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Data
{
    public class DeThiDao
    {
        DBData db = new DBData();
        public List<DeThi> ListTest()
        {
            return db.DeThis.OrderByDescending(x => x.iD_De).ToList();
        }

        public DeThi getListTest(int iD_De)
        {
            return db.DeThis.Find(iD_De);
        }

        public bool InsertTest(DeThi entity)
        {
            try
            {
                db.DeThis.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTest(DeThi entity)
        {
            try
            {
                var model = db.DeThis.Find(entity.iD_De);
                if (model != null)
                {
                    model.ngayThi = entity.ngayThi;
                    model.thoiGianThi = entity.thoiGianThi;
                    model.soCau = entity.soCau;
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

        public bool Delete(DeThi entity)
        {
            try
            {
                var model = db.DeThis.Find(entity.iD_De);
                if (model != null)
                {
                    db.DeThis.Remove(model);
                    db.SaveChanges();
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