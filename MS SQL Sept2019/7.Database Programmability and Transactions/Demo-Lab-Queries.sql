/************************
Create Functions (scalar)
************************/

CREATE FUNCTION udf_ProjectDurationWeeks
(
     @StartDate DATETIME
   , @EndDate   DATETIME
)
RETURNS INT
AS
     BEGIN
         DECLARE @projectWeeks INT;
         IF(@EndDate IS NULL)
             BEGIN
                 SET @EndDate = GETDATE();
         END;
		 SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
		 RETURN @projectWeeks;
     END;
GO

SELECT 
	[Name]
	, dbo.udf_ProjectDurationWeeks(StartDate, EndDate) AS Duration
FROM Projects
GO

/***************************************************
Create Functions (TVF) - Inline Table Value Function
****************************************************/

CREATE FUNCTION udf_AverageSalaryByDepartment ()
RETURNS TABLE
AS
     RETURN
(
    SELECT 
         d.[Name] AS Department
       , AVG(e.Salary) AS AverageSalary
    FROM 
         Departments AS d
         JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
	WHERE [Name] = @DepartmentName
    GROUP BY 
         d.DepartmentID
       , d.[Name]
);
GO


SELECT 
     *
FROM 
     dbo.udf_AverageSalaryByDepartment('Sales')
GO;

/**************************************************************
Create Functions (MSTVF) - Multi-Statement Table Value Function
***************************************************************/

CREATE FUNCTION udf_EmployeeListByDepartment
(
     @DepName NVARCHAR(20)
)
RETURNS @result TABLE
(
     FirstName NVARCHAR(50) NOT NULL
   , LastName  NVARCHAR(50) NOT NULL
   , JobTitle  NVARCHAR(20) NOT NULL
)
AS
     BEGIN
         WITH Employees_CTE(
              FirstName
            , LastName
            , DepartmentName)
              AS (SELECT 
                       e.FirstName
                     , e.LastName
                     , d.[Name]
                  FROM 
                       Employees AS e
                       LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID)

              INSERT INTO @result
              SELECT  
                   FirstName
                 , LastName
                 , DepartmentName
              FROM  
                   Employees_CTE
              WHERE DepartmentName = @DepName;
         RETURN;
     END;
GO

/*****************************
Problem: Salary Level Function
******************************/

CREATE FUNCTION ufn_GetSalaryLevel
(
     @Salary MONEY
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

/*************************************
CLR Functions: Common Language Runtime
**************************************/

/*****************************************************
Stored Procedures: Named Sequences of T-SQL statements
******************************************************/

CREATE PROCEDURE usp_GetSeniorEmployees
AS
     SELECT  
          *
     FROM  
          Employees
     WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 18
GO

EXEC dbo.usp_GetSeniorEmployees
GO

------------------------------
/*************************
Altering Stored Procedures
*************************/

ALTER PROC usp_GetSeniorEmployees
AS
     SELECT  
          FirstName
        , LastName
        , HireDate
        , DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOfService
     FROM  
          Employees
     WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 18
     ORDER BY 
          HireDate;
GO

/*************************
Dropping Stored Procedures
*************************/

DROP PROC 
     usp_GetSeniorEmployees;
GO

/*********************************
System Procedures for Dependencies
*********************************/

EXEC sp_depends 
     'Employees';

EXEC sp_depends 
     usp_GetSeniorEmployees;
GO


/********************************
Defining Parameterized Procedures
********************************/

CREATE OR ALTER PROCEDURE usp_GetSeniorEmployees
(
     @YearsOfService INT = 5
)
AS
     SELECT  
          FirstName
        , LastName
        , HireDate
        , DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOfService
     FROM  
          Employees
     WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @YearsOfService
     ORDER BY 
          HireDate;
GO

EXEC usp_GetSeniorEmployees 10;
GO

EXEC usp_GetSeniorEmployees
     @SecretText = 'Some text'
   , @YearsOfService = 16;
GO

/***************************************
Returning Values Using OUTPUT Parameters
****************************************/
CREATE PROCEDURE dbo.usp_AddNumbers
      @firstNumber SMALLINT
    , @secondNumber SMALLINT
    , @result INT OUTPUT
AS
    SET @result = @firstNumber + @secondNumber
GO

DECLARE @result INT
EXECUTE usp_AddNumbers 8, 12, @result OUT -- or OUTPUT
SELECT @result
GO

----------------------------------------
DECLARE @result INT
DECLARE @fnum INT
DECLARE @snum INT

SET @fnum = 4
SET @snum = 7

EXECUTE usp_AddNumbers @fnum, @snum, @result OUT
SELECT CONCAT(@fnum, ' + ', @snum, ' = ', @result) AS Result
GO

/*************
Error Handling
**************/
SELECT @@ERROR

BEGIN TRY
  -- generating a divide by zero
  SELECT 1/0
END TRY
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber
  , ERROR_SEVERITY() AS ErrorSeverity
  , ERROR_STATE() AS ErrorState
  , ERROR_PROCEDURE() AS ErrorProcedure
  , ERROR_LINE() AS ErrorLine
  , ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO

-------------------------------------
CREATE PROCEDURE dbo.usp_AddNumbers
      @firstNumber SMALLINT
    , @secondNumber SMALLINT
    , @result INT OUTPUT
AS
    BEGIN TRY
      SET @result = @firstNumber / @secondNumber
    END TRY
	BEGIN CATCH
	    SELECT 
		ERROR_NUMBER() AS ErrorNumber
      , ERROR_LINE() AS ErrorLine
      , ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
GO
