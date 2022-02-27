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
    public partial class frmTimSanPhamTheoSize : Form
    {
        public frmTimSanPhamTheoSize()
        {
            InitializeComponent();
        }

        private void frmTimSanPhamTheoSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        DataSet dsSize = new DataSet();
        void hienThiDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        bool flag = false;
        private void frmTimSanPhamTheoSize_Load(object sender, EventArgs e)
        {
            string sql = "select MaKichThuoc,TenKichThuoc from KichThuoc";
            dsSize = c.layDuLieu(sql);
            cmbMau.DataSource = dsSize.Tables[0];
            cmbMau.DisplayMember = "TenKichThuoc";
            cmbMau.ValueMember = "MaKichThuoc";
            cmbMau.SelectedIndex = -1;
            flag = true;
        }

        private void cmbMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            {
                if (cmbMau.SelectedIndex != -1)
                {
                    string sql = "select SanPham.MaSp,SanPham.TenSp,SanPham.SoLuong, SanPham.GiaBan from SanPham where Size = '" + cmbMau.SelectedValue.ToString() + "'";
                    hienThiDuLieu(sql, dgvDanhSach);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
