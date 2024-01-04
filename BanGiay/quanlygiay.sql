create database QLBanGiay
use QLBanGiay

Create Table TAIKHOAN (
	mataikhoan int IDENTITY(1,1) PRIMARY KEY,
	tendangnhap nvarchar(30) not null,
	matkhau varchar(100) not null,
	loaitaikhoan nvarchar(50) not null,
	sdt int null,
)

Create Table LOAIDT(
    maloaidt int IDENTITY(1,1) PRIMARY KEY,
	loaidactrung nvarchar(30) not null,     
)
Create Table THUONGHIEU(
	mathuonghieu int IDENTITY(1,1) PRIMARY KEY,
	tenthuonghieu nvarchar(30) not null,     
)
Create Table LOAIGIAY(
	maloaigiay int IDENTITY(1,1) PRIMARY KEY,
	tenloaigiay nvarchar(30) not null,     
)

Create Table DONDAT (
	madondat int IDENTITY(1,1) PRIMARY KEY,
	--user1: khách hàng đặt hàng
	mataikhoan int FOREIGN KEY
				REFERENCES TAIKHOAN (mataikhoan),
	-- user2:nhân viên tạo đơn đặt 
	
	trangthaitt nvarchar(50) not null,
	thoigian datetime  null default(GETDATE()) ,
	
	
	
	CONSTRAINT dondat_unique UNIQUE(mataikhoan,thoigian)
)


Create Table PHIEUNHAPKHO (
	maphieunhapkho int IDENTITY(1,1) PRIMARY KEY,
	--user: nhân viên lập phiếu
	mataikhoan int FOREIGN KEY
				REFERENCES TAIKHOAN (mataikhoan),
	
	trangthaitt nvarchar(50) not null,
	thoigian datetime  null default(GETDATE()) ,
	tongtien float null,
	mota nvarchar(255) null,
	CONSTRAINT phieunhap_unique UNIQUE(mataikhoan,thoigian)
)
Create Table SANPHAM(
		masanpham int IDENTITY(1,1) PRIMARY KEY,
		tensanpham nvarchar(50) not null,
		
		mota nvarchar(255) null,
		gia int ,
		mathuonghieu int FOREIGN KEY
				REFERENCES THUONGHIEU (mathuonghieu),
	    maloaigiay int FOREIGN KEY
				REFERENCES LOAIGIAY (maloaigiay),
)
create table DACTRUNG(
	madactrung int IDENTITY(1,1) PRIMARY KEY,
	maloaidt int FOREIGN KEY
				REFERENCES LoaiDT (maloaidt),
	thutu  int not null,
	donvi nvarchar(50)  null,
	ten nvarchar(50) not null,
	mota nvarchar(255)  null,
	CONSTRAINT dtrung_unique UNIQUE(maloaidt,thutu)
)


create table CHITIETPNK(
	machitietpnk int IDENTITY(1,1) PRIMARY KEY,
	masanpham int FOREIGN KEY
				REFERENCES SANPHAM (masanpham),
	maphieunhap int FOREIGN KEY
				REFERENCES PHIEUNHAPKHO (maphieunhapkho),
	soluong int  not null,
	gianhap float,
	tongtien float null,
	lohang nvarchar(255)  null,
	ghichu nvarchar(255)  null,
	CONSTRAINT cttiet_pnk_unique UNIQUE(masanpham,maphieunhap)
)


create table CHITIETDD(
	machitietDD int IDENTITY(1,1) PRIMARY KEY,
	masanpham int FOREIGN KEY
				REFERENCES SANPHAM (masanpham),
	madondat int FOREIGN KEY
				REFERENCES DONDAT (madondat),
	soluong int   null,
	tongtien float null,
	CONSTRAINT ctiet_ddh_unique UNIQUE(masanpham,madondat)
)

create table DACTRUNG_SANPHAM(
	madtsp int IDENTITY(1,1) PRIMARY KEY,
	masanpham int FOREIGN KEY
				REFERENCES Sanpham (masanpham),
	madactrung int FOREIGN KEY
				REFERENCES Dactrung (madactrung),
	mota nvarchar(255)  null,
	CONSTRAINT dtrung_spham_unique UNIQUE(masanpham,madactrung)
)
Create table CHITIETSP(
	machitietsp int IDENTITY(1,1) PRIMARY KEY,
	masanpham int FOREIGN KEY
				REFERENCES Sanpham (masanpham),
	chitietthu nvarchar(50) not null,
    tinhtrang nvarchar(255)  null,
	sodinhdanh nvarchar(255)  null,
	machitietDD int,
	machitietpnk int ,

	CONSTRAINT chitietsp_unique UNIQUE(masanpham,chitietthu)
)

---tài khoản
insert into TAIKHOAN values ( 'phamphuong',123,'quantri',046784578)
insert into TAIKHOAN values ( 'danghue',123,'khachhang',038756348)
insert into TAIKHOAN values ( 'hoang',123,'nhanvien',076345634)
insert into TAIKHOAN values ( 'hai',123,'nhacungcap',076345634)
select * from TAIKHOAN
---loại đặc trưng 
insert into LOAIDT values ('chat lieu')
insert into LOAIDT values ('kich co  ')
insert into LOAIDT values ('mau sac')
 
select * from LOAIDT
--thương hiệu
insert into THUONGHIEU values ('Nike')
insert into THUONGHIEU values ('Converse')
insert into THUONGHIEU values ('Vans')
insert into THUONGHIEU values ('Adidas')
insert into THUONGHIEU values ('MLB')
select *from THUONGHIEU

---loại giày 

insert into LOAIGIAY values ('giay the thao')
insert into LOAIGIAY values ('giay thoi trang')
insert into LOAIGIAY values ('giay tennis')
insert into LOAIGIAY values ('giay dia hinh')
select * from LOAIGIAY
insert into SanPham values ('giay adisads','don gian','600','4','2')
insert into SanPham values ('giay Converse','yeuthich','600','4','2')
insert into SanPham values ('giay MLB','nhe nhang','600','4','2')
insert into SANPHAM values ('giay MLB','tim kiem nhieu','600','4','2')
select*from SanPham
---  đơn đặt 
select*from dondat
insert into DONDAT values ('1','chua thanh toan','1/12/2023')
insert into DONDAT values ('2','chua thanh toan','11/12/2023')
insert into DONDAT values ('2',' thanh toan','10/12/2023')
insert into DONDAT values ('2','thanh toan','12/12/2023')
select*from CHITIETDD

insert into CHITIETDD values ('1','1',1,600)
insert into CHITIETDD values ('2','4',1,600)
insert into CHITIETDD values ('3','7',1,600)

