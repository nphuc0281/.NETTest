using System;
using System.Data.Entity;
using _102190228_NguyenVuPhucNguyen.DTO;

namespace _102190228_NguyenVuPhucNguyen.DAL
{
    class CreateDB : DropCreateDatabaseIfModelChanges<QLSP>
    {
        protected override void Seed(QLSP context)
        {
            context.DiaChis.AddRange(new DiaChi[]
            {
                new DiaChi(){ MaTTP = "1", TenTTP = "Da Nang"},
                new DiaChi(){ MaTTP = "2", TenTTP = "Thua Thien Hue"},
            });

            context.NhaCungCaps.AddRange(new NhaCungCap[]
            {
                new NhaCungCap(){MaNCC = 1, TenNCC ="ABC", MaTTP = "1"},
                new NhaCungCap(){MaNCC = 2, TenNCC ="XYZ", MaTTP = "2"},
                new NhaCungCap(){MaNCC = 3, TenNCC ="LMN", MaTTP = "2"},
            });

            context.SanPhams.AddRange(new SanPham[]
            {
                new SanPham(){MaSanPham = "1", TenSanPham = "A a a", GiaNhap = 34000, SoLuong = 10, NgayNhap = DateTime.Now, MaNCC = 1},
                new SanPham(){MaSanPham = "2", TenSanPham = "B b b", GiaNhap = 1000, SoLuong = 0, NgayNhap = DateTime.Now, MaNCC = 3},
                new SanPham(){MaSanPham = "3", TenSanPham = "C c c c", GiaNhap = 14000, SoLuong = 10, NgayNhap = DateTime.Now, MaNCC = 2},
            });
        }
    }
}
