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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void hienThiDuLieu(string sql, DataGridView d)
        {
            ds = c.layDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaNCC.ReadOnly = t;
            txtTenNCC.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
            txtMail.ReadOnly = t;
            txtSoDienThoai.ReadOnly = t;
            txtSoTaiKhoan.ReadOnly = t;
            txtTenTaiKhoan.ReadOnly = t;
            cboTinhTrang.Enabled = !t;
        }
        void XuLyChucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
        }
        void hienThiTextBox(int vt, DataSet ds)
        {
            txtMaNCC.Text = ds.Tables[0].Rows[vt]["MaNCC"].ToString();
            txtTenNCC.Text = ds.Tables[0].Rows[vt]["TenNCC"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["DiaChi"].ToString();
            txtSoDienThoai.Text = ds.Tables[0].Rows[vt]["Phone"].ToString();
            txtTenNCC.Text = ds.Tables[0].Rows[vt]["TenNCC"].ToString();
            txtTenTaiKhoan.Text = ds.Tables[0].Rows[vt]["TenTK"].ToString();
            txtSoTaiKhoan.Text = ds.Tables[0].Rows[vt]["SoTK"].ToString();
            txtMail.Text = ds.Tables[0].Rows[vt]["DCMail"].ToString();
            if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cboTinhTrang.SelectedIndex = 0;
            }
            else
            {
                cboTinhTrang.SelectedIndex = 1;
            }
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            cboTinhTrang.Items.Add("Hoạt động");
            cboTinhTrang.Items.Add("Ngưng hoạt động");
            hienThiDuLieu("select * from NhaCungCap where TrangThai=1", dgvDanhSach);
            XuLyChucnang(true);
            XuLyTextBox(true);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            hienThiTextBox(vt, ds);
        }

        private void frmNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                MessageBox.Show("Bạn chưa thực hiện xong thao tác", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            hienThiDuLieu("select * from NhaCungCap where TrangThai=1", dgvDanhSach);
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenNCC.Text = "";
            txtTenTaiKhoan.Text = "";
            txtSoTaiKhoan.Text = "";
            txtMail.Text = "";
            cboTinhTrang.SelectedIndex = -1;
            dgvDanhSach.Enabled = true;
            XuLyChucnang(true);
            XuLyTextBox(true);
        }

        private void txtTenNCC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtSoTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
        string PhatSinhMa()
        {
            string MaLSP = "";
            DataSet d = c.layDuLieu("select MaNCC from NhaCungCap order by MaNCC");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MaNCC"].ToString();
                int stt = Convert.ToInt32(dc.Remove(0, 3));
                if (stt < 9)
                {
                    MaLSP = dc.Substring(0, 3) + "0" + (stt + 1);
                }
                else if (stt < 99)
                {
                    MaLSP = dc.Substring(0, 3) + (stt + 1);
                }
            }
            else
            {
                MaLSP = "NCC01";
            }
            return MaLSP;
        }
        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtMaNCC.Text = PhatSinhMa();
            txtMaNCC.Enabled = false;
            XuLyChucnang(false);
            XuLyTextBox(false);
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenTaiKhoan.Text = "";
            txtSoTaiKhoan.Text = "";
            txtMail.Text = "";
            cboTinhTrang.SelectedIndex = 0;
            cboTinhTrang.Enabled = false;
            dgvDanhSach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text==""||txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần sửa", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyChucnang(true);
                XuLyTextBox(true);
            }
            else
            {
                flag = 2;
                XuLyChucnang(false);
                XuLyTextBox(false);
                txtMaNCC.Enabled = false;
                dgvDanhSach.Enabled = false;
                cboTinhTrang.Enabled = false;
            }
        }
        bool KiemTraBoTrong()
        {
            if (txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtSoDienThoai.Text == "" || txtTenTaiKhoan.Text == "" || txtSoTaiKhoan.Text == "" || txtMail.Text == "") 
            {
                return false;
            }
            return true;
        }
        int KiemTraTinhTrang()
        {
            if (cboTinhTrang.Text == "Hoạt động")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (KiemTraBoTrong() == false)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    XuLyChucnang(false);
                    XuLyTextBox(false);
                }
                else
                {
                    string txtSDT = txtSoDienThoai.Text;
                    string kq = txtSDT.Remove(2);
                    if (kq == "09" || kq == "03" || kq == "07" || kq == "08" || kq == "05")
                    {
                        if (txtSoDienThoai.Text.Length > 10 || txtSoDienThoai.Text.Length < 10)
                        {
                            MessageBox.Show("Độ dài không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSoDienThoai.Text = "";
                        }
                        else
                        {
                            string sql = "insert into NhaCungCap values('" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtDiaChi.Text + "','" + txtSoDienThoai.Text + "',N'" + txtTenTaiKhoan.Text + "', '" + txtSoTaiKhoan.Text + "','" + txtMail.Text + "'," + KiemTraTinhTrang() + ")";
                            if (c.CapNhatDuLieu(sql) != 0)
                            {
                                MessageBox.Show("Lưu dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                XuLyChucnang(true);
                                XuLyTextBox(true);
                                txtTenNCC.Text = "";
                                txtDiaChi.Text = "";
                                txtSoDienThoai.Text = "";
                                txtTenTaiKhoan.Text = "";
                                txtSoTaiKhoan.Text = "";
                                txtMail.Text = "";
                                dgvDanhSach.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Lỗi lưu trữ", "Không thể lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đầu số hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoDienThoai.Text = "";
                    }
                }
            }
            if (flag == 2)
            {
                if (KiemTraBoTrong()==false)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    XuLyChucnang(false);
                    XuLyTextBox(false);
                }
                else
                {
                    string txtSDT = txtSoDienThoai.Text;
                    string kq = txtSDT.Remove(2);
                    if (kq == "09" || kq == "03" || kq == "07" || kq == "08" || kq == "05")
                    {
                        if (txtSoDienThoai.Text.Length > 10 || txtSoDienThoai.Text.Length < 10)
                        {
                            MessageBox.Show("Độ dài không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSoDienThoai.Text = "";
                        }
                        else
                        {
                            string sql = "update NhaCungCap set TenNCC=N'" + txtTenNCC.Text + "', DiaChi=N'" + txtDiaChi.Text + "', Phone='"+ txtSoDienThoai.Text +"',TenTK=N'" + txtTenTaiKhoan.Text+ "',SoTK='" + txtSoTaiKhoan.Text+ "',DCMail='" + txtMail.Text+ "',TrangThai=" + KiemTraTinhTrang() + " where MaNCC = '" + txtMaNCC.Text + "'";
                            if (c.CapNhatDuLieu(sql) != 0)
                            {
                                MessageBox.Show("Cập nhật dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                XuLyChucnang(true);
                                XuLyTextBox(true);
                                txtTenNCC.Text = "";
                                txtDiaChi.Text = "";
                                txtSoDienThoai.Text = "";
                                txtTenTaiKhoan.Text = "";
                                txtSoTaiKhoan.Text = "";
                                txtMail.Text = "";
                                dgvDanhSach.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Lỗi lưu trữ", "Không thể lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đầu số hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoDienThoai.Text = "";
                    }
                }
            }
            if (flag==3)
            {
                string sql = "update NhaCungCap set TrangThai = 0 where MaNCC = '" + txtMaNCC.Text + "'";
                DialogResult kq = MessageBox.Show("Bạn có muốn xóa sản phẩm này", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenNCC.Text = "";
                        txtDiaChi.Text = "";
                        txtSoDienThoai.Text = "";
                        txtTenTaiKhoan.Text = "";
                        txtSoTaiKhoan.Text = "";
                        txtMail.Text = "";
                        dgvDanhSach.Enabled = true;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thễ lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtMaNCC.Text = "";
                    txtTenNCC.Text = "";
                    txtDiaChi.Text = "";
                    txtSoDienThoai.Text = "";
                    txtTenTaiKhoan.Text = "";
                    txtSoTaiKhoan.Text = "";
                    txtMail.Text = "";
                    dgvDanhSach.Enabled = true;
                    XuLyChucnang(true);
                    XuLyTextBox(true);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text==""||txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần xóa", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyChucnang(true);
                XuLyTextBox(true);
            }
            else
            {
                flag = 3;
                XuLyChucnang(false);
                XuLyTextBox(true);
                dgvDanhSach.Enabled = false;
            }
        }
    }
}
