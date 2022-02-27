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
    public partial class frmTimHoaDonTheoNgay : Form
    {
        public frmTimHoaDonTheoNgay()
        {
            InitializeComponent();
        }

        private void cboNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmTimHoaDonTheoNgay_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        int ngay = 31;
        int thang = 1;
        private void frmTimHoaDonTheoNgay_Load(object sender, EventArgs e)
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
            for (int i = 1900; i <= 2021; i++)
            {
                cboNam.Items.Add(i);
            }
            cboNgay.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
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

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThang.Text == "None")
            {
                if (ngay < 31)
                {
                    int n = ngay;
                    ngay = 31;
                    for (int i = n + 1; i <= ngay; i++)
                    {
                        cboNgay.Items.Add(i);
                    }
                }
            }
            else if(cboNam.Text == "None" && cboThang.Text == "2" && cboNgay.Text != "None")
            {
                int ngayChon = int.Parse(cboNgay.Text);
                thang = int.Parse(cboThang.Text);
                if (ngay > 29)
                {
                    int n = ngay;
                    ngay = 29;
                    if (ngayChon > ngay)
                    {
                        cboNgay.SelectedIndex = ngay;
                    }
                    for (int i = ngay + 1; i <= n; i++)
                    {
                        cboNgay.Items.RemoveAt(i);
                        n--;
                        i--;
                    }
                }
                else if (ngay < 29)
                {
                    int n = ngay;
                    ngay = 29;
                    for (int i = n + 1; i <= ngay; i++)
                    {
                        cboNgay.Items.Add(i);
                    }
                }
            }    
            else if(cboThang.Text != "None" && cboNgay.Text == "None")
            {
                thang = int.Parse(cboThang.Text);
                if(thang == 2)
                {
                    if (ngay > 29)
                    {
                        int n = ngay;
                        ngay = 29;
                        for (int i = ngay + 1; i <= n; i++)
                        {
                            cboNgay.Items.RemoveAt(i);
                            n--;
                            i--;
                        }
                    }
                    else if (ngay < 29)
                    {
                        int n = ngay;
                        ngay = 29;
                        for (int i = n + 1; i <= ngay; i++)
                        {
                            cboNgay.Items.Add(i);
                        }
                    }
                }    
                else
                {
                    if (ngay > soNgayTrongThang(thang))
                    {
                        int n = ngay;
                        ngay = soNgayTrongThang(thang);
                        for (int i = ngay + 1; i <= n; i++)
                        {
                            cboNgay.Items.RemoveAt(i);
                            n--;
                            i--;
                        }
                    }
                    else if (ngay < soNgayTrongThang(thang))
                    {
                        int n = ngay;
                        ngay = soNgayTrongThang(thang);
                        for (int i = n + 1; i <= ngay; i++)
                        {
                            cboNgay.Items.Add(i);
                        }
                    }
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
                    for (int i = ngay + 1; i <= n; i++)
                    {
                        cboNgay.Items.RemoveAt(i);
                        n--;
                        i--;
                    }
                }
                else if (ngay < soNgayTrongThang(thang))
                {
                    int n = ngay;
                    ngay = soNgayTrongThang(thang);
                    for (int i = n + 1; i <= ngay; i++)
                    {
                        cboNgay.Items.Add(i);
                    }
                }
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.Text == "None")
            {
                if (cboThang.Text == "2" && ngay < 29)
                {
                    int n = ngay;
                    ngay = 29;
                    for (int i = n + 1; i <= ngay; i++)
                    {
                        cboNgay.Items.Add(i);
                    }
                }
            }
            else
            {
                if (cboThang.Text == "2" && ngay > soNgayTrongThang(int.Parse(cboThang.Text)))
                {
                    int n = ngay;
                    ngay = soNgayTrongThang(thang);
                    cboNgay.SelectedIndex = ngay;
                    for (int i = ngay + 1; i <= n; i++)
                    {
                        cboNgay.Items.RemoveAt(i);
                        n--;
                        i--;
                    }
                }
                else if (cboThang.Text == "2" && ngay < soNgayTrongThang(int.Parse(cboThang.Text)))
                {
                    int n = ngay;
                    ngay = soNgayTrongThang(thang);
                    for (int i = n + 1; i <= ngay; i++)
                    {
                        cboNgay.Items.Add(i);
                    }
                }
            }
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void hienThiDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cboNgay.Text != "None" && cboThang.Text == "None" && cboNam.Text == "None")
            {
                string sql = "select * from HoaDon where day(NgayLapHD) like '%" + cboNgay.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else if (cboNgay.Text == "None" && cboThang.Text != "None" && cboNam.Text == "None")
            {
                string sql = "select * from HoaDon where month(NgayLapHD) like '%" + cboThang.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else if (cboNgay.Text == "None" && cboThang.Text == "None" && cboNam.Text != "None")
            {
                string sql = "select * from HoaDon where year(NgayLapHD) like '%" + cboNam.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else if (cboNgay.Text != "None" && cboThang.Text != "None" && cboNam.Text == "None")
            {
                string sql = "select * from HoaDon where day(NgayLapHD) like '%" + cboNgay.Text + "%' and month(NgayLapHD) like '%" + cboThang.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else if (cboNgay.Text != "None" && cboThang.Text == "None" && cboNam.Text != "None")
            {
                string sql = "select * from HoaDon where day(NgayLapHD) like '%" + cboNgay.Text + "%' and year(NgayLapHD) like '%" + cboNam.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else if (cboNgay.Text == "None" && cboThang.Text != "None" && cboNam.Text != "None")
            {
                string sql = "select * from HoaDon where month(NgayLapHD) like '%" + cboThang.Text + "%' and year(NgayLapHD) like '%" + cboNam.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else if (cboNgay.Text != "None" && cboThang.Text != "None" && cboNam.Text != "None")
            {
                string sql = "select * from HoaDon where day(NgayLapHD) like '%" + cboNgay.Text + "%' and month(NgayLapHD) like '%" + cboThang.Text + "%' and year(NgayLapHD) like '%" + cboNam.Text + "%'";
                hienThiDuLieu(sql, dgvDanhSachSanPham);
            }
            else
            {
                MessageBox.Show("Không có giá trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}