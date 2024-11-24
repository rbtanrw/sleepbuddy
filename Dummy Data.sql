USE BookHotel

INSERT INTO Hotel (HotelID, HotelName, HotelCity, HotelRoomAvailable, HotelRating)
VALUES
('HT08', 'Cirebon Hotel', 'Cirebon', 20, 5),
('HT11', 'Jason Hotel', 'Cirebon', 32, 5),
('HT02', 'Jasoyo', 'Cirebon', 7, 2),
('HT91', 'Mumbai Hotel', 'Tangerang', 15, 5),
('HT31', 'Purman', 'Tangerang', 21, 5),
('HT00', 'Bokoyo', 'Jakarta', 9, 3),
('HT03', 'Bokoyo Franchise', 'Jakarta', 6, 2),
('HT05', 'Bokoyo Branch', 'Jakarta', 10, 3),
('HT40', 'Bokoyo Supreme', 'Jakarta', 28, 5),
('HT76', 'Nohotel', 'Jakarta', 10, 5),
('HT64', 'Bali Hotel', 'Bali', 18, 5);

DECLARE @i INT = 1;
DECLARE @num_rows INT = 12;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT08RR'+FORMAT(@i, '00'), 899000, 'Elite', 1, 'HT08', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 13;
DECLARE @num_rows INT = 20;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT08RR'+FORMAT(@i, '00'), 499000, 'Regular', 1, 'HT08', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 32;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT11RR'+FORMAT(@i, '00'), 599000, 'Jason', 1, 'HT11', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 7;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT02RR'+FORMAT(@i, '00'), 299000, 'Regular', 1, 'HT02', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 15;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT91RR'+FORMAT(@i, '00'), 599000, 'Chill', 1, 'HT91', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 15;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT31RR'+FORMAT(@i, '00'), 999000, 'Rich', 1, 'HT31', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 16;
DECLARE @num_rows INT = 21;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT31RR'+FORMAT(@i, '00'), 99000, 'Pur', 1, 'HT31', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 9;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT00RR'+FORMAT(@i, '00'), 149000, 'Mantap', 1, 'HT00', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 6;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT03RR'+FORMAT(@i, '00'), 149000, 'Mantap', 1, 'HT03', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 10;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT05RR'+FORMAT(@i, '00'), 149000, 'Mantap', 1, 'HT05', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 10;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT40RR'+FORMAT(@i, '00'), 149000, 'Mantap', 1, 'HT40', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 11;
DECLARE @num_rows INT = 28;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT40RR'+FORMAT(@i, '00'), 1199000, 'Supreme', 1, 'HT40', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 10;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT76RR'+FORMAT(@i, '00'), 349000, 'Regular', 1, 'HT76', null
	);
    
    SET @i = @i + 1;
END;

DECLARE @i INT = 1;
DECLARE @num_rows INT = 18;

WHILE @i <= @num_rows
BEGIN
    INSERT INTO Room(RoomID, RoomPrice, RoomCategory, RoomAvailability, HotelID, ReservationID)
	VALUES(
		'HT64RR'+FORMAT(@i, '00'), 849000, 'Bali Vacation', 1, 'HT64', null
	);
    
    SET @i = @i + 1;
END;