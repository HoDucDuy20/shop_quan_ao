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
    public partial class frmKichHoatNhaCungCap : Form
    {
        public frmKichHoatNhaCungCap()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet d = new DataSet();
        void HienThiDuLieu(string sql,DataGridView dg)
        {
            d = c.layDuLieu(sql);
            dg.DataSource = d.Tables[0];
        }
        void HienThiTextBox(int vt,DataSet ds)
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
        private void KichHoatNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu("select * from NhaCungCap where TrangThai=0",dgvDanhSach);
            cboTinhTrang.Items.Add("Hoạt động");
            cboTinhTrang.Items.Add("Ngưng Hoạt động");
            XuLyTextBox(true);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt,d);
        }

        private void frmKichHoatNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        int flag;
        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần kích hoạt", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyTextBox(true);
            }
            else
            {
                dgvDanhSach.Enabled = false;
                string sql = "update NhaCungCap set TrangThai = 1 where MaNCC = '" + txtMaNCC.Text + "'";
                DialogResult kq = MessageBox.Show("Bạn có muốn kích hoạt sản phẩm này", "Thông báo kích hoạt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    if (c.CapNhatDuLieu(sql) != 0)
                    {

                        MessageBox.Show("Kích hoạt dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaNCC.Text = "";
                        txtTenNCC.Text = "";
                        txtDiaChi.Text = "";
                        txtSoDienThoai.Text = "";
                        txtTenTaiKhoan.Text = "";
                        txtSoTaiKhoan.Text = "";
                        txtMail.Text = "";
                        dgvDanhSach.Enabled = true;
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
                    XuLyTextBox(true);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HienThiDuLieu("select * from NhaCungCap where TrangThai=0", dgvDanhSach);
            XuLyTextBox(true);
        }
    }
}
