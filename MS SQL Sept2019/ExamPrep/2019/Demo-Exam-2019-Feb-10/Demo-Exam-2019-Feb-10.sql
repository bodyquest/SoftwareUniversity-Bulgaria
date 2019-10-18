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

--12. Select All Educational 
SELECT 
     p.[Name] AS PlanetName
   , sp.[Name] AS SpaceportName
FROM Planets as p
JOIN Spaceports as sp ON p.Id = sp.PlanetId
JOIN Journeys as j ON sp.Id = j.DestinationSpaceportId
WHERE j.Purpose = 'Educational'
ORDER BY SpaceportName DESC


--13. Planets And Journeys 
SELECT 
     p.[Name] AS PlanetName
   , COUNT(j.Id) AS JourneysCount
FROM Planets as p
JOIN Spaceports as sp ON p.Id = sp.PlanetId
JOIN Journeys as j ON sp.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, p.[Name]

--14. Extract The Shortest 
SELECT TOP(1)
     j.Id
   , p.[Name] AS PlanetName
   , sp.[Name] AS SpaceportName
   , j.Purpose AS JourneyPurpose
FROM Planets as p
JOIN Spaceports as sp ON p.Id = sp.PlanetId
JOIN Journeys as j ON sp.Id = j.DestinationSpaceportId
ORDER BY DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd)

--15. Select The Less Popular Job 
SELECT TOP(1)
     tc.JourneyId
   , tc.JobDuringJourney AS JobName
FROM TravelCards AS tc
WHERE tc.JourneyId =
    (
	    SELECT TOP(1)
           j.Id
        FROM Journeys AS j
        ORDER BY DATEDIFF(MINUTE, j.JourneyStart, j.JourneyEnd) DESC
    )
GROUP BY tc.JobDuringJourney, tc.JourneyId
ORDER BY COUNT (tc.JobDuringJourney)


--16. Select Special Colonists

SELECT
     Ranked.JobDuringJourney
   , CONCAT (c.FirstName, ' ', c.LastName) AS FullName
   , Ranked.JobRank
FROM (SELECT 
     tc.JobDuringJourney
   , tc.ColonistId
   , DENSE_RANK () OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.Birthdate) AS JobRank
FROM TravelCards AS tc
JOIN Colonists AS c ON tc.ColonistId = c.Id
GROUP BY tc.JobDuringJourney, tc.ColonistId, c.Birthdate
) AS Ranked
JOIN Colonists AS c ON Ranked.ColonistId = c.Id
WHERE Ranked.JobRank = 2
ORDER BY Ranked.JobDuringJourney

 --17. Planets and Spaceports

SELECT 
     p.[Name]
   , COUNT(sp.Id) AS [Count]
FROM Planets AS p
JOIN Spaceports AS sp ON p.Id = sp.PlanetId
GROUP BY p.[Name]
ORDER BY COUNT(sp.Id) DESC, p.[Name]

--18. Get Colonists Count
GO

CREATE FUNCTION udf_GetColonistsCount (@PlanetName VARCHAR (30))
RETURNS INT
AS
  BEGIN
	   DECLARE @planet VARCHAR(30) = (SELECT [Name] FROM Planets WHERE [Name] = @PlanetName)

	   RETURN (SELECT
		 COUNT(c.Id)
	   FROM Planets AS p
	   JOIN Spaceports AS sp ON p.Id = sp.PlanetId
	   JOIN Journeys AS j ON sp.Id = j.DestinationSpaceportId
	   JOIN TravelCards AS tc ON j.Id = tc.JourneyId
	   JOIN Colonists AS c ON tc.ColonistId = c.Id
	   WHERE p.[Name] = @PlanetName)
  END

--19. Change Journey Purpose
GO
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
  BEGIN
	   DECLARE @targetJourneyId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)
	   DECLARE @journeyPurpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @targetJourneyId)

	   IF(@targetJourneyId IS NULL)
		 BEGIN
			  RAISERROR ('The journey does not exist!', 16, 1)
		 END
	   
	   IF(@journeyPurpose = @NewPurpose)
	   BEGIN
			RAISERROR ('You cannot change the purpose!', 16, 2)
	   END

	   UPDATE Journeys
	   SET Purpose = @NewPurpose
	   WHERE Id = @JourneyId
  END
GO

--20. Deleted Journeys
CREATE TABLE DeletedJourneys
(
     Id INT
   , JourneyStart DATETIME
   , JourneyEnd DATETIME
   , Purpose VARCHAR (11)
   , DestinationPortId INT
   , SpaceshipId INT
)
GO

CREATE TRIGGER tr_DeletedJourneys
   ON Journeys
   AFTER DELETE
AS
  INSERT INTO DeletedJourneys (Id, JourneyStart, JourneyEnd, Purpose, DestinationPortId, SpaceshipId)
  SELECT Id,JourneyStart,JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted
GO;
