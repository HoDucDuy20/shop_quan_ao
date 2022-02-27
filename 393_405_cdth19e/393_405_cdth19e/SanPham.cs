using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace _393_405_cdth19e
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        void XuLyTextBox(Boolean t)
        {
            txtMaSanPham.ReadOnly = t;
            txtTenSanPham.ReadOnly = t;
            txtDonGia.ReadOnly = t;
            cmbKichThuoc.Enabled = !t;
            cmbTenNhaCungCap.Enabled = !t;
            cboLoaiSanPham.Enabled = !t;
            nudSoLuong.Enabled = !t;
            cmbMauSac.Enabled = !t;
            cmbTrangThai.Enabled = !t;
            btnChonHinh.Enabled = !t;
            txtTenHinh.ReadOnly = t;
        }
        void XuLyChucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
        }
        bool KiemTraBoTrong()
        {
            if (txtMaSanPham.Text == "" || txtTenSanPham.Text == "" || txtDonGia.Text == "" || nudSoLuong.Text == "" || cboLoaiSanPham.Text == "" || cmbTenNhaCungCap.Text == "" || cmbMauSac.Text == "" || cmbKichThuoc.Text=="" || txtTenHinh.Text == "")
            {
                return false;
            }
            return true;
        }
        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
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
        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();

        DataSet dsMau = new DataSet();
        DataSet dsKichThuoc = new DataSet();
        DataSet dsNCC = new DataSet();
        DataSet dsLoaiSP = new DataSet();
        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }
        string PhatSinhMa()
        {
            string MaSp = "";
            /*Sắp xếp tăng dần*/
            DataSet d = c.layDuLieu("select MaSp from SanPham order by MaSp");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)/*kiểm tra dữ liệu có tồn tại không <0 không tồn tại (0-1=-1)*/
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MaSp"].ToString();
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
                MaSp = "SP01";
            }
            return MaSp;
        }
        string NhaCC = "";
        string LoaiSp = "";
        string Colors = "";
        string Sizes = "";
        void HienThiTextBox(int vt, DataSet ds)
        {
            flpHinhAnh.Controls.Clear();
            txtMaSanPham.Text = ds.Tables[0].Rows[vt]["MaSp"].ToString();
            txtTenSanPham.Text = ds.Tables[0].Rows[vt]["TenSp"].ToString();
            txtDonGia.Text = ds.Tables[0].Rows[vt]["GiaBan"].ToString();
            nudSoLuong.Text = ds.Tables[0].Rows[vt]["SoLuong"].ToString();
            txtTenHinh.Text = ds.Tables[0].Rows[vt]["HinhAnh"].ToString();

            string sql1 = "select TenNcc from NhaCungCap where MaNCC = '" + ds.Tables[0].Rows[vt]["MaNcc"].ToString() + "'";
            dsNCC = c.layDuLieu(sql1);
            cmbTenNhaCungCap.DataSource = dsNCC.Tables[0];
            cmbTenNhaCungCap.DisplayMember = "TenNcc";
            NhaCC = cmbTenNhaCungCap.Text;

            string sql2 = "select TenLoaiSP from LoaiSanPham where MaLoaiSP = '" + ds.Tables[0].Rows[vt]["MaLoaiSP"].ToString() + "'";
            dsLoaiSP = c.layDuLieu(sql2);
            cboLoaiSanPham.DataSource = dsLoaiSP.Tables[0];
            cboLoaiSanPham.DisplayMember = "TenLoaiSP";
            LoaiSp = cboLoaiSanPham.Text;

            string sql3 = "select TenMau from MauSac where MaMau = '" + ds.Tables[0].Rows[vt]["Color"].ToString() + "'";
            dsMau = c.layDuLieu(sql3);
            cmbMauSac.DataSource = dsMau.Tables[0];
            cmbMauSac.DisplayMember = "TenMau";
            Colors = cmbMauSac.Text;

            string sql4 = "select TenKichThuoc from KichThuoc where MaKichThuoc = '" + ds.Tables[0].Rows[vt]["Size"].ToString() + "'";
            dsKichThuoc = c.layDuLieu(sql4);
            cmbKichThuoc.DataSource = dsKichThuoc.Tables[0];
            cmbKichThuoc.DisplayMember = "TenKichThuoc";
            Sizes = cmbKichThuoc.Text;

            if (ds.Tables[0].Rows[vt]["TrangThai"].ToString() == "1")
            {
                cmbTrangThai.Text = "Hoạt động";
            }
            else
            {
                cmbTrangThai.Text = "Ngưng hoạt động";
            }

            string TextHinh = txtTenHinh.Text;
            string[] HinhAnh = TextHinh.Split(';');
            flpHinhAnh.Controls.Clear();
            for (int i = 0; i < HinhAnh.Count(); i++)
            {
                string TenFile = Path.GetFullPath("hinh") + @"\";
                if (HinhAnh[i] != "")
                {
                    TenFile = TenFile + HinhAnh[i];
                }
                else
                {
                    break;
                }
                Bitmap a = new Bitmap(TenFile);
                PictureBox p = new PictureBox();
                p.Image = a;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Size = new Size(250, 250);
                flpHinhAnh.Controls.Add(p);
            }
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LayDuLieu("select *from SanPham where TrangThai = 1", dgvSanPham);
            cmbTrangThai.Items.Add("Hoạt động");
            cmbTrangThai.Items.Add("Ngưng hoạt động");
            XuLyChucnang(true);
            XuLyTextBox(true);

            cmbKichThuoc.SelectedIndex = -1;
            cmbMauSac.SelectedIndex = -1;
            cmbTenNhaCungCap.SelectedIndex = -1;
            cboLoaiSanPham.SelectedIndex = -1;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox(vt, ds);
        }
        int flag = 0;
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
                    string sql1 = "insert into SanPham values('" + txtMaSanPham.Text + "', N'" + txtTenSanPham.Text + "', " + Convert.ToInt32(nudSoLuong.Value) + ", " + Convert.ToInt32(txtDonGia.Text) + ", '" + cmbTenNhaCungCap.SelectedValue.ToString() + "'," + KiemTraTinhTrang() + ", '" + cboLoaiSanPham.SelectedValue.ToString() + "', '" + cmbKichThuoc.SelectedValue.ToString() + "', '" + cmbMauSac.SelectedValue.ToString() + "', '" + txtTenHinh.Text + "')";
                    if (c.CapNhatDuLieu(sql1) != 0)
                    {
                        MessageBox.Show("Lưu sản phẩm thành công", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flpHinhAnh.Controls.Clear();
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                        flpHinhAnh.Controls.Clear();
                        txtMaSanPham.Text = "";
                        txtTenSanPham.Text = "";
                        txtDonGia.Text = "";
                        nudSoLuong.Text = "";
                        cboLoaiSanPham.Text = "";
                        cmbTenNhaCungCap.Text = "";
                        cmbMauSac.Text = "";
                        cmbKichThuoc.Text = "";
                        txtTenHinh.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
                        dgvSanPham.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thể lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (flag == 2)
            {
                if (txtTenSanPham.Text == "" || txtDonGia.Text == "" || nudSoLuong.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Dữ liệu bị bỏ trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "";


                    if (cmbTenNhaCungCap.Text == "" && cboLoaiSanPham.Text == "" && cmbMauSac.Text == "" && cmbKichThuoc.Text == "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + SizeCu + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }

                    if (cmbTenNhaCungCap.Text == "" && cboLoaiSanPham.Text == "" && cmbMauSac.Text != "" && cmbKichThuoc.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cmbTenNhaCungCap.Text == "" && cmbMauSac.Text == "" && cmbKichThuoc.Text != "" && cboLoaiSanPham.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cmbTenNhaCungCap.Text == "" && cmbKichThuoc.Text == "" && cmbMauSac.Text != "" && cboLoaiSanPham.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + SizeCu + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }

                    if (cboLoaiSanPham.Text == "" && cmbMauSac.Text == "" && cmbTenNhaCungCap.Text != "" && cmbKichThuoc.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cboLoaiSanPham.Text == "" && cmbKichThuoc.Text == "" && cmbTenNhaCungCap.Text != "" && cmbMauSac.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + SizeCu + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }

                    if (cmbMauSac.Text == "" && cmbKichThuoc.Text == "" && cmbTenNhaCungCap.Text != "" && cboLoaiSanPham.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + SizeCu + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }

                    if (cmbTenNhaCungCap.Text == "" && cboLoaiSanPham.Text == "" && cmbMauSac.Text == "" && cmbKichThuoc.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cmbTenNhaCungCap.Text == "" && cboLoaiSanPham.Text == "" && cmbKichThuoc.Text == "" && cmbMauSac.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + SizeCu + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cboLoaiSanPham.Text == "" && cmbMauSac.Text == "" && cmbKichThuoc.Text == "" && cmbTenNhaCungCap.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + SizeCu + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cboLoaiSanPham.Text != "" && cmbMauSac.Text == "" && cmbKichThuoc.Text == "" && cmbTenNhaCungCap.Text == "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + SizeCu + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }

                    if (cmbTenNhaCungCap.Text == "" && cboLoaiSanPham.Text != "" && cmbMauSac.Text != "" && cmbKichThuoc.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + NhaCCCu + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cboLoaiSanPham.Text == "" && cmbTenNhaCungCap.Text != "" && cmbMauSac.Text != "" && cmbKichThuoc.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + LoaiSPCu + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cmbMauSac.Text == "" && cmbKichThuoc.Text != "" && cmbTenNhaCungCap.Text != "" && cboLoaiSanPham.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + ColorCu + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }
                    if (cmbKichThuoc.Text == "" && cmbMauSac.Text != "" && cmbTenNhaCungCap.Text != "" && cboLoaiSanPham.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + SizeCu + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }

                    if (cmbTenNhaCungCap.Text != "" && cboLoaiSanPham.Text != "" && cmbMauSac.Text != "" && cmbKichThuoc.Text != "")
                    {
                        sql = "update SanPham set TenSp = N'" + txtTenSanPham.Text + "', SoLuong=" + Convert.ToInt32(nudSoLuong.Value) + ", GiaBan=" + Convert.ToInt32(txtDonGia.Text) + ",MaNcc='" + cmbTenNhaCungCap.SelectedValue.ToString() + "',TrangThai = " + KiemTraTinhTrang() + ",MaLoaiSP='" + cboLoaiSanPham.SelectedValue.ToString() + "',Size='" + cmbKichThuoc.SelectedValue.ToString() + "',Color='" + cmbMauSac.SelectedValue.ToString() + "',HinhAnh='" + txtTenHinh.Text.ToString() + "' where MaSp = '" + txtMaSanPham.Text + "'";
                    }


                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Chỉnh sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flpHinhAnh.Controls.Clear();
                        txtMaSanPham.Text = "";
                        txtTenSanPham.Text = "";
                        txtDonGia.Text = "";
                        nudSoLuong.Text = "";
                        cboLoaiSanPham.Text = "";
                        cmbTenNhaCungCap.Text = "";
                        cmbMauSac.Text = "";
                        cmbKichThuoc.Text = "";
                        txtTenHinh.Text = "";
                        lblKichThuoc.Text = "";
                        lblMauSac.Text = "";
                        lblNhaCC.Text = "";
                        lblLoaiSp.Text = "";
                        cmbTrangThai.SelectedIndex = -1;
                        dgvSanPham.Enabled = true;
                        XuLyChucnang(true);
                        XuLyTextBox(true);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lưu trữ", "Không thễ lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (flag == 3)
            {
                string sql2 = "update SanPham set TrangThai = 0 where MaSp = '" + txtMaSanPham.Text + "'";
                DialogResult kq = MessageBox.Show("Bạn có muốn xóa sản phẩm này", "Thông báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kq == DialogResult.Yes)
                {
                    if (c.CapNhatDuLieu(sql2) != 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flpHinhAnh.Controls.Clear();
                        txtMaSanPham.Text = "";
                        txtTenSanPham.Text = "";
                        txtDonGia.Text = "";
                        nudSoLuong.Text = "";
                        cboLoaiSanPham.Text = "";
                        cmbTenNhaCungCap.Text = "";
                        cmbMauSac.Text = "";
                        cmbKichThuoc.Text = "";
                        txtTenHinh.Text = "";
                        dgvSanPham.Enabled = true;
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
                    flpHinhAnh.Controls.Clear();
                    txtMaSanPham.Text = "";
                    txtTenSanPham.Text = "";
                    txtDonGia.Text = "";
                    nudSoLuong.Text = "";
                    cboLoaiSanPham.Text = "";
                    cmbTenNhaCungCap.Text = "";
                    cmbMauSac.Text = "";
                    cmbKichThuoc.Text = "";
                    txtTenHinh.Text = "";
                    dgvSanPham.Enabled = true;
                    cmbTrangThai.SelectedIndex = -1;
                    XuLyChucnang(true);
                    XuLyTextBox(true);
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql1 = "select MaMau,TenMau from MauSac where TrangThai = 1";
            dsMau = c.layDuLieu(sql1);
            cmbMauSac.DataSource = dsMau.Tables[0];
            cmbMauSac.DisplayMember = "TenMau";
            cmbMauSac.ValueMember = "MaMau";

            string sql2 = "select MaKichThuoc,TenKichThuoc from KichThuoc where TrangThai = 1";
            dsKichThuoc = c.layDuLieu(sql2);
            cmbKichThuoc.DataSource = dsKichThuoc.Tables[0];
            cmbKichThuoc.DisplayMember = "TenKichThuoc";
            cmbKichThuoc.ValueMember = "MaKichThuoc";

            string sql3 = "select TenNcc,MaNCC from NhaCungCap where TrangThai = 1";
            dsNCC = c.layDuLieu(sql3);
            cmbTenNhaCungCap.DataSource = dsNCC.Tables[0];
            cmbTenNhaCungCap.DisplayMember = "TenNcc";
            cmbTenNhaCungCap.ValueMember = "MaNCC";

            string sql4 = "select MaLoaiSP,TenLoaiSP from LoaiSanPham where TrangThai = 1";
            dsLoaiSP = c.layDuLieu(sql4);
            cboLoaiSanPham.DataSource = dsLoaiSP.Tables[0];
            cboLoaiSanPham.DisplayMember = "TenLoaiSP";
            cboLoaiSanPham.ValueMember = "MaLoaiSP";

            flpHinhAnh.Controls.Clear();
            XuLyChucnang(false);
            XuLyTextBox(false);
            txtMaSanPham.Text = PhatSinhMa();
            txtMaSanPham.Enabled = false;
            txtTenSanPham.Text = "";
            txtDonGia.Text = "";
            nudSoLuong.Text = "";
            cboLoaiSanPham.Text = "";
            cmbTenNhaCungCap.Text = "";
            cmbMauSac.Text = "";
            cmbKichThuoc.Text = "";
            txtTenHinh.Text = "";
            cmbTrangThai.SelectedIndex = 0;
            cmbTrangThai.Enabled = false;
            flag = 1;
            dgvSanPham.Enabled = false;
        }
        string NhaCCCu;
        string LoaiSPCu;
        string ColorCu;
        string SizeCu;
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
                cmbTrangThai.Enabled = false;
                dgvSanPham.Enabled = false;
                txtTenHinh.ReadOnly = true;

                lblNhaCC.Text = NhaCC;
                lblLoaiSp.Text = LoaiSp;
                lblMauSac.Text = Colors;
                lblKichThuoc.Text = Sizes;

                string sql1 = "select MaMau,TenMau from MauSac where TrangThai = 1";
                dsMau = c.layDuLieu(sql1);
                cmbMauSac.DataSource = dsMau.Tables[0];
                cmbMauSac.DisplayMember = "TenMau";
                cmbMauSac.ValueMember = "MaMau";

                string sql2 = "select MaKichThuoc,TenKichThuoc from KichThuoc where TrangThai = 1";
                dsKichThuoc = c.layDuLieu(sql2);
                cmbKichThuoc.DataSource = dsKichThuoc.Tables[0];
                cmbKichThuoc.DisplayMember = "TenKichThuoc";
                cmbKichThuoc.ValueMember = "MaKichThuoc";

                string sql3 = "select TenNcc,MaNCC from NhaCungCap where TrangThai = 1";
                dsNCC = c.layDuLieu(sql3);
                cmbTenNhaCungCap.DataSource = dsNCC.Tables[0];
                cmbTenNhaCungCap.DisplayMember = "TenNcc";
                cmbTenNhaCungCap.ValueMember = "MaNCC";

                string sql4 = "select MaLoaiSP,TenLoaiSP from LoaiSanPham where TrangThai = 1";
                dsLoaiSP = c.layDuLieu(sql4);
                cboLoaiSanPham.DataSource = dsLoaiSP.Tables[0];
                cboLoaiSanPham.DisplayMember = "TenLoaiSP";
                cboLoaiSanPham.ValueMember = "MaLoaiSP";

                DataSet a = c.layDuLieu("select MaNCC from NhaCungCap where tenNCC=N'" + NhaCC + "'");
                NhaCCCu = a.Tables[0].Rows[0]["MaNCC"].ToString();
                DataSet b = c.layDuLieu("select MaMau from MauSac where TenMau = N'" + Colors + "'");
                ColorCu = b.Tables[0].Rows[0]["MaMau"].ToString();
                DataSet d = c.layDuLieu("select MaLoaiSP from LoaiSanPham where TenLoaiSP=N'" + LoaiSp + "'");
                LoaiSPCu = d.Tables[0].Rows[0]["MaLoaiSP"].ToString();
                DataSet f = c.layDuLieu("select MaKichThuoc from KichThuoc where TenKichThuoc=N'" + Sizes + "'");
                SizeCu = f.Tables[0].Rows[0]["MaKichThuoc"].ToString();

            }
            cmbKichThuoc.SelectedIndex = -1;
            cmbMauSac.SelectedIndex = -1;
            cmbTenNhaCungCap.SelectedIndex = -1;
            cboLoaiSanPham.SelectedIndex = -1;
            txtMaSanPham.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void btnChonHinh_Click_1(object sender, EventArgs e)
        {
            flpHinhAnh.Controls.Clear();
            txtTenHinh.Text = "";
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Path.GetFullPath("hinh") + @"\";
            o.Multiselect = true;
            o.ShowDialog();
            foreach (string f in o.FileNames)
            {
                Bitmap a = new Bitmap(f);
                PictureBox p = new PictureBox();
                p.Image = a;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Size = new Size(250, 250);
                flpHinhAnh.Controls.Add(p);

                string[] t = f.Split('\\');
                txtTenHinh.Text = txtTenHinh.Text + (t[t.Count() - 1] + ';');
            }
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
            }
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap x = new frmNhaCungCap();
            x.Show();
        }

        private void btnThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham x = new frmLoaiSanPham();
            x.Show();
        }

        private void btnThemMau_Click(object sender, EventArgs e)
        {
            frmMauSac x = new frmMauSac();
            x.Show();
        }

        private void btnThemKichThuoc_Click(object sender, EventArgs e)
        {
            frmKichThuoc x = new frmKichThuoc();
            x.Show();
        }

        private void btnHuyThaoTac_Click_1(object sender, EventArgs e)
        {
            LayDuLieu("select * from SanPham where TrangThai = 1", dgvSanPham);
            flpHinhAnh.Controls.Clear();
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGia.Text = "";
            nudSoLuong.Text = "";
            cboLoaiSanPham.Text = "";
            cmbTenNhaCungCap.Text = "";
            cmbMauSac.Text = "";
            cmbKichThuoc.Text = "";
            txtTenHinh.Text = "";
            dgvSanPham.Enabled = true;
            cmbTrangThai.SelectedIndex = -1;

            lblKichThuoc.Text = "";
            lblMauSac.Text = "";
            lblNhaCC.Text = "";
            lblLoaiSp.Text = "";

            XuLyChucnang(true);
            XuLyTextBox(true);
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                MessageBox.Show("Bạn chưa lưu", "Chưa lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LayDuLieu("select *from SanPham where TrangThai = 1", dgvSanPham);
                XuLyChucnang(true);
                XuLyTextBox(true);
            }
        }

        private void btnRNcc_Click(object sender, EventArgs e)
        {
            string sql3 = "select TenNcc,MaNCC from NhaCungCap where TrangThai = 1";
            dsNCC = c.layDuLieu(sql3);
            cmbTenNhaCungCap.DataSource = dsNCC.Tables[0];
            cmbTenNhaCungCap.DisplayMember = "TenNcc";
            cmbTenNhaCungCap.ValueMember = "MaNCC";
            cmbTenNhaCungCap.SelectedIndex = -1;
        }

        private void btnRLsp_Click(object sender, EventArgs e)
        {
            string sql4 = "select MaLoaiSP,TenLoaiSP from LoaiSanPham where TrangThai = 1";
            dsLoaiSP = c.layDuLieu(sql4);
            cboLoaiSanPham.DataSource = dsLoaiSP.Tables[0];
            cboLoaiSanPham.DisplayMember = "TenLoaiSP";
            cboLoaiSanPham.ValueMember = "MaLoaiSP";
            cboLoaiSanPham.SelectedIndex = -1;
        }

        private void btnRColor_Click(object sender, EventArgs e)
        {
            string sql1 = "select MaMau,TenMau from MauSac where TrangThai = 1";
            dsMau = c.layDuLieu(sql1);
            cmbMauSac.DataSource = dsMau.Tables[0];
            cmbMauSac.DisplayMember = "TenMau";
            cmbMauSac.ValueMember = "MaMau";
            cmbMauSac.SelectedIndex = -1;
        }

        private void btnRSize_Click(object sender, EventArgs e)
        {
            string sql2 = "select MaKichThuoc,TenKichThuoc from KichThuoc where TrangThai = 1";
            dsKichThuoc = c.layDuLieu(sql2);
            cmbKichThuoc.DataSource = dsKichThuoc.Tables[0];
            cmbKichThuoc.DisplayMember = "TenKichThuoc";
            cmbKichThuoc.ValueMember = "MaKichThuoc";
            cmbKichThuoc.SelectedIndex = -1;
        }
    }
}
