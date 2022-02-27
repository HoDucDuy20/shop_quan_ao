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
    public partial class frmTimKiemKhachHang : Form
    {
        public frmTimKiemKhachHang()
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

        private void frmTimKiemKhachHangTheoDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult thoat = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (thoat == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void frmTimKiemKhachHangTheoDT_Load(object sender, EventArgs e)
        {
            cboSearch.Items.Add("Số điện thoại");
            cboSearch.Items.Add("Mã khách hàng");
            cboSearch.Items.Add("Tên khách hàng");
            cboSearch.Items.Add("Địa chỉ");
            cboSearch.SelectedIndex = 0;
            string sql = "select * from KhachHang";
            LayDuLieu(sql, dgvDanhSach);
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
            else if (cboSearch.SelectedIndex == 2)
            {
                if (char.IsNumber(e.KeyChar) == true)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string sql = "select * from KhachHang where ";
            if (cboSearch.SelectedIndex == 0)
            {
                sql += "Phone like '%" + txtSearch.Text + "%'";
            }
            else if (cboSearch.SelectedIndex == 1)
            {
                sql += "MaKH like '%" + txtSearch.Text + "%'";
            }
            else if (cboSearch.SelectedIndex == 2)
            {
                sql += "TenKH like N'%" + txtSearch.Text + "%'";
            }
            else
            {
                sql += "DiaChi like N'%" + txtSearch.Text + "%'";
            }
            LayDuLieu(sql, dgvDanhSach);
        }

    }
}
