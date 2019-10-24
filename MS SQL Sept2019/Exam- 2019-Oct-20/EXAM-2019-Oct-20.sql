USE master

CREATE DATABASE [Service]

USE [Service]

/*********************
Problem 1. 
**********************/
CREATE TABLE Users
(
     Id INT PRIMARY KEY IDENTITY
   , Username VARCHAR (30) UNIQUE NOT NULL
   , [Password] VARCHAR (50) NOT NULL
   , [Name] VARCHAR (50)
   , Birthdate DATETIME
   , Age INT CHECK(Age BETWEEN 14 AND 110)
   , Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (50) NOT NULL
)

CREATE TABLE Employees
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName VARCHAR (25)
   , LastName VARCHAR (25)
   , Birthdate DATETIME
   , Age INT CHECK (Age BETWEEN 8 AND 110)
   , DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (50) NOT NULL
   , DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
     Id INT PRIMARY KEY IDENTITY
   , [Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
     Id INT PRIMARY KEY IDENTITY
   , CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
   , StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL
   , OpenDate DATETIME NOT NULL
   , CloseDate DATETIME
   , [Description] VARCHAR (200) NOT NULL
   , UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
   , EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

/*********************
Problem 2. Insert
**********************/
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
  ('Marlo', 'O''Malley', '1958-9-21', 1)
, ('Niki', 'Stanaghan', '1969-11-26', 4)
, ('Ayrton', 'Senna', '1960-03-21', 9)
, ('Ronnie', 'Peterson', '1944-02-14', 9)
, ('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
  (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2)
, (6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5)
, (14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2)
, (4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

/*********************
Problem 3. Update !!!!!!!!!!!!!!!!!! NOT SUBMITTED
**********************/

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

/*********************
Problem 4. Delete
**********************/

DELETE FROM Reports
WHERE StatusId = 4

/****************************
Problem 5. Unassigned Reports
*****************************/

SELECT
     r.[Description]
   , FORMAT(r.OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, r.[Description]


/*********************
Problem 6. 
**********************/
SELECT 
     r.[Description]
   , c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.[Description], c.[Name]

/*********************
Problem 7. 
**********************/

SELECT TOP (5)
     c.[Name] AS CategoryName
   , COUNT(r.Id) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

/*********************
Problem 8. 
**********************/

SELECT 
    u.Username
  , c.[Name] AS CategoryName
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE FORMAT(r.OpenDate, '%m-%d') = FORMAT(u.Birthdate, '%m-%d')
ORDER BY u.Username, CategoryName

/*********************
Problem 9.
**********************/

SELECT
     CONCAT (e.FirstName, ' ', e.LastName) AS FullName
   , CASE
	 WHEN COUNT(DISTINCT u.Id) = 0 THEN '0'
	 ELSE COUNT(DISTINCT u.Id)
	 END AS UsersCount
   
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY e.FirstName, e.LastName
ORDER BY COUNT(u.Id) DESC, FullName

/*********************
Problem 10. Full Info
**********************/

SELECT 
	 CASE 
	   WHEN e.FirstName IS NULL OR e.LastName IS NULL THEN 'None'
	   ELSE  CONCAT(e.FirstName, ' ', e.LastName)
       END AS Employee

   , CASE 
	   WHEN d.[Name] IS NULL THEN 'None'
	   ELSE d.[Name]
	   END AS Department

   , CASE 
	   WHEN  c.[Name] IS NULL THEN 'None'
	   ELSE  c.[Name]
	   END AS Category

   , CASE 
	   WHEN  r.[Description] IS NULL THEN 'None'
	   ELSE  r.[Description]
	   END AS [Description] 
   
   , FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate
   , s.[Label] AS [Status]
   , u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Categories as c ON r.CategoryId = c.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, [Description], r.OpenDate, [Status], [User]

/****************************
Problem 11. Hours to Complete
*****************************/
GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
  BEGIN
	   DECLARE @taskStart DATETIME = (SELECT OpenDate FROM Reports WHERE OpenDate = @StartDate)
	   DECLARE @taskEnd DATETIME = (SELECT CloseDate FROM Reports WHERE CloseDate = @EndDate)

	   IF(@taskStart IS NULL OR @taskEnd IS NULL)
		 BEGIN
			RETURN 0
		 END

	 RETURN ( SELECT DATEDIFF(HOUR, @StartDate, @EndDate) FROM Reports
	  WHERE OpenDate = @StartDate AND CloseDate = @EndDate)

  END
GO

/**************************
Problem 12. Assign Employee
***************************/

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
  BEGIN
	   DECLARE @employeeDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

	   DECLARE @reportDepartment INT =
	   (
			SELECT d.Id
			FROM Reports AS r
			JOIN Categories AS c ON r.CategoryId = c.Id
			JOIN Departments AS d ON c.DepartmentId = d.Id
			WHERE r.Id = @ReportId
	   )

	   IF(@employeeDepartment != @reportDepartment)
	     BEGIN
			RAISERROR ('Employee doesn''t belong to the appropriate department!', 16, 1)
			RETURN
		 END
	   
	   UPDATE Reports
	   SET EmployeeId = @EmployeeId
	   WHERE Id = @ReportId
  END
GO

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2

