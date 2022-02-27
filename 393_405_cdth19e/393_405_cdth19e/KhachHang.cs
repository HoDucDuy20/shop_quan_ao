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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }


        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        public string flag;
        public string TenKhachHang;
        public string MaKhachHang = "";
        public string SDT;
        public string Diachi;
        int chucnang = 0;
        int trangthai = 1;
        void XuLyTextBox(Boolean t)
        {
            lblMaKhachHang.Enabled = t;
            txtTenKhachHang.Enabled = t;
            txtDiaChi.Enabled = t;
            txtEmail.Enabled = t;
            txtSoDienThoai.Enabled = t;
            cmbTrangThai.Enabled = t;
        }

        void XuLyChucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
        }

        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        void LayThongTin()
        {
            TenKhachHang = txtTenKhachHang.Text;
            MaKhachHang = lblMaKhachHang.Text;
            SDT = txtSoDienThoai.Text;
            Diachi = txtDiaChi.Text;
        }

        void XoaThongTin()
        {
            lblMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
        }

        void LoadDL()
        {
            LayDuLieu("select * from KhachHang where trangthai = " + trangthai, dgvDanhSachKhachHang);
        }

        void HienThiTextBox(int vt, DataSet ds)
        {
            try
            {
                lblMaKhachHang.Text = ds.Tables[0].Rows[vt]["MaKh"].ToString();
                txtTenKhachHang.Text = ds.Tables[0].Rows[vt]["TenKh"].ToString();
                txtDiaChi.Text = ds.Tables[0].Rows[vt]["DiaChi"].ToString();
                txtSoDienThoai.Text = ds.Tables[0].Rows[vt]["Phone"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[vt]["DCMail"].ToString();
                if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
                {
                    cmbTrangThai.SelectedIndex = 0;
                }
                else
                {
                    cmbTrangThai.SelectedIndex = 1;
                }
                LayThongTin();
            }
            catch
            {

            }
        }

        string PhatSinhMa()
        {
            string MaHD = "";
            DataSet d = c.layDuLieu("select MaKH from KhachHang order by MaKH");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MaKH"].ToString();
                int stt = Convert.ToInt32(dc.Remove(0, 2));
                if (stt < 9)
                {
                    MaHD = dc.Substring(0, 2) + "0" + (stt + 1);
                }
                else if (stt < 99)
                {
                    MaHD = dc.Substring(0, 2) + (stt + 1);
                }
            }
            else
            {
                MaHD = "KH01";
            }
            return MaHD;
        }

        bool KiemTraBoTrong()
        {
            if (lblMaKhachHang.Text == "" || txtSoDienThoai.Text == "" || txtTenKhachHang.Text == "" || txtDiaChi.Text == "" || cmbTrangThai.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        void luuDL(String sql, String ThongBao)
        {
            if (c.CapNhatDuLieu(sql) != 0)
            {
                DialogResult kq = MessageBox.Show(ThongBao + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult kq = MessageBox.Show(ThongBao + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            radHD.Checked = true;
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            XuLyChucnang(true);
            XuLyTextBox(false);
            cmbTrangThai.SelectedIndex = -1;
            cboSearch.Items.Add("Số điện thoại");
            cboSearch.Items.Add("Tên khách hàng");
            cboSearch.SelectedIndex = 0;
            LoadDL();
            if (flag == "sdt")
            {
                chucnang = 1;
                XuLyChucnang(false);
                XuLyTextBox(true);
                cmbTrangThai.SelectedIndex = 0;
                cmbTrangThai.Enabled = false;
                dgvDanhSachKhachHang.Enabled = false;
                lblMaKhachHang.Text = PhatSinhMa();
                txtSoDienThoai.Text = SDT;
                txtTenKhachHang.Focus();
            }
            else if (flag == "btnTim" && MaKhachHang != "")
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["MaKH"].ToString() == MaKhachHang)
                    {
                        HienThiTextBox(i, ds);
                        dgvDanhSachKhachHang.Rows[2].Selected = true;
                        break;
                    }
                }
            }
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag == "sdt" || flag == "btnTim")
            {

            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt, ds);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong())
            {
                SDT = txtSoDienThoai.Text;
                if (SDT.Substring(0, 1) != "0" || SDT.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql;
                    if (chucnang == 1)
                    {
                        sql = "insert into KhachHang values('" + lblMaKhachHang.Text + "', N'" + txtTenKhachHang.Text + "', N'" + txtDiaChi.Text + "', '" + txtSoDienThoai.Text + "', '" + txtEmail.Text + "', " + (int.Parse(cmbTrangThai.SelectedIndex.ToString()) == 0 ? 1 : 0) + ")";
                        luuDL(sql, "Thêm");
                        dgvDanhSachKhachHang.Enabled = true;
                        if (flag == "sdt" || flag == "btnTim")
                        {
                            this.Close();
                        }
                    }
                    else if (chucnang == 2)
                    {
                        sql = "update KhachHang set TenKH = N'" + txtTenKhachHang.Text + "', DiaChi = N'" + txtDiaChi.Text + "', Phone = '" + txtSoDienThoai.Text + "', DCMail = '" + txtEmail.Text + "', TrangThai = " + (int.Parse(cmbTrangThai.SelectedIndex.ToString()) == 0 ? 1 : 0) + " where MaKH = '" + lblMaKhachHang.Text + "'";
                        luuDL(sql, "Sửa");
                    }
                    else if (chucnang == 3)
                    {
                        if (trangthai == 1)
                        {
                            sql = "update KhachHang set TrangThai = 0 where MaKH = '" + lblMaKhachHang.Text + "'";
                            luuDL(sql, "Xóa");
                        }
                        else
                        {
                            sql = "update KhachHang set TrangThai = 1 where MaKH = '" + lblMaKhachHang.Text + "'";
                            luuDL(sql, "Kích hoạt");
                        }
                    }
                    LoadDL();
                    LayThongTin();
                    XuLyChucnang(true);
                    XuLyTextBox(false);
                    chucnang = 0;
                }
            }
            else
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void btnThem_Click(object sender, EventArgs e)
        {
            chucnang = 1;
            XuLyChucnang(false);
            XuLyTextBox(true);
            XoaThongTin();
            cmbTrangThai.SelectedIndex = 0;
            cmbTrangThai.Enabled = false;
            lblMaKhachHang.Text = PhatSinhMa();
            txtTenKhachHang.Focus();
            dgvDanhSachKhachHang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong())
            {
                chucnang = 2;
                XuLyChucnang(false);
                XuLyTextBox(true);
                txtTenKhachHang.Focus();
            }
            else
            {
                MessageBox.Show("Bạn cần chọn một thông tin khách hàng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XuLyChucnang(true);
            XuLyTextBox(false);
            XoaThongTin();
            dgvDanhSachKhachHang.Enabled = true;
            cmbTrangThai.SelectedIndex = -1;
            chucnang = 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong())
            {
                chucnang = 3;
                XuLyChucnang(false);
                XuLyTextBox(false);
                btnLuu.Focus();
            }
            else
            {
                MessageBox.Show("Bạn cần chọn một thông tin khách hàng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where trangthai = " + trangthai + " and ";
            if (cboSearch.SelectedIndex == 0)
            {
                sql += "Phone like '%" + txtSearch.Text + "%'";
            }
            else
            {
                sql += "TenKH like N'%" + txtSearch.Text + "%'";
            }
            LayDuLieu(sql, dgvDanhSachKhachHang);
        }

        private void cmbTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (char.IsNumber(e.KeyChar) == true)
                {
                    e.Handled = true;
                }
            }
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void radHD_CheckedChanged(object sender, EventArgs e)
        {
            trangthai = 1;
            LoadDL();
            btnHuy_Click(sender, e);
            btnXoa.Text = "Xóa";
        }

        private void radNgungHD_CheckedChanged(object sender, EventArgs e)
        {
            trangthai = 0;
            LoadDL();
            btnHuy_Click(sender, e);
            btnXoa.Text = "K Hoạt";
        }
    }

}