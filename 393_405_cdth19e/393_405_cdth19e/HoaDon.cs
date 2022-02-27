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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        ClassQuanLyBanHang c = new ClassQuanLyBanHang();
        DataSet ds = new DataSet();
        DataSet SanPham = new DataSet();
        DataSet HoaDon = new DataSet();
        DataSet ChiTietHoaDon = new DataSet();

        int TongThanhTien = 0;
        int ChucNang = 0;
        string MaKhachHang;
        string flag = "sdt";

        void XuLyXoaHD(int vt)
        {
            lblMaHoaDon.Text = "";
            lblTenKhachHang.Text = "";
            lblDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            cmbTrangThai.SelectedIndex = vt;
            lblTongTien1.Text = "";
        }

        void XuLyXoaCTHD()
        {
            txtMaSanPham.Text = "";
            lblTenSanPham.Text = "";
            lblDonGia.Text = "";
            txtSoLuong.Text = "";
            txtKhuyenMai.Text = "";
            picSanPham.Image = null;
        }

        void XuLyTextBox(Boolean t)
        {
            lblMaHoaDon.Enabled = !t;
            txtSoDienThoai.Enabled = !t;
            dtpNgayLapHoaDon.Enabled = !t;
            lblTenKhachHang.Enabled = !t;
            lblDiaChi.Enabled = !t;
            cmbTrangThai.Enabled = !t;
            txtSoDienThoai.Focus();
            dgvDanhSachHoaDon.Enabled = true;
            txtSoDienThoai.ReadOnly = false;
        }

        void XuLyChucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
            btnTimKiem.Enabled = !t;
            if (trangthai == 0 || trangthai == 3)
            {
                btnSua.Enabled = false;
            }
        }

        void XuLyChucnang2(Boolean t)
        {
            btnThem.Enabled = t;
            btnXoa.Enabled = t;
            btnSua.Enabled = t;
            btnLuu.Enabled = t;
            btnHuy.Enabled = t;
            btnTimKiem.Enabled = t;
        }

        void XuLyAnHienCTHD(Boolean t)
        {
            txtMaSanPham.Enabled = t;
            txtSoLuong.Enabled = t;
            txtKhuyenMai.Enabled = t;
            btnThemSanPham.Enabled = t;
            btnHT.Enabled = t;
            dgvChiTietHoaDon.ReadOnly = !t;
        }

        string PhatSinhMa()
        {
            string MaHD = "";
            DataSet d = c.layDuLieu("select MaHD from HoaDon order by MaHD");
            int DongCuoi = d.Tables[0].Rows.Count - 1;
            if (DongCuoi >= 0)
            {
                string dc = d.Tables[0].Rows[DongCuoi]["MaHD"].ToString();
                int stt = Convert.ToInt32(dc.Remove(0, 2));
                if (stt < 9)
                {
                    MaHD = dc.Substring(0, 2) + "0" + (stt + 1);
                }
                else if (stt < 99)
                {
                    MaHD = dc.Substring(0, 2) + (stt + 1);
                }
            }
            else
            {
                MaHD = "HD01";
            }
            return MaHD;
        }

        void LayDuLieu(string sql, DataGridView dgv)
        {
            ds = c.layDuLieu(sql);
            dgv.DataSource = ds.Tables[0];
        }

        string DinhDangTien(String t)
        {
            try
            {
                int n = t.Length;
                int j = (n - 1) / 3;
                for (int i = 0; i < j; i++)
                {
                    t = t.Insert((n - (3 * (i + 1)) - i), ",");
                    n++;
                }
                return t + " Đ";
            }
            catch
            {
                return "";
            }
        }

        void HienThiTextBox1(int vt, DataSet ds)
        {
            try
            {
                lblMaHoaDon.Text = ds.Tables[0].Rows[vt]["MaHD"].ToString();
                lblTongTien1.Text = DinhDangTien(ds.Tables[0].Rows[vt]["TongTien"].ToString());
                MaKhachHang = ds.Tables[0].Rows[vt]["MaKh"].ToString();
                txtSoDienThoai.Text = ds.Tables[0].Rows[vt]["Phone"].ToString();
                lblDiaChi.Text = ds.Tables[0].Rows[vt]["DiaChi"].ToString();

                string sql = "select TenKh from KhachHang where MaKh = '" + MaKhachHang + "'";
                DataSet Tenkh = new DataSet();
                Tenkh = c.layDuLieu(sql);
                lblTenKhachHang.Text = Tenkh.Tables[0].Rows[0]["TenKh"].ToString();

                int tt = int.Parse(ds.Tables[0].Rows[vt]["TrangThai"].ToString());
                if (tt == 0)
                {
                    cmbTrangThai.Text = "Đã hủy";
                }
                else
                {
                    cmbTrangThai.SelectedIndex = (tt - 1);
                }

                TongThanhTien = int.Parse(ds.Tables[0].Rows[vt]["tongtien"].ToString());
                dtpNgayLapHoaDon.Text = ds.Tables[0].Rows[vt]["NgayLapHD"].ToString();
            }
            catch
            {

            }
        }

        int sl;
        void HienThiTextBox2(int vt, DataSet ds)
        {
            try
            {
                txtMaSanPham.Text = ds.Tables[0].Rows[vt]["MaSP"].ToString();
                sl = int.Parse(ds.Tables[0].Rows[vt]["SoLuong"].ToString());
                txtSoLuong.Text = sl.ToString();
                lblDonGia.Text = ds.Tables[0].Rows[vt]["DonGia"].ToString();
                txtKhuyenMai.Text = ds.Tables[0].Rows[vt]["ChietKhau"].ToString();
                lblTongTien2.Text = DinhDangTien(ds.Tables[0].Rows[vt]["ThanhTien"].ToString());
                string sql = "select TenSP, HinhAnh from SanPham where MaSP = '" + txtMaSanPham.Text + "'";
                DataSet SP = new DataSet();
                SP = c.layDuLieu(sql);
                lblTenSanPham.Text = SP.Tables[0].Rows[0]["TenSP"].ToString();
                loadAnh(SP.Tables[0].Rows[0]["HinhAnh"].ToString());
            }
            catch
            {

            }
        }

        void loadAnh(String h)
        {
            string[] HinhAnh = h.Split(';');
            string FileName = Path.GetFullPath("Hinh") + @"\";
            FileName = FileName + HinhAnh[0];
            Bitmap a = new Bitmap(FileName);
            picSanPham.Image = a;
            picSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        bool KiemTraBoTrong()
        {
            if (lblTenKhachHang.Text == "" || txtSoDienThoai.Text == "" || lblDiaChi.Text == "" || lblMaHoaDon.Text == "" || dtpNgayLapHoaDon.Text == "" || (cmbTrangThai.SelectedIndex == -1 && trangthai != 0))
            {
                return false;
            }
            return true;
        }

        int trangthai = 1;
        void loadDL_HD()
        {
            try
            {
                LayDuLieu("Select  mahd, ngaylaphd, k.makh, k.phone, k.diachi, loaihd, tongtien, h.trangthai from HoaDon h, KhachHang k where h.makh = k.makh and h.trangthai = " + trangthai + " order by mahd", dgvDanhSachHoaDon);
                HoaDon = c.layDuLieu("Select  mahd, ngaylaphd, k.makh, k.phone, k.diachi, loaihd, tongtien, h.trangthai from HoaDon h, KhachHang k where h.makh = k.makh and h.trangthai = " + trangthai + " order by mahd");
            }
            catch
            {

            }
        }

        void loadDL_HD(string sql)
        {
            try
            {
                LayDuLieu("Select  mahd, ngaylaphd, k.makh, k.phone, k.diachi, loaihd, tongtien, h.trangthai from HoaDon h, KhachHang k where h.makh = k.makh and h.trangthai = " + trangthai + " and " + sql + " order by mahd", dgvDanhSachHoaDon);
                HoaDon = c.layDuLieu("Select  mahd, ngaylaphd, k.makh, k.phone, k.diachi, loaihd, tongtien, h.trangthai from HoaDon h, KhachHang k where h.makh = k.makh and h.trangthai = " + trangthai + " order by mahd");
            }
            catch
            {

            }
        }

        void loadDL_CTHD(string mahd)
        {
            try
            {
                LayDuLieu("select masp, dongia, soluong, chietkhau, thanhtien from CT_HoaDon where mahd = '" + mahd + "'", dgvChiTietHoaDon);
                ChiTietHoaDon = c.layDuLieu("select * from CT_HoaDon where mahd = '" + mahd + "'");
            }
            catch
            {

            }
        }

        int KiemTraTinhTrang()
        {
            int tt = int.Parse(cmbTrangThai.SelectedIndex.ToString());
            return (tt + 1);
        }

        void luuDL(String sql, String ThongBao)
        {
            if (c.CapNhatDuLieu(sql) != 0)
            {
                DialogResult kq = MessageBox.Show(ThongBao + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult kq = MessageBox.Show(ThongBao + " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            loadDL_HD();
            loadDL_CTHD("");
            cmbTrangThai.Items.Add("Mới");
            cmbTrangThai.Items.Add("Đang giao");
            cmbTrangThai.Items.Add("Đã giao");
            //cmbTrangThai.Items.Add("Đã hủy");
            dtpNgayLapHoaDon.MaxDate = DateTime.Today;
            dtpNgayLapHoaDon.Value = DateTime.Today;
            XuLyChucnang(true);
            XuLyTextBox(true);
            XuLyAnHienCTHD(false);
            radMoi.Checked = true;
            cboSearch.Items.Add("Mã HD");
            cboSearch.Items.Add("SĐT");
            cboSearch.Items.Add("Tên KH");
            cboSearch.SelectedIndex = 0;

        }

        private void dgvDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox1(vt, HoaDon);
            XuLyXoaCTHD();
            lblTongTien2.Text = "";
            loadDL_CTHD(lblMaHoaDon.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucNang = 1;
            XuLyChucnang(false);
            XuLyTextBox(false);
            XuLyXoaHD(0);
            lblMaHoaDon.Text = PhatSinhMa();
            cmbTrangThai.Enabled = false;
            dgvDanhSachHoaDon.Enabled = false;
            lblTongTien1.Text = "0 Đ";
            dtpNgayLapHoaDon.Value = DateTime.Today;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong())
            {
                ChucNang = 2;
                XuLyChucnang(false);
                XuLyTextBox(true);
            }
            else
            {
                MessageBox.Show("Bạn cần chọn một thông tin khách hàng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong())
            {
                ChucNang = 3;
                XuLyChucnang(false);
                XuLyTextBox(false);
                cmbTrangThai.Focus();
                txtSoDienThoai.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Bạn cần chọn một thông tin khách hàng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraBoTrong())
            {
                string sql;
                if (ChucNang == 1)
                {
                    sql = "insert into HoaDon values('" + lblMaHoaDon.Text + "', '" + dtpNgayLapHoaDon.Text + "', '" + MaKhachHang + "', 'X', " + 0 + "," + KiemTraTinhTrang() + ")";
                    luuDL(sql, "Thêm");
                    XuLyChucnang2(false);
                    XuLyAnHienCTHD(true);
                    txtMaSanPham.Focus();
                }
                else if (ChucNang == 2)
                {
                    if (trangthai != 0)
                    {
                        sql = "update CT_HoaDon set TrangThai = " + '0' + " where MaHD = '" + lblMaHoaDon.Text + "'";
                        c.CapNhatDuLieu(sql);
                        loadDL_CTHD(lblMaHoaDon.Text);
                        sql = "update HoaDon set TrangThai = " + '0' + " where MaHD = '" + lblMaHoaDon.Text + "'";
                        luuDL(sql, "Xóa");
                        XuLyXoaHD(-1);
                        XuLyChucnang(true);
                    }
                    else
                    {
                        sql = "update CT_HoaDon set TrangThai = " + '1' + " where MaHD = '" + lblMaHoaDon.Text + "'";
                        c.CapNhatDuLieu(sql);
                        loadDL_CTHD(lblMaHoaDon.Text);
                        sql = "update HoaDon set TrangThai = " + '1' + " where MaHD = '" + lblMaHoaDon.Text + "'";
                        luuDL(sql, "Kích hoạt");
                        XuLyXoaHD(-1);
                        XuLyChucnang(true);
                    }
                }
                else if (ChucNang == 3)
                {
                    sql = "update HoaDon set NgayLapHD = '" + dtpNgayLapHoaDon.Text + "', MaKH = '" + MaKhachHang + "', LoaiHD = '" + 'X' + "', TrangThai = " + KiemTraTinhTrang() + " where MaHD = '" + lblMaHoaDon.Text + "'";
                    luuDL(sql, "Sửa");
                    XuLyChucnang2(false);
                    XuLyAnHienCTHD(true);
                    txtMaSanPham.Focus();
                }

                loadDL_HD();
                loadDL_CTHD(lblMaHoaDon.Text);
                XuLyTextBox(true);
                XuLyXoaCTHD();
                lblTongTien2.Text = "";
                if (cmbTrangThai.SelectedIndex != 0)
                {
                    btnHT_Click(sender, e);
                }
                if (ChucNang == 1 || ChucNang == 3)
                {
                    dgvDanhSachHoaDon.Enabled = false;
                }
                ChucNang = 0;
            }
            else
            {
                DialogResult kq = MessageBox.Show("Bạn cần điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmKhachHang KH = new frmKhachHang();
            KH.flag = "btnTim";
            KH.MaKhachHang = MaKhachHang;
            KH.ShowDialog();
            lblTenKhachHang.Text = KH.TenKhachHang;
            txtSoDienThoai.Text = KH.SDT;
            lblDiaChi.Text = KH.Diachi;
            MaKhachHang = KH.MaKhachHang;
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtMaSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "select * from sanpham where MaSp = '" + txtMaSanPham.Text + "'";
                DataSet dsSanPham = c.layDuLieu(sql);
                if (dsSanPham.Tables[0].Rows.Count > 0)
                {
                    lblTenSanPham.Text = dsSanPham.Tables[0].Rows[0]["TenSp"].ToString();
                    lblDonGia.Text = dsSanPham.Tables[0].Rows[0]["GiaBan"].ToString();

                    loadAnh(dsSanPham.Tables[0].Rows[0]["HinhAnh"].ToString());

                    txtSoLuong.Focus();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string SDT = txtSoDienThoai.Text;
                    if ((SDT.Substring(0, 2) == "03" || SDT.Substring(0, 2) == "05" || SDT.Substring(0, 2) == "07" || SDT.Substring(0, 2) == "08" || SDT.Substring(0, 2) == "09") && SDT.Length == 10)
                    {
                        DataSet DsKhachHang = new DataSet();
                        DsKhachHang = c.layDuLieu("select * from KhachHang");
                        bool check = false;
                        foreach (DataRow d in DsKhachHang.Tables[0].Rows)
                        {
                            if (d["Phone"].ToString() == txtSoDienThoai.Text)
                            {
                                lblTenKhachHang.Text = d["TenKh"].ToString();
                                lblDiaChi.Text = d["DiaChi"].ToString();
                                MaKhachHang = d["MaKh"].ToString();
                                check = true;
                                break;
                            }
                        }
                        if (check == false)
                        {
                            frmKhachHang KH = new frmKhachHang();
                            KH.SDT = txtSoDienThoai.Text;
                            KH.flag = flag;
                            KH.ShowDialog();
                            lblTenKhachHang.Text = KH.TenKhachHang;
                            txtSoDienThoai.Text = KH.SDT;
                            lblDiaChi.Text = KH.Diachi;
                            MaKhachHang = KH.MaKhachHang;
                        }
                        btnLuu.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ChucNang = 0;
            XuLyChucnang(true);
            XuLyTextBox(true);
            XuLyXoaCTHD();
            lblTongTien2.Text = "";
            XuLyAnHienCTHD(false);
            XuLyXoaHD(-1);
            dgvDanhSachHoaDon.Enabled = true;
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "" || lblTenSanPham.Text == "" || txtSoLuong.Text == "" || txtKhuyenMai.Text == "")
            {
                MessageBox.Show("Bạn chưa điển đủ thông tin chi tiết", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lblMaHoaDon.Text != "")
            {
                bool check = true;
                foreach (DataRow d in ChiTietHoaDon.Tables[0].Rows)
                {
                    if (txtMaSanPham.Text == d["MaSP"].ToString())
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    SanPham = c.layDuLieu("Select soluong from sanpham where masp = '" + txtMaSanPham.Text + "'");
                    int soluong = int.Parse(SanPham.Tables[0].Rows[0]["soluong"].ToString());
                    if (int.Parse(txtSoLuong.Text) <= 0 || int.Parse(txtKhuyenMai.Text) < 0)
                    {
                        MessageBox.Show("Giá trị không phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (soluong < int.Parse(txtSoLuong.Text))
                    {
                        MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string sql;
                    int ThanhTien = 0;

                    ThanhTien = ((int.Parse(txtSoLuong.Text) * int.Parse(lblDonGia.Text)) - int.Parse(txtKhuyenMai.Text));
                    lblTongTien2.Text = DinhDangTien(ThanhTien.ToString());
                    sql = "insert into CT_HoaDon values('" + lblMaHoaDon.Text + "', '" + txtMaSanPham.Text + "', " + txtSoLuong.Text + ", " + lblDonGia.Text + ", " + txtKhuyenMai.Text + ", " + 1 + "," + ThanhTien + ")";
                    c.CapNhatDuLieu(sql);

                    sql = "update SanPham set SoLuong -= " + int.Parse(txtSoLuong.Text) + " where MaSP = '" + txtMaSanPham.Text + "'";
                    c.CapNhatDuLieu(sql);

                    TongThanhTien += ThanhTien;
                    lblTongTien1.Text = DinhDangTien(TongThanhTien.ToString());
                    sql = "update HoaDon set TongTien = " + TongThanhTien + " where MaHD = '" + lblMaHoaDon.Text + "'";
                    c.CapNhatDuLieu(sql);

                    loadDL_CTHD(lblMaHoaDon.Text);
                    XuLyXoaCTHD();
                    txtMaSanPham.Focus();
                }
                else
                {
                    MessageBox.Show("Sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHT_Click(object sender, EventArgs e)
        {
            loadDL_HD();
            loadDL_CTHD(lblMaHoaDon.Text);
            XuLyXoaCTHD();
            lblTongTien2.Text = "";
            XuLyAnHienCTHD(false);
            XuLyChucnang2(true);
            dgvDanhSachHoaDon.Enabled = true;
        }
        void capNhat(int vt, int truoc, int sau, string mahd)
        {
            String sql;
            HienThiTextBox2(vt, ChiTietHoaDon);
            if (truoc < sau)
            {
                TongThanhTien += (truoc - sau);
                sql = "update HoaDon set TongTien += " + (sau - truoc) + " where MaHD = '" + mahd + "'";
                c.CapNhatDuLieu(sql);
            }
            else if (truoc > sau)
            {
                TongThanhTien -= (truoc - sau);
                sql = "update HoaDon set TongTien -= " + (truoc - sau) + " where MaHD = '" + mahd + "'";
                c.CapNhatDuLieu(sql);
            }
            lblTongTien1.Text = DinhDangTien(TongThanhTien.ToString());
        }

        private void dgvChiTietHoaDon_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;

            if (int.Parse(ds.Tables[0].Rows[vt]["SoLuong"].ToString()) < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds.Tables[0].Rows[vt]["SoLuong"] = ChiTietHoaDon.Tables[0].Rows[vt]["SoLuong"];
                return;
            }

            if (int.Parse(ds.Tables[0].Rows[vt]["ChietKhau"].ToString()) < 0)
            {
                MessageBox.Show("ChietKhau không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds.Tables[0].Rows[vt]["ChietKhau"] = ChiTietHoaDon.Tables[0].Rows[vt]["ChietKhau"];
                return;
            }

            int dongia = int.Parse(ds.Tables[0].Rows[vt]["DonGia"].ToString());
            int slht = int.Parse(ds.Tables[0].Rows[vt]["SoLuong"].ToString()) - sl;
            int tt = (dongia * int.Parse(ds.Tables[0].Rows[vt]["SoLuong"].ToString()) - int.Parse(ds.Tables[0].Rows[vt]["ChietKhau"].ToString()));
            SanPham = c.layDuLieu("Select soluong from sanpham where masp = '" + txtMaSanPham.Text + "'");
            int soluong = int.Parse(SanPham.Tables[0].Rows[0]["soluong"].ToString()) - slht;

            if (soluong >= 0)
            {
                string sql = "update CT_HoaDon set SoLuong = " + decimal.Parse(ds.Tables[0].Rows[vt]["SoLuong"].ToString()) + ", ChietKhau = " + decimal.Parse(ds.Tables[0].Rows[vt]["ChietKhau"].ToString()) + ", ThanhTien = " + tt + " where MaHD = '" + lblMaHoaDon.Text + "' AND MaSP = '" + ds.Tables[0].Rows[vt]["MaSP"].ToString() + "'";
                luuDL(sql, "Sửa");

                sql = "update SanPham set SoLuong = " + soluong + " where MaSP = '" + ds.Tables[0].Rows[vt]["MaSP"].ToString() + "'";
                c.CapNhatDuLieu(sql);

                capNhat(vt, int.Parse(ChiTietHoaDon.Tables[0].Rows[vt]["ThanhTien"].ToString()), tt, lblMaHoaDon.Text.ToString());

                loadDL_CTHD(lblMaHoaDon.Text);
                HienThiTextBox2(vt, ChiTietHoaDon);
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ds.Tables[0].Rows[vt]["SoLuong"] = ChiTietHoaDon.Tables[0].Rows[vt]["SoLuong"];
            }
        }

        private void dgvChiTietHoaDon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int vt = e.RowIndex;
            HienThiTextBox2(vt, ChiTietHoaDon);
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.Parse(txtSoLuong.Text) <= 0)
                {
                    MessageBox.Show("Giá trị không phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SanPham = c.layDuLieu("Select soluong from sanpham where masp = '" + txtMaSanPham.Text + "'");
                int soluong = int.Parse(SanPham.Tables[0].Rows[0]["soluong"].ToString());
                if (soluong >= int.Parse(txtSoLuong.Text))
                {
                    txtKhuyenMai.Focus();
                }
                else
                {
                    MessageBox.Show("Số lượng sản phẩm không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtKhuyenMai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.Parse(txtKhuyenMai.Text) < 0)
                {
                    MessageBox.Show("Giá trị không phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnThemSanPham.Select();
            }
        }

        private void radDaHuy_CheckedChanged(object sender, EventArgs e)
        {
            trangthai = 0;
            loadDL_HD();
            loadDL_CTHD("");
            btnHuy_Click(sender, e);
            btnXoa.Text = "K Hoạt";
        }

        private void radMoi_CheckedChanged(object sender, EventArgs e)
        {
            trangthai = 1;
            loadDL_HD();
            loadDL_CTHD("");
            btnHuy_Click(sender, e);
            btnXoa.Text = "Xóa";
        }

        private void radDangGiao_CheckedChanged(object sender, EventArgs e)
        {
            trangthai = 2;
            loadDL_HD();
            loadDL_CTHD("");
            btnHuy_Click(sender, e);
            btnXoa.Text = "Xóa";
        }

        private void radDaGiao_CheckedChanged(object sender, EventArgs e)
        {
            trangthai = 3;
            loadDL_HD();
            loadDL_CTHD("");
            btnHuy_Click(sender, e);
            btnXoa.Text = "Xóa";
        }

        private void cmbTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cboSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboSearch.SelectedIndex == 0)
            {
                sql = "H.MaHD like '%" + txtSearch.Text + "%'";
            }
            else if (cboSearch.SelectedIndex == 1)
            {
                sql = "K.Phone like '%" + txtSearch.Text + "%'";
            }
            else
            {
                sql = "TenKH like N'%" + txtSearch.Text + "%'";
            }
            loadDL_HD(sql);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboSearch.SelectedIndex == 1)
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

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void dtpNgayLapHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}