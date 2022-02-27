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
    public partial class frmThongKeDoanhThuTheoTungThangTrongNam : Form
    {
        public frmThongKeDoanhThuTheoTungThangTrongNam()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        DateTime aDateTime = DateTime.Now;
        int soNam;

        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        string DinhDangTien(String t)
        {
            try
            {
                int n = t.Length;
                int j = (n - 1) / 3;
                for (int i = 0; i < j; i++)
                {
                    t = t.Insert((n - (3 * (i + 1)) - i), ",");
                    n++;
                }
                if (t == "")
                    return "0 Đ";
                return t + " Đ";
            }
            catch
            {
                return "";
            }
        }

        void ThongKe()
        {
            string sql = "SELECT MONTH(NgayLapHD) AS THANG,SUM(CT_HoaDon.SoLuong*CT_HoaDon.DonGia) AS DOANHTHU FROM HoaDon,CT_HoaDon WHERE CT_HoaDon.MaHD=HoaDon.MaHD AND YEAR(NgayLapHD)=" + Convert.ToInt32(cboNam.Text) + "GROUP BY MONTH(NgayLapHD)";
            LayDuLieu(sql, dgvDoanhThu);
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void frmThongKeDoanhThuTheoTungThangTrongNam_Load(object sender, EventArgs e)
        {
            soNam = aDateTime.Year;
            for (int i = 1900; i <= soNam; i++)
            {
                cboNam.Items.Add(i);
            }
            cboNam.SelectedIndex = (soNam - 1900);
            ThongKe();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void cboNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
