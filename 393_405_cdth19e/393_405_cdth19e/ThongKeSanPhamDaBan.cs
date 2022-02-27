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
    public partial class frmThongKeSanPhamDaBan : Form
    {
        public frmThongKeSanPhamDaBan()
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

        private void dtpKeThuc_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select s.MaSP, s.TenSp, Sum(s.SoLuong) as 'Tong' from HoaDon h, CT_HoaDon c , SanPham s where h.MaHD = c.MaHD AND s.MaSP = c.MaSP AND h.TrangThai != 0 AND c.TrangThai ! = 0  AND ";

            if (SoSanhNgay(dtpBatDau.Value.Date, dtpKeThuc.Value.Date) > 0)
            {
                dtpKeThuc.Value = dtpBatDau.Value;
                return;
            }
            else
            {
                sql += "NgayLapHD >= '" + dtpBatDau.Text + "' AND NgayLapHD <= '" + dtpKeThuc.Text + "' group by s.MaSP, s.TenSp";
                LayDuLieu(sql, dgvDanhSach);
            }
        }

        int SoSanhNgay(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1, date2);
        }

        private void dtpBatDau_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select s.MaSP, s.TenSp, Sum(s.SoLuong) as 'Tong' from HoaDon h, CT_HoaDon c , SanPham s where h.MaHD = c.MaHD AND s.MaSP = c.MaSP AND h.TrangThai != 0 AND c.TrangThai ! = 0  AND ";

            if (SoSanhNgay(dtpBatDau.Value.Date, dtpKeThuc.Value.Date) > 0)
            {
                dtpBatDau.Value = dtpKeThuc.Value;
                return;
            }
            else
            {
                sql += "NgayLapHD >= '" + dtpBatDau.Text + "' AND NgayLapHD <= '" + dtpKeThuc.Text + "' group by s.MaSP, s.TenSp";
                LayDuLieu(sql, dgvDanhSach);
            }
        }

        private void frmThongKeSanPhamDaBan_Load(object sender, EventArgs e)
        {
            dtpBatDau.MaxDate = DateTime.Today;
            dtpKeThuc.MaxDate = DateTime.Today;
            dtpKeThuc.Value = DateTime.Today;
            dtpBatDau.Value = DateTime.Today;
        }
    }
}
