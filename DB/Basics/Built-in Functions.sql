--Problem 1
SELECT FirstName,LastName FROM Employees
WHERE FirstName LIKE 'sa%'

--Problem 2
SELECT FirstName,LastName FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3
SELECT FirstName FROM Employees
WHERE (DepartmentID=3 OR DepartmentID=10)
AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

--Problem 4
SELECT FirstName,LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5
SELECT [Name] FROM Towns
WHERE LEN([Name])=5 OR LEN([Name])=6
ORDER BY [Name]

--Problem 6
SELECT TownID,[Name] FROM Towns
WHERE LEFT([Name],1)='M' 
OR LEFT([Name],1)='K'
OR LEFT([Name],1)='B'
OR LEFT([Name],1)='E'
ORDER BY [Name]

--Problem 7
SELECT TownID,[Name] FROM Towns
WHERE LEFT([Name],1) NOT LIKE '[RBD]'
ORDER BY [Name]

--Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,Lastname FROM Employees
WHERE DATEPART(YEAR,HireDate)>2000

--Problem 9
SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName)=5

--Problem 10
SELECT EmployeeID,FirstName,LastName,Salary, DENSE_RANK() OVER   
      (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]  
    FROM Employees   
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--Problem 11
SELECT*FROM(SELECT EmployeeID,FirstName,LastName,Salary, DENSE_RANK() OVER   
      (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]  
    FROM Employees   

	WHERE Salary BETWEEN 10000 AND 50000) AS MyTable
	WHERE [Rank]=2

	ORDER BY Salary DESC

--Problem 12
SELECT CountryName AS [Country Name],IsoCode AS [ISO Code] FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--Problem 13

SELECT Peaks.PeakName,
       Rivers.RiverName,
       LOWER(CONCAT(LEFT(Peaks.PeakName, LEN(Peaks.PeakName)-1), Rivers.RiverName)) AS Mix
FROM Peaks
     JOIN Rivers ON RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
ORDER BY Mix;

--Problem 14
SELECT TOP(50)[Name],FORMAT(CAST ([Start] AS DATE),'yyyy-MM-dd') AS [Start]FROM Games
WHERE DATEPART(YEAR,Start) BETWEEN 2011 AND 2012
ORDER BY [Start],[Name]

--Problem 15
SELECT Username,RIGHT(Email,LEN(Email)-CHARINDEX('@',Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider],Username

--Problem 16

SELECT Username,IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE'___.1_%._%.___'
ORDER BY Username

--Problem 17
SELECT [Name] AS [Games],
CASE
WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11
THEN 'Morning'
WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17
THEN 'Afternoon'
WHEN DATEPART(HOUR,[Start]) BETWEEN 18 AND 23
THEN 'Evening'
ELSE 'N/A'
END AS [Part of the Day],
CASE
WHEN Duration BETWEEN 0 AND 3
THEN 'Extra Short'
WHEN Duration BETWEEN 4 AND 6
THEN 'Short'
WHEN Duration >6
THEN 'Long'
WHEN Duration IS NULL
THEN 'Extra Long'
ELSE 'Error - must be unreachable case'
END AS [Duration]
FROM Games
ORDER BY [Name],[Duration],[Part of the Day]


		
	 
	 