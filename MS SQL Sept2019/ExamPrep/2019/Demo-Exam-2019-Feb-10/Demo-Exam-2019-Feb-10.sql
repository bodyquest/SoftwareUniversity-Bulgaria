USE Master
-- Problem 1
CREATE DATABASE ColonialJourney
USE ColonialJourney

CREATE TABLE Planets
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR(50) NOT NULL
   , PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR(50) NOT NULL
   , Manufacturer VARCHAR (30) NOT NULL
   , LightSpeedRate INT DEFAULT(0)
)

CREATE TABLE Colonists
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName VARCHAR (20) NOT NULL
   , LastName VARCHAR (20) NOT NULL
   , Ucn VARCHAR (10) UNIQUE NOT NULL
   , BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
     Id INT PRIMARY KEY IDENTITY
   , JourneyStart DATETIME NOT NULL
   , JourneyEnd DATETIME NOT NULL
   , Purpose VARCHAR (11) CHECK (Purpose = 'Medical' OR Purpose = 'Technical' OR Purpose = 'Educational' OR Purpose = 'Military')
   , DestinationSpaceportId INT FOREIGN KEY REFERENCES SpacePorts (Id) NOT NULL
   , SpaceshipId INT FOREIGN KEY REFERENCES Spaceships (Id) NOT NULL
)

CREATE TABLE TravelCards
(
     Id INT PRIMARY KEY IDENTITY
   , CardNumber CHAR(10) UNIQUE NOT NULL
   , JobDuringJourney VARCHAR (8)
     CHECK
     (
	      JobDuringJourney = 'Pilot'
	    OR JobDuringJourney = 'Engineer'
	    OR JobDuringJourney = 'Trooper'
	    OR JobDuringJourney = 'Cleaner'
	    OR JobDuringJourney = 'Cook'
     )
   , ColonistId INT FOREIGN KEY REFERENCES Colonists (Id) NOT NULL
   , JourneyId INT FOREIGN KEY REFERENCES Journeys (Id) NOT NULL
)

--Problem 2
INSERT INTO Planets ([Name])
VALUES
  ('Mars')
, ('Earth')
, ('Jupiter')
, ('Saturn')

INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate)
VALUES
  ('Golf', 'VW', 3)
, ('WakaWaka', 'Wakanda', 4)
, ('Falcon9', 'SpaceX', 1)
, ('Bed', 'Vidolov', 6)

--Problem 3

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--Problem 4
DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2, 3)

--Problem 5
SELECT 
     CardNumber
   , JobDuringJourney
FROM TravelCards
ORDER BY CardNumber

--Problem 6
SELECT 
     Id
   , CONCAT (FirstName, ' ', LastName) AS FullName
   , Ucn
FROM Colonists
ORDER BY FirstName, LastName, Id


--Problem 7
SELECT
     Id
   , CONVERT(VARCHAR, JourneyStart, 103) AS JourneyStart
   , CONVERT(VARCHAR, JourneyEnd, 103) AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--Problem 8
SELECT 
     c.Id
   , CONCAT (c.FirstName, ' ', c.LastName) AS FullName
FROM Colonists as c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

--Probelm 9
SELECT 
     COUNT(c.Id) AS [Count]
FROM Colonists as c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

--Problem 10
SELECT TOP (1)
     s.[Name]
   , sp.[Name]
FROM Spaceships AS s
JOIN Journeys AS j ON s.Id = j.SpaceshipId
JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
ORDER BY s.LightSpeedRate DESC

--Problem 11
SELECT
     s.[Name]
   , s.Manufacturer
FROM Spaceships AS s
JOIN Journeys AS j ON s.Id = j.SpaceshipId
JOIN TravelCards AS tc ON j.Id = tc.JourneyId
JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
ORDER BY s.[Name]

--Problem 12
SELECT 
     p.[Name] AS PlanetName
   , sp.[Name] AS SpaceportName
FROM Planets as p
JOIN Spaceports as sp ON p.Id = sp.PlanetId
JOIN Journeys as j ON sp.Id = j.DestinationSpaceportId
WHERE j.Purpose = 'Educational'
ORDER BY SpaceportName DESC


--Problem 13