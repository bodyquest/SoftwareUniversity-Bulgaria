--PROBLEM 1. DDL

CREATE DATABASE Supermarket
USE Supermarket

CREATE TABLE Categories
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] NVARCHAR (30) NOT NULL
)

CREATE TABLE Items
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (30) NOT NULL
   , Price DECIMAL (18, 2) NOT NULL
   , CategoryId INT FOREIGN KEY REFERENCES Categories (Id) NOT NULL
)

CREATE TABLE Employees
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName NVARCHAR (50) NOT NULL
   , LastName NVARCHAR (50) NOT NULL
   , Phone CHAR(12) NOT NULL
   , Salary DECIMAL (14, 2) NOT NULL
)

CREATE TABLE Shifts
(
     Id INT PRIMARY KEY IDENTITY
   , EmployeeId INT FOREIGN KEY REFERENCES Employees (Id)
   , CheckIn DATETIME NOT NULL
   , CheckOut DATETIME NOT NULL

   , CONSTRAINT ck_CheckOutAfterCheckIn CHECK (CheckIn < CheckOut)
)

CREATE TABLE Orders
(
     Id INT PRIMARY KEY IDENTITY
   , [DateTime] DATETIME NOT NULL
   , EmployeeId INT FOREIGN KEY REFERENCES Employees (Id) NOT NULL
)

CREATE TABLE OrderItems
(
     OrderId INT FOREIGN KEY REFERENCES Orders (Id) NOT NULL
   , ItemId INT FOREIGN KEY REFERENCES Items (Id) NOT NULL
   , Quantity INT CHECK (Quantity >= 1) NOT NULL

   , CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
)
GO

/******   DML  ******/
-- PROBLEM 2.
INSERT INTO Employees (FirstName, LastName, Phone, Salary)
VALUES
  ('Stoyan', 'Petrov', '888-785-8573', 500.25)
, ('Stamat', 'Nikolov', '789-613-1122', 999995.25)
, ('Evgeni', 'Petkov', '645-369-9517', 1234.51)
, ('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items ([Name], Price, CategoryId)
VALUES
  ('Tesla battery', 154.25, 8)
, ('Chess', 30.25, 8)
, ('Juice', 5.32, 1)
, ('Glasses ', 10, 8)
, ('Bottle of water', 1, 1)

-- Problem 3.
UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1, 2, 3)

-- Problem 4.
DELETE
FROM OrderItems
WHERE OrderId = 48

DELETE
FROM Orders
WHERE Id = 48

--QUERYING
-- Problem 5.

SELECT
     Id
   , FirstName
FROM Employees 
WHERE Salary > 6500
ORDER BY FirstName, Id

--Problem 6.
SELECT
     CONCAT(FirstName, ' ', LastName) AS [Full Name]
   , Phone AS [Phone NUmber]
FROM Employees 
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

--Problem 7.

SELECT
     FirstName
   , LastName
   , COUNT(o.EmployeeId) AS Count
FROM Employees AS e
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY FirstName, LastName
ORDER BY COUNT(o.EmployeeId) DESC, e.FirstName

-- Problem 8.
SELECT 
     result.FirstName
   , result.LastName
   , result.[Work hours]
FROM (SELECT
     e.FirstName
   , e.LastName
   , e.Id
   , AVG (DATEDIFF(HOUR, s.CheckIn,s.CheckOut)) AS [Work hours]
FROM Employees AS e
JOIN Shifts AS s ON e.Id = s.EmployeeId
GROUP BY FirstName, LastName, e.Id
HAVING AVG (DATEDIFF(HOUR, s.CheckIn,s.CheckOut)) > 7
) AS result
ORDER BY result.[Work hours] DESC, result.Id

--Problem 9.
SELECT TOP(1)
     oi.OrderId AS [OrderId]
   , SUM (i.Price * oi.Quantity) AS [TotalPrice]
FROM OrderItems AS oi
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY oi.OrderId
ORDER BY [TotalPrice] DESC

--Problem 10.
SELECT
     o.Id AS [OrderId]
   , MAX(i.Price)
   , MIN(i.Price)
FROM Orders AS o
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY o.Id
ORDER BY MAX(i.Price) DESC, o.Id

--Problem 11.

SELECT 
       result.EmployeeId
	 , result.FirstName
	 , result.LastName
FROM(
	  SELECT
	        o.EmployeeId
          , e.FirstName
          , e.LastName
FROM Employees AS e
JOIN Orders AS o ON e.Id = o.EmployeeId
GROUP BY o.EmployeeId, e.FirstName, e.LastName
) AS result
ORDER BY result.EmployeeId

--Problem 12.

SELECT
     e.Id
   , CONCAT(e.FirstName, ' ', e.LastName) AS [Fill Name]
FROM Employees AS e
JOIN Shifts AS s ON e.Id = s.EmployeeId
WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

--Problem 13.

SELECT
      CONCAT (e.FirstName, ' ', e.Lastname) AS [Full Name]
	, SUM(i.Price * oi.Quantity) AS [Total Price]
	, SUM(oi.Quantity) AS [Items]
FROM Employees AS e
JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
WHERE o.[DateTime] < '2018-06-15'
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, [Items] DESC


--Problem 14.
SELECT 
     CONCAT (e.FirstName, ' ', e.Lastname) AS [Full Name]
   , DATENAME(DW, s.CheckIn) AS [Day of week]
FROM Employees AS e
LEFT JOIN Orders AS o ON e.Id = o.EmployeeId
JOIN Shifts AS s ON e.Id = s.EmployeeId
WHERE o.EmployeeId IS NULL AND DATEDIFF(HOUR, s.CheckIn,s.CheckOut) > 12
ORDER BY e.Id

--Problem 15.
SELECT 
     result.[Full Name]
   , DATEDIFF(HOUR, s.CheckIn,s.CheckOut) AS [WorkHours]
   , result.TotalPrice
FROM
(
   SELECT 
        o.Id AS OrderID
	  , e.Id AS EmployeeId
	  , o.[DateTime]
      , CONCAT (e.FirstName, ' ', e.Lastname) AS [Full Name]
      , SUM(i.Price * oi.Quantity) AS [TotalPrice]
	  , ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM(i.Price * oi.Quantity) DESC) AS RowNumber
   FROM Employees AS e
   JOIN Orders AS o ON e.Id = o.EmployeeId
   JOIN OrderItems AS oi ON o.Id = oi.OrderId
   JOIN Items AS i ON oi.ItemId = i.Id
   GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.[DateTime]
) AS result
JOIN Shifts AS s ON result.EmployeeId = s.EmployeeId
WHERE result.RowNumber = 1 AND result.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY result.[Full Name]
       , WorkHours DESC
	   , result.TotalPrice DESC

--Problem 16.

SELECT 
     DATEPART(DAY, o.[DateTime]) AS [Day]
   , FORMAT(AVG(i.Price * oi.Quantity), 'N2') AS [Total profit]
FROM Orders AS o
JOIN OrderItems AS oi ON o.Id = oi.OrderId
JOIN Items AS i ON oi.ItemId = i.Id
GROUP BY DATEPART(DAY, o.[DateTime])
ORDER BY [Day]

--Problem 17.
SELECT 
     i.[Name] AS Item
   , c.[Name] AS Category
   , SUM (oi.Quantity) AS [Count]
   , SUM(i.Price * oi.Quantity) AS [TotalPrice]
FROM Items AS i
JOIN Categories AS c ON i.CategoryId = c.Id
LEFT JOIN OrderItems AS oi ON i.Id = oi.ItemId
GROUP BY i.[Name], c.[Name]
ORDER BY [TotalPrice] DESC, [Count] DESC


GO
/*********  PROGRAMMABILITY  ********/
--18.Problem
CREATE FUNCTION udf_GetPromotedProducts
(@CurrentDate DATE, @StartDate DATE, @EndDate DATE, @Discount DECIMAL (10, 2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR (MAX)
BEGIN
     DECLARE @firstItemName VARCHAR(20) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
     DECLARE @secondItemName VARCHAR(20) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
     DECLARE @thirdItemName VARCHAR(20) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)
     
     IF(@firstItemName IS NULL OR @secondItemName IS NULL OR @thirdItemName IS NULL)
     BEGIN
	      RETURN 'One of the items does not exists!'
     END
     
     IF(@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
     BEGIN
	      RETURN 'The current date is not within the promotion dates!'
     END
     
	 DECLARE @firstItemPrice DECIMAL (15, 2) = (SELECT Price FROm Items WHERE Id = @FirstItemId)
	 DECLARE @secondItemPrice DECIMAL (15, 2) = (SELECT Price FROm Items WHERE Id = @SecondItemId)
	 DECLARE @thirdItemPrice DECIMAL (15, 2) = (SELECT Price FROm Items WHERE Id = @ThirdItemId)

	 SET @firstItemPrice = @firstItemPrice - (@firstItemPrice * (@Discount/100))
	 SET @secondItemPrice = @secondItemPrice - (@secondItemPrice * (@Discount/100))
	 SET @thirdItemPrice = @thirdItemPrice - (@thirdItemPrice * (@Discount/100))

     RETURN CONCAT(@firstItemName, ' price: ', CAST(@firstItemPrice AS VARCHAR(10)), ' <-> ', @secondItemName, ' price: ', CAST(@secondItemPrice AS VARCHAR(10)), ' <-> ', @thirdItemName, ' price: ', CAST(@thirdItemPrice AS VARCHAR(10)))
END
GO

--19.Problem
CREATE PROCEDURE usp_CancelOrder
(@OrderId INT, @CancelDate DATETIME)
AS
  BEGIN
       DECLARE @targetOrder INT = (SELECT Id FROM Orders WHERE Id = @OrderId)
	   DECLARE @purchaseDate DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)

	   IF(@targetOrder IS NULL)
	   BEGIN
			RAISERROR ('The order does not exist!', 16, 1)
			RETURN
	   END

	   IF(@CancelDate > DATEADD(DAY, 3, @purchaseDate))
	   BEGIN
	        RAISERROR ('You cannot cancel the order!', 16, 2)
			RETURN
	   END

	   DELETE FROM OrderItems
	   WHERE OrderId = @OrderId

	   DELETE FROM Orders
	   WHERE Id = @OrderId

  END
GO