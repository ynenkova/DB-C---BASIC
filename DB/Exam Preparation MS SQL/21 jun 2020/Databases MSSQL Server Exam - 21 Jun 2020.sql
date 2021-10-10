CREATE DATABASE TripService
CREATE TABLE Cities
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode NVARCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(14,2)
)

CREATE TABLE Rooms
(
Id INT IDENTITY PRIMARY KEY,
Price DECIMAL(14,2)  NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
Id INT IDENTITY PRIMARY KEY,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
BookDate DATE  NOT NULL,
ArrivalDate DATE  NOT NULL,
ReturnDate DATE NOT NULL,
CancelDate DATE,
CHECK(BookDate<ArrivalDate),
CHECK(ArrivalDate<ReturnDate)
)

CREATE TABLE Accounts
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
BirthDate DATE NOT NULL,
Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
Luggage INT CHECK(Luggage>=0) NOT NULL
)

--2 Insert 
INSERT INTO Accounts VALUES
('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com'),
('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com'),
('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg'),
('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
(101,'2015-04-12','2015-04-14','2015-04-20','2015-02-02'),
(102,'2015-07-07','2015-07-15','2015-07-22','2015-04-29'),
(103,'2013-07-17','2013-07-23','2013-07-24',NULL),
(104,'2012-03-17','2012-03-31','2012-04-01','2012-01-10'),
(109,'2017-08-07','2017-08-28','2017-08-29',NULL)

--3 Update

UPDATE Rooms
SET Price+=Price*0.14
WHERE Id IN (5,7,9)

--4 Delete

DELETE AccountsTrips
WHERE AccountId=47

--5 EEE-Mails
SELECT a.FirstName,a.LastName,FORMAT(a.BirthDate,'MM-dd-yyyy') AS BirthDate ,c.Name,a.Email FROM Accounts AS a
JOIN Cities AS c ON c.Id=a.CityId
WHERE a.Email LIKE 'e%'
ORDER BY c.Name

--6  City Statistics

SELECT c.Name AS City, COUNT(h.Id) AS Hotels FROM Cities AS c
JOIN Hotels AS h ON h.CityId=c.Id
GROUP BY c.Name
ORDER BY Hotels DESC,c.Name

--7 Longest and Shortest Trips

SELECT a.Id,a.FirstName+' '+a.LastName AS FullName,
MAX(DATEDIFF(DAY,tr.ArrivalDate,tr.ReturnDate)) AS LongestTrip,
MIN(DATEDIFF(DAY,tr.ArrivalDate,tr.ReturnDate)) AS ShortestTrip 
FROM Accounts AS a

JOIN AccountsTrips AS t ON t.AccountId=a.Id
JOIN Trips AS tr ON tr.Id=t.TripId

WHERE tr.CancelDate IS  NULL AND  a.MiddleName IS  NULL
GROUP BY a.Id,a.FirstName,a.LastName
ORDER BY LongestTrip DESC,ShortestTrip ASC

--8 Metropilis
SELECT TOP(10) c.Id,c.Name,c.CountryCode AS Country,COUNT(a.Id) AS Accounts FROM Cities AS c
JOIN Accounts AS a ON a.CityId=c.Id
GROUP BY c.Id,c.Name,c.CountryCode
ORDER BY Accounts DESC

--9. Romantic Getaways

SELECT a.Id,
a.Email,
c.Name,COUNT(c.Id) AS Trips

FROM Accounts AS a
	JOIN AccountsTrips AS at ON at.AccountId=a.Id
	JOIN Trips AS t ON t.Id=at.TripId
	JOIN Rooms AS r ON r.Id=t.RoomId
	JOIN Hotels AS h ON h.Id=r.HotelId
	JOIN Cities AS c ON c.Id=a.CityId
WHERE h.CityId=a.CityId
GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips DESC,a.Id ASC

--10. GDPR Violation

SELECT t.Id,a.FirstName+' '+IIF(a.MiddleName IS NULL,'',a.MiddleName)+' '+a.LastName AS [Full Name],c.Name AS [From],(SELECT cc.Name FROM Trips AS tt
	JOIN AccountsTrips AS accT2 ON accT2.TripId = tt.Id
	JOIN Accounts AS aa ON aa.Id = accT2.AccountId
	JOIN Rooms AS rr ON rr.Id = tt.RoomId
	JOIN Hotels AS hh ON hh.Id = rr.HotelId
	JOIN Cities AS cc ON hh.CityId = cc.Id
WHERE tt.Id = t.Id AND a.Id = aa.Id AND hh.Id = h.Id) AS [To],

IIF(t.CancelDate=NULL,'Canceled',CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' ','days')) AS [Duration] 
FROM Trips AS t

	JOIN AccountsTrips AS accT ON accT.TripId = t.Id
	JOIN Accounts AS a ON a.Id = accT.AccountId
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId

	
	ORDER BY [Full Name],t.Id



CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR
AS
BEGIN 
	DECLARE @RoomId INT = (SELECT TOP(1) r.Id FROM Trips AS t
						JOIN Rooms AS r ON t.RoomId = r.Id
						JOIN Hotels AS h ON r.HotelId = h.Id
						WHERE h.Id = @HotelId 
						  AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate 
						  AND t.CancelDate IS NULL
						  AND r.Beds >= @People
						  AND YEAR(@Date) = YEAR(t.ArrivalDate)
						  ORDER BY r.Price DESC)

  IF @RoomId IS NULL
	RETURN 'No rooms available'

	DECLARE @Type NVARCHAR(100)=(SELECT Rooms.Type FROM Rooms WHERE Rooms.Id=@RoomId)
	DECLARE @rate DECIMAL(14,2)=(SELECT Hotels.BaseRate FROM Hotels WHERE Hotels.Id=@HotelId)
	DECLARE @BedsCount INT  = (SELECT Beds FROM Rooms WHERE Id = @RoomId)
	DECLARE @roomPrice DECIMAL(14,2)=(SELECT Rooms.Price FROM Rooms WHERE Rooms.Id=@RoomId)
	DECLARE @price DECIMAL(14,2)= (@rate + @roomPrice)*@People

	
	RETURN 'Room ' + CONVERT(NVARCHAR,@RoomId) 
		+ ': ' + CONVERT(NVARCHAR, @Type) 
		+ ' (' + CONVERT(NVARCHAR, @BedsCount) 
		+ ' beds)' 
		+ ' - $' 
		+ CONVERT(NVARCHAR, @price)
	
END

--12. Switch Room
CREATE ALTER PROCEDURE usp_SwitchRoom @TripId INT, @TargetRoomId INT
AS
BEGIN
DECLARE @RoomHotelId INT = (SELECT TOP(1) h.Id FROM Trips AS t
       JOIN Rooms AS r ON r.Id = t.RoomId
       JOIN HOTELS AS h ON h.Id = r.HotelId
       WHERE t.Id = @TripId)

DECLARE @HotelId INT = (SELECT HotelId FROM Rooms WHERE @TargetRoomId = Id)

DECLARE @BedsCount INT = (SELECT Beds FROM Rooms WHERE @TargetRoomId = Id)

DECLARE @AccoutTripsCount INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)

  IF @RoomHotelId != @HotelId
           THROW 50001, 'Target room is in another hotel!', 1
 
  ELSE IF @BedsCount < @AccoutTripsCount      
           THROW 50002, 'Not enough beds in target room!', 1
              
  ELSE       
	BEGIN
        UPDATE Trips
            SET RoomId = @TargetRoomId
            WHERE Id = @TripId
	END
	
	






	 