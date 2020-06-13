create database QuanLyKhoHang
use QuanLyKhoHang
GO
create table NhaCungCap
(
	id nvarchar(50) primary key,
	ten nvarchar(200),
	phone nvarchar(20),
	email nvarchar(50),
	diaChi nvarchar(200)
)
go
create table DonVi
(
	id int identity(1,1) primary key,
	ten nvarchar(50)
)
go 
create table MatHang
(
	id nvarchar(50) primary key,
	ten nvarchar(50),
	idDonVi int
)
go 
create table NhanVien
(
	id nvarchar(50) primary key,
	ten nvarchar(200),
	phone nvarchar(20),
	email nvarchar(50),
	diaChi nvarchar(200)
)
go 
create table TaiKhoan
(
	id int identity(1,1) primary key,
	taiKhoan nvarchar(50),
	matKhau nvarchar(50),
	idNhanVien nvarchar(50),
	quyen nvarchar(50)
)
go 
create table KhachHang
(
	id int identity(1,1) primary key,
	ma nvarchar(50),
	ten nvarchar(200),
	phone nvarchar(20),
	email nvarchar(50),
	diaChi nvarchar(200)
)
go 
create table PhieuNhap
(
	id int identity(1,1) primary key,
	ngay datetime,
	idNhaCungCap nvarchar(50),
	idNhanVien nvarchar(50)
)
go 
create table ChiTietPhieuNhap
(
	id int identity(1,1) primary key,
	idMatHang nvarchar(50),
	idPhieuNhap int,
	soLuong int,
	giaNhap int,
	giaXuat int,
	trangThai int
)
go 
create table PhieuXuat
(
	id int identity(1,1) primary key,
	ngay datetime,
	idKhachHang int,
	idNhanVien nvarchar(50)
)
go 
create table ChiTietPhieuXuat
(
	id int identity(1,1) primary key,
	idPhieuXuat int,
	idMatHang nvarchar(50),
	idChiTietPhieuNhap int,
	soLuong int
)
go
--Thêm các ràng buộc cho các bảng
--MatHang
alter table MatHang
add constraint MatHang_DonVi_FK
foreign key (idDonVi) references DonVi(id)
--Tài Khoản
go
alter table TaiKhoan
add constraint TaiKhoan_NhanVien_FK
foreign key (idNhanVien) references NhanVien(id)
--PhieuNhap
alter table PhieuNhap
add constraint PhieuNhap_NhaCungCap_FK
foreign key (idNhaCungCap) references NhaCungCap(id)
go
alter table PhieuNhap
add constraint PhieuNhap_NhanVien_FK
foreign key (idNhanVien) references NhanVien(id)
go
--Chi tiết phiếu nhập
alter table ChiTietPhieuNhap
add constraint ChiTietPhieuNhap_PhieuNhap_FK
foreign key (idPhieuNhap) references PhieuNhap(id)
go
alter table ChiTietPhieuNhap
add constraint ChiTietPhieuNhap_MatHang_FK
foreign key (idMatHang) references MatHang(id)
go
--Phiếu xuất 
alter table PhieuXuat
add constraint PhieuXuat_KhachHang_FK
foreign key (idKhachHang) references KhachHang(id)
go
alter table PhieuXuat
add constraint PhieuXuat_NhanVien_FK
foreign key (idNhanVien) references NhanVien(id)
--Chi tiết phiếu xuất
go
alter table ChiTietPhieuXuat
add constraint ChiTietPhieuXuat_PhieuXuat_FK
foreign key (idPhieuXuat) references PhieuXuat(id)
go
alter table ChiTietPhieuXuat
add constraint ChiTietPhieuXuat_MatHang_FK
foreign key (idMatHang) references MatHang(id)
go
alter table ChiTietPhieuXuat
add constraint ChiTietPhieuXuat_ChiTietPhieuNhap_FK
foreign key (idChiTietPhieuNhap) references ChiTietPhieuNhap(id)

select *from(select MatHang.id,MatHang.ten,MatHang.idDonVi,DonVi.ten as tenDV from MatHang,DonVi where MatHang.idDonVi=DonVi.id) as MatHang_DonVi where  MatHang_DonVi.id like N'%1%' or MatHang_DonVi.ten like N'%1%'
select *from MatHang where idDonVi like N'%1%' or id like N'%3%'
--update MatHang set id=N'xm03' where id=N'xm02'
--insert into MatHang(id,ten,idDonVi) values(N'xm02',N'Xi măng cam nhông',N'3')
select *from PhieuNhap,ChiTietPhieuNhap,MatHang where ChiTietPhieuNhap.idPhieuNhap = PhieuNhap.id and ChiTietPhieuNhap.idMatHang=MatHang.id
--insert into KhachHang(ma,ten,phone,email,diaChi) values(null,N'Côn',null,null,null)
--insert into PhieuNhap(ngay,idNhaCungCap,idNhanVien) values(getdate(),null,null)
select top(1) id from PhieuNhap where ngay is null and idNhaCungCap =N'a' and idNhanVien = N'b'
select id,ma,ten,phone,email,diaChi from KhachHang where ma is not null and ma != N''
select *from ChiTietPhieuNhap where trangThai >= 500
select idMatHang,giaXuat,sum(trangThai) as tonKho from ChiTietPhieuNhap where idMatHang=N'xm03' and giaXuat= N'13000' group by giaXuat,idMatHang having sum(trangThai) >0
