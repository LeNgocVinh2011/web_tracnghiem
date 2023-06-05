namespace WebTracNghiem_LeNgocVinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iD_NguoiDung { get; set; }
        [Display(Name = "Là Admin")]
        [StringLength(500)]
        public string laAdmin { get; set; }
        [Display(Name = "Là người dùng")]
        [StringLength(500)]
        public string laUser { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
