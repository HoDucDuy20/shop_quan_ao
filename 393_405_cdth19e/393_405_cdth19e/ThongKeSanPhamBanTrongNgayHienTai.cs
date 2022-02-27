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
    public partial class frmThongKeSanPhamBanTrongNgayHienTai : Form
    {
        public frmThongKeSanPhamBanTrongNgayHienTai()
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

        private void ThongKeSanPhamBanTrongNgayHienTai_Load(object sender, EventArgs e)
        {
            string sql = "SELECT TenSp,SUM(CT_HoaDon.SoLuong) AS TONGSOLUONG FROM SanPham, CT_HoaDon, HoaDon WHERE CT_HoaDon.MaSp = SanPham.MaSp AND CT_HoaDon.MaHD = HoaDon.MaHD AND DAY(NgayLapHD)=DAY(GETDATE()) AND MONTH(NgayLapHD)= MONTH(GETDATE()) AND YEAR(NgayLapHD)= YEAR(GETDATE()) GROUP BY TenSp";
            LayDuLieu(sql, dgvTongSoLuong);

        }

        private void frmThongKeSanPhamBanTrongNgayHienTai_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
