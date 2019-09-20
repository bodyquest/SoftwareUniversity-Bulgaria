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
   ALTER COLUMN ManagerID INT --TODO
   
GO

EXECUTE usp_DeleteEmployeesFromDepartment 1
GO

/******************************
Problem 9. 
*******************************/



/******************************
Problem 10. 
*******************************/



/******************************
Problem 11. 
*******************************/



/******************************
Problem 12. 
*******************************/



/******************************
Problem 13. 
*******************************/



/******************************
Problem 14. 
*******************************/



/******************************
Problem 15. 
*******************************/




/******************************
Problem 16. 
*******************************/




/******************************
Problem 17. 
*******************************/




/******************************
Problem 18. 
*******************************/



/******************************
Problem 19. 
*******************************/



/******************************
Problem 20. 
*******************************/



/******************************
Problem 21. 
*******************************/

