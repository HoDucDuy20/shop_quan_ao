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
    public partial class frmKichHoatSize : Form
    {
        public frmKichHoatSize()
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
            txtMaKichThuoc.ReadOnly = t;
            txtTenKichThuoc.ReadOnly = t;
            cmbTrangThai.Enabled = !t;
        }

        private void KichHoatSize_Load(object sender, EventArgs e)
        {
            LayDuLieu("select *from KichThuoc where TrangThai = 0", dgvKichThuoc);
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            XuLyTextBox(true);
        }

        private void KichHoatSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
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
        bool KiemTraBoTrong()
        {
            if (txtMaKichThuoc.Text == "" || txtTenKichThuoc.Text == "")
            {
                return false;
            }
            return true;
        }
        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong() == false)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần xóa", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XuLyTextBox(true);
            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn muốn kích hoạt kích thước này ", "Thông báo kích hoạt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    string sql = "update KichThuoc set TrangThai = 1 where MakichTHuoc = '" + txtMaKichThuoc.Text + "'";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Kích hoạt dữ liệu thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaKichThuoc.Text = "";
                        txtTenKichThuoc.Text = "";
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
                    txtMaKichThuoc.Text = "";
                    txtTenKichThuoc.Text = "";
                    cmbTrangThai.SelectedIndex = -1;
                    dgvKichThuoc.Enabled = true;
                    XuLyTextBox(true);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LayDuLieu("select *from KichThuoc where TrangThai = 0", dgvKichThuoc);
            XuLyTextBox(true);
        }
    }
}
