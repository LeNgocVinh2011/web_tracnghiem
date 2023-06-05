using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTracNghiem_LeNgocVinh.Models;
using System.Data.Entity;
using WebTracNghiem_LeNgocVinh.Help;

namespace WebTracNghiem_LeNgocVinh.Areas.admin.Data
{
    public class NguoiDungDao
    {
        private DBData db = new DBData();
        public List<NguoiDung> ListUsers()
        {
            return db.NguoiDungs.OrderByDescending(x => x.iD_NguoiDung).ToList();
        }

        public List<NguoiDung> ListAdmin()
        {
            return db.NguoiDungs.OrderByDescending(x => x.iD_NguoiDung).Where(x => x.PhanQuyen.laAdmin == "admin").ToList();
        }
        public NguoiDung getListUser(int IDUser)
        {
            return db.NguoiDungs.Find(IDUser);
        }

        public bool InsertUser(NguoiDung entity)
        {
            try
            {
                db.NguoiDungs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUsers(NguoiDung entity)
        {
            Md5 md5 = new Md5();
            try
            {
                var model = db.NguoiDungs.Find(entity.iD_NguoiDung);
                if (model != null)
                {
                    model.tenDN = entity.tenDN;
                    model.matKhau = md5.GetMD5(entity.matKhau);
                    model.hoTen = entity.hoTen;
                    model.imgProfile = entity.imgProfile;
                    model.eMail = entity.eMail;
                    model.ghiChu = entity.ghiChu;
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

        public bool Delete(NguoiDung entity)
        {
            try
            {
                var model = db.NguoiDungs.Find(entity.iD_NguoiDung);
                if (model != null)
                {
                    db.NguoiDungs.Remove(model);
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