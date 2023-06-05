namespace WebTracNghiem_LeNgocVinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQua")]
    public partial class KetQua
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iD_NguoiDung { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iD_De { get; set; }

        public int? soCauDung { get; set; }

        [Column("ketQua")]
        [StringLength(10)]
        public string ketQua1 { get; set; }

        public virtual DeThi DeThi { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
