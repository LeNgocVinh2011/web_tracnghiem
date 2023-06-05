namespace WebTracNghiem_LeNgocVinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanhMucLuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucLuat()
        {
            CauHois = new HashSet<CauHois>();
        }

        [Key]
        public int iD_DanhMuc { get; set; }
        [Display(Name = "Tên danh mục")]
        [StringLength(100)]
        public string tenDanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHois> CauHois { get; set; }
    }
}
