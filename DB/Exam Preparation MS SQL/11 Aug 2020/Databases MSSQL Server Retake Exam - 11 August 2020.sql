CREATE TABLE Countries
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1) CHECK(Gender IN('M','F')),
Age INT,
PhoneNumber NVARCHAR(50) CHECK(LEN(PhoneNumber)=10),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)
CREATE TABLE Products
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(25) UNIQUE,
[Description] NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price DECIMAL(17,2) CHECK(Price>0)
)
CREATE TABLE Feedbacks
(
Id INT IDENTITY PRIMARY KEY,
[Description] NVARCHAR(255),
Rate DECIMAL(17,2) CHECK(Rate BETWEEN 0 AND 10),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)
CREATE TABLE Distributors
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30) ,
[Description] NVARCHAR(200) ,
OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
ProductId INT FOREIGN KEY REFERENCES Products(Id),
IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id)
PRIMARY KEY(ProductId,IngredientId)
)

--2.	Insert
INSERT INTO Distributors VALUES
('Deloitte & Touche',	'6 Arch St #9757',	'Customizable neutral traveling',	2),
('Congress Title'	,'58 Hancock St	Customer ','loyalty',13	),
('Kitchen People'	,'3 E 31st St #77','	Triple-buffered stable delivery',1	),
('General Color Co Inc'	,'6185 Bohn St #72','	Focus group'	,21),
('Beck Corporation'	,'21 E 64th Ave	','Quality-focused 4th generation hardware',23	)

INSERT INTO Customers VALUES
('Francoise','Rautenstrauch','M',15,'0195698399',5),
('Kendra','Loud','F',22,'0063631526',11),
('Lourdes','Bauswell','M',50,'0139037043',8),
('Hannah','Edmison','F',18,'0043343686',1),
('Tom','Loeza','M',31,'0144876096',23),
('Queenie','Kramarczyk','F',30,'0064215793',29),
('Hiu','Portaro	','M',25,'0068277755',16),
('Josefa','Opitz','F',43,'0197887645',17)

--03. Update

UPDATE Ingredients
SET DistributorId=35 
WHERE [Name] IN('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId=14 
WHERE OriginCountryId=8

--04. Delete

DELETE Feedbacks
WHERE CustomerId=14 OR ProductId=5

--05. Products By Price
SELECT Products.Name,Products.Price ,Products.Description FROM Products
ORDER BY Products.Price DESC,Products.Name

--6.	Negative Feedback
SELECT f.ProductId,f.Rate,f.Description,c.Age,c.Gender FROM Feedbacks AS f
JOIN Customers AS c ON c.Id=f.CustomerId

WHERE f.Rate<5.0
ORDER BY f.ProductId DESC,f.Rate

--7.	Customers without Feedback
SELECT c.FirstName+' '+c.LastName AS [CustomerName],c.PhoneNumber,c.Gender FROM Customers AS c
LEFT JOIN Feedbacks AS f ON f.CustomerId=c.Id
WHERE f.Id IS NULL
ORDER BY c.Id
--8.	Customers by Criteria
SELECT c.FirstName,c.Age,c.PhoneNumber FROM Customers AS c
WHERE c.Age>=21 AND c.FirstName LIKE '%an%' OR c.PhoneNumber LIKE '%38' AND c.CountryId != 31
ORDER BY c.FirstName,c.Age

--9.	Middle Range Distributors
SELECT d.Name AS DistributorName,i.Name AS IngredientName,p.Name AS ProductName,AVG(f.Rate) AS AverageRate FROM Distributors AS d
		LEFT JOIN Ingredients AS i ON i.DistributorId=d.Id
		LEFT JOIN ProductsIngredients AS pri ON pri.IngredientId=i.Id
		LEFT JOIN Products AS p ON p.Id=pri.ProductId
		LEFT JOIN Feedbacks AS f ON f.ProductId=pri.ProductId
		
		GROUP BY d.Name,i.Name,p.Name
		HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY DistributorName,IngredientName,ProductName

--10.	Country Representative
SELECT temp.CountryName ,temp.DisributorName  FROM 
(
SELECT c.Name AS CountryName,
	   d.Name AS DisributorName,
	   DENSE_RANK () OVER(PARTITION BY c.Name ORDER BY COUNT(i.id) DESC )
	   AS [rank] FROM Countries AS c

JOIN Distributors AS d ON d.CountryId=c.Id
LEFT JOIN Ingredients AS i ON i.DistributorId=d.Id
GROUP BY c.Name, d.Name

) 
AS temp

WHERE [rank]=1
ORDER BY temp.CountryName, temp.DisributorName

--11.	Customers with Countries
CREATE VIEW v_UserWithCountries AS
SELECT c.FirstName+' '+c.LastName AS CustomerName,c.Age,c.Gender,co.Name FROM Customers AS c
 JOIN Countries AS co ON co.Id=c.CountryId

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --12.	Delete Products

 CREATE TRIGGER tr_DeleteProduct ON Products  
 INSTEAD OF DELETE
 AS

 DECLARE @idDelete INT=(SELECT Id FROM deleted )

 DELETE ProductsIngredients
 WHERE ProductId=@idDelete

 DELETE  Feedbacks
 WHERE ProductId=@idDelete

  DELETE Products
 WHERE Id=@idDelete
 
