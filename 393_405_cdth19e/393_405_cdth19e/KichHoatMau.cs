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
    public partial class frmKichHoatMau : Form
    {
        public frmKichHoatMau()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaMau.ReadOnly = t;
            txtTenMau.ReadOnly = t;
            cmbTrangThai.Enabled = !t;
        }
        private void KichHoatMau_Load(object sender, EventArgs e)
        {
            LayDuLieu("select *from MauSac where TrangThai = 0", dgvMauSac);
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            XuLyTextBox(true);
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
        private void KichHoatMau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        bool KiemTraBoTrong()
        {
            if (txtMaMau.Text == "" || txtTenMau.Text == "")
            {
                return false;
            }
            return true;
        }
        private void dgvMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt, ds);
        }

        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong() == false)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần kích hoạt", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyTextBox(true);
            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn muốn kích hoạt màu này ", "Thông báo kích hoạt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    string sql = "update MauSac set TrangThai = 1 where MaMau = '" + txtMaMau.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Kích hoạt dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaMau.Text = "";
                        txtTenMau.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
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
                    XuLyTextBox(true);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LayDuLieu("select *from MauSac where TrangThai = 0", dgvMauSac);
            XuLyTextBox(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
