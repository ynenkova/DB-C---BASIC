--Create Table Logs
CREATE TRIGGER tr_InsertInTable ON Accounts FOR UPDATE
AS 
BEGIN
INSERT INTO Logs(AccountId,OldSum,NewSum)
SELECT deleted.Id,deleted.Balance,inserted.Balance FROM deleted 
JOIN inserted ON deleted.Id=inserted.Id
END

--2.	Create Table Emails
CREATE TABLE  NotificationEmails
(
Id INT IDENTITY PRIMARY KEY,
Recipent INT FOREIGN KEY REFERENCES Logs(Id),
[Subject] VARCHAR(MAX),
Body VARCHAR(MAX)

)
 

CREATE TRIGGER tr_LogsInsert ON Logs FOR INSERT
AS

INSERT INTO NotificationEmails(Recipient,Subject,Body)
SELECT 
i.AccountId,
'Balance change for account: '+CONVERT(varchar,i.AccountId),
'On '+ CONVERT(varchar, GETDATE(), 0)+ ' your balance was changed from '+ CONVERT(varchar,i.OldSum)  +' to '+ CONVERT(varchar,i.NewSum)+'.'
FROM inserted AS i

--3.	Deposit Money
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(20,4)) 
AS
	BEGIN TRANSACTION
	DECLARE @account INT=(SELECT Accounts.Id FROM Accounts WHERE Accounts.Id=@AccountId)

	IF(@MoneyAmount<0 OR @account IS NULL)
	BEGIN
	ROLLBACK
	RAISERROR('Invalid operation',16,1)
	RETURN
	END

	UPDATE Accounts
	SET Balance+=@MoneyAmount
	WHERE Id=@AccountId

	COMMIT

--4.	Withdraw Money
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
     AS
  BEGIN TRANSACTION
 UPDATE Accounts
    SET Balance -= @MoneyAmount
  WHERE Id = @AccountId
DECLARE @LeftBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @AccountId)
	 IF(@LeftBalance < 0)
	  BEGIN
	   ROLLBACK
	   RAISERROR('',16,2)
	   RETURN
	  END
COMMIT

--5.	Money Transfer
CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT , @Amount DECIMAL(15,4))
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @senderId,@Amount
EXEC usp_DepositMoney @receiverId,@Amount
COMMIT

--6.	Trigger

CREATE TRIGGER tr_ItemsUsers ON Users 
INSTEAD OF UPDATE
AS
	BEGIN

	DECLARE @itemId INT=(SELECT ItemId FROM inserted)
	DECLARE @userGameId INT=(SELECT UserGameId FROM inserted)

	DECLARE @itemLevel INT=(SELECT MinLevel FROM Items WHERE Id=@itemId)
	DECLARE @userGameLevel INT=(SELECT Level FROM UsersGames WHERE Id=@itemId)

	IF(@userGameLevel>=@itemLevel)
	BEGIN
		INSERT INTO UserGameItems(ItemId,UserGameId) VALUES
		(@itemId,@userGameId)
	END

	UPDATE ug
  SET
      ug.Cash+=50000
FROM UsersGames AS ug
     JOIN Users AS u ON u.Id = ug.UserId
     JOIN Games AS g ON g.Id = ug.GameId
WHERE u.FirstName IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali'
END

--8.	Employees with Three Projects

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION

	DECLARE @empId INT=(SELECT Employees.EmployeeID FROM Employees WHERE EmployeeID=@emloyeeId)
	DECLARE @count INT=(SELECT COUNT(EmployeesProjects.ProjectID) FROM EmployeesProjects WHERE EmployeesProjects.EmployeeID=@emloyeeId)

	IF(@count>=3)
	BEGIN
	ROLLBACK
	RAISERROR ('The employee has too many projects!',16,1)
	RETURN
	END

	INSERT INTO EmployeesProjects VALUES
	(@emloyeeId,@projectID)

	COMMIT

--9. Delete Employees
CREATE TABLE Deleted_Employees
(
EmployeeId INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL, 
MiddleName NVARCHAR(50) , 
JobTitle NVARCHAR(50), 
DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
Salary DECIMAL(20,2)
) 

CREATE TRIGGER tr_DeleteEmployee ON Employees FOR DELETE
AS



 INSERT INTO Deleted_Employees(FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
 SELECT FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary FROM deleted