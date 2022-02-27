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
    public partial class frmKichThuoc : Form
    {
        public frmKichThuoc()
        {
            InitializeComponent();
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaKichThuoc.ReadOnly = t;
            txtTenKichThuoc.ReadOnly = t;
            cmbTrangThai.Enabled = !t;
        }
        void XuLyChucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        private void KichThuoc_Load(object sender, EventArgs e)
        {
            LayDuLieu("select *from KichThuoc where TrangThai = 1", dgvKichThuoc);
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            XuLyChucnang(true);
            XuLyTextBox(true);
        }

        private void frmKichThuoc_FormClosing(object sender, FormClosingEventArgs e)
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
        void HienThiTextBox(int vt, DataSet ds)
        {
            txtMaKichThuoc.Text = ds.Tables[0].Rows[vt]["MaKichThuoc"].ToString();
            txtTenKichThuoc.Text = ds.Tables[0].Rows[vt]["TenKichThuoc"].ToString();
            if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cmbTrangThai.SelectedIndex = 0;
            }
            else
            {
                cmbTrangThai.SelectedIndex = 1;
            }
        }
        private void dgvKichThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt, ds);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            XuLyChucnang(false);
            XuLyTextBox(false);
            txtMaKichThuoc.Text = PhatSinhMa();
            txtTenKichThuoc.Text = "";
            cmbTrangThai.SelectedIndex = 0;

            dgvKichThuoc.Enabled = false;
            cmbTrangThai.Enabled = false;
            txtMaKichThuoc.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong() == false)
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
                txtMaKichThuoc.ReadOnly = true;
                cmbTrangThai.Enabled = false;
                dgvKichThuoc.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        bool KiemTraBoTrong()
        {
            if (txtMaKichThuoc.Text == "" || txtTenKichThuoc.Text == "")
            {
                return false;
            }
            return true;
        }
        int KiemTraTinhTrang()
        {
            if (cmbTrangThai.Text == "Hoạt động")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        string PhatSinhMa()
        {
            string MaSp = "";
            DataSet d = c.layDuLieu("select MakichThuoc from KichThuoc order by MakichThuoc");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MakichThuoc"].ToString();
                int stt = Convert.ToInt32(dc.Remove(0, 2));
                if (stt < 9)
                {
                    MaSp = dc.Substring(0, 2) + "0" + (stt + 1);
                }
                else if (stt < 99)
                {
                    MaSp = dc.Substring(0, 2) + (stt + 1);
                }
            }
            else
            {
                MaSp = "KT01";
            }
            return MaSp;
        }
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (KiemTraBoTrong() == false)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "insert into KichThuoc values('" + txtMaKichThuoc.Text + "', N'" + txtTenKichThuoc.Text + "'," + KiemTraTinhTrang() + ")";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Lưu dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaKichThuoc.Text = "";
                        txtTenKichThuoc.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thể lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            if (flag == 2)
            {
                if (KiemTraBoTrong() == false)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "update KichThuoc set TenKichThuoc=N'" + txtTenKichThuoc.Text + "',TrangThai=" + KiemTraTinhTrang() + "where MaKichThuoc = '" + txtMaKichThuoc.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaKichThuoc.Text = "";
                        txtTenKichThuoc.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thể lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (flag == 3)
            {
                DialogResult kq = MessageBox.Show("Bạn muốn xóa kích thước này ", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    string sql = "update KichThuoc set TrangThai = 0 where MakichTHuoc = '" + txtMaKichThuoc.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaKichThuoc.Text = "";
                        txtTenKichThuoc.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
                        dgvKichThuoc.Enabled = true;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thể lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtMaKichThuoc.Text = "";
                    txtTenKichThuoc.Text = "";
                    cmbTrangThai.SelectedIndex = -1;
                    dgvKichThuoc.Enabled = true;
                    XuLyChucnang(true);
                    XuLyTextBox(true);
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LayDuLieu("select * from KichThuoc where TrangThai = 1", dgvKichThuoc);
            txtMaKichThuoc.Enabled = false;
            txtMaKichThuoc.Text = "";
            txtTenKichThuoc.Text = "";
            cmbTrangThai.SelectedIndex = -1;
            dgvKichThuoc.Enabled = true;
            XuLyChucnang(true);
            XuLyTextBox(true);
        }
        private void txtTenKichThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong() == false)
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
                dgvKichThuoc.Enabled = false;
            }
        }
    }
}
