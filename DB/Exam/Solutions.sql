
CREATE TABLE Sizes
(
Id INT IDENTITY PRIMARY KEY,
Length INT CHECK(Length BETWEEN 10 AND 25) NOT NULL,
RingRange DECIMAL(14,2) CHECK(RingRange BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE Tastes
(
Id INT IDENTITY PRIMARY KEY,
TasteType NVARCHAR(20) NOT NULL,
TasteStrength NVARCHAR(15) NOT NULL,
ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
Id INT IDENTITY PRIMARY KEY,
BrandName NVARCHAR(30) UNIQUE NOT NULL,
BrandDescription NVARCHAR(MAX) 
)

CREATE TABLE Cigars
(
Id INT IDENTITY PRIMARY KEY,
CigarName NVARCHAR(80) UNIQUE NOT NULL,
BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
PriceForSingleCigar MONEY NOT NULL,
ImageURL NVARCHAR(100) NOT NULL

)

CREATE TABLE Addresses
(
Id INT IDENTITY PRIMARY KEY,
Town NVARCHAR(30) NOT NULL,
Country NVARCHAR(30) NOT NULL,
Streat NVARCHAR(100) NOT NULL,
ZIP NVARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Email NVARCHAR(50) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
ClientId INT FOREIGN KEY REFERENCES Clients(Id) ,
CigarId INT FOREIGN KEY REFERENCES Cigars(Id) 
PRIMARY KEY(ClientId,CigarId)
)

--2 Insert
INSERT INTO Cigars VALUES
('COHIBA ROBUSTO',	9	,1,	5	,15.50	,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',	9,	1	,10	,410.00	,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',	14,	5	,11	,7.50,	'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14	,4	,15	,32.00	,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2	,3	,8	,85.21	,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses VALUES
('Sofia'	,'Bulgaria'	,'18 Bul. Vasil levski',	'1000'),
('Athens',	'Greece'	,'4342 McDonald Avenue',	'10435'),
('Zagreb'	,'Croatia'	,'4333 Lauren Drive',	'10000')

--3 Update
UPDATE Cigars
SET PriceForSingleCigar+=PriceForSingleCigar*0.2
WHERE TastId=1

UPDATE Brands
SET BrandDescription='New description'
WHERE BrandDescription IS NULL

--4 
DELETE Clients
WHERE AddressId IN (7,8,10)

DELETE Addresses
WHERE Country LIKE 'C%'

--5
SELECT Cigars.CigarName,Cigars.PriceForSingleCigar,Cigars.ImageURL FROM Cigars
ORDER BY Cigars.PriceForSingleCigar ASC, Cigars.CigarName DESC

--6
SELECT c.Id,c.CigarName,c.PriceForSingleCigar,t.TasteType,t.TasteStrength FROM Cigars AS c
JOIN Tastes AS t ON t.Id=c.TastId
WHERE t.TasteType IN ('Earthy','Woody')
ORDER BY c.PriceForSingleCigar DESC
--7
SELECT c.Id,c.FirstName+' '+c.LastName AS ClientName,c.Email FROM Clients AS c 
LEFT JOIN ClientsCigars AS ci ON ci.ClientId=c.Id
WHERE ci.CigarId IS NULL

ORDER BY ClientName ASC

--8
SELECT TOP(5) c.CigarName,c.PriceForSingleCigar,c.ImageURL FROM Cigars AS c 
JOIN Sizes AS s ON s.Id=c.SizeId
WHERE s.Length>=12  AND s.RingRange>2.55
AND c.PriceForSingleCigar>50 OR  c.CigarName LIKE '%ci%'


ORDER BY c.CigarName ASC,c.PriceForSingleCigar DESC

--9
SELECT c.FirstName+' '+c.LastName AS FullName,a.Country,a.ZIP
,
CONCAT('$',ci.PriceForSingleCigar) AS PriceForSingleCigar FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON cc.ClientId=c.Id
LEFT JOIN Cigars AS ci ON ci.Id=cc.CigarId
LEFT JOIN Addresses AS a ON a.Id=c.AddressId
WHERE a.ZIP NOT LIKE '%[^0-9]%' AND ci.PriceForSingleCigar=(SELECT MAX(ci.PriceForSingleCigar) FROM Cigars LEFT JOIN ClientsCigars AS cc ON cc.ClientId=c.Id
LEFT JOIN Cigars AS ci ON ci.Id=cc.CigarId  )

GROUP BY c.FirstName,c.LastName,a.Country,a.ZIP,ci.PriceForSingleCigar
HAVING MAX(ci.PriceForSingleCigar)>=543.23
ORDER BY FullName ASC

--10
SELECT c.LastName,AVG(s.Length) AS CiagrLength,CEILING(AVG(s.RingRange)) AS CiagrRingRange FROM Clients AS c
JOIN ClientsCigars AS cc ON cc.ClientId=c.Id
JOIN Cigars AS ci ON ci.Id=cc.CigarId
JOIN Sizes AS s ON s.Id=ci.SizeId
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--11
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT AS
BEGIN 
	DECLARE @Count INT
SET @Count=	(SELECT COUNT(*) FROM Cigars 
JOIN ClientsCigars AS cc ON cc.CigarId=Cigars.Id
JOIN Clients AS ci ON ci.Id=cc.ClientId
WHERE ci.FirstName=@name)
	RETURN @Count
END

SELECT dbo.udf_ClientWithCigars('Betty')


--12
CREATE PROC usp_SearchByTaste(@taste NVARCHAR(20))
AS
BEGIN
SELECT c.CigarName,CONCAT('$',c.PriceForSingleCigar) AS PriceForSingleCigar,t.TasteType,b.BrandName,
CONCAT(s.Length ,' cm')  AS CigarLength,
CONCAT(s.RingRange,' cm') AS CigarRingRange FROM Cigars AS c
JOIN Brands AS b ON b.Id=c.BrandId
JOIN Tastes AS t ON t.Id=c.TastId
JOIN Sizes AS s ON s.Id=c.SizeId
WHERE t.TasteType=@taste
ORDER BY CigarLength ASC,CigarRingRange DESC
END

