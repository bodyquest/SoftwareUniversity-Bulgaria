CREATE DATABASE RentACar;
GO

USE RentACar
GO
/**************************
 Problem 1. Database Design
***************************/

CREATE TABLE Clients
(
      Id INT IDENTITY
	, FirstName NVARCHAR (30) NOT NULL
	, LastName NVARCHAR (30) NOT NULL
	, Gender CHAR (1)
	, BirthDate DATETIME
	, CreditCard NVARCHAR(30) NOT NULL
	, CardValidity DATETIME
	, Email NVARCHAR (50) NOT NULL

	CONSTRAINT PK_Clients
	PRIMARY KEY (Id),

	CONSTRAINT CHK_Clients_Gender
	CHECK (Gender = 'M' OR Gender = 'F')
)

CREATE TABLE Towns
(
      Id INT IDENTITY
	, [Name] NVARCHAR (50) NOT NULL

	CONSTRAINT PK_Towns
	PRIMARY KEY (Id)
)

CREATE TABLE Offices
(
      Id INT IDENTITY
	, [Name] NVARCHAR (40)
	, ParkingPlaces INT
	, TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL

	CONSTRAINT PK_Offices
	PRIMARY KEY (Id)
)

CREATE TABLE Models
(
      Id INT IDENTITY
	, Manufacturer NVARCHAR (50) NOT NULL
	, Model NVARCHAR (50) NOT NULL
	, ProductionYear DATETIME
	, Seats INT
	, Class NVARCHAR (10)
	, Consumption DECIMAL (14, 2)

	CONSTRAINT PK_Models
	PRIMARY KEY (Id)
)

CREATE TABLE Vehicles
(
      Id INT IDENTITY
	, ModelId INT FOREIGN KEY REFERENCES Models(Id) NOT NULL
	, OfficeId INT FOREIGN KEY REFERENCES Offices(Id) NOT NULL
	, Mileage INT

	CONSTRAINT PK_Vehicles
	PRIMARY KEY (Id)
)

CREATE TABLE Orders
(
      Id INT IDENTITY
	, ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
	, TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
	, VehicleId INT FOREIGN KEY REFERENCES Vehicles(Id) NOT NULL
	, CollectionDate DATETIME NOT NULL
	, CollectionOfficeId INT FOREIGN KEY REFERENCES Offices (Id) NOT NULL
	, ReturnDate DATETIME
	, ReturnOfficeId INT FOREIGN KEY REFERENCES Offices (Id)
	, Bill DECIMAL (14, 2)
	, TotalMileage INT

	CONSTRAINT PK_Orders
	PRIMARY KEY (Id)
)


/*****************
 Problem 2. Insert
******************/

INSERT INTO Models (Manufacturer, Model, ProductionYear, Seats, Class, Consumption)
VALUES
  ('Chevrolet', 'Astro', '2005-07-27 00:00:00.000', 4, 'Economy', 12.60)
, ('Toyota', 'Solara', '2009-10-15 00:00:00.000', 7, 'Family', 13.80)
, ('Volvo', 'S40', '2010-10-12 00:00:00.000', 3, 'Average', 11.30)
, ('Suzuki', 'Swift', '2000-02-03 00:00:00.000', 7, 'Economy', 16.20)

INSERT INTO Orders(ClientId, TownId, VehicleId, CollectionDate, CollectionOfficeId, ReturnDate, ReturnOfficeId, Bill, TotalMileage)
VALUES
(17, 2, 52, '2017-08-08', 30, '2017-09-04 ', 42, 2360.00, 7434)
,(78, 17, 50, '2017-04-22', 10, '2017-05-09 ', 12, 2326.00, 7226)
,(27, 13, 28, '2017-04-25', 21, '2017-05-09 ', 34, 597.00, 1880)

/*****************
 Problem 3. Update
******************/
SELECT * FROM dbo.Clients
SELECT * FROM dbo.Models
SELECT * FROM dbo.Offices
SELECT * FROM dbo.Towns
SELECT * FROM dbo.Vehicles
SELECT * FROM dbo.Orders

UPDATE Models
SET [Class] = 'Luxury'
WHERE [Consumption] > 20

/*****************
 Problem 4. Delete
******************/
DELETE 
FROM Orders
WHERE ReturnDate IS NULL


/*******************
Section 3. QUERYING
 Problem 5. Showroom
********************/
SELECT Manufacturer, Model
FROM Models
ORDER BY Manufacturer, Id DESC

/***********************
 Problem 6. Y Generation
************************/
SELECT FirstName, LastName
FROM Clients
WHERE YEAR(BirthDate) BETWEEN YEAR('1977') AND YEAR('1994')
ORDER BY FirstName, LastName, Id

/**************************
 Problem 7. Spacious Office
***************************/
SELECT 
  t.[Name] AS [TownName]
  , o.[Name] AS OfficeName
  , o.ParkingPlaces
FROM Offices AS o
JOIN Towns AS t ON o.TownId = t.Id
WHERE ParkingPlaces > 25
ORDER BY [TownName], o.Id

/*****************************
 Problem 8. Available Vehicles
******************************/
SELECT 
      m.Model
	, m.Seats
	, v.Mileage
 FROM Models AS m
 JOIN Vehicles AS v ON m.Id = v.ModelId
WHERE v.Id NOT IN 
  (SELECT o.VehicleId 
     FROM Orders AS o 
	 WHERE o.ReturnDate IS NULL
  )
ORDER BY v.Mileage, m.Seats DESC, m.Id

/***************************
 Problem 9. Offices per Town
****************************/
SELECT 
      t.[Name] AS TownName
	, COUNT (*) AS OfficesNumber
  FROM Towns AS t
  JOIN Offices AS o ON t.Id = o.TownId
GROUP BY t.[Name], o.TownId
ORDER BY OfficesNumber DESC, TownName

/******************************
 Problem 10. Buyers Best Choice
*******************************/
SELECT Manufacturer, Model, SUM (CountOfOrdersById) AS TimesOrdered
FROM
(SELECT 
       m.Manufacturer
	 , m.Model
	 , COUNT(v.Id) AS CountOfOrdersById
   FROM Models AS m
   LEFT JOIN Vehicles AS v ON m.Id = v.ModelId
   RIGHT JOIN Orders AS o ON v.Id = o.VehicleId
   GROUP BY m.Model, m.Manufacturer, v.Id
) AS H1
GROUP BY Manufacturer, Model 
ORDER BY TimesOrdered DESC, Manufacturer DESC, Model

/************************
 Problem 11. Kinda Person
*************************/
SELECT Names, Class
FROM (
      SELECT 
      CONCAT(c.FirstName, ' ', c.LastName) AS [Names]
    , m.Class AS Class
	, RANK () OVER (PARTITION BY CONCAT(c.FirstName, ' ', c.LastName) ORDER BY COUNT(m.Class) DESC) AS [Rank]
  FROM Orders AS o
  JOIN Clients AS c ON c.Id = o.ClientId
  JOIN Vehicles AS v ON v.Id = o.VehicleId
  JOIN Models As m ON m.Id = v.ModelId
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), m.Class
) AS H1
WHERE [Rank] = 1
ORDER BY [Names], Class

/******************************
 Problem 12. Age Groups Revenue
*******************************/
SELECT AgeGroup =
  CASE
      WHEN YEAR (c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
      WHEN YEAR (c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
      WHEN YEAR (c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
	  ELSE 'Others'
  END
  , SUM(o.Bill) AS Revenue
  , AVG (o.TotalMileage) AS AverageMileage
FROM Clients AS c
JOIN Orders AS o ON o.ClientId = c.Id
GROUP BY
  CASE
      WHEN YEAR (c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
      WHEN YEAR (c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
      WHEN YEAR (c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
	  ELSE 'Others'
  END
ORDER BY AgeGroup

/*******************************
 Problem 13. Consumption in Mind
********************************/
SELECT Manufacturer, AverageConsumption
FROM (SELECT TOP (7) 
        m.Model
	  , m.Manufacturer
	  , AVG(m.Consumption) AS AverageConsumption
	  , COUNT (m.Model) AS [Counter]
  FROM Orders AS o
  JOIN Vehicles AS v ON v.Id = o.VehicleId
  JOIN Models AS m ON m.Id = v.ModelId
GROUP BY m.Manufacturer, m.Model
ORDER BY [Counter] DESC
) AS H
WHERE AverageConsumption BETWEEN 5 AND 15
ORDER BY Manufacturer, AverageConsumption

/***********************
 Problem 14. Debt Hunter
 ***********************/
SELECT [Names], Emails, Bills, TownsName
FROM (
    SELECT
          ROW_NUMBER() OVER (PARTITION BY t.[name] ORDER BY o.Bill DESC) AS     OrderByHighestBill
        , CONCAT(c.FirstName, ' ', c.LastName) AS [Names]
		, c.Id AS ClientId
    	, c.Email AS Emails
		, o.Bill AS Bills
		, t.[Name] AS TownsName
    FROM Clients AS c
    JOIN Orders AS o ON c.Id = o.ClientId
    JOIN Towns AS t ON o.TownId = t.Id
    WHERE c.CardValidity < o.CollectionDate AND o.Bill IS NOT NULL
) AS H
WHERE OrderByHighestBill IN (1, 2)
ORDER BY TownsName, Bills, ClientId

/***************************
 Problem 15. Town Statistics
 ***************************/
 
 SELECT 
       t.[Name] AS TownName
     , SUM (H.M) * 100 / (ISNULL(SUM(H.M), 0) + ISNULL(SUM(H.F), 0)) AS MalePercent
     , SUM (H.F) * 100 / (ISNULL(SUM(H.M), 0) + ISNULL(SUM(H.F), 0))AS FemalePercent
 FROM (
	  SELECT o.TownId
	         , CASE WHEN (Gender = 'M') THEN COUNT(o.Id) ELSE NULL END AS M
			 , CASE WHEN (Gender = 'F') THEN COUNT(o.Id) ELSE NULL END AS F
	  FROM Orders AS o
	  JOIN Clients AS c ON o.ClientId = c.Id
	  GROUP BY c.Gender, o.TownId
) AS H
JOIN Towns AS t ON t.Id = H.TownId
GROUP BY t.[Name]
GO
/***************************
 Problem 16. Home Sweet Home
 ***************************/
WITH cte_Ranks (ReturnOfficeId, OfficeId, Id, Manufacturer, Model)
AS
(
   SELECT 
		  RankedByDateDesc.ReturnOfficeId	  
		  , RankedByDateDesc.OfficeId	  
		  , RankedByDateDesc.Id	  
		  , RankedByDateDesc.Manufacturer	  
		  , RankedByDateDesc.Model
   FROM
   (
	   SELECT 
			DENSE_RANK() OVER (PARTITION BY v.Id ORDER BY o.CollectionDate DESC)   
			AS LatestRentCarsRank
		  , o.ReturnOfficeId
 		 , v.OfficeId	  , v.Id
 		 , m.Manufacturer
 		 , m.Model
	   FROM Orders AS o
	   RIGHT JOIN Vehicles As v ON o.VehicleId = v.Id
	   JOIN Models AS m ON m.Id = v.ModelId
   )   AS RankedByDateDesc
   WHERE LatestRentCarsRank = 1
)

SELECT CONCAT (Manufacturer, ' - ', Model) AS Vehicle
	 , [Location] = 
	 CASE
		 WHEN 
		 (
			SELECT COUNT(*)
			FROM Orders AS o
			WHERE o.VehicleId = cte_Ranks.Id
		 ) = 0  -- TODO
		 THEN 'home'
		 WHEN
		 (
			cte_Ranks.ReturnOfficeId IS NULL
		 )
		 THEN 'on a rent'
		 WHEN
		 (
			cte_Ranks.ReturnOfficeId != cte_Ranks.OfficeId
		 )
		 THEN(
			SELECT CONCAT (t.[Name], ' - ', o.[Name])
			FROM Towns AS t
			JOIN Offices AS o ON t.Id = o.TownId
			WHERE o.Id = cte_Ranks.ReturnOfficeId
		 )
	  END
FROM cte_Ranks
ORDER BY Vehicle, cte_Ranks.Id
GO
/************************
 Problem 17. Find My Ride
 ************************/

 CREATE FUNCTION udf_CheckForVehicle
(
      @townName NVARCHAR (MAX)
	, @seatsNumber INT
)
RETURNS NVARCHAR (50)
BEGIN
   DECLARE @result VARCHAR(100) =
   (
       SELECT TOP (1)
   	      CONCAT(o.[Name], ' - ', m.Model)
       FROM Vehicles AS v
   	JOIN Offices AS o ON v.OfficeId = o.Id
   	JOIN Towns AS t ON o.TownId = t.Id
   	JOIN Models AS m ON v.ModelId = m.Id
       WHERE m.Seats = @seatsNumber AND t.[Name] = @townName
   	ORDER BY o.[Name]
   )
   
   IF (@result IS NULL)
   BEGIN
        RETURN 'NO SUCH VEHICLE FOUND';
   END
   
   RETURN @result;
END
GO

/**************************
 Problem 18. Move a Vehicle
 **************************/

CREATE PROCEDURE usp_MoveVehicle
(
     @vehicleId INT
   , @officeId  INT
)
AS
    BEGIN
	  BEGIN TRANSACTION

	  UPDATE Vehicles
	  SET OfficeId = @officeId
	  WHERE Id = @vehicleId

	  DECLARE @countVehiclesById INT =
	  (SELECT COUNT(v.Id) FROM Vehicles AS v WHERE v.OfficeId = @officeId)

	  DECLARE @parkingPlaces INT = 
	  (SELECT ParkingPlaces FROM Offices AS o WHERE o.Id = @officeId)

	  IF(@countVehiclesById > @parkingPlaces)
	  BEGIN
		 ROLLBACK
		 RAISERROR ('Not enough room in this office!', 16, 1)
		 RETURN
	  END

	  COMMIT
    END;
GO

EXEC usp_MoveVehicle 7, 32;
SELECT OfficeId FROM Vehicles WHERE Id = 7
GO

/**************************
 Problem 19. Move the Tally
 **************************/

CREATE TRIGGER tr_UMoveTheTally ON Orders FOR UPDATE
AS
BEGIN
   DECLARE @newTotalMileage INT = 
   (SELECT TotalMileage FROM inserted)

   DECLARE @oldTotalMileage INT =
   (SELECT TotalMileage FROM deleted)

   DECLARE @vehicleId INT = 
   (SELECT VehicleId FROM inserted)

   IF (@oldTotalMileage IS NULL AND @vehicleId IS NOT NULL)
   BEGIN
        UPDATE Vehicles
		SET Mileage += @newTotalMileage 
		WHERE Id = @vehicleId
   END
END
GO

