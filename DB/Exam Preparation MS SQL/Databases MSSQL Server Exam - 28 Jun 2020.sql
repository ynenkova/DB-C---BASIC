CREATE TABLE Planets
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30) NOT NULL 
)

CREATE TABLE Spaceports
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Manufacturer NVARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Ucn NVARCHAR(10) NOT NULL UNIQUE,
BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
Id INT IDENTITY PRIMARY KEY,
JourneyStart DATETIME NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose NVARCHAR(11) CHECK( Purpose IN ('Medical','Technical','Educational','Military')),
DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
Id INT IDENTITY PRIMARY KEY,
CardNumber NVARCHAR(10) NOT NULL UNIQUE,
JobDuringJourney NVARCHAR (8) CHECK(JobDuringJourney IN('Pilot','Engineer','Trooper','Cleaner','Cook')),
ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

--Insert
INSERT INTO Planets VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',6)

--3 Update
UPDATE Spaceships
SET LightSpeedRate+=1
WHERE Id BETWEEN 8 AND 12

--4 Delete

DELETE  FROM TravelCards
WHERE JourneyId IN(1,2,3)

DELETE FROM Journeys
WHERE Id IN(1,2,3)

--5 Select All Military Journeys
SELECT j.Id,FORMAT(j.JourneyStart,'dd/MM/yyyy') AS JourneyStart,FORMAT(j.JourneyEnd,'dd/MM/yyyy') AS JourneyEnd FROM Journeys AS j
WHERE Purpose='Military'
ORDER BY JourneyStart

--6 Select All Pilots
SELECT c.Id,c.FirstName+' '+c.LastName AS full_name FROM Colonists AS c
JOIN TravelCards AS t ON t.ColonistId=c.Id
WHERE t.JobDuringJourney='Pilot'
ORDER BY c.Id

--7 Count Colonists
SELECT COUNT(c.id) AS [count] FROM Colonists AS c
JOIN TravelCards AS t ON t.ColonistId=c.Id
JOIN Journeys AS j ON j.Id=t.JourneyId
WHERE j.Purpose='Technical'

--8  Select Spaceships With Pilots

SELECT s.Name,s.Manufacturer FROM Spaceships AS s
JOIN Journeys AS j ON j.SpaceshipId=s.Id
JOIN TravelCards AS tc ON tc.JourneyId=j.Id
JOIN Colonists AS c ON c.Id=tc.ColonistId
WHERE tc.JobDuringJourney='Pilot' AND DATEDIFF(YEAR,C.BirthDate,'01/01/2019')<30
ORDER BY s.Name

--9 Planets And Journeys
SELECT p.Name AS PlanetName,COUNT(j.Id) AS JourneysCount FROM Planets AS p
JOIN Spaceports AS s ON s.PlanetId=p.Id
JOIN Journeys AS j ON j.DestinationSpaceportId=s.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC,PlanetName

--10  Select Special Colonists

--11
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT
AS
BEGIN
	
	DECLARE @Count INT= (SELECT COUNT(c.Id) FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId=c.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId=tc.JourneyId
	JOIN Spaceports AS s ON s.Id=j.DestinationSpaceportId
	JOIN Planets AS p ON p.Id=s.PlanetId
	WHERE p.Name=@PlanetName	)
	RETURN @Count

END

SELECT dbo.udf_GetColonistsCount('Otroyphus')