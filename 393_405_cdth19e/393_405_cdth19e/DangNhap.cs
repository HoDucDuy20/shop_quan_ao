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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();

        void LayDuLieu(string sql)
        {
            ds = c.layDuLieu(sql);
        }

        int ktTK(String tk)
        {
            int n = ds.Tables[0].Rows.Count;
            for (int i = 0; i < n; i++)
            {
                if (tk == ds.Tables[0].Rows[i]["TenTK"].ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        bool ktMK(String mk, int vt)
        {
            if (mk == ds.Tables[0].Rows[vt]["MatKhau"].ToString())
            {
                return true;
            }
            return false;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            LayDuLieu("select * from TaiKhoan");
            txtMK.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
        }

        private void btnDanNhap_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "" || txtMK.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int check = ktTK(txtTK.Text);
                if (check != -1)
                {
                    if (ktMK(txtMK.Text, check))
                    {
                        frmGiaoDienChinh f = new frmGiaoDienChinh();
                        f.taikhoan = check;
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMK.Text = "";
                        txtMK.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMK.Text = "";
                    txtTK.Focus();
                }
            }
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHienThi.Checked)
            {
                txtMK.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }    
            else
            {
                txtMK.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }    
        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDanNhap_Click(sender, e);
            }    
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDanNhap_Click(sender, e);
            }
        }
    }
}
