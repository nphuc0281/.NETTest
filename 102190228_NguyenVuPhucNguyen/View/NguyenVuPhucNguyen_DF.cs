using System;
using System.Windows.Forms;
using _102190228_NguyenVuPhucNguyen.DTO;
using _102190228_NguyenVuPhucNguyen.BLL;

namespace _102190228_NguyenVuPhucNguyen.View
{
    public partial class DetailForm : Form
    {
        public delegate void reload(object sender, EventArgs e);
        public reload Reload;
        public DetailForm()
        {
            InitializeComponent();
            SetCBB();
        }

        private void SetCBB()
        {
            foreach (DiaChi i in BLL_Main.Instance.GetListDiaChi())
            {
                cbbTTP.Items.Add(new CBBItem() { Tag = i.MaTTP, Text = i.TenTTP });
            }
            cbbTTP.SelectedIndex = 0;
            cbbNCC.SelectedIndex = 0;
        }

        public void SetCBBNCC(string IDTTP)
        {
            cbbNCC.Items.Clear();
            foreach (NhaCungCap i in BLL_Main.Instance.GetListNCC(IDTTP))
            {
                cbbNCC.Items.Add(new CBBItem() { ID = i.MaNCC, Text = i.TenNCC });
            }
            cbbNCC.SelectedIndex = 0;
        }

        public void LoadInfo(SanPham i = null)
        {
            txtID.Text = i.MaSanPham;
            txtName.Text = i.TenSanPham;
            txtCost.Text = i.GiaNhap.ToString();
            txtQty.Text = i.SoLuong.ToString();
            dtpDate.Value = i.NgayNhap;
            cbbTTP.Text = i.NhaCungCap.DiaChi.TenTTP;
            SetCBBNCC(i.NhaCungCap.MaTTP);
            cbbNCC.Text = i.NhaCungCap.TenNCC;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtCost.Text == "" || txtName.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("Khong duoc de trong cac truong.");
                return;
            }
            try
            {
                float a = float.Parse(txtCost.Text);
                int b = int.Parse(txtQty.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Sai dinh dang so lieu.");
                return;
            }
                
            SanPham i = new SanPham()
            {
                MaSanPham = txtID.Text,
                TenSanPham = txtName.Text,
                GiaNhap = float.Parse(txtCost.Text),
                NgayNhap = dtpDate.Value,
                SoLuong = int.Parse(txtQty.Text),
                MaNCC = ((CBBItem)cbbNCC.SelectedItem).ID
            };
            try
            {
                BLL_Main.Instance.ExcuteDB(i);
            }
            catch
            {
                MessageBox.Show("Thao tac that bai.");
                return;
            }
            Reload(null, null);
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cbbTTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCBBNCC(((CBBItem)cbbTTP.SelectedItem).Tag);
        }
    }
}
