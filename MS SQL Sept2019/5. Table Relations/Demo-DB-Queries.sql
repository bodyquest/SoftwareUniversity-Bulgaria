

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

ALTER TABLE Students
ADD CONSTRAINT PK_Students PRIMARY KEY(StudentID);

ALTER TABLE Exams
ADD CONSTRAINT PK_Exams PRIMARY KEY(ExamID);

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(
     StudentID)
  , CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(
     ExamID);

/*********************************
Problem 4.	Self-Referencing
*********************************/

CREATE TABLE Teachers
(
     TeacherID INT PRIMARY KEY IDENTITY(101, 1)
   , [Name]    VARCHAR(30)
   , ManagerID INT FOREIGN KEY REFERENCES Teachers(
     TeacherID)
);

INSERT INTO Teachers VALUES
	 ( 'John', NULL)
	,( 'Maya', 106)
	,( 'Silvia', 106)
	,( 'Ted', 105)
	,( 'Mark', 101)
	,( 'Greta', 101)

/********************************
Problem 5.	Online Store Database
*********************************/
USE Master
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities
(
     CityID INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
     CustomerID INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (50) NOT NULL
   , Birthday DATE
   , CityID INT FOREIGN KEY REFERENCES Cities (CityID) NOT NULL
)

CREATE TABLE Orders
(
     OrderID INT PRIMARY KEY IDENTITY
   , CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID) NOT NULL
)

CREATE TABLE ItemTypes
(
     ItemTypeID INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (50) NOT NULL
)

CREATE TABLE Items
(
     ItemID INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (50) NOT NULL
   , ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems
(
     OrderID INT NOT NULL
   , ItemID INT NOT NULL
)

ALTER TABLE OrderItems
ADD CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID);

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID)

/********************************
Problem 6.	Univeristy Database
*********************************/
CREATE DATABASE University
USE University

CREATE TABLE Majors
(
     MajorID INT PRIMARY KEY IDENTITY
   , [Name] VARCHAR (20) NOT NULL
)

CREATE TABLE Students
(
     StudentID INT PRIMARY KEY IDENTITY
   , StudentNumber INT NOT NULL
   , StudentName VARCHAR (50) NOT NULL
   , MajorID INT FOREIGN KEY REFERENCES Majors (MajorID) NOT NULL
)

CREATE TABLE Payments
(
     PaymentID INT PRIMARY KEY IDENTITY
   , PaymentDate DATETIME NOT NULL
   , PaymentAmount DECIMAL (10, 2) NOT NULL
   , StudentID INT FOREIGN KEY REFERENCES Students (StudentID)
)

CREATE TABLE Subjects
(
     SubjectID INT PRIMARY KEY IDENTITY
   , SubjectName VARCHAR (20) NOT NULL
)

CREATE TABLE Agenda
(
     StudentID INT NOT NULL
   , SubjectID INT NOT NULL
)

ALTER TABLE Agenda
ADD CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID)

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_SubjectID FOREIGN KEY (SubjectID) REFERENCES Subjects (SubjectID)

/************************
Problem 9.	Peaks In Rila
*************************/
USE Geography
GO

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC