using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _102190228_NguyenVuPhucNguyen.DTO
{
    public class SanPham
    {
        [Key][StringLength(10)]
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float GiaNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        [NotMapped]
        public bool TinhTrang
        {
            get
            {
                if (SoLuong > 0) return true;
                return false;
            }
            private set { }
        }
        [Browsable(false)]
        public int SoLuong { get; set; }
        public int MaNCC { get; set; }

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
