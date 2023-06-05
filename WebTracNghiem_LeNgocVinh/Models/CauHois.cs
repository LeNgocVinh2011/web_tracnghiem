namespace WebTracNghiem_LeNgocVinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CauHois
    {
        [Key]
        public int iD_CauHoi { get; set; }
        [Display(Name = "Danh mục luật")]
        public int? iD_DanhMuc { get; set; }
        [Display(Name = "Người tạo")]
        public int? iD_NguoiDung { get; set; }
        [Display(Name = "Câu hỏi")]
        [StringLength(1000)]
        public string cauHoi { get; set; }
        [Display(Name = "Liên kết ảnh")]
        [StringLength(500)]
        public string urlImg { get; set; }
        [Display(Name = "Đáp án A")]
        [StringLength(1000)]
        public string dapAnA { get; set; }
        [Display(Name = "Đáp án B")]
        [StringLength(1000)]
        public string dapAnB { get; set; }
        [Display(Name = "Đáp án C")]
        [StringLength(1000)]
        public string dapAnC { get; set; }
        [Display(Name = "Đáp án D")]
        [StringLength(1000)]
        public string dapAnD { get; set; }
        [Display(Name = "Đáp án")]
        [StringLength(1000)]
        public string dapAn { get; set; }
        [Display(Name = "Ngày tạo")]
        [StringLength(100)]
        public string ngayTao { get; set; }
        [Display(Name = "Ngày sửa")]
        [StringLength(100)]
        public string ngaySua { get; set; }

        public virtual DanhMucLuat DanhMucLuat { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
