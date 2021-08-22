using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _102190228_NguyenVuPhucNguyen.DTO
{
    public class DiaChi
    {
        public DiaChi()
        {
            NhaCungCaps = new HashSet<NhaCungCap>();
        }
        [Key]
        [StringLength(2)]
        public string MaTTP { get; set; }
        public string TenTTP { get; set; }
        public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; }
    }
}
