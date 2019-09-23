USE SoftUni
GO
/*******************************************
Problem 1. Employees with Salary Above 35000
********************************************/
CREATE PROCEDURE usp_GetEmployeeSalaryAbove35000
AS
   SELECT FirstName, LastName
   FROM Employees
   WHERE Salary > 35000
GO
EXECUTE usp_GetEmployeeSalaryAbove35000
GO

/********************************************
Problem 2. Employees with Salary Above Number
*********************************************/
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber
(
   @salaryAboveNum DECIMAL(18,4)
)
AS
   SELECT FirstName, LastName
   FROM Employees
   WHERE Salary >= @salaryAboveNum
GO
EXECUTE usp_GetEmployeesSalaryAboveNumber 48100
GO
 
/*********************************
Problem 3. Town Name Starting With
**********************************/

CREATE PROCEDURE usp_GetTownsStartingWith
(
   @input VARCHAR(10) --b
)
AS
  SELECT [Name]
  FROM Towns
  WHERE [Name] LIKE @input + '%'
GO

EXECUTE usp_GetTownsStartingWith 'b'
GO

/******************************
Problem 4. Employees from Town
*******************************/

CREATE PROCEDURE usp_GetEmployeesFromTown
(
   @townName VARCHAR(MAX)
)
AS
  SELECT e.FirstName, e.LastName
  FROM Employees AS e
  JOIN Addresses AS a ON e.AddressID = a.AddressID
  JOIN Towns As t ON t.TownID = a.TownID
  WHERE t.[Name] = @townName
GO

EXECUTE usp_GetEmployeesFromTown 'Sofia'
GO

/*******************************
Problem 5. Salary Level Function
********************************/

CREATE FUNCTION ufn_GetSalaryLevel
(
     @Salary DECIMAL(18,4)
)
RETURNS VARCHAR(10)
AS
     BEGIN
         DECLARE @Result VARCHAR(10);

         IF(@Salary < 30000)
             SET @Result = 'Low';
             ELSE
             IF(@Salary <= 50000)
                 SET @Result = 'Average';
                 ELSE
                 SET @Result = 'High';

         RETURN @Result;
     END;
GO

SELECT 
     FirstName
   , LastName
   , Salary
   , dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM 
     Employees;
GO

/***********************************
Problem 6. Employees by Salary Level
************************************/

CREATE PROCEDURE usp_EmployeesBySalaryLevel
(
   @salaryLevel VARCHAR(10)
)
AS
  SELECT
         FirstName
	   , LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

GO

EXECUTE usp_EmployeesBySalaryLevel 'High'
GO

/*************************
Problem 7. Define Function
**************************/

CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR (MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
  DECLARE @count INT = 1

  WHILE (@count <= LEN(@word))
  BEGIN
  DECLARE @currentLetter CHAR (1) = SUBSTRING(@word, @count, 1)
  DECLARE @charIndex INT = CHARINDEX(@currentLetter, @setOfLetters)
  IF (@charIndex = 0)
    RETURN 0

	SET @count +=1
  END
  RETURN 1

END
GO

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised ('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised ('pppp', 'Guy')
GO

/******************************************
Problem 8. Delete Employees and Departments
*******************************************/
-- alter table Departments - set ManagerId column NULL
-- delete from EmployeesProjects
-- update department setManagerId column = NULL
-- delete from Employees where depId = depId
-- delete from dep where Id = Id

 CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
 (
   @departmentId INT
 )
 AS
   ALTER TABLE Departments
   ALTER COLUMN ManagerID INT

   DELETE FROM EmployeesProjects
   WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

   UPDATE Departments
   SET ManagerID = NULL
   WHERE ManagerID IN (Select EmployeeID FROM Employees WHERE DepartmentID = @departmentId) 

   UPDATE Employees
   SET ManagerID = NULL
   WHERE DepartmentID = @departmentId

   DELETE FROM Employees
   WHERE DepartmentID = @departmentId

   DELETE FROM Departments 
   WHERE DepartmentID = @departmentId

   SELECT Count(*)
   FROM Employees
   WHERE DepartmentID = @departmentId
GO

EXECUTE usp_DeleteEmployeesFromDepartment 1
GO
--TODO Restore Database

/******************************
Problem 9. Queries for Bank Database
*******************************/
USE Bank
GO
CREATE PROCEDURE usp_GetHoldersFullName
AS
  SELECT
         FirstName + ' ' + LastName AS FullName
FROM AccountHolders
GO

EXECUTE usp_GetHoldersFullName
GO

/******************************************
Problem 10. People with Balance Higher Than
*******************************************/

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan
(
   @balanceLowerLimit DECIMAL (18,4)
)
AS
  SELECT filtered.FirstName, filtered.LastName
  FROM
  (
      SELECT
             ah.Id
           , ah.FirstName
		   , ah.LastName
      FROM AccountHolders AS ah
      JOIN Accounts AS a ON ah.Id = a.AccountHolderId
      GROUP BY ah.Id, ah.FirstName, ah.LastName
      HAVING SUM(a.Balance) > @balanceLowerLimit
  ) AS filtered
ORDER BY filtered.FirstName, filtered.LastName
GO

EXECUTE usp_GetHoldersWithBalanceHigherThan 50000
GO

/********************************
Problem 11. Future Value Function
*********************************/
USE Bank
GO
CREATE FUNCTION ufn_CalculateFutureValue
(
     @sum DECIMAL (18,4)
   , @yearlyInterestRate FLOAT
   , @numberOfyears INT
)
RETURNS DECIMAL (18, 4)
BEGIN
     RETURN @sum *POWER((1 + @yearlyInterestRate), @numberOfyears)
END
GO

SELECT dbo.ufn_CalculateFutureValue (10000, 0.035, 20)
GO

/*******************************
Problem 12. Calculating Interest
********************************/

CREATE PROCEDURE usp_CalculateFutureValueForAccount
(
     @accountId INT
   , @yearlyInterestRate FLOAT
)
AS
  SELECT
         a.Id AS [Account Id]
       , ah.FirstName AS [First Name]
	   , ah.LastName AS [Last Name]
	   , a.Balance AS [Current Balance]
	   , dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5)
FROM Accounts AS a
JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
WHERE a.Id = @accountId
GO

EXECUTE usp_CalculateFutureValueForAccount 1, 0.1
GO

/*******************************************************
Problem 13. Scalar Function: Cash in User Games Odd Rows
********************************************************/

CREATE FUNCTION ufn_CashInUsersGames
(
     @gameName VARCHAR(MAX)
)
RETURNS TABLE
RETURN
(
    SELECT      
         SUM(result.Cash) AS SumCash
    FROM          
    (
        SELECT  
             g.[Name]
           , ug.Cash
           , ROW_NUMBER() OVER(
             ORDER BY 
             Cash DESC) AS RowNumber
        FROM  
             Games AS g
             JOIN UsersGames AS ug ON g.Id = ug.GameId
        WHERE g.[Name] = @gameName
    ) AS result
    WHERE result.RowNumber % 2 = 1
);
GO

SELECT 
     *
FROM 
     dbo.ufn_CashInUsersGames('Love in a mist');
GO

/****************************
Problem 14. Create Table Logs
*****************************/
USE Bank
GO

CREATE TABLE Logs
(
     LogId INT PRIMARY KEY IDENTITY
   , AccountId INT FOREIGN KEY REFERENCES Accounts (Id)
   , OldSum DECIMAL (15, 2)
   , NewSum DECIMAL (15, 2)
)
GO

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
  DECLARE @newSum DECIMAL (15, 2) = (SELECT Balance FROM inserted)
  DECLARE @oldSum DECIMAL (15, 2) = (SELECT Balance FROM deleted)
  DECLARE @accountId INT = (SELECT Id FROM inserted)

  INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES (@accountId, @newSum, @oldSum)
GO

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

SELECT *
FROM Accounts WHERE Id = 1

SELECT *
FROM Logs
/******************************
Problem 15. CREATE TABLE Emails
*******************************/
CREATE TABLE NotificationEmails
(
   Id INT PRIMARY KEY IDENTITY
   , Recipient INT FOREIGN KEY REFERENCES Accounts (Id)
   , [Subject] VARCHAR (50) NOT NULL
   , Body VARCHAR (MAX) 
)
GO

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
  DECLARE @accountId INT = (SELECT TOP (1) AccountId FROM inserted)
  DECLARE @oldSum DECIMAL (15, 2) = (SELECT TOP (1) OldSum FROM inserted)
  DECLARE @newSum DECIMAL (15, 2) = (SELECT TOP (1) NewSum FROM inserted)

  INSERT INTO NotificationsEmails (Recipient, [Subject], Body) VALUES
  (
	  @accountId
	  , 'Balance change for account: ' + CAST(@accountId AS VARCHAR (20))
	  , 'On ' + CONVERT(VARCHAR (20), GETDATE(), 103)  + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20))
  )

  UPDATE ccounts 
  SET Balance += 100
  WHERE Id = 1
GO

/************************
Problem 16. Deposit Money
*************************/

CREATE PROCEDURE usp_DepositMmoney
(
     @accountId      INT
   , @moneyAmount DECIMAL(15, 4)
)
AS
    BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

	IF (@account IS NULL)
	BEGIN
	     ROLLBACK
		 RAISERROR ('Invalid account ID!', 16, 1)
		 RETURN
	END

	IF(@moneyAmount < 0)
	BEGIN
	     ROLLBACK
		 RAISERROR ('Negative amount!', 16, 1)
		 RETURN
	END

    UPDATE Accounts
      SET  
          Balance += @moneyAmount
    WHERE   
         Id = @accountId
    COMMIT
GO

EXECUTE usp_DepositMmoney 1, 250
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails
GO
/******************************
Problem 17. Withdraw Money
*******************************/
CREATE PROCEDURE usp_WithdrawMoney
(
      @AccountId INT
	, @MoneyAmount DECIMAL (15, 4)
)
AS
  BEGIN TRANSACTION
      DECLARE @Account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)
      DECLARE @AccountBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF (@Account IS NULL)
	BEGIN
	     ROLLBACK
		 RAISERROR ('Invalid account ID!', 16, 1)
		 RETURN
	END

	IF(@MoneyAmount < 0)
	BEGIN
	     ROLLBACK
		 RAISERROR ('Negative amount!', 16, 1)
		 RETURN
	END

	IF(@AccountBalance - @MoneyAmount < 0)
	BEGIN
	     ROLLBACK
		 RAISERROR ('Insufficient funds!', 16, 1)
		 RETURN
	END

	UPDATE Accounts
	  SET  
          Balance -= @MoneyAmount
    WHERE   
         Id = @AccountId
  COMMIT
GO

EXECUTE usp_WithdrawMoney 1, 20
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails
GO

/**************************
Problem 18. Money Transfer
***************************/
CREATE PROCEDURE usp_TransferMoney 
(
      @SenderId INT
	, @ReceiverId INT
	, @Amount DECIMAL (15, 4)
)
AS
  BEGIN TRANSACTION
      EXECUTE usp_WithdrawMoney @SenderId, @Amount
      EXECUTE usp_DepositMmoney @ReceiverId, @Amount
  COMMIT
GO

SELECT Id AS [AccountId], AccountHolderId, Balance FROM Accounts
WHERE Id = 1 OR Id = 2
EXECUTE usp_TransferMoney 1, 2, 100
GO

/******************************
Problem 19. 
*******************************/



/******************************
Problem 20. 
*******************************/



/******************************
Problem 21. 
*******************************/

