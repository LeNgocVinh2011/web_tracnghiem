namespace WebTracNghiem_LeNgocVinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            CauHois = new HashSet<CauHois>();
            KetQuas = new HashSet<KetQua>();
        }

        [Key]
        public int iD_NguoiDung { get; set; }
        [Display(Name = "Họ tên")]
        [StringLength(100)]
        public string hoTen { get; set; }
        [Display(Name = "Ảnh profile")]
        [StringLength(500)]
        public string imgProfile { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [StringLength(50)]
        public string tenDN { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string matKhau { get; set; }
        [Display(Name = "Email")]
        [StringLength(100)]
        public string eMail { get; set; }
        [Display(Name = "Ghi chú")]
        [StringLength(1000)]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHois> CauHois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
