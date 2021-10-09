--Problem 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
 SELECT Employees.FirstName,Employees.LastName FROM Employees WHERE Employees.Salary>35000
END
EXEC usp_GetEmployeesSalaryAbove35000 

--Problem 2

CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS
BEGIN

SELECT Employees.FirstName,Employees.LastName FROM Employees WHERE Employees.Salary>=@number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Problem 3

CREATE PROC usp_GetTownsStartingWith(@Start NVARCHAR(20)) AS
	SELECT Name AS Town FROM Towns 
	WHERE Name LIKE @Start + '%'
EXEC usp_GetTownsStartingWith b

--Problem 4

CREATE PROC usp_GetEmployeesFromTown(@Town NVARCHAR(50)) AS 
	SELECT FirstName, LastName FROM Employees AS e
	JOIN Addresses AS a 
		ON e.AddressID = a.AddressID
	JOIN Towns AS t 
		ON t.TownID = a.TownID
	WHERE t.Name = @Town

EXEC usp_GetEmployeesFromTown 'Sofia'

--Problem 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(50) 
AS
BEGIN
DECLARE @result NVARCHAR(50)

IF(@salary<30000)
SET @result= 'Low'

ELSE IF(@salary>=30000 AND @salary<=50000)
SET @result='Average'

ELSE	
SET @result='High'

RETURN @result
END

SELECT dbo.ufn_GetSalaryLevel (13500.00) AS [Salary Level]
SELECT dbo.ufn_GetSalaryLevel (43300.00) AS [Salary Level]
SELECT dbo.ufn_GetSalaryLevel (125500.00) AS [Salary Level]

--Problem 6
CREATE PROC usp_EmployeesBySalaryLevel (@level NVARCHAR(50))
AS
	BEGIN
	SELECT Employees.FirstName,Employees.LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary)=@level
	END

	EXEC usp_EmployeesBySalaryLevel 'High'

--Problem 7

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
RETURNS BIT
AS
BEGIN

DECLARE @Index INT= 1;	

	WHILE (@Index <= LEN(@Word))
		BEGIN
			
			IF CHARINDEX(SUBSTRING(@Word, @Index, 1), @SetOfLetters) = 0 
			BEGIN
				RETURN 0
			END 
				SET @Index += 1;
		END

			RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS [Result]
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS [Result]
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob') AS [Result]
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy') AS [Result]

--Problem 8
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN 

DELETE EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID=@departmentId)

UPDATE Employees
SET ManagerID=null
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID=@departmentId)

ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

UPDATE Departments
	SET ManagerID = NULL 
	WHERE DepartmentID = @DepartmentId

DELETE  Employees
WHERE Employees.DepartmentID=@departmentId 

DELETE Departments
WHERE DepartmentID=@departmentId

SELECT COUNT(*) FROM Employees
WHERE DepartmentID=@departmentId
END

--Problem 9
CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
SELECT FirstName + ' ' + LastName AS [Full Name] FROM AccountHolders
END

--Problem 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(15,2))
AS
BEGIN
SELECT a.FirstName,a.LastName FROM AccountHolders AS a
JOIN Accounts AS ac On a.Id=ac.AccountHolderId

GROUP BY a.FirstName,a.LastName

HAVING SUM(ac.Balance)>@number

ORDER BY a.FirstName,a.LastName

END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 30000

--Problem 11

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,2),@rate FLOAT,@nimberOfyears INT)
RETURNS DECIMAL(15,4) AS
BEGIN

DECLARE @Result DECIMAL(15,4)=@sum*POWER((1+@rate),@nimberOfyears)

RETURN @Result

END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--Problem 12
CREATE PROC usp_CalculateFutureValueForAccount (@id INT, @rate FLOAT)
AS
BEGIN
SELECT ac.Id,ac.FirstName,ac.LastName,a.Balance, dbo.ufn_CalculateFutureValue(a.Balance,@rate,5) AS [Balance in 5 years] 
FROM AccountHolders AS ac
JOIN Accounts AS a ON a.AccountHolderId=ac.Id AND a.id=@id
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--Problem 13
CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(155)) 
RETURNS TABLE AS

RETURN SELECT SUM(Cash) AS SumCash FROM (SELECT UsersGames.Cash,ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowOdd FROM UsersGames
JOIN Games AS g ON g.Id=UsersGames.GameId
WHERE g.Name=@gamename
) AS Game
WHERE RowOdd%2=1



SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

