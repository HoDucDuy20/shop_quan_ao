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
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
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
            txtMaLoai.ReadOnly = t;
            txtTenLoai.ReadOnly = t;
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
            txtMaLoai.Text = ds.Tables[0].Rows[vt]["MaLoaiSP"].ToString();
            txtTenLoai.Text = ds.Tables[0].Rows[vt]["TenLoaiSP"].ToString();
            if(ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cboTinhTrang.SelectedIndex = 0;
            }
            else
            {
                cboTinhTrang.SelectedIndex = 1;
            } 
        }
        string PhatSinhMa()
        {
            string MaLSP = "";
            DataSet d = c.layDuLieu("select MaLoaiSP from LoaiSanPham order by MaLoaiSP");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MaLoaiSP"].ToString();
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
                MaLSP = "LSP01";
            }
            return MaLSP;
        }
        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            hienThiDuLieu("select * from LoaiSanPham where TrangThai = 1", dgvDanhSach);
            txtMaLoai.Enabled = false;
            cboTinhTrang.Items.Add("Hoạt động");
            cboTinhTrang.Items.Add("Ngưng Hoạt động");
            XuLyChucnang(true);
            XuLyTextBox(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoaiSanPham_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            hienThiDuLieu("select * from LoaiSanPham where TrangThai = 1", dgvDanhSach);
            txtMaLoai.Enabled = false;
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            cboTinhTrang.SelectedIndex = -1;
            dgvDanhSach.Enabled = true;
            XuLyChucnang(true);
            XuLyTextBox(true);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            hienThiTextBox(vt, ds);
        }

        private void txtTenLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtMaLoai.Text = PhatSinhMa();
            txtTenLoai.Text = "";
            cboTinhTrang.SelectedIndex = 0;

            XuLyChucnang(false);
            XuLyTextBox(false);
            dgvDanhSach.Enabled = false;
            cboTinhTrang.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "" || txtTenLoai.Text == "")
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
                if (txtTenLoai.Text != "")
                {
                    string sql = "insert into LoaiSanPham values('" + txtMaLoai.Text + "',N'" + txtTenLoai.Text + "'," + KiemTraTinhTrang() + ")";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Lưu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaLoai.Text = "";
                        txtTenLoai.Text = "";
                        cboTinhTrang.SelectedIndex = -1;
                        dgvDanhSach.Enabled = true;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên loại", "Lỗi lưu trữ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            if (flag==2)
            {
                if (txtTenLoai.Text != "")
                {
                    string sql = "update LoaiSanPham set TenLoaiSp = N'" + txtTenLoai.Text + "',TrangThai=" + KiemTraTinhTrang() + " where MaLoaiSP = '" + txtMaLoai.Text+"'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaLoai.Text = "";
                        txtTenLoai.Text = "";
                        dgvDanhSach.Enabled = true;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên loại", "Lỗi lưu trữ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (flag == 3)
            {
                DialogResult kq = MessageBox.Show("Bạn muốn xóa loại sản phẩm ", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq==DialogResult.Yes)
                {
                    string sql = "update LoaiSanPham set TrangThai = 0 where MaLoaiSP = '" + txtMaLoai.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Xóa thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaLoai.Text = "";
                        txtTenLoai.Text = "";
                        dgvDanhSach.Enabled = true;
                        cboTinhTrang.SelectedIndex = -1;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                }
                else
                {
                    txtMaLoai.Text = "";
                    txtTenLoai.Text = "";
                    cboTinhTrang.SelectedIndex = -1;
                    dgvDanhSach.Enabled = true;
                    XuLyChucnang(true);
                    XuLyTextBox(true);
                }
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            if (txtMaLoai.Text==""||txtTenLoai.Text=="")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần sửa", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyChucnang(true);
                XuLyTextBox(true);
            }
            else
            {
                XuLyChucnang(false);
                XuLyTextBox(false);
                txtTenLoai.Enabled = true;
                cboTinhTrang.Enabled = false;
                dgvDanhSach.Enabled = false;
            }
        }
    }
}
