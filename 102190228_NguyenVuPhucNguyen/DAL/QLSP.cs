using System.Data.Entity;
using _102190228_NguyenVuPhucNguyen.DTO;

namespace _102190228_NguyenVuPhucNguyen.DAL
{
    public class QLSP : DbContext
    {
        public QLSP()
            : base("name=QLSP")
        {
            Database.SetInitializer<QLSP>(new CreateDB());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
    }

}