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
    public partial class frmTimThongTinChiTietCua1HoaDon : Form
    {
        public frmTimThongTinChiTietCua1HoaDon()
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
        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql = "select CT_HoaDon.MaSp,CT_HoaDon.SoLuong,CT_HoaDon.DonGia,CT_HoaDon.ChietKhau, CT_HoaDon.SoLuong* CT_HoaDon.DonGia as TongTien from HoaDon, CT_HoaDon where HoaDon.MaHD = CT_HoaDon.MaHD and HoaDon.MaHD = '" + txtMaHoaDon.Text + "'";
            LayDuLieu(sql, dgvDanhSachChiTietHoaDon);
        }

        private void frmTimThongTinChiTietCua1HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void frmTimThongTinChiTietCua1HoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
