using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _102190228_NguyenVuPhucNguyen.DTO
{
    public class NhaCungCap
    {
        public NhaCungCap()
        {
            SanPhams = new HashSet<SanPham>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        [StringLength(2)]
        public string MaTTP { get; set; }
        
        [ForeignKey("MaTTP")]
        public virtual DiaChi DiaChi { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
        public override string ToString()
        {
            return TenNCC;
        }
    }
}
