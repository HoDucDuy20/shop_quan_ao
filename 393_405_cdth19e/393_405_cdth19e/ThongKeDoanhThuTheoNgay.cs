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
    public partial class frmThongKeDoanhThuTheoNgay : Form
    {
        public frmThongKeDoanhThuTheoNgay()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        DateTime aDateTime = DateTime.Now;
        int ngay = 31;
        int thang = 1;
        int soThang = 12;
        int soNam;

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

        void TinhDoanhThu()
        {
            string sql = "SELECT SUM(TongTien) FROM HoaDon WHERE ";
            if (cboNgay.Text == "None" && cboThang.Text == "None" && cboNam.Text != "None")
            {
                sql += "year(NgayLapHD) = '" + cboNam.Text + "'";
            }
            else if (cboNgay.Text == "None" && cboThang.Text != "None" && cboNam.Text != "None")
            {
                sql += "month(NgayLapHD) = '" + cboThang.Text + "' and year(NgayLapHD) = '" + cboNam.Text + "'";
            }
            else if (cboNgay.Text != "None" && cboThang.Text != "None" && cboNam.Text != "None")
            {
                sql += "day(NgayLapHD) = '" + cboNgay.Text + "' and month(NgayLapHD) = '" + cboThang.Text + "' and year(NgayLapHD) = '" + cboNam.Text + "'";
            }
            else
            {
                sql += "year(NgayLapHD) = '0'";
            }
            ds = c.layDuLieu(sql);
            lblDoanhThu.Text = DinhDangTien(ds.Tables[0].Rows[0][0].ToString());
        }

        private void ThongKeDoanhThuTheoNgayHienTai_Load(object sender, EventArgs e)
        {
            cboNgay.Items.Add("None");
            cboThang.Items.Add("None");
            cboNam.Items.Add("None");
            for (int i = 1; i <= 31; i++)
            {
                cboNgay.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }
            soNam = aDateTime.Year;
            for (int i = 1900; i <= soNam; i++)
            {
                cboNam.Items.Add(i);
            }
            cboNgay.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
            TinhDoanhThu();
        }


        bool kiemTraNamNhuan()
        {
            int nam = int.Parse(cboNam.Text);
            if (nam % 4 == 0 && (nam % 100 != 0 || nam % 400 == 0))
            {
                return true;
            }
            return false;
        }

        int soNgayTrongThang(int thang)
        {
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (kiemTraNamNhuan())
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
            }
            return 0;
        }

        void ThemNgay(ref int soNgayTruoc, ref int soNgaySau)
        {
            for (int i = soNgayTruoc + 1; i <= soNgaySau; i++)
            {
                cboNgay.Items.Add(i);
            }
        }

        void XoaNgay(ref int soNgayTruoc, ref int soNgaySau)
        {
            for (int i = soNgayTruoc + 1; i <= soNgaySau; i++)
            {
                cboNgay.Items.RemoveAt(i);
                soNgaySau--;
                i--;
            }
        }

        void ThemThang(ref int soThangTruoc, ref int soThangSau)
        {
            for (int i = soThangTruoc + 1; i <= soThangSau; i++)
            {
                cboThang.Items.Add(i);
            }
        }

        void XoaThang(ref int soThangTruoc, ref int soThangSau)
        {
            for (int i = soThangTruoc + 1; i <= soThangSau; i++)
            {
                cboThang.Items.RemoveAt(i);
                soThangSau--;
                i--;
            }
        }

        private void cboNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThang.Text == "None" && cboNgay.Text != "None")
            {
                int chonNam = soNam - 1900 + 1;
                int n = soThang;
                soThang = aDateTime.Month;
                XoaThang(ref soThang, ref n);
                if (int.Parse(cboNgay.Text) <= aDateTime.Day)
                {
                    cboThang.SelectedIndex = aDateTime.Month;
                    n = ngay;
                    ngay = aDateTime.Day;
                    XoaNgay(ref ngay, ref n);
                }
                else
                {
                    int t = aDateTime.Month - 1;
                    while (true)
                    {
                        if (t == 0)
                        {
                            chonNam--;
                            n = soThang;
                            soThang = 12;
                            t = soThang;
                            ThemThang(ref n, ref soThang);
                        }
                        int songay = soNgayTrongThang(t);
                        if (int.Parse(cboNgay.Text) <= songay)
                        {
                            if (ngay > songay)
                            {
                                n = ngay;
                                ngay = songay;
                                XoaNgay(ref ngay, ref n);
                            }
                            cboThang.SelectedIndex = t;
                            break;
                        }
                        t--;
                    }

                }
                cboNam.SelectedIndex = chonNam;
            }
            TinhDoanhThu();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThang.Text == "None")
            {
                cboNgay.SelectedIndex = 0;
                if (ngay < 31)
                {
                    int n = ngay;
                    ngay = 31;
                    ThemNgay(ref n, ref ngay);
                }
            }
            else
            {
                if (cboNam.Text == "None")
                {
                    if (int.Parse(cboThang.Text) <= aDateTime.Month)
                    {
                        cboNam.SelectedIndex = soNam - 1900 + 1;
                    }
                    else
                    {
                        cboNam.SelectedIndex = soNam - 1900;
                    }
                }
                if (cboNam.Text == aDateTime.Year.ToString() && cboThang.Text == aDateTime.Month.ToString())
                {
                    int songayht = aDateTime.Day;
                    if (songayht < ngay)
                    {
                        int n = ngay;
                        ngay = songayht;
                        if (cboNgay.Text != "None")
                        {
                            if (int.Parse(cboNgay.Text) > ngay)
                            {
                                cboNgay.SelectedIndex = ngay;
                            }
                        }
                        XoaNgay(ref ngay, ref n);
                    }
                    else
                    {
                        int n = ngay;
                        ngay = songayht;
                        ThemNgay(ref n, ref ngay);
                    }
                }
                else
                {
                    if (cboNgay.Text == "None")
                    {
                        thang = int.Parse(cboThang.Text);
                        if (ngay > soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            XoaNgay(ref ngay, ref n);
                        }
                        else if (ngay < soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            ThemNgay(ref n, ref ngay);
                        }
                    }
                    else
                    {
                        int ngayChon = int.Parse(cboNgay.Text);
                        thang = int.Parse(cboThang.Text);
                        if (ngay > soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            if (ngayChon > ngay)
                            {
                                cboNgay.SelectedIndex = ngay;
                            }
                            XoaNgay(ref ngay, ref n);
                        }
                        else if (ngay < soNgayTrongThang(thang))
                        {
                            int n = ngay;
                            ngay = soNgayTrongThang(thang);
                            ThemNgay(ref n, ref ngay);
                        }
                    }
                }
            }
            TinhDoanhThu();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.Text == "None")
            {
                cboNgay.SelectedIndex = 0;
                cboThang.SelectedIndex = 0;
                if (ngay < 31)
                {
                    int n = ngay;
                    ngay = 31;
                    ThemNgay(ref n, ref ngay);
                }
                if (soThang < 12)
                {
                    int n = soThang;
                    soThang = 12;
                    ThemThang(ref n, ref soThang);
                }
            }
            else
            {
                if (cboNam.Text == aDateTime.Year.ToString())
                {
                    if (soThang > aDateTime.Month)
                    {
                        int n = soThang;
                        soThang = aDateTime.Month;
                        if (cboThang.SelectedIndex > soThang && cboThang.SelectedIndex != 0)
                        {
                            cboThang.SelectedIndex = soThang;
                        }
                        XoaThang(ref soThang, ref n);
                    }
                }
                else
                {
                    if (soThang < 12)
                    {
                        int n = soThang;
                        soThang = 12;
                        ThemThang(ref n, ref soThang);
                    }
                }
                if (cboNam.Text == aDateTime.Year.ToString() && cboThang.Text == aDateTime.Month.ToString())
                {
                    int songay = aDateTime.Day;
                    if (songay < ngay)
                    {
                        int n = ngay;
                        ngay = songay;
                        if (cboNgay.Text != "None")
                        {
                            if (int.Parse(cboNgay.Text) > ngay)
                            {
                                cboNgay.SelectedIndex = ngay;
                            }
                        }
                        XoaNgay(ref ngay, ref n);
                    }
                    else
                    {
                        int n = ngay;
                        ngay = songay;
                        ThemNgay(ref n, ref ngay);
                    }
                }
                else if (cboThang.Text != "None" && cboNgay.Text != "None")
                {
                    thang = int.Parse(cboThang.Text);
                    if (ngay > soNgayTrongThang(thang))
                    {
                        int ngayChon = int.Parse(cboNgay.Text);
                        int n = ngay;
                        ngay = soNgayTrongThang(thang);
                        if (ngayChon > ngay)
                        {
                            cboNgay.SelectedIndex = ngay;
                        }
                        XoaNgay(ref ngay, ref n);
                    }
                    else if (ngay < soNgayTrongThang(thang))
                    {
                        int n = ngay;
                        ngay = soNgayTrongThang(thang);
                        ThemNgay(ref n, ref ngay);
                    }
                }
            }
            TinhDoanhThu();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboNgay.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
            TinhDoanhThu();
        }
    }
}
