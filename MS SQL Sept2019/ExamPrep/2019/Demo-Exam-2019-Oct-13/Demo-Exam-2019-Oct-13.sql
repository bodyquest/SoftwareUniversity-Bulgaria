--Problem 1
USE Master

CREATE DATABASE Bitbucket
USE Bitbucket

CREATE TABLE Users
(
     Id INT PRIMARY KEY IDENTITY
   , Username VARCHAR(30) UNIQUE NOT NULL
   , [Password] VARCHAR(30) NOT NULL
   , Email VARCHAR (50) NOT NULL
)

CREATE TABLE Repositories
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (50) NOT NULL
)

CREATE TABLE RepositoriesContributors 
(
     RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
   , ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL

   , CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
     Id INT PRIMARY KEY IDENTITY
   , Title VARCHAR (255) NOT NULL
   , IssueStatus CHAR(6) NOT NULL
   , RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
   , AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
     Id INT PRIMARY KEY IDENTITY
   , [Message] VARCHAR (255) NOT NULL
   , IssueId INT FOREIGN KEY REFERENCES Issues(Id)
   , RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
   , ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR(100) NOT NULL
   , Size DECIMAL (18, 2) NOT NULL
   , ParentId INT
   , CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL

   , CONSTRAINT FK_Files_Files FOREIGN KEY (ParentId) REFERENCES Files (Id)
)

--Problem 2
INSERT INTO Files ([Name], Size, ParentId, CommitId)
VALUES
 ('Trade.idk', 2598.0, 1, 1)
,('menu.net', 9238.31, 2, 2)
,('Administrate.soshy', 1246.93, 3, 3)
,('Controller.php', 7353.15, 4,	4)
,('Find.java', 9957.86, 5, 5)
,('Controller.json', 14034.87, 3, 6)
,('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
  ('Critical Problem with HomeController.cs file', 'open', 1, 4)
, ('Typo fix in Judge.html', 'open', 4, 3)
, ('Implement documentation for UsersService.cs', 'closed', 8, 2)
, ('Unreachable code in Index.cs', 'open', 9, 8)

--Problem 3

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--Problem 4
DELETE
FROM RepositoriesContributors
WHERE RepositoryId IN (Select Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE
FROM Issues
WHERE RepositoryId IN (Select Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

--Problem 5
SELECT 
     Id
   , [Message]
   , RepositoryId
   , ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

--Problem 6
SELECT
     Id
   , [Name]
   , Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

--Problem 7

SELECT 
     i.Id AS [Id]
   , CONCAT (u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, [IssueAssignee]

--Problem 8

SELECT
     pf.Id
   , pf.[Name]
   , pf.Size
FROM Files AS f
RIGHT JOIN Files AS pf ON f.ParentId = pf.Id
WHERE f.Id IS NULL
ORDER BY pf.Id, pf.[Name], pf.Size DESC

--Problem 9

SELECT TOP (5)
     r.Id
   , r.[Name]
   , COUNT(c.Id) AS [Commits]
FROM Repositories AS r
JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
JOIN Users AS u ON rc.ContributorId = u.Id
JOIN Commits AS c ON r.Id = c.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]


--Problem 10

SELECT
     u.Username
   , AVG(f.Size) AS [Size]
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY [Size] DESC, u.Username

--Problem 11
GO
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR (30))
RETURNS INT
AS
   BEGIN
		DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = @username)
		DECLARE @count INT = 
		(
		  SELECT
		   COUNT (Id)
		  FROM Commits
		  WHERE ContributorId = @userId
		)
	    
		RETURN @count
   END
GO

--Problem 12
CREATE PROCEDURE usp_FindByExtension (@extension VARCHAR (10))
AS
  BEGIN
	   SELECT
		   Id
		 , [Name]
		 , CONCAT (Size, 'KB') AS [Size]
	   FROM Files
	   WHERE [Name] LIKE CONCAT('%', @extension)
  END
GO

EXEC usp_FindByExtension 'txt'