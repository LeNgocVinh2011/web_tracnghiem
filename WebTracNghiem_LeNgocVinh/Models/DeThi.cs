namespace WebTracNghiem_LeNgocVinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeThi()
        {
            KetQuas = new HashSet<KetQua>();
        }

        [Key]
        public int iD_De { get; set; }
        [Display(Name = "Ngày thi")]
        [StringLength(100)]
        public string ngayThi { get; set; }
        [Display(Name = "Thời gian thi")]
        public int? thoiGianThi { get; set; }
        [Display(Name = "Số câu")]
        public int? soCau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
