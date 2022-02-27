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
    public partial class frmMauSac : Form
    {
        public frmMauSac()
        {
            InitializeComponent();
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaMau.ReadOnly = t;
            txtTenMau.ReadOnly = t;
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
        private void MauSac_Load(object sender, EventArgs e)
        {
            LayDuLieu("select *from MauSac where TrangThai = 1", dgvMauSac);
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            XuLyChucnang(true);
            XuLyTextBox(true);
            
        }

        private void frmMauSac_FormClosing(object sender, FormClosingEventArgs e)
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
            txtMaMau.Text = ds.Tables[0].Rows[vt]["MaMau"].ToString();
            txtTenMau.Text = ds.Tables[0].Rows[vt]["TenMau"].ToString();
            if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cmbTrangThai.SelectedIndex = 0;
            }
            else
            {
                cmbTrangThai.SelectedIndex = 1;
            }
        }
        private void dgvMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt, ds);
        }
        bool KiemTraBoTrong()
        {
            if (txtMaMau.Text==""||txtTenMau.Text=="")
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
            DataSet d = c.layDuLieu("select MaMau from MauSac order by MaMau");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MaMau"].ToString();
                int stt = Convert.ToInt32(dc.Remove(0, 1));
                if (stt < 9)
                {
                    MaSp = dc.Substring(0, 1) + "0" + (stt + 1);
                }
                else if (stt < 99)
                {
                    MaSp = dc.Substring(0, 1) + (stt + 1);
                }
            }
            else
            {
                MaSp = "M01";
            }
            return MaSp;
        }
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag==1)
            {
                if (KiemTraBoTrong() == false)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "insert into MauSac values('"+txtMaMau.Text+"', N'" + txtTenMau.Text + "',"+KiemTraTinhTrang()+")";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Lưu dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaMau.Text = "";
                        txtTenMau.Text = "";
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
            if (flag==2)
            {
                if (KiemTraBoTrong() == false)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "update MauSac set TenMau=N'" + txtTenMau.Text + "',TrangThai=" + KiemTraTinhTrang() + "where MaMau = '" + txtMaMau.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaMau.Text = "";
                        txtTenMau.Text = "";
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
            if (flag==3)
            {
                DialogResult kq = MessageBox.Show("Bạn muốn xóa màu này", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    string sql = "update MauSac set TrangThai=0 where MaMau = '" + txtMaMau.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaMau.Text = "";
                        txtTenMau.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
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
                    txtMaMau.Text = "";
                    txtTenMau.Text = "";
                    cmbTrangThai.SelectedIndex = -1;
                    dgvMauSac.Enabled = true;
                    XuLyChucnang(true);
                    XuLyTextBox(true);
                }
            }
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            XuLyChucnang(false);
            XuLyTextBox(false);
            txtMaMau.Text = PhatSinhMa();
            txtTenMau.Text = "";
            cmbTrangThai.SelectedIndex = 0;

            dgvMauSac.Enabled = false;
            cmbTrangThai.Enabled = false;
            txtMaMau.ReadOnly = true;
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
                dgvMauSac.Enabled = false;
            }
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
                txtMaMau.ReadOnly = true;
                cmbTrangThai.Enabled = false;
                dgvMauSac.Enabled = false;
            }
            
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LayDuLieu("select * from MauSac where TrangThai = 1", dgvMauSac);
            txtMaMau.Enabled = false;
            txtMaMau.Text = "";
            txtTenMau.Text = "";
            cmbTrangThai.SelectedIndex = -1;
            dgvMauSac.Enabled = true;
            XuLyChucnang(true);
            XuLyTextBox(true);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
