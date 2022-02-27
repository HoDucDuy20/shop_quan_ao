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
    public partial class frmTimHoaDonTheoKhachHang : Form
    {
        public frmTimHoaDonTheoKhachHang()
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
        private void txtTenKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            string sql = "select KhachHang.TenKh,HoaDon.MaHD,HoaDon.NgayLapHD,HoaDon.TongTien,HoaDon.TrangThai,HoaDon.LoaiHD from KhachHang,HoaDon where KhachHang.MaKh = HoaDon.MaKh and TenKh like N'%" + txtTenKhachHang.Text + "%'";
            LayDuLieu(sql, dgvDanhSach);

        }

        private void frmTimHoaDonTheoKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
