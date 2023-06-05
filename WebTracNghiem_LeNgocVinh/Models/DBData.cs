using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebTracNghiem_LeNgocVinh.Models
{
    public partial class DBData : DbContext
    {
        public DBData()
            : base("name=DBData")
        {
        }

        public virtual DbSet<CauHois> CauHois { get; set; }
        public virtual DbSet<DanhMucLuat> DanhMucLuats { get; set; }
        public virtual DbSet<DeThi> DeThis { get; set; }
        public virtual DbSet<KetQua> KetQuas { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeThi>()
                .HasMany(e => e.KetQuas)
                .WithRequired(e => e.DeThi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.KetQuas)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasOptional(e => e.PhanQuyen)
                .WithRequired(e => e.NguoiDung);
        }
    }
}
