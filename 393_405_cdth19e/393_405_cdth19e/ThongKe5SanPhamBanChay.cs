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
    public partial class frmThongKe5SanPhamBanChay : Form
    {
        public frmThongKe5SanPhamBanChay()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (txtThang.Text == "" || txtNam.Text == "")
            {
                DialogResult kq = MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = "SELECT TOP 5  TenSp,SUM(CT_HoaDon.SoLuong) AS BANCHAY FROM SanPham, CT_HoaDon, HoaDon WHERE CT_HoaDon.MaHD = HoaDon.MaHD AND CT_HoaDon.MaSp = SanPham.MaSp AND MONTH(NgayLapHD)= "+txtThang.Text+" AND YEAR(NgayLapHD)= "+txtNam.Text+" GROUP BY TenSp ORDER BY BANCHAY DESC";
                LayDuLieu(sql, dgvBanChay);
                groupBox1.Text = groupBox1.Text + "Tháng " + txtThang.Text + " Năm " + txtNam.Text;
            }
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void ThongKe5SanPhamBanChay_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
