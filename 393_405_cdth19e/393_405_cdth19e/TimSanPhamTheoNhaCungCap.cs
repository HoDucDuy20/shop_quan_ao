using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _393_405_cdth19e
{
    public partial class frmTimSanPhamTheoNhaCungCap : Form
    {
        public frmTimSanPhamTheoNhaCungCap()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet dsNCC = new DataSet();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cmbTenNCC.SelectedIndex != -1)
                {
                    string sql = "select *from SanPham where MaNCC = '" + cmbTenNCC.SelectedValue.ToString() + "'";
                    LayDuLieu(sql, dgvDanhSachSanPham);
                }
            }
        }
        bool flag = false;
        private void frmTimSanPhamTheoNhaCungCap_Load(object sender, EventArgs e)
        {
            string sql = "select MaNCC,TenNcc from NhaCungCap";
            dsNCC = c.layDuLieu(sql);
            cmbTenNCC.DataSource = dsNCC.Tables[0];
            cmbTenNCC.DisplayMember = "TenNcc";
            cmbTenNCC.ValueMember = "MaNCC";
            cmbTenNCC.SelectedIndex = -1;
            flag = true;
        }

        private void frmTimSanPhamTheoNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
