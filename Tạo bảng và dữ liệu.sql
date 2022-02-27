create table TaiKhoan
(
	TenTK varchar(30),
	MatKhau varchar(30),
	CONSTRAINT PK_TK primary key (TenTK)
)
create table SanPham
(
	MaSp nvarchar(20),
	TenSp nvarchar(100),
	SoLuong int,	
	GiaBan int,
	MaNcc nvarchar(20),
	TrangThai int,
	MaLoaiSP nvarchar(20),
	Size nvarchar(10),
	Color nvarchar(10),
	HinhAnh varchar(300),
	CONSTRAINT PK_MASP primary key (MaSp)
)
create table HoaDon
(
	MaHD nvarchar(20),
	NgayLapHD DateTime,
	MaKh nvarchar(20),
	LoaiHD char(5),
	TongTien int,
	TrangThai int,
	CONSTRAINT PK_MAHD primary key (MaHD)
)
create table CT_HoaDon
(
	MaHD nvarchar(20),
	MaSp	 nvarchar(20),
	SoLuong	int	,
	DonGia	int,	
	ChietKhau int,
	TrangThai int,
	ThanhTien int,
	CONSTRAINT PK_MASP_MAHD primary key (MaSp,MaHD)
)
create table NhaCungCap
(
	MaNCC	nvarchar(20),	
	TenNcc	Nvarchar(100),
	Diachi	Nvarchar(100),	
	Phone	Varchar(30)	,
	TenTK nvarchar(50),
	SoTK nvarchar(50),
	DCMail	Varchar(50),
	TrangThai int,	
	CONSTRAINT PK_MANCC primary key (MaNCC)
)
create table KhachHang
(
	MaKh	nvarChar(20),
	TenKh	Nvarchar(100),
	DiaChi	Nvarchar(100),	
	Phone	Varchar(24),	
	DCMail	varchar(50),
	TrangThai int,	
	CONSTRAINT PK_MAKH primary key (MaKH)
)
create table LoaiSanPham
(
	MaLoaiSP nvarchar(20),
	TenLoaiSP nvarchar(100),
	TrangThai int,
	CONSTRAINT PK_MaLoaiSP primary key (MaLoaiSP),
)
create table KichThuoc
(
	MaKichThuoc nvarchar(20),
	TenKichThuoc nvarchar(100),
	TrangThai int,
	CONSTRAINT PK_MaKichThuoc primary key (MaKichThuoc),
)
create table MauSac
(
	MaMau nvarchar(20),
	TenMau nvarchar(100),
	TrangThai int,
	CONSTRAINT PK_MaMau primary key (MaMau)
)
--
alter table HoaDon
add CONSTRAINT FK_MAKH foreign key(makh) references khachhang(makh)
--
alter table CT_HoaDon
add CONSTRAINT FK_MAHD foreign key(mahd) references hoadon(mahd)
alter table CT_HoaDon
add CONSTRAINT FK_MASP foreign key(masp) references sanpham(masp)
--
alter table sanpham
add CONSTRAINT FK_MANCC foreign key(mancc) references nhacungcap(mancc)
alter table sanpham
add CONSTRAINT FK_MALOAISP foreign key(MaLoaiSP) references LoaiSanPham(MaLoaiSP)

/*---------------------------------------------------------------------------------------------------------------------------*/
insert into KichThuoc
values('KT01',N'S ',1)
insert into KichThuoc
values('KT02',N'M',1)
insert into KichThuoc
values('KT03',N'L',1)
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into MauSac
values('M01',N'Red',1)
insert into MauSac
values('M02',N'Green',1)
insert into MauSac
values('M03',N'Blue',1)
/*Nhập tháng trước ngày sau, Kiểu unicode cần Có N đứng đầu dấu ngoặc*/
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into LoaiSanPham
values('LSP01',N'Áo',1)
insert into LoaiSanPham
values('LSP02',N'Quần',1)
insert into LoaiSanPham
values('LSP03',N'Vớ',1)
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into NhaCungCap
values('NCC01',N'Việt Tiến',N'7 Lê Minh Xuân, P.7, Q. Tân Bình','0283864080',null,null,'viettien@gmail.com',1)
insert into NhaCungCap
values('NCC02',N'An Phước',N'100/11-12 An Dương Vương, P.9, Q.5','02838307337',null,null,'anphuoc@gmail.com',1)
insert into NhaCungCap
values('NCC03',N'Adidas',N'số 102 Nguyễn Hoàng, p Mỹ Đình 2, Nam Từ Liêm, Hà Nội','0966342792',null,null,'adidas@gmail.com',1)
insert into NhaCungCap
values('NCC04',N'Nike',N'M Trì, Từ Liêm, Hà Nội.','0289998921',null,null,'nike@gmail.com',1)
insert into NhaCungCap
values('NCC06',N'Blues',N'359 Lê Văn Sĩ, Phường 13, Quận 3, TP. HCM','0868570768',null,null,'blues@gmail.com',1)
insert into NhaCungCap
values('NCC05',N'Chanel',N'94 Nguyễn Trãi, Q1, TP.HCM','0964743232',null,null,'chanel@gmail.com',1)
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into SanPham
values('SP01',N'Áo sơ mi',10,50000,'NCC01',1,'LSP01','KT01','M01','06.jpg')
insert into SanPham
values('SP02',N'Quần tây',10,85000,'NCC02',1,'LSP02','KT03','M02','05.jpg')
insert into SanPham
values('SP03',N'Vớ cổ cao',10,20000,'NCC03',1,'LSP03','KT02','M01','04.jpg')
insert into SanPham
values('SP04',N'Áo thun',10,99000,'NCC04',1,'LSP01','KT03','M03','03.jpg')
insert into SanPham
values('SP05',N'Áo hoodie',10,299000,'NCC05',1,'LSP01','KT01','M02','02.jpg')
insert into SanPham
values('SP06',N'Quần short',10,250000,'NCC06',1,'LSP02','KT02','M03','01.jpg')
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into KhachHang
values('KH01',N'Nguyễn Văn A',N' 264A-Nguyễn Thị Minh Khai, Phường 6, Quận 3','0283864080','nguyenvana@gmail.com',1)
insert into KhachHang
values('KH02',N'Nguyễn Văn B',N' Số 9-11 Nguyễn Thị Thập, Phường Tân Phú, Quận 7','0287305686', 'nguyenvanb@gmail.com',1)
insert into KhachHang
values('KH03',N'Nguyễn Văn C',N'1A Lê Văn Việt, Phường Hiệp Phú, Quận 9','0275304686','nguyenvancb@gmail.com',1)
insert into KhachHang
values('KH04',N'Nguyễn Văn Liêm',N' 241 Xuân Thủy, Cầu Giấy, Hà Nội','0377399686', 'nguyenvanliem@gmail.com',1)
insert into KhachHang
values('KH05',N'Nguyễn Thị Thu',N'31 Tân Cảng, Phường 25, Bình Thạnh','0937359595','nguyenthithu@gmail.com',1)
insert into KhachHang
values('KH06',N'Nguyễn Trần Công Nam',N'249A Hoàng Văn Thụ, Phường 1, Tân Bình','0987353258','nguyentrancongnam@gmail.com',1)
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into HoaDon
values('HD01','5/23/1997','KH01','X',null, 1)
insert into HoaDon
values('HD02','10/20/1995','KH02','X',null, 1)
insert into HoaDon
values('HD03','8/15/1994','KH03','X',null, 1)
insert into HoaDon
values('HD04','12/25/1997','KH04','X',null, 1)
insert into HoaDon
values('HD05','4/20/1997','KH05','X',null, 1)
insert into HoaDon
values('HD06','7/21/1997','KH06','X',null, 1)
/*---------------------------------------------------------------------------------------------------------------------------*/
insert into CT_HoaDon
values('HD01','SP01',5,50000,0,1,null)
insert into CT_HoaDon
values('HD02','SP02',3,85000,0,1,null)
insert into CT_HoaDon
values('HD03','SP03',7,20000,0,1,null)
insert into CT_HoaDon
values('HD04','SP04',5,99000,0,1,null)
insert into CT_HoaDon
values('HD05','SP05',6,299000,0,1,null)
insert into CT_HoaDon
values('HD06','SP06',3,250000,0,1,null)
/*------------------------*/
insert into TaiKhoan
values('admin','123')
/*---------------------------------------------------------------------------------------------------------------------------*/
update CT_HoaDon
set ThanhTien = (CT_HoaDon.SoLuong*CT_HoaDon.DonGia)
update HoaDon
set TongTien = CT_HoaDon.ThanhTien
from CT_HoaDon
where HoaDon.MaHD = CT_HoaDon.MaHD
