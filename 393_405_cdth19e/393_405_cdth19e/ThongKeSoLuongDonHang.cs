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
    public partial class frmThongKeSoLuongDonHang : Form
    {
        public frmThongKeSoLuongDonHang()
        {
            InitializeComponent();
        }

        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();

        void LayDuLieu(string sql)
        {
            ds = c.layDuLieu(sql);
        }

        void hienThiKQ(string sql)
        {
            LayDuLieu(sql);
            string kq = "Tổng hóa đơn được lập: " + ds.Tables[0].Rows[0][0].ToString() + " hóa đơn";
            lblKQ.Text = kq;
        }

        private void dtpKeThuc_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select COUNT(MaHD) from HoaDon where TrangThai != 0 AND ";
            if (SoSanhNgay(dtpBatDau.Value.Date, dtpKeThuc.Value.Date) > 0)
            {
                dtpKeThuc.Value = dtpBatDau.Value;
                return;
            }
            else
            {
                sql += "NgayLapHD >= '" + dtpBatDau.Text + "' AND NgayLapHD <= '" + dtpKeThuc.Text + "'";
                hienThiKQ(sql);
            }
        }

        int SoSanhNgay(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1, date2);
        }

        private void dtpBatDau_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select COUNT(MaHD) from HoaDon where TrangThai != 0 AND ";

            if (SoSanhNgay(dtpBatDau.Value.Date, dtpKeThuc.Value.Date) > 0)
            {
                dtpBatDau.Value = dtpKeThuc.Value;
                return;
            }
            else
            {
                sql += "NgayLapHD >= '" + dtpBatDau.Text + "' AND NgayLapHD <= '" + dtpKeThuc.Text + "'";
                hienThiKQ(sql);
            }
        }

        private void frmThongKeSoLuongDonHang_Load(object sender, EventArgs e)
        {
            dtpBatDau.MaxDate = DateTime.Today;
            dtpKeThuc.MaxDate = DateTime.Today;
            dtpKeThuc.Value = DateTime.Today;
            dtpBatDau.Value = DateTime.Today;
        }
    }
}
