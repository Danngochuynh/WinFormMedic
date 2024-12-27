-- Tạo cơ sở dữ liệu pharmacy
CREATE DATABASE pharmacy;
GO

-- Sử dụng cơ sở dữ liệu pharmacy
USE pharmacy;
GO

-- Tạo bảng customers
CREATE TABLE [dbo].[customers] (
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [FullName] VARCHAR(250) NOT NULL,
    [Gender] VARCHAR(10) NOT NULL,
    [PhoneNumber] BIGINT NOT NULL,
    [BirthDate] VARCHAR(250) NOT NULL,
    [Address] VARCHAR(250) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Chèn dữ liệu vào bảng customers
INSERT INTO [dbo].[customers] ([FullName], [Gender], [PhoneNumber], [BirthDate], [Address])
VALUES 
('Huynh Ngoc Dan', 'Nam', 7776131313, 'Jul 15 2015 11:03AM', 'MoDuc'),
('Uchiha', 'Nam', 0, 'Jun 16 2020 11:03AM', 'MoDuc'),
('Dan', 'Nam', 777541018, 'Jun  2 2020 11:03AM', 'Duc Hoa'),
('Dan', 'Nam', 1, 'Feb  6 2024 11:03AM', 'Duc'),
('Dan1', 'Nam', 777123232, 'Jul 17 2019 11:03AM', 'MoDuc'),
('Dan1', 'Nam', 11, 'Oct 17 2018 11:03AM', 'DucHoa'),
('Dan', 'Nam', 12, 'Feb  7 2024 11:03AM', 'Dv'),
('Dab', 'Nam', 999999999, 'Jan 30 1940 11:03AM', 'DA'),
('Dan', 'Nam', 111, 'Jun  2 2004 11:03AM', 'Da'),
('Dan', 'Nam', 909, 'Jul 12 1950 11:03AM', 'Kaka');

-- Tạo bảng medic
CREATE TABLE [dbo].[medic] (
    [Id] INT IDENTITY(1, 1) NOT NULL,
    [mid] VARCHAR(250) NOT NULL,
    [mname] VARCHAR(250) NOT NULL,
    [mnumber] VARCHAR(250) NOT NULL,
    [mDate] VARCHAR(250) NOT NULL,
    [eDate] VARCHAR(250) NOT NULL,
    [quantity] BIGINT NOT NULL,
    [perUnit] BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Chèn dữ liệu vào bảng medic
INSERT INTO [dbo].[medic] ([mid], [mname], [mnumber], [mDate], [eDate], [quantity], [perUnit])
VALUES 
('T2', 'VitaminB2', '30', '10/12/2024', '10/14/2024', 30, 30000),
('T3', 'VitaminC', '25', '2024-10-12', '2024-10-11', 29, 120),
('T4', 'VitaminD3', '31', '10/12/2024', '12/31/2024', 78, 24),
('T5', 'VitaminE', '9', '2024-10-12', '2024-12-12', 973, 10);
CREATE PROCEDURE sp_GetAllMedicCoGiaTien
AS
BEGIN
    -- Lấy thông tin thuốc cùng tổng tiền của từng loại thuốc
    SELECT 
        Id, 
        mid AS MedicineID,	
        mname AS MedicineName, 
        mnumber AS BatchNumber, 
        mDate AS ManufacturingDate, 
        eDate AS ExpirationDate, 
        quantity AS Quantity, 
        perUnit AS UnitPrice,
        (quantity * perUnit) AS TotalPrice -- Tính tổng tiền cho từng thuốc
    FROM medic;
END;
-- Tạo bảng users
CREATE TABLE [dbo].[users] (
    [Id] INT IDENTITY(1, 1) NOT NULL,
    [userRole] VARCHAR(50) NOT NULL,
    [name] VARCHAR(250) NOT NULL,
    [dob] VARCHAR(250) NOT NULL,
    [mobile] BIGINT NOT NULL,
    [email] VARCHAR(250) NOT NULL,
    [username] VARCHAR(250) NOT NULL,
    [pass] VARCHAR(250) NOT NULL
);

-- Chèn dữ liệu vào bảng users
INSERT INTO [dbo].[users] ([userRole], [name], [dob], [mobile], [email], [username], [pass])
VALUES 
('Admin', 'Dan', 'Monday, March 22, 2004', 777541018, 'dan@gmail.com', 'Admin2', '12345'),
('Admin', 'Yen', 'Thursday, July 15, 2004', 999999999, 'Yen@gmail.com', 'Admin3', 'Pass1'),
('User', 'Dev', 'Monday, September 30, 2024', 7777777777, 'Dev@gmail.com', 'Dev1', '12345'),
('Admin', 'Dan2', 'Tuesday, February 11, 2020', 1312312312, 'dan@gmail.com', 'Dev2', '12345'),
('User', 'Dev', 'Tuesday, September 3, 2024', 99999999, 'dan@gamil.com', 'Dev3', '12345'),
('User', 'Dan', 'Tuesday, February 8, 2000', 777541018, 'Dan@gmail.com', 'Admin4', 'Pass3'),
('User', 'Dab', 'Tuesday, June 20, 2000', 1234567891, 'ab@gmai.com', 'abc', 'Pass1#');

-- Stored Procedure: Thêm, Xóa, Sửa, Tìm kiếm cho bảng customers
CREATE PROCEDURE sp_GetAllCustomers
AS
BEGIN
    SELECT * FROM [dbo].[customers];
END;
CREATE PROCEDURE sp_AddCustomer
    @FullName VARCHAR(250),
    @Gender VARCHAR(10),
    @PhoneNumber BIGINT,
    @BirthDate VARCHAR(250),
    @Address VARCHAR(250)
AS
BEGIN
    INSERT INTO [dbo].[customers] ([FullName], [Gender], [PhoneNumber], [BirthDate], [Address])
    VALUES (@FullName, @Gender, @PhoneNumber, @BirthDate, @Address);
END;

CREATE PROCEDURE sp_DeleteCustomer
    @ID INT
AS
BEGIN
    DELETE FROM [dbo].[customers] WHERE [ID] = @ID;
END;

CREATE PROCEDURE sp_UpdateCustomer
    @ID INT,
    @FullName VARCHAR(250),
    @Gender VARCHAR(10),
    @PhoneNumber BIGINT,
    @BirthDate VARCHAR(250),
    @Address VARCHAR(250)
AS
BEGIN
    UPDATE [dbo].[customers]
    SET [FullName] = @FullName,
        [Gender] = @Gender,
        [PhoneNumber] = @PhoneNumber,
        [BirthDate] = @BirthDate,
        [Address] = @Address
    WHERE [ID] = @ID;
END;

CREATE PROCEDURE sp_SearchCustomer
    @FullName VARCHAR(250)
AS
BEGIN
    SELECT * FROM [dbo].[customers] WHERE [FullName] LIKE '%' + @FullName + '%';
END;

-- Stored Procedure: Thêm, Xóa, Sửa, Tìm kiếm cho bảng medic
CREATE PROCEDURE sp_GetAllMedic
AS
BEGIN
    SELECT * FROM [dbo].[medic];
END;

CREATE PROCEDURE sp_AddMedic
    @mid VARCHAR(250),
    @mname VARCHAR(250),
    @mnumber VARCHAR(250),
    @mDate VARCHAR(250),
    @eDate VARCHAR(250),
    @quantity BIGINT,
    @perUnit BIGINT
AS
BEGIN
    INSERT INTO [dbo].[medic] ([mid], [mname], [mnumber], [mDate], [eDate], [quantity], [perUnit])
    VALUES (@mid, @mname, @mnumber, @mDate, @eDate, @quantity, @perUnit);
END;

CREATE PROCEDURE sp_DeleteMedic
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[medic] WHERE [Id] = @Id;
END;

CREATE PROCEDURE sp_UpdateMedic
    @Id INT,
    @mid VARCHAR(250),
    @mname VARCHAR(250),
    @mnumber VARCHAR(250),
    @mDate VARCHAR(250),
    @eDate VARCHAR(250),
    @quantity BIGINT,
    @perUnit BIGINT
AS
BEGIN
    UPDATE [dbo].[medic]
    SET [mid] = @mid,
        [mname] = @mname,
        [mnumber] = @mnumber,
        [mDate] = @mDate,
        [eDate] = @eDate,
        [quantity] = @quantity,
        [perUnit] = @perUnit
    WHERE [Id] = @Id;
END;

CREATE PROCEDURE sp_SearchMedic
    @mname VARCHAR(250)
AS
BEGIN
    SELECT * FROM [dbo].[medic] WHERE [mname] LIKE '%' + @mname + '%';
END;

-- Stored Procedure: Thêm, Xóa, Sửa, Tìm kiếm cho bảng users
CREATE PROCEDURE sp_GetAllUser
AS
BEGIN
    SELECT * FROM [dbo].[users];
END;
CREATE PROCEDURE sp_AddUsers
    @userRole VARCHAR(50),
    @name VARCHAR(250),
    @dob VARCHAR(250),
    @mobile BIGINT,
    @email VARCHAR(250),
    @username VARCHAR(250),
    @pass VARCHAR(250)
AS
BEGIN
    INSERT INTO [dbo].[users] ([userRole], [name], [dob], [mobile], [email], [username], [pass])
    VALUES (@userRole, @name, @dob, @mobile, @email, @username, @pass);
END;

CREATE PROCEDURE sp_DeleteUser
    @Id INT
AS
BEGIN
    DELETE FROM [dbo].[users] WHERE [Id] = @Id;
END;

CREATE PROCEDURE sp_UpdateUser
    @Id INT,
    @userRole VARCHAR(50),
    @name VARCHAR(250),
    @dob VARCHAR(250),
    @mobile BIGINT,
    @email VARCHAR(250),
    @username VARCHAR(250),
    @pass VARCHAR(250)
AS
BEGIN
    UPDATE [dbo].[users]
    SET [userRole] = @userRole,
        [name] = @name,
        [dob] = @dob,
        [mobile] = @mobile,
        [email] = @email,
        [username] = @username,
        [pass] = @pass
    WHERE [Id] = @Id;
END;

CREATE PROCEDURE sp_SearchUser
    @name VARCHAR(250)
AS
BEGIN
    SELECT * FROM [dbo].[users] WHERE [name] LIKE '%' + @name + '%';
END;

---Exec các dữ liệu 
--Thêm
EXEC sp_AddCustomer 
    @FullName = 'Nguyen Van A', 
    @Gender = 'Nam', 
    @PhoneNumber = 9876543210, 
    @BirthDate = '1990-01-01', 
    @Address = 'Hanoi';
EXEC sp_AddMedic 
    @mid = 'T6', 
    @mname = 'VitaminK', 
    @mnumber = '40', 
    @mDate = '2024-11-30', 
    @eDate = '2025-11-30', 
    @quantity = 50, 
    @perUnit = 5000;
EXEC sp_AddUsers
    @userRole = 'User', 
    @name = 'Nguyen Thi B', 
    @dob = '1995-05-15', 
    @mobile = 9876543210, 
    @email = 'nguyenb@gmail.com', 
    @username = 'userB', 
    @pass = 'passB';
--tìm kiếm 
EXEC sp_SearchCustomer @FullName = 'Nguyen Van A';
EXEC sp_SearchMedic @mname = 'VitaminC';
EXEC sp_SearchUser @name = 'Nguyen Thi B';


--sửa
EXEC sp_UpdateCustomer 
    @ID = 1, 
    @FullName = 'Nguyen Van A Updated', 
    @Gender = 'Nam', 
    @PhoneNumber = 9876543210, 
    @BirthDate = '1990-01-01', 
    @Address = 'Hanoi Updated';
EXEC sp_UpdateMedic 
    @Id = 5, 
    @mid = 'T6', 
    @mname = 'VitaminK Updated', 
    @mnumber = '45', 
    @mDate = '2024-11-30', 
    @eDate = '2025-11-30', 
    @quantity = 60, 
    @perUnit = 6000;
EXEC sp_UpdateUser 
    @Id = 7, 
    @userRole = 'User', 
    @name = 'Nguyen Thi B Updated', 
    @dob = '1995-05-15', 
    @mobile = 9876543210, 
    @email = 'nguyenb_updated@gmail.com', 
    @username = 'userBUpdated', 
    @pass = 'passBUpdated';
--xóa
EXEC sp_DeleteCustomer 
    @ID = 1;
EXEC sp_DeleteMedic 
    @Id = 5;
EXEC sp_DeleteUser 
    @Id = 7;
	
