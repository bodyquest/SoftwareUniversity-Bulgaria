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
