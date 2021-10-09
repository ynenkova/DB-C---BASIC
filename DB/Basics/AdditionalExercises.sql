--1. Number of Users for Email Provider

SELECT [Email Provider],
COUNT([Email Provider]) AS [Number Of Users]
FROM 
(SELECT SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)-LEN(SUBSTRING(Email,0,CHARINDEX('@',Email)))) AS [Email Provider] FROM Users)
AS us
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC,[Email Provider]

--Problem 2.	All User in Games

SELECT g.Name,gt.Name,u.Username,ug.Level,ug.Cash,c.Name FROM Games AS g
JOIN UsersGames AS ug ON ug.GameId=g.Id
JOIN Users AS u ON u.Id=ug.UserId
JOIN Characters AS c ON c.Id=ug.CharacterId
JOIN GameTypes AS gt ON gt.Id=g.GameTypeId

ORDER BY ug.Level DESC, u.Username,g.Name

--Problem 3.	Users in Games with Their Items

SELECT u.Username,g.Name AS [Game],
COUNT(i.Id) AS [Items Count],
SUM(i.Price) AS [Items Price] 
FROM Users AS u

JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId

GROUP BY g.Name,u.Username
HAVING COUNT(i.Id)>=10

ORDER BY [Items Count] DESC,[Items Price] DESC,u.Username

--05. All Items with Greater than Average Statistics
SELECT i.[Name],
       i.Price,
       i.MinLevel,
       s.Strength,
       s.Defence,
       s.Speed,
       s.Luck,
       s.Mind
FROM Items AS i
     JOIN [Statistics] AS s ON s.Id = i.StatisticId
WHERE s.Mind >
(
    SELECT AVG(Mind)
    FROM [Statistics]
)
      AND s.Luck >
(
    SELECT AVG(Luck)
    FROM [Statistics]
)
      AND s.Speed >
(
    SELECT AVG(Speed)
    FROM [Statistics]
)
ORDER BY i.[Name]
--Problem 6.	Display All Items with Information about Forbidden Game Type

SELECT i.Name AS Item, i.Price,i.MinLevel,gt.Name AS [Forbidden Game Type] FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS g ON g.ItemId=i.Id
LEFT JOIN GameTypes AS gt ON gt.Id=g.GameTypeId

ORDER BY gt.Name DESC,i.Name

--Problem 7.	Buy Items for User in Game

DECLARE @userId INT=(SELECT Id FROM Users WHERE Username='Alex')
DECLARE @gameId INT=(SELECT Id FROM Games WHERE Name='Edinburgh')

BEGIN TRANSACTION

DECLARE @itemId INT =(SELECT Items.Id FROM Items WHERE Items.Name='Blackguard')

UPDATE UsersGames
SET Cash-=(SELECT Price FROM Items WHERE Id=@itemId)
WHERE UserId=@userId AND GameId=@gameId

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
)

COMMIT

BEGIN TRANSACTION

SET @itemId  =(SELECT Items.Id FROM Items WHERE Items.Name='Bottomless Potion of Amplification')


UPDATE UsersGames
SET Cash-=(SELECT Price FROM Items WHERE Id=@itemId)
WHERE UserId=@userId AND GameId=@gameId

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
)

COMMIT

BEGIN TRANSACTION

SET @itemId  =(SELECT Items.Id FROM Items WHERE Items.Name='Eye of Etlich (Diablo III)')


UPDATE UsersGames
SET Cash-=(SELECT Price FROM Items WHERE Id=@itemId)
WHERE UserId=@userId AND GameId=@gameId

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
)

COMMIT



BEGIN TRANSACTION

SET @itemId  =(SELECT Items.Id FROM Items WHERE Items.Name='Gem of Efficacious Toxin')


UPDATE UsersGames
SET Cash-=(SELECT Price FROM Items WHERE Id=@itemId)
WHERE UserId=@userId AND GameId=@gameId

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
)

COMMIT

BEGIN TRANSACTION

SET @itemId  =(SELECT Items.Id FROM Items WHERE Items.Name='Golden Gorget of Leoric')


UPDATE UsersGames
SET Cash-=(SELECT Price FROM Items WHERE Id=@itemId)
WHERE UserId=@userId AND GameId=@gameId

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
)

COMMIT

BEGIN TRANSACTION

SET @itemId  =(SELECT Items.Id FROM Items WHERE Items.Name='Hellfire Amulet')


UPDATE UsersGames
SET Cash-=(SELECT Price FROM Items WHERE Id=@itemId)
WHERE UserId=@userId AND GameId=@gameId

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
)

COMMIT


SELECT u.Username,g.Name,ug.Cash,i.Name AS[Item Name] FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
     JOIN Games AS g ON g.Id = ug.GameId
     JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
     JOIN Items AS i ON i.Id = ugi.ItemId

	 WHERE g.Name='Edinburgh'

	 ORDER BY i.Name

--08. Peaks and Mountains

SELECT p.PeakName,m.MountainRange,p.Elevation FROM Peaks AS p
JOIN Mountains AS m ON m.Id=p.MountainId
ORDER BY p.Elevation DESC

--09. Peaks with Mountain, Country and Continent

SELECT p.PeakName, m.MountainRange, c.CountryName, con.ContinentName
FROM     Peaks AS p
JOIN Mountains AS m ON m.Id=p.MountainId
JOIN MountainsCountries AS mc ON mc.MountainId=m.Id
JOIN Countries AS c ON c.CountryCode=mc.CountryCode
JOIN Continents AS con ON con.ContinentCode=c.ContinentCode

ORDER BY p.PeakName,c.CountryName

--10. Rivers by Country
SELECT c.CountryName,con.ContinentName,COUNT(r.id) AS [RiversCount],ISNULL(SUM(r.Length),0) AS [TotalLength] FROM Countries AS c
JOIN Continents AS con ON con.ContinentCode=c.ContinentCode
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers AS r ON r.Id=cr.RiverId

GROUP BY c.CountryName,con.ContinentName

ORDER BY [RiversCount] DESC,[TotalLength] DESC,c.CountryName

--11. Count of Countries by Currency
SELECT curr.CurrencyCode,curr.Description AS [Currency],COUNT(c.CountryCode) AS [NumberOfCountries] FROM Currencies AS curr
LEFT JOIN Countries AS c ON c.CurrencyCode=curr.CurrencyCode
GROUP BY curr.CurrencyCode,curr.Description
ORDER BY [NumberOfCountries] DESC,[Currency]

--12. Population and Area by Continent

SELECT con.ContinentName,SUM(CAST(c.AreaInSqKm AS BIGINT)) AS [CountriesArea],SUM(CAST(c.Population AS BIGINT)) AS [CountriesPopulation] FROM  Countries AS c
JOIN Continents AS con ON con.ContinentCode=c.ContinentCode
GROUP BY con.ContinentName
ORDER BY [CountriesPopulation] DESC

--13. Monasteries by Country
CREATE TABLE Monasteries
(
Id INT IDENTITY PRIMARY KEY, 
[Name] NVARCHAR(50),
CountryCode NVARCHAR(50),
MonasteriesCountries CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)


INSERT INTO Monasteries([Name],
                        CountryCode
                       )
VALUES
(
       'Rila Monastery “St. Ivan of Rila”',
       'BG'
),
(
       'Bachkovo Monastery “Virgin Mary”',
       'BG'
),
(
       'Troyan Monastery “Holy Mother''s Assumption”',
       'BG'
),
(
       'Kopan Monastery',
       'NP'
),
(
       'Thrangu Tashi Yangtse Monastery',
       'NP'
),
(
       'Shechen Tennyi Dargyeling Monastery',
       'NP'
),
(
       'Benchen Monastery',
       'NP'
),
(
       'Southern Shaolin Monastery',
       'CN'
),
(
       'Dabei Monastery',
       'CN'
),
(
       'Wa Sau Toi',
       'CN'
),
(
       'Lhunshigyia Monastery',
       'CN'
),
(
       'Rakya Monastery',
       'CN'
),
(
       'Monasteries of Meteora',
       'GR'
),
(
       'The Holy Monastery of Stavronikita',
       'GR'
),
(
       'Taung Kalat Monastery',
       'MM'
),
(
       'Pa-Auk Forest Monastery',
       'MM'
),
(
       'Taktsang Palphug Monastery',
       'BT'
),
(
       'Sümela Monastery',
       'TR'
)

ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0

UPDATE Countries
SET IsDeleted = 0
      

UPDATE Countries
SET IsDeleted=1
WHERE CountryCode IN 
(
    SELECT c.CountryCode
    FROM Countries AS c
         JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
    GROUP BY c.CountryCode
    HAVING COUNT(cr.RiverId) > 3
)

SELECT m.Name AS [Monastery],c.CountryName AS Country FROM Monasteries AS m
JOIN Countries AS c ON c.CountryCode=m.CountryCode
WHERE c.IsDeleted=0
ORDER BY [Monastery]

--14. Monasteries by Continents and Countries
UPDATE Countries
SET CountryName='Burma'
WHERE CountryName='Myanmar'


INSERT INTO Monasteries ([Name],
                        CountryCode
                       )VALUES
('Hanga Abbey',(SELECT Countries.CountryCode FROM Countries WHERE Countries.CountryName='Tanzania')),
('Myin-Tin-Daik',(SELECT Countries.CountryCode FROM Countries WHERE Countries.CountryName='Myanmar'))

SELECT c.ContinentName,
	ct.CountryName,
	COUNT(m.Id) AS [MonasteriesCount] 
	FROM Continents AS c
LEFT JOIN Countries AS ct ON ct.ContinentCode=c.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode=ct.CountryCode
WHERE ct.IsDeleted=0
GROUP BY c.ContinentName,ct.CountryName
ORDER BY [MonasteriesCount] DESC,ct.CountryName

