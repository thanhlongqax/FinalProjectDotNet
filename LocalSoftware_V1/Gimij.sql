use master;
drop database if exists Gimji
go

create database Gimji;
go

use Gimji;
go


-- Tạo bảng Khach_hang
CREATE TABLE Khach_hang (
   id_khach_hang varchar(8) PRIMARY KEY,
   ten_dang_nhap VARCHAR(100) not null,
   mat_khau VARCHAR(20) not null,
   ten_khach_hang NVARCHAR(200) ,
   ngay_sinh DATE,
   gioi_tinh nvarchar(4),
   so_dien_thoai NVARCHAR(20),
   dia_chi NVARCHAR(200),
   email NVARCHAR(100),
   diem_thuong INT default 0,
   loai_tai_khoan NVARCHAR(100) not null default N'Đồng' check (loai_tai_khoan in (N'Đồng' , N'Bạc' , N'Vàng' , N'Kim Cương'))
);

go
INSERT INTO Khach_hang (id_khach_hang, ten_dang_nhap, mat_khau, ten_khach_hang, ngay_sinh, gioi_tinh, so_dien_thoai, dia_chi, email, diem_thuong, loai_tai_khoan)
VALUES
('UID00002', 'customer1', 'password1', N'Nguyễn Văn Khánh', '1990-01-15', N'Nam', '1234567891', N'123 Main St, Hanoi', 'customer1@email.com', 100, N'Đồng'),
('UID00003', 'customer2', 'password2', N'Nguyễn Thị Hằng', '1985-03-20', N'Nữ', '1234567892', N'456 Oak St, Ho Chi Minh City', 'customer2@email.com', 150, N'Bạc'),
('UID00004', 'customer3', 'password3', N'Trần Đức Anh', '1992-05-10', N'Nam', '1234567893', N'789 Pine St, Da Nang', 'customer3@email.com', 200, N'Vàng'),
('UID00005', 'customer4', 'password4', N'Phạm Thị Mai', '1980-08-05', N'Nữ', '1234567894', N'101 Elm St, Hanoi', 'customer4@email.com', 250, N'Kim Cương'),
('UID00006', 'customer5', 'password5', N'Hoàng Đình Trường', '1988-12-30', N'Nam', '1234567895', N'222 Maple St, Ho Chi Minh City', 'customer5@email.com', 300, N'Đồng'),
('UID00007', 'customer6', 'password6', N'Nguyễn Thị Lan', '1983-02-25', N'Nữ', '1234567896', N'333 Cedar St, Da Nang', 'customer6@email.com', 350, N'Bạc'),
('UID00008', 'customer7', 'password7', N'Lê Văn Đức', '1995-07-18', N'Nam', '1234567897', N'444 Walnut St, Hanoi', 'customer7@email.com', 400, N'Vàng'),
('UID00009', 'customer8', 'password8', N'Nguyễn Thị Hoa', '1987-11-12', N'Nữ', '1234567898', N'555 Birch St, Ho Chi Minh City', 'customer8@email.com', 450, N'Kim Cương'),
('UID00010', 'customer9', 'password9', N'Vũ Minh Tuấn', '1991-04-22', N'Nam', '1234567899', N'666 Oak St, Da Nang', 'customer9@email.com', 500, N'Đồng'),
('UID00011', 'customer10', 'password10', N'Phạm Thị Hương', '1989-09-08', N'Nữ', '1234567890', N'777 Elm St, Hanoi', 'customer10@email.com', 550, N'Bạc');
go
CREATE PROCEDURE UpdateCustomerById
    @id_khach_hang varchar(8),
	@ten_dang_nhap VARCHAR(100),
    @mat_khau VARCHAR(20),
    @ten_khach_hang NVARCHAR(200),
    @ngay_sinh DATE,
    @gioi_tinh nvarchar(4),
    @so_dien_thoai NVARCHAR(20),
    @dia_chi NVARCHAR(200),
    @email NVARCHAR(100),
    @diem_thuong INT
AS
BEGIN
    UPDATE Khach_hang
    SET
        ten_khach_hang = @ten_khach_hang,
        ngay_sinh = @ngay_sinh,
        gioi_tinh = @gioi_tinh,
        so_dien_thoai = @so_dien_thoai,
        dia_chi = @dia_chi,
        email = @email,
        diem_thuong = @diem_thuong
    WHERE
        id_khach_hang = @id_khach_hang;
END

go
-- procedure de tao nguoi dung
create procedure InsertCusTomerLoginData
    @userName varchar(500),
    @userPassword varchar(500)
as
begin
    declare @newUserID char(8)
	declare @maxUserID varchar(500)
	set @newUserID = 'UID00001'
	select @maxUserID = cast(max(cast(substring(id_khach_hang, 4, 8) as int)) + 1 as varchar) from Khach_hang where substring(id_khach_hang, 1, 3) = 'UID'
	if (cast(@maxUserID as int) > cast(substring(@newUserID, 4, 8) as int))
	begin
		while (len(@maxUserID) < 5)
		begin
			set @maxUserID = '0' + @maxUserID
		end
		set @newUserID = 'UID' + @maxUserID 
	end
	    insert into Khach_hang(id_khach_hang , ten_dang_nhap , mat_khau) values (@newUserID, @userName, @userPassword )
end
go

CREATE PROCEDURE InsertCustomer
    @ten_dang_nhap VARCHAR(30),
    @mat_khau VARCHAR(20),
    @ten_khach_hang NVARCHAR(200),
    @ngay_sinh DATE,
    @gioi_tinh nvarchar(4),
    @so_dien_thoai NVARCHAR(20),
    @dia_chi NVARCHAR(200),
    @email NVARCHAR(100),
    @diem_thuong INT
AS
BEGIN
declare @newUserID char(8)
	declare @maxUserID varchar(500)
	set @newUserID = 'UID00001'
	select @maxUserID = cast(max(cast(substring(id_khach_hang, 4, 8) as int)) + 1 as varchar) from Khach_hang where substring(id_khach_hang, 1, 3) = 'UID'
	if (cast(@maxUserID as int) > cast(substring(@newUserID, 4, 8) as int))
	begin
		while (len(@maxUserID) < 5)
		begin
			set @maxUserID = '0' + @maxUserID
		end
		set @newUserID = 'UID' + @maxUserID 
	end
    INSERT INTO Khach_hang (id_khach_hang, ten_dang_nhap, mat_khau, ten_khach_hang, ngay_sinh, gioi_tinh, so_dien_thoai, dia_chi, email, diem_thuong)
    VALUES (@newUserID, @ten_dang_nhap, @mat_khau, @ten_khach_hang, @ngay_sinh, @gioi_tinh, @so_dien_thoai, @dia_chi, @email, @diem_thuong);
END

go

-- Tạo bảng Nhan_vien
CREATE TABLE Nhan_vien (
	id_nhan_vien varchar(8) primary key,
   ten_dang_nhap VARCHAR(200) not null,
   mat_khau VARCHAR(20) not null,
   ten_nhan_vien NVARCHAR(500) not null ,
   ngay_sinh varchar(10) not null,
   gioi_tinh NVARCHAR(4),
   dia_chi NVARCHAR(200) not null,
   so_dien_thoai NVARCHAR(20) not null,
   email NVARCHAR(100),
   ngay_bat_dau varchar(10),
   muc_luong FLOAT,
   viTri Nvarchar (50) 
);
go

-- Tạo procedure cập nhật thông tin nhân viên dựa vào id_nhan_vien
CREATE PROCEDURE UpdateStaffById
    @id_nhan_vien varchar(8),
    @ten_dang_nhap VARCHAR(200),
    @mat_khau VARCHAR(20),
    @ten_nhan_vien NVARCHAR(500),
    @ngay_sinh varchar(10),
    @gioi_tinh NVARCHAR(4),
    @dia_chi NVARCHAR(200),
    @so_dien_thoai NVARCHAR(20),
    @email NVARCHAR(100),
    @ngay_bat_dau varchar(10),
    @muc_luong FLOAT,
    @viTri Nvarchar(50)
AS
BEGIN
    -- Kiểm tra xem nhân viên có tồn tại dựa vào id_nhan_vien
    IF EXISTS (SELECT 1 FROM Nhan_vien WHERE id_nhan_vien = @id_nhan_vien)
    BEGIN
        -- Nếu nhân viên tồn tại, thực hiện cập nhật thông tin
        UPDATE Nhan_vien
        SET
            ten_dang_nhap = @ten_dang_nhap,
            mat_khau = @mat_khau,
            ten_nhan_vien = @ten_nhan_vien,
            ngay_sinh = @ngay_sinh,
            gioi_tinh = @gioi_tinh,
            dia_chi = @dia_chi,
            so_dien_thoai = @so_dien_thoai,
            email = @email,
            ngay_bat_dau = @ngay_bat_dau,
            muc_luong = @muc_luong,
            viTri = @viTri
        WHERE id_nhan_vien = @id_nhan_vien;
    END
END
go
--procedure tao nhan vien
create procedure InsertStaffLoginData
    @userName varchar(500),
    @userPassword varchar(500),
    @fullName nvarchar(500),
	@contactAddress nvarchar(500),
	@phoneNumber varchar(10),
    @emailAddress varchar(500),
	@DateOfBirth varchar(10),
	@position nvarchar(50),
	@gender nvarchar(10)
as
begin
    declare @newUserID char(8)
	declare @maxUserID varchar(500)
	set @newUserID = 'SID00001'
	select @maxUserID = cast(max(cast(substring(id_nhan_vien, 4, 8) as int)) + 1 as varchar) from Nhan_vien where substring(id_nhan_vien, 1, 3) = 'SID'
	if (cast(@maxUserID as int) > cast(substring(@newUserID, 4, 8) as int))
	begin
		while (len(@maxUserID) < 5)
		begin
			set @maxUserID = '0' + @maxUserID
		end
		set @newUserID = 'SID' + @maxUserID 
	end
	    insert into Nhan_vien(id_nhan_vien,ten_dang_nhap ,  mat_khau , ten_nhan_vien ,dia_chi,so_dien_thoai,email , ngay_sinh ,viTri ,gioi_tinh) values 
			(@newUserID,@userName , @userPassword, @fullName, @contactAddress , @phoneNumber , @emailAddress, @DateOfBirth ,@position ,@gender);
end
go

-- Insert the first Vietnamese employee
EXEC InsertStaffLoginData
    @fullName = N'Nguyễn Văn An',
    @emailAddress = 'nguyenvanan@example.com',
    @contactAddress = N'123 Đường A, Quận 1, TP.HCM',
    @phoneNumber = '0901234567',
    @DateOfBirth = '1990-01-15',
    @userName = 'nguyenvanan',
    @userPassword = 'password123',
    @position = N'Nhân viên',
	@gender = N'Nam';
go
-- Insert the second Vietnamese employee
EXEC InsertStaffLoginData
    @fullName = N'Trần Thị Bình',
    @emailAddress = 'tranthibinh@example.com',
    @contactAddress = N'456 Đường B, Quận 2, TP.HCM',
    @phoneNumber = '0909876543',
    @DateOfBirth = '1985-07-22',
    @userName = 'tranthibinh',
    @userPassword = 'securepassword',
    @position = N'Đầu Bếp',
	@gender = N'Nữ';
go
-- Insert the third Vietnamese employee
EXEC InsertStaffLoginData
    @fullName = N'Võ Hoàng Quân',
    @emailAddress = 'thanhlongqax@gmail.com',
    @contactAddress = N'789 Đường C, Quận 3, TP.HCM',
    @phoneNumber = '0912345678',
    @DateOfBirth = '1995-03-10',
    @userName = 'quandeptrai',
    @userPassword = 'mypassword123',
    @position = N'Nhân Viên',
	@gender = N'Nam';
go
CREATE TABLE Admin (
   id_admin varchar(8) PRIMARY KEY,
   ten_dang_nhap VARCHAR(30) not null,
   mat_khau VARCHAR(20) not null,
   ten_admin NVARCHAR(500) not null,
   ngay_sinh DATE null,
   email NVARCHAR(200) not null,
   so_dien_thoai NVARCHAR(20) not null


);
go
--procedure tao admin
create procedure InsertAdminLoginData
    @userName varchar(500),
    @userPassword varchar(500),
    @fullName nvarchar(500),
	@phoneNumber varchar(10),
	@emailAddress varchar(500),
	@DateOfBirth varchar(10)
as
begin
    declare @newAdminID char(8)
	declare @maxAdminID varchar(500)
	set @newAdminID = 'AID00001'
	select @maxAdminID = cast(max(cast(substring(id_admin, 4, 8) as int)) + 1 as varchar) from Admin where substring(id_admin, 1, 3) = 'AID'
	if (cast(@maxAdminID as int) > cast(substring(@newAdminID, 4, 8) as int))
	begin
		while (len(@maxAdminID) < 5)
		begin
			set @maxAdminID = '0' + @maxAdminID
		end
		set @newAdminID = 'AID' + @maxAdminID 
	end
		    insert into Admin(id_admin,ten_dang_nhap, mat_khau ,ten_admin ,ngay_sinh ,email ,  so_dien_thoai) values (@newAdminID , @userName, @userPassword , @fullName  ,@DateOfBirth ,@emailAddress , @phoneNumber)
end

go 
-- Execute the stored procedure to insert an admin
EXEC InsertAdminLoginData
    @userName = 'admin',
    @userPassword = 'admin_password',
    @fullName = 'Võ Hoàng Quân',
    @phoneNumber = '123456789',
    @emailAddress = 'admin@example.com',
    @DateOfBirth = '2000-01-01';  -- Adjust the date format

go
CREATE TABLE Danh_muc_mon_an (
   id_danhMuc INT PRIMARY KEY ,
   loai_mon NVARCHAR(30) not null
);

go
create procedure InsertCatergory
	@idCategory int ,
    @FoodType Nvarchar(500)
as
begin
	insert into Danh_muc_mon_an(id_danhMuc,loai_mon) values (@idCategory,@FoodType)
end
go
Insert into Danh_muc_mon_an(id_danhMuc,loai_mon) values
	(0,N'All'),
	(1,N'TOKBOKKI'),
	(2,N'THỊT NƯỚNG'),
	(3,N'SALAD'),
	(4,N'KIMBAK'),
	(5,N'CƠM')

go
CREATE TABLE Mon_an(
   id_mon_an INT PRIMARY KEY , 
   ten_mon_an NVARCHAR(200),
   don_gia FLOAT,
   hinh_anh NVARCHAR(200),
   tinh_trang NVARCHAR(200),
   id_danh_muc INT constraint fk_id_danh_muc Foreign key (id_danh_muc) references Danh_muc_mon_an(id_danhMuc)
)

go
CREATE PROCEDURE InsertDish
    @Name NVARCHAR(200),
    @donGia FLOAT,
    @picture NVARCHAR(200),
    @Type NVARCHAR(200),
    @id_danhMuc INT
AS
BEGIN
    INSERT INTO Mon_an( ten_mon_an, don_gia, hinh_anh, tinh_trang, id_danh_muc)
    VALUES ( @Name, @donGia, @picture, @Type, @id_danhMuc);
END;


go

INSERT INTO Mon_an(id_mon_an, ten_mon_an, don_gia, hinh_anh, tinh_trang, id_danh_muc)
VALUES
    (1, N'Tobokki Chả Cá Sốt', 50.000, N'Resources/AnhMonAn/Tokbokki/tokbokki_chả_cá_sốt_HQ-removebg-preview.png', N'Còn Hàng', 1),
    (2, N'Tobokki Gà Sốt HQ', 100.000, N'Resources/AnhMonAn/Tokbokki/tokbokki_gà_sốt_HQ-removebg-preview.png', N'Còn Hàng', 1),
    (3, N'Tokbokki Sốt Phô Mai', 150.000, N'Resources/AnhMonAn/Tokbokki/Tokbokki_sotPhoMai.png', N'Còn Hàng', 1),
    (4, N'Ba Chỉ Heo Nướng', 150.000, N'Resources/AnhMonAn/ThitNuong/BaChiHeoNuong.png', N'Còn Hàng', 2),
    (5, N'Ba Chỉ Heo Nướng Mật Ong', 150.000, N'Resources/AnhMonAn/ThitNuong/BachiHeoNuongMatOng.png', N'Còn Hàng', 2),
    (6, N'Salad Gà Gốt Mayonnaise', 200.000, N'Resources/AnhMonAn/Salad/salad_gà_sốt_mayonnaise-removebg-preview.png', N'Còn Hàng', 3),
    (7, N'Salad Gimji', 175.000, N'Resources/AnhMonAn/Salad/salad_gimji-removebg-preview.png', N'Còn Hàng', 3),
    (8, N'KimBak Truyền Thống', 230.000, N'Resources/AnhMonAn/KimBak/kimbab_truyền_thống-removebg-preview.png', N'Còn Hàng', 4),
    (9, N'KimBak Chiên Xù', 230.000, N'Resources/AnhMonAn/KimBak/KimbakChienXu.png', N'Còn Hàng', 4),
    (10, N'KimBak Thịt Heo Chiên', 250.000, N'Resources/AnhMonAn/KimBak/KimBakThitHeoChien.png', N'Còn Hàng', 4),
    (11, N'KimBak Trướng Cuộn', 270.000, N'Resources/AnhMonAn/KimBak/Trứng_cuộn-removebg-preview.png', N'Còn Hàng', 4),
    (12, N'Cơm Trộn Hàn Quốc', 200.000, N'Resources/AnhMonAn/Com/ComtronHanQuoc.png', N'Còn Hàng', 5);


go

CREATE TABLE Ban (
   id_ban INT PRIMARY KEY Identity,
   ten_ban NVARCHAR(20) ,
   tang int,
);
go
INSERT INTO Ban (ten_ban, tang)
VALUES
    (N'Bàn 1', 1),
    (N'Bàn 2', 1),
    (N'Bàn 3', 1),
    (N'Bàn 4', 1),
    (N'Bàn 5', 2),
    (N'Bàn 6', 2),
    (N'Bàn 7', 2)
go
Create table Ban_NV(
	id_ban INT ,
	ten_khach_hang nvarchar(200) , 
	sdt_khach_hang nvarchar(200) ,
	ghi_chu VARCHAR(200),
	ngay_dat_ban Date,
	primary key (id_ban),
	CONSTRAINT fk_ban FOREIGN KEY (id_ban) REFERENCES Ban(id_ban),
);
go
CREATE PROCEDURE InsertTable_NV (
    @id_ban INT,
    @ten_khach_hang NVARCHAR(200),
    @sdt_khach_hang NVARCHAR(200),
    @ghi_chu VARCHAR(200),
    @ngay_dat_ban DATE
)
AS
BEGIN
    -- Insert a new record into Ban_NV table
    INSERT INTO Ban_NV (id_ban, ten_khach_hang, sdt_khach_hang, ghi_chu, ngay_dat_ban)
    VALUES (@id_ban, @ten_khach_hang, @sdt_khach_hang, @ghi_chu, @ngay_dat_ban);
END;
go
-- Tạo bảng Phuong_thuc_thanh_toan
CREATE TABLE Phuong_thuc_thanh_toan (
   id_phuong_thuc INT PRIMARY KEY,
   ten_phuong_thuc NVARCHAR(45) not null,
);
go
Insert into Phuong_thuc_thanh_toan(id_phuong_thuc , ten_phuong_thuc )values 
	(1,N'Tiền Mặt'),
	(2,N'Credit Card'),
	(3,N'QR Code')
go


-- Tạo bảng Chi_tiet_hoa_don
CREATE TABLE Chi_tiet_hoa_don (
   id_chi_tiet INT PRIMARY KEY identity,
   id_mon_an INT CONSTRAINT FK_Chi_tiet_hoa_don_Danh_muc_mon_an FOREIGN KEY (id_mon_an) REFERENCES Mon_an(id_mon_an),
   so_luong INT NOT NULL,
   don_gia FLOAT NOT NULL,
   id_phuong_thuc INT CONSTRAINT FK_Chi_tiet_hoa_don_Phuong_thuc_thanh_toan FOREIGN KEY (id_phuong_thuc) REFERENCES Phuong_thuc_thanh_toan(id_phuong_thuc),
   id_nhan_vien varchar(8) ,
   trang_thai varchar(200),
   ten_khach_hang varchar(200),
   ngay_lap DATETIME not null
);
go
CREATE PROCEDURE insertChiTietHoaDon
    @id_mon_an INT,
    @so_luong INT,
    @don_gia FLOAT,
    @id_phuong_thuc INT,
    @id_nhan_vien VARCHAR(8),  
    @trang_thai VARCHAR(200),
	@ten_khach_hang varchar(200),
    @ngay_lap DATETIME 
AS
BEGIN
    INSERT INTO Chi_tiet_hoa_don (
        id_mon_an,
        so_luong,
        don_gia,
        id_phuong_thuc,
		ten_khach_hang,
        id_nhan_vien,  -- Bổ sung nếu cần
        trang_thai,  -- Bổ sung nếu cần
        ngay_lap  -- Bổ sung nếu cần
    )
    VALUES (
        @id_mon_an,
        @so_luong,
        @don_gia,
        @id_phuong_thuc,
		@id_nhan_vien,
        @id_nhan_vien,  -- Bổ sung nếu cần
        @trang_thai,  -- Bổ sung nếu cần
        @ngay_lap  -- Bổ sung nếu cần
    );
END;

go
-- Tạo bảng Ca_lam
CREATE TABLE Ca_lam (
   id_ca VARCHAR(45) PRIMARY KEY ,
   note VARCHAR(500),
   ca_lam VARCHAR(45),
   ngay_lam DATE NOT NULL,
   nhan_vien_id varchar(8) CONSTRAINT FK_Ca_lam_Nhan_vien FOREIGN KEY (nhan_vien_id) REFERENCES Nhan_vien(id_nhan_vien)
);

go
CREATE OR ALTER TRIGGER CheckStaffLimit
ON Ca_lam
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT ca_lam, ngay_lam, COUNT(*) AS staff_count
        FROM Ca_lam
        GROUP BY ca_lam, ngay_lam
        HAVING COUNT(*) >3
    )
    BEGIN
        RAISERROR (50002, 16, 1)
        ROLLBACK 
    END
	IF EXISTS (
        SELECT ca_lam, ngay_lam, COUNT(nhan_vien_id) AS staff_count
        FROM Ca_lam
        GROUP BY ca_lam, ngay_lam, nhan_vien_id
        HAVING COUNT(nhan_vien_id) > 1
    )
	BEGIN
        RAISERROR (50001, 16, 1)
        ROLLBACK TRANSACTION
    END
END

EXEC sp_addmessage 50001, 16, 'Duplicate staff members for a shift and date are not allowed.'
EXEC sp_addmessage 50002, 16, 'The number of staff members for a shift cannot exceed 3 per day.'


--drop trigger LimitStaffPerShiftPerDay
go
CREATE PROCEDURE Insert_Ca_lam (
	@p_note VARCHAR(500),
    @p_ca_lam VARCHAR(45),
    @p_ngay_lam DATE,
    @p_nhan_vien_id VARCHAR(8)
)
AS
BEGIN
    DECLARE @NextID INT;
    DECLARE @NewID VARCHAR(45);

    -- Find the next ID
    SELECT @NextID = ISNULL(MAX(RIGHT(id_ca, LEN(id_ca) - 2)), 0) + 1
    FROM Ca_lam;

    -- Generate the new ID in the format "Ca0001"
    SET @NewID = 'CA' + RIGHT('0000' + CAST(@NextID AS VARCHAR(4)), 4);

    -- Insert the record into Ca_lam
    INSERT INTO Ca_lam (id_ca,note, ca_lam, ngay_lam, nhan_vien_id)
    VALUES (@NewID,@p_note,@p_ca_lam, @p_ngay_lam, @p_nhan_vien_id);
END;

go
EXEC Insert_Ca_lam  'Nothing','Shift 1','2023-12-05', 'SID00003';
EXEC Insert_Ca_lam  'Please' ,'Shift 2','2023-12-05', 'SID00002';
EXEC Insert_Ca_lam 'Note 1', 'Shift 1', '2023-12-05', 'SID00001';
EXEC Insert_Ca_lam 'Nothing', 'Shift 1', '2023-12-05', 'SID00002';
EXEC Insert_Ca_lam 'Please', 'Shift 2', '2023-12-06', 'SID00002';

-- Tạo bảng Giao_hang
CREATE TABLE Giao_hang (
   id_giao_hang INT PRIMARY KEY,
   ngay_dat_hang DATETIME not null default current_timestamp,
   trang_thai INT,
   dia_chi_giao NVARCHAR(200) not null,
   ghi_chu NVARCHAR(500),
   tong_tien FLOAT not null,
   khach_hang_id varchar(8)
);
go
-- Add a foreign key to khach_hang_id in the Giao_hang table
ALTER TABLE Giao_hang ADD CONSTRAINT FK_Giao_hang_Khach_hang FOREIGN KEY (khach_hang_id) REFERENCES Khach_hang(id_khach_hang);


-- Tạo bảng Chi_tiet_giao_hang
CREATE TABLE Chi_tiet_giao_hang (
   id_chi_tiet INT PRIMARY KEY,
   giao_hang_id INT,
   mon_an_id INT,
   so_luong INT not null,
   don_vi_van_chuyen NVARCHAR(100)
);
go
-- Add a foreign key to giao_hang_id in the Chi_tiet_giao_hang table
ALTER TABLE Chi_tiet_giao_hang ADD CONSTRAINT FK_Chi_tiet_giao_hang_Giao_hang FOREIGN KEY (giao_hang_id) REFERENCES Giao_hang(id_giao_hang);

-- Add a foreign key to mon_an_id in the Chi_tiet_giao_hang table
ALTER TABLE Chi_tiet_giao_hang ADD CONSTRAINT FK_Chi_tiet_giao_hang_Danh_muc_mon_an FOREIGN KEY (mon_an_id) REFERENCES Mon_an(id_mon_an);

go
CREATE TABLE Uu_Dai(
   id_UuDai varchar(100) PRIMARY KEY,
   ten_UuDai NVARCHAR(200),
   statu NVARCHAR(20),
   mo_ta NVARCHAR(200),
   dieu_kien NVARCHAR(200),
   timeBatDau DATE default current_timestamp,
   timeKetThuc DATE default current_timestamp
);
go

CREATE PROCEDURE InsertVoucher
    @nameVoucher varchar(500),
	@status varchar(20),
    @description nvarchar(500),
	@conditions nvarchar(500),
	@dateStart Date,
	@dateEnd Date
as
begin
    declare @newIdVoucher char(7)
	declare @maxIdVoucher varchar(500)
	set @newIdVoucher = 'VC00001'
	select @maxIdVoucher = cast(max(cast(substring(id_UuDai, 3, 7) as int)) + 1 as varchar) from Uu_Dai where substring(id_UuDai, 1, 2) = 'VC'
	if (cast(@maxIdVoucher as int) > cast(substring(@newIdVoucher, 3,7) as int))
	begin
		while (len(@maxIdVoucher) < 5)
		begin
			set @maxIdVoucher = '0' + @maxIdVoucher
		end
		set @newIdVoucher = 'VC' + @maxIdVoucher 
	end
	    insert into Uu_Dai(id_UuDai,ten_UuDai,statu,mo_ta,dieu_kien,timeBatDau,timeKetThuc) values 
			(@newIdVoucher,@nameVoucher,@status,@description,@conditions,@dateStart,@dateEnd);
end

go

CREATE PROCEDURE UpdateVoucherById
	@idVoucher varchar(500),
    @nameVoucher varchar(500),
	@status varchar(20),
    @description nvarchar(500),
	@conditions nvarchar(500),
	@dateStart Date,
	@dateEnd Date
as
begin 
	update Uu_Dai
	Set 
		id_UuDai = @idVoucher,
		ten_UuDai = @nameVoucher,
		statu = @status,
		mo_ta = @description,
		dieu_kien = @conditions,
		timeBatDau = @dateStart,
		timeKetThuc = @dateEnd
	Where 
		id_UuDai = @idVoucher;
end
drop procedure UpdateVoucherById
go

EXEC InsertVoucher 
    @nameVoucher = 'Discount50',
	@status ='Active',
    @description = '50% off on selected items',
    @conditions = 'Valid for purchases above $100',
    @dateStart = '2023-12-01',
    @dateEnd = '2024-01-01';

CREATE TABLE CartItem (
	IdTaiKhoan varchar(8),
    Id INT PRIMARY KEY identity,
	id_mon_an INT constraint fk_monAN foreign key (id_mon_an) references Mon_an(id_mon_an),
    Name NVARCHAR(255),
    Price float,
	hinh_anh NVARCHAR(200),
    Quantity INT
);
go
CREATE PROCEDURE GetCartItemsByIdTaiKhoan
    @IdTaiKhoan varchar(8)
AS
BEGIN
    SELECT 
        c.Id,
		c.id_mon_an,
        c.Name,
        c.Price,
		c.hinh_anh,
        c.Quantity
    FROM 
        CartItem c
    WHERE 
        c.IdTaiKhoan = @IdTaiKhoan;
END;
go
CREATE PROCEDURE InsertCartItem
    @IdTaiKhoan varchar(8),
	@IdMonAn int,
    @Name NVARCHAR(255),
    @Price FLOAT,
    @hinh_anh NVARCHAR(200),
    @Quantity INT
AS
BEGIN
    INSERT INTO CartItem (IdTaiKhoan,id_mon_an, Name, Price, hinh_anh, Quantity)
    VALUES (@IdTaiKhoan,@IdMonAn, @Name, @Price, @hinh_anh, @Quantity);
END;
go
CREATE PROCEDURE DeleteCartItemById
    @Id INT
AS
BEGIN
    DELETE FROM CartItem
    WHERE Id = @Id;
END;

go


CREATE TABLE Doanh_Thu(
	ID INT PRIMARY KEY IDENTITY(1,1),
    total_Customers INT,
    revenue money,
    dishes_Ordered INT,
    dayTime Date not null
);

INSERT INTO Doanh_Thu(total_Customers, revenue, dishes_Ordered, dayTime)
VALUES
    (10, 150050, 5, '2023-12-01'),
    (15, 200075, 8, '2023-02-05'),
    (8, 100225, 3, '2023-03-10'),
    (12, 180300, 6, '2023-04-15'),
    (20, 300580, 10, '2023-05-20'),
    (18, 250160, 7, '2023-06-25'),
    (22, 350025, 9, '2023-07-30'),
    (11, 160630, 4, '2023-08-05'),
    (14, 190750, 6, '2023-09-10'),
    (17, 230875, 8, '2023-10-15'),
    (9, 12090, 4, '2023-11-20'),
    (13, 170190, 7, '2023-12-25'),
    (10, 160250, 6, '2022-01-01'),
    (16, 220375, 9, '2022-02-05'),
    (7, 90425, 2, '2023-03-10'),
    (11, 150000, 5, '2022-04-15'),
    (18, 280080, 11, '2021-05-20'),
    (15, 260060, 8, '2022-06-25'),
    (19, 310525, 10, '2023-07-30'),
    (14, 180430, 6, '2023-08-05'),
    (11, 150250, 7, '2022-09-10'),
    (20, 240275, 9, '2022-10-15'),
    (12, 130840, 5, '2022-11-20'),
    (18, 200790, 8, '2022-12-25'),
    (11, 140850, 6, '2021-01-01'),
    (17, 260075, 9, '2021-02-05'),
    (6, 70925, 3, '2021-03-10'),
    (13, 170100, 7, '2021-04-15'),
    (16, 280280, 10, '2021-05-20'),
    (14, 240460, 8, '2022-06-25'),
    (18, 310525, 11, '2022-07-30');

--drop procedure GetRevenueDataByPeriod
go
CREATE OR ALTER PROCEDURE GetRevenueDataByPeriod
@Period NVARCHAR(50)  -- Input parameter to specify the month or quarter ('Month', 'Quarter')
AS
BEGIN
    IF @Period ='Month'
    BEGIN
        -- Select data for a specific month
        SELECT 
			YEAR(dayTime) as [Year],
            SUM(CASE WHEN MONTH(dayTime) = 1 THEN revenue ELSE 0 END) AS January,
            SUM(CASE WHEN MONTH(dayTime) = 2 THEN revenue ELSE 0 END) AS February,
            SUM(CASE WHEN MONTH(dayTime) = 3 THEN revenue ELSE 0 END) AS March,
            SUM(CASE WHEN MONTH(dayTime) = 4 THEN revenue ELSE 0 END) AS April,
            SUM(CASE WHEN MONTH(dayTime) = 5 THEN revenue ELSE 0 END) AS May,
            SUM(CASE WHEN MONTH(dayTime) = 6 THEN revenue ELSE 0 END) AS June,
            SUM(CASE WHEN MONTH(dayTime) = 7 THEN revenue ELSE 0 END) AS July,
            SUM(CASE WHEN MONTH(dayTime) = 8 THEN revenue ELSE 0 END) AS August,
            SUM(CASE WHEN MONTH(dayTime) = 9 THEN revenue ELSE 0 END) AS September,
            SUM(CASE WHEN MONTH(dayTime) = 10 THEN revenue ELSE 0 END) AS October,
            SUM(CASE WHEN MONTH(dayTime) = 11 THEN revenue ELSE 0 END) AS November,
            SUM(CASE WHEN MONTH(dayTime) = 12 THEN revenue ELSE 0 END) AS December
        FROM Doanh_Thu
		GROUP BY YEAR(dayTime)
		ORDER BY [Year];
    END
    ELSE IF @Period = 'Quarter'
    BEGIN
        -- Select data for a specific quarter
        SELECT 
			YEAR(dayTime) AS [Year],
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 1 THEN revenue ELSE 0 END) AS Q1,
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 2 THEN revenue ELSE 0 END) AS Q2,
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 3 THEN revenue ELSE 0 END) AS Q3,
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 4 THEN revenue ELSE 0 END) AS Q4
        FROM Doanh_Thu
		GROUP BY YEAR(dayTime)
		ORDER BY [Year];
    END
    ELSE
    BEGIN
        -- Invalid input for @Period
        PRINT 'Invalid period specified.'
    END
END

exec GetRevenueDataByPeriod @Period='Quarter'


Select sum(total_Customers) as TotalCustomer, sum(revenue) as Revenue ,sum(dishes_Ordered) as Dish
FROM Doanh_Thu
WHERE 
    MONTH(dayTime) = MONTH(GETDATE()) AND YEAR(dayTime) = YEAR(GETDATE())

go
CREATE OR ALTER PROCEDURE GetRevenueCurrent
    @Period NVARCHAR(50)  -- Input parameter to specify the month or quarter ('Month', 'Quarter')
AS
BEGIN
    IF @Period = 'Month'
    BEGIN
        -- Select data for the current month
        SELECT 
            SUM(CASE WHEN MONTH(dayTime) = 01 THEN revenue ELSE 0 END) AS January,
            SUM(CASE WHEN MONTH(dayTime) = 02 THEN revenue ELSE 0 END) AS February,
            SUM(CASE WHEN MONTH(dayTime) = 03 THEN revenue ELSE 0 END) AS March,
            SUM(CASE WHEN MONTH(dayTime) = 04 THEN revenue ELSE 0 END) AS April,
            SUM(CASE WHEN MONTH(dayTime) = 05 THEN revenue ELSE 0 END) AS May,
            SUM(CASE WHEN MONTH(dayTime) = 06 THEN revenue ELSE 0 END) AS June,
            SUM(CASE WHEN MONTH(dayTime) = 07 THEN revenue ELSE 0 END) AS July,
            SUM(CASE WHEN MONTH(dayTime) = 08 THEN revenue ELSE 0 END) AS August,
            SUM(CASE WHEN MONTH(dayTime) = 09 THEN revenue ELSE 0 END) AS September,
            SUM(CASE WHEN MONTH(dayTime) = 10 THEN revenue ELSE 0 END) AS October,
            SUM(CASE WHEN MONTH(dayTime) = 11 THEN revenue ELSE 0 END) AS November,
            SUM(CASE WHEN MONTH(dayTime) = 12 THEN revenue ELSE 0 END) AS December
        FROM Doanh_Thu
        WHERE  YEAR(dayTime) = YEAR(GETDATE())
		GROUP BY  YEAR(dayTime);
    END
    ELSE IF @Period = 'Quarter'
    BEGIN
        -- Select data for the current year's quarters
        SELECT 
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 1 THEN revenue ELSE 0 END) AS Q1,
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 2 THEN revenue ELSE 0 END) AS Q2,
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 3 THEN revenue ELSE 0 END) AS Q3,
            SUM(CASE WHEN DATEPART(QUARTER, dayTime) = 4 THEN revenue ELSE 0 END) AS Q4
        FROM Doanh_Thu
        WHERE YEAR(dayTime) = YEAR(GETDATE())
		GROUP BY  YEAR(dayTime);
    END
    ELSE
    BEGIN
        -- Invalid input for @Period
        PRINT 'Invalid period specified.';
    END
END

Exec GetRevenueCurrent @Period = 'Month'