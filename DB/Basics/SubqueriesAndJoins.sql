--Problem 1
SELECT TOP(5) Employees.EmployeeID, Employees.JobTitle,Employees.AddressID, Addresses.AddressText FROM Employees 
JOIN Addresses ON Employees.AddressID=Addresses.AddressID
ORDER BY Addresses.AddressID

--Problem 2
SELECT TOP(50) Employees.FirstName,Employees.LastName, Towns.Name,Addresses.AddressText
FROM((Employees JOIN Addresses ON Employees.AddressID=Addresses.AddressID)
JOIN Towns ON Addresses.TownID=Towns.TownID)
ORDER BY FirstName,LastName

--Problem 3
SELECT e.EmployeeID,e.FirstName,e.LastName,d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d On d.DepartmentID=e.DepartmentID
WHERE d.Name='Sales'
ORDER BY e.EmployeeID

--Problem 4
SELECT TOP(5)Employees.EmployeeID,Employees.FirstName,Employees.Salary,Departments.Name FROM Employees
JOIN Departments ON Employees.DepartmentID=Departments.DepartmentID
WHERE Employees.Salary>15000
ORDER BY Departments.DepartmentID

--Problem 5 Може и с LEFT JOIN
SELECT TOP(3)  e.EmployeeID,e.FirstName 
FROM Employees AS e
FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--Problem 6
SELECT Employees.FirstName,Employees.LastName,Employees.HireDate, Departments.Name FROM Employees
JOIN Departments ON Employees.DepartmentID=Departments.DepartmentID 
WHERE Employees.HireDate>'1999-1-1'
AND Departments.Name='Sales' OR Departments.Name='Finance'
ORDER BY Employees.HireDate

--Problem 7
SELECT TOP(5) e.EmployeeID,e.FirstName,p.Name FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
JOIN Projects AS p ON ep.ProjectID=p.ProjectID
WHERE p.StartDate>'2002-08-13' or p.StartDate IS NULL
ORDER BY e.EmployeeID

--Problem 8
SELECT e.EmployeeID,e.FirstName,CASE
WHEN p.StartDate>='2005'
THEN 'NULL'
ELSE p.Name
END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID=e.EmployeeID
JOIN Projects AS p ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID=24

--Problem 9
SELECT e.EmployeeID,
       e.FirstName,
       e.ManagerID,
       m.FirstName AS ManagerName
FROM Employees AS e
     JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

--Problem 10
SELECT TOP (50) e.EmployeeID,
                e.FirstName+' '+e.LastName AS EmployeeName,
                m.FirstName+' '+m.LastName AS ManagerName,
                d.Name AS DepartmentName
FROM Employees AS e
     JOIN Employees AS m ON e.ManagerID = m.EmployeeID
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--Problem 11
SELECT TOP(1) AVG(Salary) AS MinAverageSalary FROM Employees 
GROUP BY DepartmentID 
ORDER BY MinAverageSalary

SELECT MIN(asbd.AverageSalary)
FROM
(
    SELECT AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
) AS asbd

--Problem 12
SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode=c.CountryCode
JOIN Mountains AS m ON m.Id=mc.MountainId
JOIN Peaks AS p ON p.MountainId=m.Id
WHERE Elevation>2835 AND c.CountryCode='BG'
ORDER BY Elevation DESC

--Problem 13
SELECT Countries.CountryCode,COUNT(m.MountainRange) AS MountainRanges FROM Countries
JOIN MountainsCountries ON Countries.CountryCode=MountainsCountries.CountryCode
JOIN Mountains AS m ON m.Id=MountainsCountries.MountainId
WHERE Countries.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY Countries.CountryCode

--Problem 14

SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c


LEFT JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers AS r ON r.Id=cr.RiverId
 JOIN Continents AS con ON c.ContinentCode=con.ContinentCode
WHERE con.ContinentName ='Africa' 

ORDER BY c.CountryName
--Problem 15
SELECT ContinentCode,CurrencyCode,CurrencyUsage 

FROM(

SELECT ContinentCode,
CurrencyCode ,
  COUNT(CurrencyCode) AS [CurrencyUsage],
 DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC)
AS Ranked
FROM
Countries 
  GROUP BY ContinentCode, CurrencyCode

) AS k
  WHERE k.Ranked=1 AND k.CurrencyUsage>1
    ORDER BY K.ContinentCode
    
--Problem 16
SELECT  COUNT(c.CountryCode) AS [Count] FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
WHERE mc.CountryCode IS NULL

--Problem 17
SELECT TOP 5 c.CountryName, 
	   MAX(p.Elevation) AS [HighestPeakElevation], 
	   MAX(r.Length) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks As p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC,
		[LongestRiverLength] DESC,
		c.CountryName 
              
--Problem 18*              
