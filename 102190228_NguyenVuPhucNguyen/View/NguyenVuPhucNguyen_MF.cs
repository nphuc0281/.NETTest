using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _102190228_NguyenVuPhucNguyen.DTO;
using _102190228_NguyenVuPhucNguyen.BLL;

namespace _102190228_NguyenVuPhucNguyen.View
{
    public partial class MainForm : Form
    {
        bool reverse = false;
        public MainForm()
        {
            InitializeComponent();
            SetCBB();
            cbbSort.SelectedIndex = 0;
        }

        public void SetCBB()
        {
            cbbNCC.Items.Add(new CBBItem() { Text = "All" });
            cbbTTP.Items.Add(new CBBItem() { Text = "All" });
            foreach (DiaChi i in BLL_Main.Instance.GetListDiaChi())
            {
                cbbTTP.Items.Add(new CBBItem() { Tag = i.MaTTP, Text = i.TenTTP });
            }
            cbbTTP.SelectedIndex = 0;
        }

        public void SetCBBNCC(string IDTTP)
        {
            cbbNCC.Items.Clear();
            cbbNCC.Items.Add(new CBBItem() { Text = "All" });

            if (cbbTTP.Text == "All")
            {
                foreach (NhaCungCap i in BLL_Main.Instance.GetListNCC())
                {
                    cbbNCC.Items.Add(new CBBItem() { ID = i.MaNCC, Text = i.TenNCC });
                }
            }
            else
            {
                foreach (NhaCungCap i in BLL_Main.Instance.GetListNCC(IDTTP))
                {
                    cbbNCC.Items.Add(new CBBItem() { ID = i.MaNCC, Text = i.TenNCC });
                }
            }
            cbbNCC.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = BLL_Main.Instance.GetListSanPham(IDTTP: ((CBBItem)cbbTTP.SelectedItem).Tag, IDNCC: ((CBBItem)cbbNCC.SelectedItem).ID);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm f = new DetailForm();
            f.Reload += new DetailForm.reload(btnShow_Click);
            f.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            List<string> listID = new List<string>();
            foreach (DataGridViewRow i in dataGridView.SelectedRows)
            {
                listID.Add(i.Cells[0].Value.ToString());
            }
            BLL_Main.Instance.DelSP(listID);
            btnShow_Click(null, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<SanPham> list = BLL_Main.Instance.GetListSanPham(IDTTP: ((CBBItem)cbbTTP.SelectedItem).Tag, IDNCC: ((CBBItem)cbbNCC.SelectedItem).ID);
            dataGridView.DataSource= BLL_Main.Instance.GetListSanPham(list, txtSearch.Text, true);
        }

        private void cbbTTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCBBNCC(((CBBItem)cbbTTP.SelectedItem).Tag);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            DetailForm f = new DetailForm();
            f.LoadInfo(BLL_Main.Instance.GetSanPham(dataGridView.CurrentRow.Cells[0].Value.ToString()));
            f.Reload += new DetailForm.reload(btnShow_Click);
            f.Show();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<SanPham> list = BLL_Main.Instance.GetListSanPham(IDTTP: ((CBBItem)cbbTTP.SelectedItem).Tag, IDNCC: ((CBBItem)cbbNCC.SelectedItem).ID);
            dataGridView.DataSource = BLL_Main.Instance.Sort(list, cbbSort.Text, reverse);
            reverse = (reverse) ? false:true;
        }
    }
}
