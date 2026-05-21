-- SQL Server initialization script for the Hotel_System WinForms application.
-- Default C# connection string:
-- Server=localhost\SQLEXPRESS;Database=hoteldb;Trusted_Connection=True;TrustServerCertificate=True;

IF DB_ID(N'hoteldb') IS NULL
BEGIN
    CREATE DATABASE hoteldb;
END
GO

USE hoteldb;
GO

DROP VIEW IF EXISTS dbo.vw_booking_report;
DROP VIEW IF EXISTS dbo.vw_payment_report;
DROP VIEW IF EXISTS dbo.vw_checkout_report;
GO

DROP TABLE IF EXISTS dbo.payments;
DROP TABLE IF EXISTS dbo.checkouts;
DROP TABLE IF EXISTS dbo.checkins;
DROP TABLE IF EXISTS dbo.bookings;
DROP TABLE IF EXISTS dbo.rooms;
DROP TABLE IF EXISTS dbo.roomtypes;
DROP TABLE IF EXISTS dbo.customers;
DROP TABLE IF EXISTS dbo.admins;
GO

CREATE TABLE dbo.admins (
    AdminID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Admins PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL CONSTRAINT UQ_Admins_Username UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(30) NOT NULL CONSTRAINT DF_Admins_Role DEFAULT N'Staff',
    ImagePath NVARCHAR(500) NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Admins_CreatedAt DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Admins_Role CHECK (Role IN (N'SuperAdmin', N'Staff', N'Administrator'))
);

CREATE TABLE dbo.customers (
    CustomerID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Customers PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(20) NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(255) NULL,
    IDCardNumber NVARCHAR(50) NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Customers_CreatedAt DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(0) NULL,
    CONSTRAINT CK_Customers_Gender CHECK (Gender IS NULL OR Gender IN (N'Male', N'Female', N'Other'))
);

CREATE TABLE dbo.roomtypes (
    RoomTypeID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_RoomTypes PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL CONSTRAINT UQ_RoomTypes_TypeName UNIQUE,
    Description NVARCHAR(255) NULL,
    PricePerNight DECIMAL(10,2) NOT NULL,
    Capacity INT NOT NULL CONSTRAINT DF_RoomTypes_Capacity DEFAULT 1,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_RoomTypes_CreatedAt DEFAULT SYSDATETIME()
);

CREATE TABLE dbo.rooms (
    RoomID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Rooms PRIMARY KEY,
    RoomNumber NVARCHAR(10) NOT NULL CONSTRAINT UQ_Rooms_RoomNumber UNIQUE,
    RoomTypeID INT NOT NULL,
    Floor NVARCHAR(20) NULL,
    BedType NVARCHAR(50) NULL,
    Capacity INT NOT NULL CONSTRAINT DF_Rooms_Capacity DEFAULT 1,
    PricePerNight DECIMAL(10,2) NOT NULL CONSTRAINT DF_Rooms_PricePerNight DEFAULT 0.00,
    Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Rooms_Status DEFAULT N'Available',
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Rooms_CreatedAt DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(0) NULL,
    CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY (RoomTypeID) REFERENCES dbo.roomtypes(RoomTypeID),
    CONSTRAINT CK_Rooms_Status CHECK (Status IN (N'Available', N'Occupied', N'Reserved', N'Reserved/Booked', N'Cleaning', N'Maintenance'))
);

CREATE TABLE dbo.bookings (
    BookingID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Bookings PRIMARY KEY,
    CustomerID INT NOT NULL,
    RoomID INT NOT NULL,
    BookingDate DATETIME2(0) NOT NULL CONSTRAINT DF_Bookings_BookingDate DEFAULT SYSDATETIME(),
    CheckInDate DATETIME2(0) NOT NULL,
    CheckOutDate DATETIME2(0) NOT NULL,
    Nights INT NOT NULL CONSTRAINT DF_Bookings_Nights DEFAULT 1,
    Adults INT NOT NULL CONSTRAINT DF_Bookings_Adults DEFAULT 1,
    Children INT NOT NULL CONSTRAINT DF_Bookings_Children DEFAULT 0,
    Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Bookings_Status DEFAULT N'Reserved',
    Note NVARCHAR(255) NULL,
    PricePerNight DECIMAL(10,2) NOT NULL CONSTRAINT DF_Bookings_PricePerNight DEFAULT 0.00,
    Discount DECIMAL(10,2) NOT NULL CONSTRAINT DF_Bookings_Discount DEFAULT 0.00,
    TotalPrice DECIMAL(10,2) NOT NULL CONSTRAINT DF_Bookings_TotalPrice DEFAULT 0.00,
    Deposit DECIMAL(10,2) NOT NULL CONSTRAINT DF_Bookings_Deposit DEFAULT 0.00,
    CreatedByAdminID INT NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Bookings_CreatedAt DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2(0) NULL,
    CONSTRAINT FK_Bookings_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.customers(CustomerID),
    CONSTRAINT FK_Bookings_Rooms FOREIGN KEY (RoomID) REFERENCES dbo.rooms(RoomID),
    CONSTRAINT FK_Bookings_Admins FOREIGN KEY (CreatedByAdminID) REFERENCES dbo.admins(AdminID),
    CONSTRAINT CK_Bookings_Dates CHECK (CheckOutDate >= CheckInDate),
    CONSTRAINT CK_Bookings_Status CHECK (Status IN (N'Reserved', N'Booked', N'Checked In', N'Checked Out', N'Cancelled', N'Completed'))
);

CREATE TABLE dbo.checkins (
    CheckInID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CheckIns PRIMARY KEY,
    BookingID INT NULL,
    CustomerID INT NOT NULL,
    RoomID INT NOT NULL,
    CheckInDate DATETIME2(0) NOT NULL,
    CreatedByAdminID INT NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_CheckIns_CreatedAt DEFAULT SYSDATETIME(),
    CONSTRAINT FK_CheckIns_Bookings FOREIGN KEY (BookingID) REFERENCES dbo.bookings(BookingID),
    CONSTRAINT FK_CheckIns_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.customers(CustomerID),
    CONSTRAINT FK_CheckIns_Rooms FOREIGN KEY (RoomID) REFERENCES dbo.rooms(RoomID),
    CONSTRAINT FK_CheckIns_Admins FOREIGN KEY (CreatedByAdminID) REFERENCES dbo.admins(AdminID)
);

CREATE TABLE dbo.checkouts (
    CheckOutID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CheckOuts PRIMARY KEY,
    CheckInID INT NOT NULL CONSTRAINT UQ_CheckOuts_CheckInID UNIQUE,
    CheckOutDate DATETIME2(0) NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL CONSTRAINT DF_CheckOuts_SubTotal DEFAULT 0.00,
    Discount DECIMAL(10,2) NOT NULL CONSTRAINT DF_CheckOuts_Discount DEFAULT 0.00,
    Tax DECIMAL(10,2) NOT NULL CONSTRAINT DF_CheckOuts_Tax DEFAULT 0.00,
    TotalAmount DECIMAL(10,2) NOT NULL,
    Deposit DECIMAL(10,2) NOT NULL CONSTRAINT DF_CheckOuts_Deposit DEFAULT 0.00,
    Remaining DECIMAL(10,2) NOT NULL CONSTRAINT DF_CheckOuts_Remaining DEFAULT 0.00,
    CreatedByAdminID INT NULL,
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_CheckOuts_CreatedAt DEFAULT SYSDATETIME(),
    CONSTRAINT FK_CheckOuts_CheckIns FOREIGN KEY (CheckInID) REFERENCES dbo.checkins(CheckInID),
    CONSTRAINT FK_CheckOuts_Admins FOREIGN KEY (CreatedByAdminID) REFERENCES dbo.admins(AdminID)
);

CREATE TABLE dbo.payments (
    PaymentID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Payments PRIMARY KEY,
    CheckOutID INT NOT NULL,
    PaymentDate DATETIME2(0) NOT NULL CONSTRAINT DF_Payments_PaymentDate DEFAULT SYSDATETIME(),
    AmountPaid DECIMAL(10,2) NOT NULL,
    RoomCharge DECIMAL(10,2) NOT NULL CONSTRAINT DF_Payments_RoomCharge DEFAULT 0.00,
    ServiceCharge DECIMAL(10,2) NOT NULL CONSTRAINT DF_Payments_ServiceCharge DEFAULT 0.00,
    PaymentMethod NVARCHAR(30) NULL,
    PaymentStatus NVARCHAR(30) NOT NULL CONSTRAINT DF_Payments_PaymentStatus DEFAULT N'Paid',
    CreatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_Payments_CreatedAt DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Payments_CheckOuts FOREIGN KEY (CheckOutID) REFERENCES dbo.checkouts(CheckOutID),
    CONSTRAINT CK_Payments_Method CHECK (PaymentMethod IS NULL OR PaymentMethod IN (N'Cash', N'Card', N'Bank', N'Other', N'Credit Card', N'Transfer')),
    CONSTRAINT CK_Payments_Status CHECK (PaymentStatus IN (N'Paid', N'Pending', N'Refunded', N'Unpaid', N'Partial'))
);
GO

CREATE VIEW dbo.vw_booking_report AS
SELECT
    b.BookingID AS booking_id,
    c.FullName AS customer_name,
    c.Phone AS phone_number,
    r.RoomNumber AS room,
    rt.TypeName AS room_type,
    b.CheckInDate AS [check-in],
    b.CheckOutDate AS [check-out],
    b.Nights AS nights,
    b.PricePerNight AS price_per_night,
    b.Discount AS discount,
    b.TotalPrice AS total_price,
    b.Status AS status,
    b.Note AS note
FROM dbo.bookings b
JOIN dbo.customers c ON c.CustomerID = b.CustomerID
JOIN dbo.rooms r ON r.RoomID = b.RoomID
JOIN dbo.roomtypes rt ON rt.RoomTypeID = r.RoomTypeID;
GO

CREATE VIEW dbo.vw_payment_report AS
SELECT
    c.FullName AS customer_name,
    c.Phone AS phone_number,
    r.RoomNumber AS room,
    rt.TypeName AS room_type,
    ci.CheckInDate AS [check-in],
    co.CheckOutDate AS [check-out],
    p.RoomCharge AS room_service,
    p.ServiceCharge AS service_charge,
    co.TotalAmount AS total_amount,
    p.PaymentMethod AS payment
FROM dbo.payments p
JOIN dbo.checkouts co ON co.CheckOutID = p.CheckOutID
JOIN dbo.checkins ci ON ci.CheckInID = co.CheckInID
JOIN dbo.customers c ON c.CustomerID = ci.CustomerID
JOIN dbo.rooms r ON r.RoomID = ci.RoomID
JOIN dbo.roomtypes rt ON rt.RoomTypeID = r.RoomTypeID;
GO

CREATE VIEW dbo.vw_checkout_report AS
SELECT
    c.FullName AS customer_name,
    c.Phone AS phone_number,
    r.RoomNumber AS room,
    rt.TypeName AS room_type,
    r.RoomNumber AS room_number,
    c.IDCardNumber AS id_passport,
    ci.CheckInDate AS [check-in],
    co.CheckOutDate AS [check-out],
    co.SubTotal AS sub_total,
    co.Discount AS discount,
    co.TotalAmount AS total_price,
    p.PaymentMethod AS payment_method,
    co.Deposit AS deposit,
    co.Remaining AS Remaining
FROM dbo.checkouts co
JOIN dbo.checkins ci ON ci.CheckInID = co.CheckInID
JOIN dbo.customers c ON c.CustomerID = ci.CustomerID
JOIN dbo.rooms r ON r.RoomID = ci.RoomID
JOIN dbo.roomtypes rt ON rt.RoomTypeID = r.RoomTypeID
LEFT JOIN dbo.payments p ON p.CheckOutID = co.CheckOutID;
GO

INSERT INTO dbo.admins (Username, Password, FullName, Role)
VALUES (N'admin', N'admin123', N'Hotel Admin', N'SuperAdmin');

INSERT INTO dbo.roomtypes (TypeName, Description, PricePerNight, Capacity)
VALUES
    (N'Standard', N'Standard room for budget stays', 80.00, 2),
    (N'Deluxe', N'Deluxe room with upgraded amenities', 120.00, 2),
    (N'Suite', N'Suite room for families and long stays', 200.00, 4),
    (N'Luxury', N'Luxury room with premium service', 360.00, 4);

INSERT INTO dbo.rooms (RoomNumber, RoomTypeID, Floor, BedType, Capacity, PricePerNight, Status)
VALUES
    (N'101', 1, N'1', N'Queen', 2, 80.00, N'Available'),
    (N'102', 1, N'1', N'Twin', 2, 80.00, N'Available'),
    (N'201', 2, N'2', N'King', 2, 120.00, N'Available'),
    (N'301', 3, N'3', N'King + Sofa', 4, 200.00, N'Available'),
    (N'401', 4, N'4', N'King', 4, 360.00, N'Available');
GO
