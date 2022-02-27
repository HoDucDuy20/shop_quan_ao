
namespace _393_405_cdth19e
{
    partial class frmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham));
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.MaSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuyThaoTac = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRSize = new System.Windows.Forms.Button();
            this.btnRColor = new System.Windows.Forms.Button();
            this.btnRLsp = new System.Windows.Forms.Button();
            this.btnRNcc = new System.Windows.Forms.Button();
            this.cboLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.btnThemLoaiSanPham = new System.Windows.Forms.Button();
            this.btnThemMau = new System.Windows.Forms.Button();
            this.btnThemKichThuoc = new System.Windows.Forms.Button();
            this.btnThemNhaCungCap = new System.Windows.Forms.Button();
            this.lblKichThuoc = new System.Windows.Forms.Label();
            this.lblMauSac = new System.Windows.Forms.Label();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.lblLoaiSp = new System.Windows.Forms.Label();
            this.lblNhaCC = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenHinh = new System.Windows.Forms.TextBox();
            this.cmbTenNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cmbKichThuoc = new System.Windows.Forms.ComboBox();
            this.cmbMauSac = new System.Windows.Forms.ComboBox();
            this.flpHinhAnh = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSp,
            this.TenSp,
            this.SoLuong,
            this.GiaBan,
            this.MaNcc,
            this.TrangThai,
            this.MaLoaiSP,
            this.Size,
            this.Color,
            this.HinhAnh});
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Location = new System.Drawing.Point(4, 23);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 56;
            this.dgvSanPham.Size = new System.Drawing.Size(1315, 268);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // MaSp
            // 
            this.MaSp.DataPropertyName = "MaSp";
            this.MaSp.HeaderText = "Ma San Pham";
            this.MaSp.MinimumWidth = 7;
            this.MaSp.Name = "MaSp";
            this.MaSp.ReadOnly = true;
            this.MaSp.Width = 135;
            // 
            // TenSp
            // 
            this.TenSp.DataPropertyName = "TenSp";
            this.TenSp.HeaderText = "Ten San Pham";
            this.TenSp.MinimumWidth = 7;
            this.TenSp.Name = "TenSp";
            this.TenSp.ReadOnly = true;
            this.TenSp.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "So Luong";
            this.SoLuong.MinimumWidth = 7;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 135;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Don Gia";
            this.GiaBan.MinimumWidth = 7;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.Width = 135;
            // 
            // MaNcc
            // 
            this.MaNcc.DataPropertyName = "MaNcc";
            this.MaNcc.HeaderText = "Ma Nha Cung Cap";
            this.MaNcc.MinimumWidth = 7;
            this.MaNcc.Name = "MaNcc";
            this.MaNcc.ReadOnly = true;
            this.MaNcc.Width = 135;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trang Thai";
            this.TrangThai.MinimumWidth = 7;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 135;
            // 
            // MaLoaiSP
            // 
            this.MaLoaiSP.DataPropertyName = "MaLoaiSP";
            this.MaLoaiSP.HeaderText = "Ma Loai San Pham";
            this.MaLoaiSP.MinimumWidth = 7;
            this.MaLoaiSP.Name = "MaLoaiSP";
            this.MaLoaiSP.ReadOnly = true;
            this.MaLoaiSP.Width = 135;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Kich Thuoc";
            this.Size.MinimumWidth = 7;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 135;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Mau Sac";
            this.Color.MinimumWidth = 7;
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 135;
            // 
            // HinhAnh
            // 
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.HeaderText = "Hinh Anh";
            this.HinhAnh.MinimumWidth = 6;
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.ReadOnly = true;
            this.HinhAnh.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 462);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1323, 295);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSua.Location = new System.Drawing.Point(336, 23);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(149, 46);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLuu.Location = new System.Drawing.Point(493, 23);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(149, 46);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThoat.Location = new System.Drawing.Point(968, 23);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(149, 46);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnXoa.Location = new System.Drawing.Point(179, 23);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(149, 46);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThem.Location = new System.Drawing.Point(20, 23);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(149, 46);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHuyThaoTac);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(95, 371);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1139, 85);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btnHuyThaoTac
            // 
            this.btnHuyThaoTac.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnHuyThaoTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThaoTac.Location = new System.Drawing.Point(652, 23);
            this.btnHuyThaoTac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuyThaoTac.Name = "btnHuyThaoTac";
            this.btnHuyThaoTac.Size = new System.Drawing.Size(149, 46);
            this.btnHuyThaoTac.TabIndex = 58;
            this.btnHuyThaoTac.Text = "Hủy thao tác";
            this.btnHuyThaoTac.UseVisualStyleBackColor = false;
            this.btnHuyThaoTac.Click += new System.EventHandler(this.btnHuyThaoTac_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(811, 23);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 46);
            this.btnRefresh.TabIndex = 57;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Location = new System.Drawing.Point(549, 34);
            this.cmbTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(205, 33);
            this.cmbTrangThai.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(369, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Trạng thái";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 224);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Số lượng";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(157, 159);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(204, 30);
            this.txtDonGia.TabIndex = 20;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanPham.Location = new System.Drawing.Point(157, 97);
            this.txtTenSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(204, 30);
            this.txtTenSanPham.TabIndex = 19;
            this.txtTenSanPham.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenSanPham_KeyPress);
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSanPham.Location = new System.Drawing.Point(157, 34);
            this.txtMaSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(204, 30);
            this.txtMaSanPham.TabIndex = 18;
            this.txtMaSanPham.TextChanged += new System.EventHandler(this.txtMaSanPham_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đơn giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tên nhà cung cấp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(369, 162);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "Tên loại sản phẩm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(368, 224);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 25);
            this.label9.TabIndex = 34;
            this.label9.Text = "Màu sắc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(369, 286);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 25);
            this.label10.TabIndex = 36;
            this.label10.Text = "Kích thước";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(157, 222);
            this.nudSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(204, 30);
            this.nudSoLuong.TabIndex = 38;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRSize);
            this.groupBox3.Controls.Add(this.btnRColor);
            this.groupBox3.Controls.Add(this.btnRLsp);
            this.groupBox3.Controls.Add(this.btnRNcc);
            this.groupBox3.Controls.Add(this.cboLoaiSanPham);
            this.groupBox3.Controls.Add(this.btnThemLoaiSanPham);
            this.groupBox3.Controls.Add(this.btnThemMau);
            this.groupBox3.Controls.Add(this.btnThemKichThuoc);
            this.groupBox3.Controls.Add(this.btnThemNhaCungCap);
            this.groupBox3.Controls.Add(this.lblKichThuoc);
            this.groupBox3.Controls.Add(this.lblMauSac);
            this.groupBox3.Controls.Add(this.btnChonHinh);
            this.groupBox3.Controls.Add(this.lblLoaiSp);
            this.groupBox3.Controls.Add(this.lblNhaCC);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtTenHinh);
            this.groupBox3.Controls.Add(this.cmbTenNhaCungCap);
            this.groupBox3.Controls.Add(this.cmbKichThuoc);
            this.groupBox3.Controls.Add(this.cmbMauSac);
            this.groupBox3.Controls.Add(this.nudSoLuong);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.flpHinhAnh);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbTrangThai);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDonGia);
            this.groupBox3.Controls.Add(this.txtTenSanPham);
            this.groupBox3.Controls.Add(this.txtMaSanPham);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(16, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1323, 351);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sản phẩm";
            // 
            // btnRSize
            // 
            this.btnRSize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRSize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRSize.BackgroundImage")));
            this.btnRSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRSize.Location = new System.Drawing.Point(940, 282);
            this.btnRSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRSize.Name = "btnRSize";
            this.btnRSize.Size = new System.Drawing.Size(40, 33);
            this.btnRSize.TabIndex = 59;
            this.btnRSize.UseVisualStyleBackColor = false;
            this.btnRSize.Click += new System.EventHandler(this.btnRSize_Click);
            // 
            // btnRColor
            // 
            this.btnRColor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRColor.BackgroundImage")));
            this.btnRColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRColor.Location = new System.Drawing.Point(940, 220);
            this.btnRColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRColor.Name = "btnRColor";
            this.btnRColor.Size = new System.Drawing.Size(40, 33);
            this.btnRColor.TabIndex = 58;
            this.btnRColor.UseVisualStyleBackColor = false;
            this.btnRColor.Click += new System.EventHandler(this.btnRColor_Click);
            // 
            // btnRLsp
            // 
            this.btnRLsp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRLsp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRLsp.BackgroundImage")));
            this.btnRLsp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRLsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRLsp.Location = new System.Drawing.Point(940, 159);
            this.btnRLsp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRLsp.Name = "btnRLsp";
            this.btnRLsp.Size = new System.Drawing.Size(40, 33);
            this.btnRLsp.TabIndex = 57;
            this.btnRLsp.UseVisualStyleBackColor = false;
            this.btnRLsp.Click += new System.EventHandler(this.btnRLsp_Click);
            // 
            // btnRNcc
            // 
            this.btnRNcc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRNcc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRNcc.BackgroundImage")));
            this.btnRNcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRNcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRNcc.Location = new System.Drawing.Point(940, 96);
            this.btnRNcc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRNcc.Name = "btnRNcc";
            this.btnRNcc.Size = new System.Drawing.Size(40, 33);
            this.btnRNcc.TabIndex = 56;
            this.btnRNcc.UseVisualStyleBackColor = false;
            this.btnRNcc.Click += new System.EventHandler(this.btnRNcc_Click);
            // 
            // cboLoaiSanPham
            // 
            this.cboLoaiSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiSanPham.FormattingEnabled = true;
            this.cboLoaiSanPham.Location = new System.Drawing.Point(549, 159);
            this.cboLoaiSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLoaiSanPham.Name = "cboLoaiSanPham";
            this.cboLoaiSanPham.Size = new System.Drawing.Size(205, 33);
            this.cboLoaiSanPham.TabIndex = 55;
            // 
            // btnThemLoaiSanPham
            // 
            this.btnThemLoaiSanPham.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThemLoaiSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLoaiSanPham.Location = new System.Drawing.Point(892, 158);
            this.btnThemLoaiSanPham.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemLoaiSanPham.Name = "btnThemLoaiSanPham";
            this.btnThemLoaiSanPham.Size = new System.Drawing.Size(40, 33);
            this.btnThemLoaiSanPham.TabIndex = 54;
            this.btnThemLoaiSanPham.Text = "+";
            this.btnThemLoaiSanPham.UseVisualStyleBackColor = false;
            this.btnThemLoaiSanPham.Click += new System.EventHandler(this.btnThemLoaiSanPham_Click);
            // 
            // btnThemMau
            // 
            this.btnThemMau.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThemMau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMau.Location = new System.Drawing.Point(892, 220);
            this.btnThemMau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemMau.Name = "btnThemMau";
            this.btnThemMau.Size = new System.Drawing.Size(40, 33);
            this.btnThemMau.TabIndex = 53;
            this.btnThemMau.Text = "+";
            this.btnThemMau.UseVisualStyleBackColor = false;
            this.btnThemMau.Click += new System.EventHandler(this.btnThemMau_Click);
            // 
            // btnThemKichThuoc
            // 
            this.btnThemKichThuoc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThemKichThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKichThuoc.Location = new System.Drawing.Point(892, 282);
            this.btnThemKichThuoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemKichThuoc.Name = "btnThemKichThuoc";
            this.btnThemKichThuoc.Size = new System.Drawing.Size(40, 33);
            this.btnThemKichThuoc.TabIndex = 52;
            this.btnThemKichThuoc.Text = "+";
            this.btnThemKichThuoc.UseVisualStyleBackColor = false;
            this.btnThemKichThuoc.Click += new System.EventHandler(this.btnThemKichThuoc_Click);
            // 
            // btnThemNhaCungCap
            // 
            this.btnThemNhaCungCap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThemNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhaCungCap.Location = new System.Drawing.Point(892, 96);
            this.btnThemNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemNhaCungCap.Name = "btnThemNhaCungCap";
            this.btnThemNhaCungCap.Size = new System.Drawing.Size(40, 33);
            this.btnThemNhaCungCap.TabIndex = 51;
            this.btnThemNhaCungCap.Text = "+";
            this.btnThemNhaCungCap.UseVisualStyleBackColor = false;
            this.btnThemNhaCungCap.Click += new System.EventHandler(this.btnThemNhaCungCap_Click);
            // 
            // lblKichThuoc
            // 
            this.lblKichThuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKichThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKichThuoc.Location = new System.Drawing.Point(760, 283);
            this.lblKichThuoc.Name = "lblKichThuoc";
            this.lblKichThuoc.Size = new System.Drawing.Size(125, 33);
            this.lblKichThuoc.TabIndex = 50;
            this.lblKichThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMauSac
            // 
            this.lblMauSac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMauSac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMauSac.Location = new System.Drawing.Point(760, 220);
            this.lblMauSac.Name = "lblMauSac";
            this.lblMauSac.Size = new System.Drawing.Size(125, 33);
            this.lblMauSac.TabIndex = 49;
            this.lblMauSac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnChonHinh.Location = new System.Drawing.Point(1095, 297);
            this.btnChonHinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(113, 41);
            this.btnChonHinh.TabIndex = 5;
            this.btnChonHinh.Text = "Chọn hình";
            this.btnChonHinh.UseVisualStyleBackColor = false;
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click_1);
            // 
            // lblLoaiSp
            // 
            this.lblLoaiSp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoaiSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiSp.Location = new System.Drawing.Point(760, 159);
            this.lblLoaiSp.Name = "lblLoaiSp";
            this.lblLoaiSp.Size = new System.Drawing.Size(125, 33);
            this.lblLoaiSp.TabIndex = 48;
            this.lblLoaiSp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNhaCC
            // 
            this.lblNhaCC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNhaCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCC.Location = new System.Drawing.Point(760, 97);
            this.lblNhaCC.Name = "lblNhaCC";
            this.lblNhaCC.Size = new System.Drawing.Size(125, 33);
            this.lblNhaCC.TabIndex = 47;
            this.lblNhaCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 286);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 46;
            this.label6.Text = "Hình đã chọn";
            // 
            // txtTenHinh
            // 
            this.txtTenHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenHinh.Location = new System.Drawing.Point(157, 283);
            this.txtTenHinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenHinh.Name = "txtTenHinh";
            this.txtTenHinh.Size = new System.Drawing.Size(204, 30);
            this.txtTenHinh.TabIndex = 45;
            // 
            // cmbTenNhaCungCap
            // 
            this.cmbTenNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenNhaCungCap.FormattingEnabled = true;
            this.cmbTenNhaCungCap.Location = new System.Drawing.Point(549, 97);
            this.cmbTenNhaCungCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTenNhaCungCap.Name = "cmbTenNhaCungCap";
            this.cmbTenNhaCungCap.Size = new System.Drawing.Size(205, 33);
            this.cmbTenNhaCungCap.TabIndex = 43;
            // 
            // cmbKichThuoc
            // 
            this.cmbKichThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKichThuoc.FormattingEnabled = true;
            this.cmbKichThuoc.Location = new System.Drawing.Point(547, 283);
            this.cmbKichThuoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbKichThuoc.Name = "cmbKichThuoc";
            this.cmbKichThuoc.Size = new System.Drawing.Size(207, 33);
            this.cmbKichThuoc.TabIndex = 42;
            // 
            // cmbMauSac
            // 
            this.cmbMauSac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMauSac.FormattingEnabled = true;
            this.cmbMauSac.Location = new System.Drawing.Point(547, 220);
            this.cmbMauSac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMauSac.Name = "cmbMauSac";
            this.cmbMauSac.Size = new System.Drawing.Size(207, 33);
            this.cmbMauSac.TabIndex = 41;
            // 
            // flpHinhAnh
            // 
            this.flpHinhAnh.AutoScroll = true;
            this.flpHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpHinhAnh.Location = new System.Drawing.Point(997, 38);
            this.flpHinhAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpHinhAnh.Name = "flpHinhAnh";
            this.flpHinhAnh.Size = new System.Drawing.Size(291, 253);
            this.flpHinhAnh.TabIndex = 40;
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1357, 766);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Sản Phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSanPham_FormClosing);
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbKichThuoc;
        private System.Windows.Forms.ComboBox cmbMauSac;
        private System.Windows.Forms.ComboBox cmbTenNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhAnh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenHinh;
        private System.Windows.Forms.FlowLayoutPanel flpHinhAnh;
        private System.Windows.Forms.Button btnChonHinh;
        private System.Windows.Forms.Label lblKichThuoc;
        private System.Windows.Forms.Label lblMauSac;
        private System.Windows.Forms.Label lblLoaiSp;
        private System.Windows.Forms.Label lblNhaCC;
        private System.Windows.Forms.Button btnHuyThaoTac;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnThemLoaiSanPham;
        private System.Windows.Forms.Button btnThemMau;
        private System.Windows.Forms.Button btnThemKichThuoc;
        private System.Windows.Forms.Button btnThemNhaCungCap;
        private System.Windows.Forms.ComboBox cboLoaiSanPham;
        private System.Windows.Forms.Button btnRSize;
        private System.Windows.Forms.Button btnRColor;
        private System.Windows.Forms.Button btnRLsp;
        private System.Windows.Forms.Button btnRNcc;
    }
}