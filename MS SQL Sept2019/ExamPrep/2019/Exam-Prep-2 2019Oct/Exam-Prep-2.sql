--Problem #1
CREATE DATABASE School
USE School

CREATE TABLE Subjects
(
     Id INT PRIMARY KEY IDENTITY
   , [Name] NVARCHAR(20) NOT NULL
   , Lessons INT NOT NULL CHECK(Lessons > 0)
)

CREATE TABLE Teachers
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName NVARCHAR(20) NOT NULL
   , LastName NVARCHAR(20) NOT NULL
   , [Address] NVARCHAR(20) NOT NULL
   , Phone CHAR(10)
   , SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE Exams
(
     Id INT PRIMARY KEY IDENTITY
   , [Date] DATETIME
   , SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE Students
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName NVARCHAR(30) NOT NULL
   , MiddleName NVARCHAR(25)
   , LastName NVARCHAR(30) NOT NULL
   , Age INT NOT NULL CHECK (Age > 0)
   , [Address] NVARCHAR(50)
   , Phone CHAR(10)
)

CREATE TABLE StudentsTeachers
(
     StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
   , TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL

   , CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)

CREATE TABLE StudentsSubjects
(
     Id INT PRIMARY KEY IDENTITY
   , StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
   , SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
   , Grade DECIMAL (10, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE StudentsExams
(
     StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
   , ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL
   , Grade DECIMAL (10, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

--Problem #2

INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId)
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6)
,('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2)
,('Merrile',	'Lambdin', '81 Dahle Plaza', '4373065154', 5)
,('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects ([Name], Lessons)
VALUES
  ('Geometry', 12)
, ('Health', 10)
, ('Drama', 7)
, ('Sports', 9)

--Problem #3

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE Grade >= 5.50 AND SubjectId IN(1, 2)

--Problem #4

DELETE FROM StudentsTeachers
WHERE TeacherId IN
(SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--Problem #5

SELECT 
     FirstName
   , LastName
   , Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--Problem #6

SELECT
     s.FirstName
   , s.LastName
   , COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName

--Problem #7

SELECT 
  CONCAT (FirstName, ' ', Lastname) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

--Problem #8

SELECT TOP (10)
     s.FirstName
   , s.LastName
   , FORMAT(AVG(se.Grade), 'N2') AS [Grade]
FROM Students AS s
JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName
ORDER BY [Grade] DESC, s.FirstName, s.LastName

--Problem #9

SELECT
     CASE
	 WHEN s.MiddleName IS NULL THEN CONCAT(s.FirstName, ' ', s.Lastname)
	 ELSE CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.Lastname)
	 END AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

--Problem #10

SELECT 
     s.[Name]
   , AVG(ss.Grade)
FROM StudentsSubjects AS ss
JOIN Subjects AS s ON ss.SubjectId = s.Id
GROUP BY s.[Name]

--Problem #11
GO

CREATE FUNCTION udf_ExamGradesToUpdate (@studentId INT, @grade DECIMAL (10, 2))
RETURNS NVARCHAR(MAX)
AS
    BEGIN
	     DECLARE @StudentIdToFind INT = (SELECT Id FROM Students WHERE Id = @studentId)
		 DECLARE @StudentFirstName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)
		 DECLARE @GradeToChange DECIMAL (10, 2) = (SELECT Grade FROM StudentsExams WHERE StudentId = @StudentIdToFind AND Grade = @grade)
		 

		 IF(@StudentIdToFind IS NULL)
		     BEGIN
				  RETURN 'The student with provided id does not exist in the school!'
			 END

		 DECLARE @Count INT =
		 (
			SELECT TOP(1)
			   COUNT(Grade)
			FROM StudentsExams
			WHERE StudentId = 12 AND Grade >= @grade AND GRADE <= @grade + 0.50
			GROUP BY StudentId
		 )

		 IF(@grade > 6.00)
		     BEGIN
				  RETURN 'Grade cannot be above 6.00!'
			 END

			 RETURN CONCAT('You have to update ', @Count, ' grades for the student ', @StudentFirstName)
    END
GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)
GO

--Problem #12

CREATE OR ALTER PROCEDURE usp_ExcludeFromSchool (@StudentId  INT)
AS
   BEGIN



   END
GO
