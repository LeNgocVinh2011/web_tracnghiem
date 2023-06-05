using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTracNghiem_LeNgocVinh.Models;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Data
{
    public class CauHoiDao
    {
        DBData db = new DBData();

        public List<CauHois> listAll()
        {
            var listCauHoi = db.CauHois.Include(t => t.DanhMucLuat).Include(t => t.NguoiDung);
            return listCauHoi.OrderByDescending(x => x.iD_CauHoi).ToList();
        }

        public CauHois getById(int iD_CauHoi)
        {
            return db.CauHois.Find(iD_CauHoi);
        }

        public bool inSertCauHoi(CauHois entity)
        {
            entity.ngayTao = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            entity.ngaySua = "";
            try
            {
                db.CauHois.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool upDate(CauHois entity)
        {
            try
            {
                var model = db.CauHois.Find(entity.iD_CauHoi);
                if(model != null)
                {
                    model.iD_DanhMuc = entity.iD_DanhMuc;
                    model.iD_NguoiDung = entity.iD_NguoiDung;
                    model.cauHoi = entity.cauHoi;
                    model.dapAnA = entity.dapAnA;
                    model.dapAnB = entity.dapAnB;
                    model.dapAnC = entity.dapAnC;
                    model.dapAnD = entity.dapAnD;
                    model.dapAn = entity.dapAn;
                    entity.ngaySua = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                    model.ngaySua = entity.ngaySua;
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            { 
                return false;
            }
        }

        public bool Delete(CauHois entity)
        {
            try
            {
                var model = db.CauHois.Find(entity.iD_CauHoi);
                if(model != null)
                {
                    db.CauHois.Remove(model);
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}