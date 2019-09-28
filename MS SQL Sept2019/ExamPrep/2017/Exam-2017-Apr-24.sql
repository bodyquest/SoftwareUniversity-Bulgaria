CREATE DATABASE WMS;

USE WMS;

/***********
 Problem 1. 
***********/
--•	Clients – contains information about the customers that use the service
--•	Mechanics – contains information about employees
--•	Jobs – contains information about all machines that clients submitted for    repairs
--•	Models – list of all washing machine models that the servie operates with
--•	Orders – contains information about orders for parts
--•	Parts – list of all parts the service operates with
--•	OrderParts – mapping table between Orders and Parts with additional          Quantity field
--•	PartsNeeded – mapping table between Jobs and Parts with additional Quantity   field
--•	Vendors – list of vendors that supply parts to the service

CREATE TABLE Clients
(
      ClientId INT PRIMARY KEY IDENTITY
	, FirstName VARCHAR(50) NOT NULL
	, LastName VARCHAR(50) NOT NULL
	, Phone CHAR (12) NOT NULL
)

CREATE TABLE Mechanics
(
      MechanicId INT PRIMARY KEY IDENTITY
	, FirstName VARCHAR(50) NOT NULL
	, LastName VARCHAR(50) NOT NULL
	, [Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
      ModelId INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs -- after TABLE Models
(
      JobId INT PRIMARY KEY IDENTITY
	, ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL
	, [Status] VARCHAR(11) DEFAULT 'Pending' CHECK ([Status] = 'Pending' OR [Status] = 'In Progress' OR [Status] = 'Finished') NOT NULL
	, ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL
	, MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId)
	, IssueDate DATE NOT NULL
	, FinishDate DATE
)

CREATE TABLE Orders
(
      OrderId INT PRIMARY KEY IDENTITY
	, JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL
	, IssueDate DATE
	, Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
      VendorId INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
      PartId INT PRIMARY KEY IDENTITY
	, SerialNumber VARCHAR(50) NOT NULL UNIQUE
	, [Description] VARCHAR(255)
	, Price DECIMAL (6,2) NOT NULL CHECK (Price >= 1)
	, VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL
	, StockQty INT DEFAULT 0 NOT NULL CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
      OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL
	, PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL
	, Quantity INT DEFAULT 1 CHECK (Quantity >= 1) NOT NULL

	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
      JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL
	, PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL
	, Quantity INT DEFAULT 1 NOT NULL

	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

/*****************
 Problem 2. Insert
******************/
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Teri','Ennaco','570-889-5187')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Merlyn','Lawler','201-588-7810')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Georgene','Montezuma','925-615-5185')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Jettie','Mconnell','908-802-3564')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Lemuel','Latzke','631-748-6479')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Melodie','Knipp','805-690-1682')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Candida','Corbley','908-275-8357')

INSERT INTO Parts (PartId, SerialNumber, [Description], Price, VendorId, StockQty)
VALUES
('WP8182119','Door Boot Seal', 117.86,2),
('W10780048','Suspension Rod', 42.81,1),
('W10841140','Silicone Adhesive', 6.77,4),
('WPY055980','High Temperature Adhesive', 13.94,3)

/*****************
 Problem 3. Update
******************/
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'

/*****************
 Problem 4. Delete
******************/

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

/**************************
 Problem 5. Clients By Name
***************************/

SELECT 
     FirstName
   , LastName
   , Phone
FROM 
     Clients
ORDER BY 
     LastName
   , ClientId;

/*********************
 Problem 6. Job Status
**********************/

SELECT  
     [Status]
   , IssueDate
FROM  
     Jobs
WHERE [Status] != 'Finished'
ORDER BY 
     IssueDate
   , JobId;

/*******************************
 Problem 7. Mechanic Assignments
********************************/

SELECT 
     FirstName + ' ' + LastName AS [Mechanic]
   , j.[Status]
   , j.IssueDate
FROM 
     Mechanics AS m
     JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId;

/**************************
 Problem 8. Current Clients
***************************/
SELECT 
      c.FirstName + ' ' + c.LastName AS [Client]
	  , DATEDIFF (DAY, j.IssueDate, '2017-04-24') AS [Days going]
	  , j.[Status]
  FROM Clients AS c
  JOIN Jobs AS j ON c.ClientId = j.ClientId
  WHERE j.[Status] != 'Finished'
  ORDER BY [Days going] DESC, c.ClientId

/******************************
 Problem 9. Mechanic Perforance
*******************************/
SELECT 
       FirstName + ' ' + LastName AS [Mechanic]
	 , AVG(DATEDIFF (DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
  FROM Mechanics AS m
  JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName, m.LastName, m.MechanicId
ORDER BY m.MechanicId

/************************
 Problem 10. Hard Earners
*************************/

SELECT TOP (3)  
     FirstName + ' ' + LastName AS [Mechanic]
   , COUNT(j.JobId) AS [Jobs]
FROM  
     Mechanics AS m
     JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] != 'Finished'
GROUP BY 
     m.FirstName
   , m.LastName
   , m.MechanicId
HAVING COUNT(j.JobId) > 1
ORDER BY 
     [Jobs] DESC
   , m.MechanicId;

/*******************************
 Problem 11. Available Mechanics
********************************/
SELECT 
     FirstName + ' ' + LastName AS Available
FROM 
     Mechanics
     WHERE MechanicId NOT IN (SELECT MechanicId FROM Jobs WHERE [Status] != 'Finished' AND MechanicId IS NOT NULL)
ORDER BY MechanicId

/***********************
 Problem 12. 2017-Parts Cost
************************/
-- TODO
SELECT ISNULL (SUM(p.Price * op.Quantity), 0) AS [Parts Total] 
  FROM Parts AS p
  JOIN OrderParts AS op ON p.PartId = op.PartId
  JOIN Orders AS o ON op.OrderId = o.OrderId
WHERE DATEDIFF(WEEK, o.IssueDate, '2017-04-24') <= 3

/*************************
 Problem 13. Past Expenses
**************************/
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS [Total]
  FROM Jobs AS j
  LEFT JOIN Orders AS o ON j.JobId = o.JobId
  LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
  LEFT JOIN Parts as p ON op.PartId = p.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY [Total] DESC, j.JobId

/*****************************
 Problem 14. Model Repair Time
******************************/

SELECT 
     m.ModelId
   , [Name]
   , CAST(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS VARCHAR) + ' days' AS [Average Service Time]
FROM 
     Models AS m
     LEFT JOIN Jobs AS j ON m.ModelId = j.ModelId
GROUP BY 
     m.ModelId
   , m.[Name]
ORDER BY 
     AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate));

/*****************************
 Problem 15. Faultiest Model
******************************/

SELECT TOP 1 WITH TIES
     m.[Name]
   , COUNT(j.JobId) AS [Times Serviced]
   , (SELECT ISNULL (SUM(p.Price * op.Quantity), 0)
     FROM Orders AS o 
     JOIN OrderParts AS op ON o.OrderId = op.OrderId
     JOIN Parts as p ON op.PartId = p.PartId
	 JOIN Jobs AS j ON j.JobId = o.JobId
	 WHERE j.ModelId = m.ModelId) AS [Parts Total]
FROM 
     Models AS m
     JOIN Jobs AS j ON m.ModelId = j.ModelId
GROUP BY 
     m.[Name]
	 , m.ModelId
ORDER BY [Times Serviced] DESC

/*************************
 Problem 16. Missing Parts
**************************/

SELECT 
       p.PartId
	   , p.[Description]
	   , SUM(pn.Quantity) AS [Required]
	   , SUM(p.StockQty) AS [In Stock]
	   , ISNULL (SUM(op.Quantity), 0) AS [Ordered]
  FROM PARTS AS p
  JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
  JOIN Jobs AS j ON pn.JobId = j.JobId
  LEFT JOIN Orders AS o ON j.JobId = o.JobId
  LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
  WHERE j.[Status] != 'Finished'
GROUP BY p.PartId, p.[Description]
  HAVING SUM(p.StockQty) + ISNULL (SUM(op.Quantity), 0) < SUM(pn.Quantity)
ORDER BY p.PartId
GO
/*************************
 PROGRAMMABILITY PART
 Problem 17. Cost of Order
**************************/
CREATE FUNCTION udf_GetCost
(
    @jobId INT
)
RETURNS DECIMAL (10,2)
BEGIN
DECLARE @totalCost DECIMAL (10, 2) =
(
    SELECT SUM(p.Price * op.Quantity) 
      FROM Jobs AS j
      JOIN Orders AS o ON j.JobId = o.JobId
      JOIN OrderParts AS op ON o.OrderId = op.OrderId
      JOIN Parts AS p ON op.PartId = p.PartId
    WHERE j.JobId = @jobId
)

IF (@totalCost IS NULL)
BEGIN
     RETURN 0
END

RETURN @totalCost
END
GO

SELECT dbo.udf_GetCost(3)
GO

/***********************
 Problem 18. Place Order
************************/

CREATE PROCEDURE usp_PlaceOrder
(
      @jobId INT
	, @serialNumber VARCHAR(50)
	, @quantity INT
)
AS

BEGIN
    DECLARE @partId INT = 
	(
	    SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber
	)

	DECLARE @orderId INT = 
	(
	     SELECT TOP 1 OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL
    )

	IF((SELECT JobId FROM Jobs WHERE JobId = @jobId AND [Status] = 'Finished') IS NOT NULL)
	BEGIN
	     ;THROW 50011, 'This job isnot active', 1
	END

	IF(@quantity <= 0)
	BEGIN
	     ;THROW 50012, 'Part quantity must be more that zero!', 1
	END

	IF((SELECT JobId FROm Jobs WHERE JobId = @jobId) IS NULL)
	BEGIN
	     ;THROW 50013, 'Job not found!', 1
	END

	IF(@partId IS NULL)
	BEGIN
	     ;THROW 50014, 'Part not found!', 1
	END

	IF(@orderId IS NULL)
	BEGIN
	     INSERT INTO Orders (JobId, IssueDate) VALUES (@jobId, NULL)


		 INSERT INT OrderParts (OrderId, PartId, Quantity) VALUES ()
	END
END