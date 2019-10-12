--Problem #1

CREATE DATABASE Airport
USE Airport

CREATE TABLE Planes
(
     [Id] INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR(30) NOT NULL
   , [Seats] INT NOT NULL
   , [Range] INT NOT NULL
)

CREATE TABLE Flights
(
     [Id] INT PRIMARY KEY IDENTITY
   , [DepartureTime] DATETIME 
   , [ArrivalTime] DATETIME
   , [Origin] VARCHAR(50) NOT NULL
   , [Destination] VARCHAR(50) NOT NULL

   --FK
   , PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
     [Id] INT PRIMARY KEY IDENTITY
   , [FirstName] VARCHAR(30) NOT NULL
   , [Lastname] VARCHAR(30) NOT NULL
   , [Age] INT NOT NULL
   , [Address] VARCHAR(30) NOT NULL
   , [PassportId] CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
     [Id] INT PRIMARY KEY IDENTITY
   , [Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
     [Id] INT PRIMARY KEY IDENTITY

	 --FK
   , [LuggageTypeId] INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL
   , [PassengerId] INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
     [Id] INT PRIMARY KEY IDENTITY
   , [PassengerId] INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL

   --FK
   , [FlightId] INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL
   , [LuggageId] INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL

   , [Price] DECIMAL (18, 2) NOT NULL
)


--Problem #2
INSERT INTO Planes ([Name], [Seats], [Range])
VALUES
('Airbus 336', 112, 5132)
,('Airbus 330', 432, 5325)
,('Boeing 369', 231, 2355)
,('Stelt 297',  254, 2143)
,('Boeing 338', 165, 5111)
,('Airbus 558', 387, 1342)
,('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type])
VALUES
('Crossbody Bag')
,('School Backpa')
,('Shoulder Bag')


--Problem #3

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Carlsbad')

--Problem #4

DELETE 
FROM Tickets
WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE
FROM Flights
WHERE Destination = 'Ayn Halagim'

--Problem #5

SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

--Problem #6

SELECT
      FlightId
	, SUM(Price)
FROM Tickets
GROUP BY FlightId
ORDER BY SUM(Price) DESC, FlightId


--Problem #7
SELECT 
     CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name]
   , f.Origin
   , f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights As f ON t.FlightId = f.Id
ORDER BY [Full Name], f.Origin, f.Destination

--Problem #8

SELECT 
     p.FirstName AS [First Name]
   , p.LastName AS [Last Name]
   , p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC, [First Name], [Last Name]

--Problem #9

SELECT 
     CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name]
   , pl.[Name] AS [Plane Name]
   , CONCAT(f.Origin, ' - ', f.Destination) AS Trip
   , lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

--Problem #10
SELECT
     pl.[Name]
   , pl.Seats
   , COUNT(t.FlightId) AS [Passengers Count]
FROM Planes AS pl
LEFT JOIN Flights AS f ON pl.Id = f.PlaneId
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC, pl.[Name], pl.Seats


--Problem #11


--Problem #12