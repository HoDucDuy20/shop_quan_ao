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
    public partial class frmThongKeTongSoLuongBan : Form
    {
        public frmThongKeTongSoLuongBan()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql,DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (txtThang.Text==""||txtNam.Text=="")
            {
                DialogResult kq = MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = "SELECT TenSp,SUM(CT_HoaDon.SoLuong) AS TONGSOLUONG FROM SanPham, CT_HoaDon, HoaDon WHERE CT_HoaDon.MaSp = SanPham.MaSp AND CT_HoaDon.MaHD = HoaDon.MaHD AND MONTH(NgayLapHD)= " + txtThang.Text + " AND YEAR(NgayLapHD)= " + txtNam.Text + " GROUP BY TenSp";
                LayDuLieu(sql, dgvTongSoLuong);
                groupBox1.Text =groupBox1.Text+"tháng "+txtThang.Text + " năm " + txtNam.Text;
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

        private void frmThongKeTongSoLuongBan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmThongKeTongSoLuongBan_Load(object sender, EventArgs e)
        {

        }
    }
}
