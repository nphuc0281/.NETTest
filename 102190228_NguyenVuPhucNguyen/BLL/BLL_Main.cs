using System;
using System.Collections.Generic;
using System.Linq;
using _102190228_NguyenVuPhucNguyen.DTO;
using _102190228_NguyenVuPhucNguyen.DAL;

namespace _102190228_NguyenVuPhucNguyen.BLL
{
    public class BLL_Main
    {
        private static BLL_Main _Instance;
        public static BLL_Main Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Main();
                }
                return _Instance;
            }

            private set { }
        }

        public List<SanPham> GetListSanPham(List<SanPham> data = null, string text = null, bool search = false, string ID = null, string IDTTP = null, int IDNCC = -1)
        {
            QLSP context = new QLSP();
            if (search)
            {
                List<SanPham> result = new List<SanPham>();
                try
                {
                    float n = float.Parse(text);
                    result.AddRange(data.Select(p => p).Where(p => p.GiaNhap == n).ToList());
                }
                catch (Exception)
                {
                    result.AddRange(data.Select(p => p).Where(p => p.TenSanPham.Contains(text)).ToList());
                    result.AddRange(data.Select(p => p).Where(p => p.NhaCungCap.TenNCC.Contains(text)).ToList());
                    result.AddRange(data.Select(p => p).Where(p => p.NhaCungCap.DiaChi.TenTTP.Contains(text)).ToList());
                }
                return result.Distinct().ToList();
            }
            
            if (IDTTP != null && IDNCC != -1) return context.SanPhams.Where(p => p.MaNCC == IDNCC && p.NhaCungCap.MaTTP == IDTTP).ToList();
            if (IDTTP != null && IDNCC == -1) return context.SanPhams.Where(p => p.NhaCungCap.DiaChi.MaTTP == IDTTP).ToList();
            if (IDTTP == null && IDNCC != -1) return context.SanPhams.Where(p => p.MaNCC == IDNCC).ToList();

            return context.SanPhams.ToList();
        }

        public SanPham GetSanPham(string id) {
            QLSP context = new QLSP();
            return context.SanPhams.Find(id);
        }

        public List<DiaChi> GetListDiaChi(string ID = null)
        {
            QLSP context = new QLSP();
            if (ID != null) return context.DiaChis.Where(p => p.MaTTP == ID).ToList();
            return context.DiaChis.ToList();
        }

        public List<NhaCungCap> GetListNCC(string IDTTP = null)
        {
            QLSP context = new QLSP();
            if (IDTTP != null) return context.NhaCungCaps.Where(p => p.DiaChi.MaTTP == IDTTP).ToList();
            return context.NhaCungCaps.ToList();
        }

        public void DelSP(List<string> list)
        {
            QLSP context = new QLSP();
            foreach (string i in list)
            {
                SanPham id = context.SanPhams.Where(p => p.MaSanPham == i).FirstOrDefault();
                context.SanPhams.Remove(id);
            }
            context.SaveChanges();
        }

        public void ExcuteDB(SanPham i)
        {
            try
            {
                QLSP context = new QLSP();
                SanPham sp = context.SanPhams.Find(i.MaSanPham);
                if (sp != null)
                {
                    sp.MaSanPham = i.MaSanPham;
                    sp.TenSanPham = i.TenSanPham;
                    sp.GiaNhap = i.GiaNhap;
                    sp.SoLuong = i.SoLuong;
                    sp.NgayNhap = i.NgayNhap;
                    sp.MaNCC = i.MaNCC;
                }
                else
                {
                    context.SanPhams.Add(i);
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SanPham> Sort(List<SanPham> list, string str, bool reverse = false)
        {
            QLSP context = new QLSP();
            List<SanPham> new_list = null;

            if (!reverse)
            {
                switch (str)
                {
                    case "Ten SP": new_list = list.OrderBy(p => p.TenSanPham).ToList(); break;
                    case "Gia nhap": new_list = list.OrderBy(p => p.GiaNhap).ToList(); break;
                    case "Tinh Trang": new_list = list.OrderBy(p => p.TinhTrang).ToList(); break;
                }
            }
            else
            {
                switch (str)
                {
                    case "Ten SP": new_list = list.OrderBy(p => p.TenSanPham).Reverse().ToList(); break;
                    case "Gia nhap": new_list = list.OrderBy(p => p.GiaNhap).Reverse().ToList(); break;
                    case "Tinh Trang": new_list = list.OrderBy(p => p.TinhTrang).Reverse().ToList(); break;
                }
            }

            return new_list;
        }
    }
}
