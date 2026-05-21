USE hoteldb;
GO

IF COL_LENGTH('dbo.bookings', 'Nights') IS NULL
BEGIN
    ALTER TABLE dbo.bookings ADD Nights INT NOT NULL CONSTRAINT DF_Bookings_Nights_Migration DEFAULT 1;
END
GO

IF COL_LENGTH('dbo.bookings', 'PricePerNight') IS NULL
BEGIN
    ALTER TABLE dbo.bookings ADD PricePerNight DECIMAL(10,2) NOT NULL CONSTRAINT DF_Bookings_PricePerNight_Migration DEFAULT 0.00;
END
GO

IF COL_LENGTH('dbo.bookings', 'Discount') IS NULL
BEGIN
    ALTER TABLE dbo.bookings ADD Discount DECIMAL(10,2) NOT NULL CONSTRAINT DF_Bookings_Discount_Migration DEFAULT 0.00;
END
GO

UPDATE b
SET
    b.Nights = CASE WHEN DATEDIFF(day, b.CheckInDate, b.CheckOutDate) > 1 THEN DATEDIFF(day, b.CheckInDate, b.CheckOutDate) ELSE 1 END,
    b.PricePerNight = r.PricePerNight,
    b.Discount = 0.00
FROM dbo.bookings b
JOIN dbo.rooms r ON r.RoomID = b.RoomID
WHERE b.Nights IS NULL OR b.PricePerNight = 0.00;
GO
