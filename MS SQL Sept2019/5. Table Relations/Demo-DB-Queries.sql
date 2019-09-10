

USE Demo;

CREATE TABLE Drivers
(
     DriverID   INT
     PRIMARY KEY
   , DriverName VARCHAR(50)
);

CREATE TABLE Cars
(
     CarID    INT
     PRIMARY KEY
   , DriverID INT
   , CONSTRAINT FK_Car_Driver FOREIGN KEY(DriverID) REFERENCES Drivers(
     DriverID)
);

CREATE TABLE Test
(
     FirstName  CHAR(15)
   , MiddleName VARCHAR(15)
   , LastName   NVARCHAR(15)
);

INSERT INTO Test
(
     FirstName
   , MiddleName
   , LastName
)
VALUES
       (
       'Gosho', 'Goshoev', 'Goshevski'
       );

SELECT 
     DATALENGTH(FirstName)
   , DATALENGTH(MiddleName)
   , DATALENGTH(LastName)
FROM 
     Test;

/***************************
 Exercises: Table Relations 
***************************/


/*********************************
Problem 1.	One-To-One Relationship
*********************************/

CREATE TABLE Persons
(
     PersonID   INT
     PRIMARY KEY
   , FirstName  VARCHAR(20) NOT NULL
   , Salary     DECIMAL(15, 2)
   , PassportID INT NOT NULL
);

CREATE TABLE Passports
(
     PassportID     INT
     PRIMARY KEY
   , PassportNumber CHAR(20) NOT NULL
);

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) REFERENCES Passports(
     PassportID);

ALTER TABLE Persons
ADD 
     UNIQUE(PassportID);

ALTER TABLE Passports
ADD 
     UNIQUE(PassportNumber);

INSERT INTO Passports
(
     PassportID
   , PassportNumber
)
VALUES
       (
       101, 'N34FG21B'
       ),
       (
       102, 'K65LO4R7'
       ),
       (
       103, 'ZE657QP2'
       );

INSERT INTO Persons
(
     PersonID
   , FirstName
   , Salary
   , PassportID
)
VALUES
       (
       1, 'Roberto', 43300.00, 102
       ),
       (
       2, 'Tom', 56100.00, 103
       ),
       (
       3, 'Yana', 60200.00, 101
       );

--EXEC sp_rename 'Passports.PersonID', 'PassportID', 'COLUMN';

ALTER TABLE Persons
ADD 
     PRIMARY KEY(PersonID);

ALTER TABLE Passports
ADD 
     PRIMARY KEY(PassportID);

ALTER TABLE Persons
ADD 
     FOREIGN KEY(PassportID) REFERENCES Passports(
     PassportID);

/*********************************
Problem 2.	One-To-Many Relationship
*********************************/

CREATE TABLE Manufacturers
(
     ManufacturerID INT PRIMARY KEY IDENTITY
   , [Name]         VARCHAR(15) NOT NULL
   , EstablishedOn  DATE NOT NULL
);

CREATE TABLE Models
(
     ModelID        INT PRIMARY KEY IDENTITY(101, 1)
   , [Name]         VARCHAR(15) NOT NULL
   , ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(
     ManufacturerID)
);

SET IDENTITY_INSERT Manufacturers ON
INSERT INTO Manufacturers
(
	ManufacturerID
	,[Name]
	,EstablishedOn
)
VALUES
	    (1, 'BMW', '07/03/1916')
	  , (2, 'Tesla', '01/01/2003')
	  , (3, 'Lada', '01/05/1966')

INSERT INTO Models
(
	 [Name]
	,ManufacturerID
)
VALUES
	  ('X1', 1)
	  ,('i6', 1)
	  ,('Model S', 2)
	  ,('Model X', 2)
	  ,('Model 3', 2)
	  ,('Nova', 3)

/*********************************
Problem 3.	Many-To-Many Relationship
*********************************/

CREATE TABLE Students
(
     StudentID INT NOT NULL
   , [Name]    VARCHAR(20)
);

CREATE TABLE Exams
(
     ExamID INT NOT NULL
   , [Name] VARCHAR(20)
);

CREATE TABLE StudentsExams
(
     StudentID INT NOT NULL
   , ExamID    INT NOT NULL
);


ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID);

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(
     StudentID)
  , CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(
     ExamID);

ALTER TABLE Students
ADD CONSTRAINT PK_Students PRIMARY KEY(StudentID);

ALTER TABLE Exams
ADD CONSTRAINT PK_Exams PRIMARY KEY(ExamID);

