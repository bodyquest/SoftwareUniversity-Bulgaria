USE Master
CREATE DATABASE Minions
GO

--Problem 2. Create Tables
USE Minions

CREATE TABLE Minions
(
	Id INT PRIMARY KEY
	, [Name] NVARCHAR(20) NOT NULL
	, Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY
	, [Name] NVARCHAR(20) NOT NULL
)

--Problem 3. Alter Mionions Tables
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--Problem 4. Insert Records in Both Tables
INSERT INTO Towns (Id, [Name]) VALUES
    (1, 'Sofia')
    , (2, 'Plovdiv')
    , (3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES 
    (1, 'Kevin', 22, 1)
    , (2, 'Bob', 15, 3)
    , (3, 'Steward', NULL, 2)

--Problem 5.
TRUNCATE TABLE Minions

--Problem 6.
DROP TABLE Minions
DROP TABLE Towns

--Problem 7. Create Table People
CREATE TABLE People
(
   Id INT PRIMARY KEY IDENTITY
   ,[Name] NVARCHAR(200) NOT NULL
   ,Picture VARBINARY(MAX)
   , Height DECIMAL (3,2)
   , [Weight] DECIMAL (5, 2)
   , Gender CHAR(1) NOT NULL
   , Birthdate DATE NOT NULL
   , Biography NTEXT
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
     ('Dari', NULL, 1.78, 97, 'm', '01/26/1982', 'I give you best price- 34.50!')
   , ('Rosi', NULL, 1.85, 85, 'm','01/26/1982', 'No deal')
   , ('Radi', NULL, 1.70, NULL, 'f', '01/26/1982', 'Exceptional')
   , ('Qnko', NULL, 2.00, 100, 'm', '01/26/1982', NULL)
   , ('Shisho', NULL, 1.85, 101, 'm', '01/26/1982', NULL)

SELECT * FROM People

ALTER TABLE People
ADD CONSTRAINT CHK_T_Picture_2MB CHECK(DATALENGTH(Picture) <= 2097152);

--Problem 8. Create Table Users

CREATE TABLE Users
(
   Id INT PRIMARY KEY IDENTITY
   ,Username VARCHAR(30) NOT NULL
   ,[Password] VARCHAR(26) NOT NULL
   ,ProfilePicture VARBINARY(MAX)
   , LastLoginTime DATETIME2
   , IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
     ('Bodyquest', 'parola1', NULL, '01/26/1982 7:30:00', 0)
   , ('Desa', 'parola2',NULL, '01/26/1982 7:30:00', 1)
   , ('Kanalin', 'parola3', NULL, '01/26/1982 7:30:00', 0)
   , ('Qnko', 'parola4', NULL, '01/26/1982 7:30:00', 0)
   , ('Shisho', 'parola5', NULL, '01/26/1982 7:30:00', 0)

SELECT * FROM Users

--Problem 9. Change Primary KEY
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC0723571F71]

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id, Username)

--Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_Pass_Length_Over_5 CHECK(LEN([Password]) >= 5);

--Problem 11. Set Default Value of a Field
ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime

--Problem 12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Id

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT uq_Username 
UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_Username_Length_Over_5 CHECK(LEN(Username) >= 5)

--Problem 13. Movies Database

CREATE DATABASE Movies
USE Movies
CREATE TABLE Directors
(
     ID INT PRIMARY KEY IDENTITY
   , DirectorName NVARCHAR(50)NOT NULL
   , Notes TEXT
)

CREATE TABLE Genres
(
     ID INT PRIMARY KEY IDENTITY
   , GenreName NVARCHAR(50) NOT NULL
   , Notes TEXT
)

CREATE TABLE Categories
(
     ID INT PRIMARY KEY IDENTITY
   , CategoryName NVARCHAR(50) NOT NULL
   , Notes TEXT
)

CREATE TABLE Movies
(
     ID INT PRIMARY KEY IDENTITY
   , Title NVARCHAR(50) NOT NULL
   , DirectorID INT FOREIGN KEY REFERENCES Directors (Id)
   , CopyrightYear CHAR(4)
   , [Length] VARCHAR(50)
   , GenreId INT FOREIGN KEY REFERENCES Genres(Id)
   , CategoryId INT FOREIGN KEY REFERENCES Categories (Id)
   , Rating DECIMAL (3, 1)
   , Notes TEXT
)

INSERT INTO Directors (DirectorName, Notes)
VALUES
     ('Steven Spielberg', 'Best ever')
   , ('Martin Scorsese', 'Classic')
   , ('Quentin Tarantino ', 'Nuts')
   , ('Peter Jackson', 'Best fantasy')
   , ('James Cameron', 'First 3D')

INSERT INTO Genres (GenreName, Notes)
VALUES
      ('Mistery', 'No Like')
	, ('Action', 'Like')
	, ('Sci-Fi', 'Like')
	, ('Fantasy', NULL)
	, ('Comedy', 'Like')

INSERT INTO Categories (CategoryName, Notes)
VALUES
      ('Category', NULL)
	, ('Category2', NULL)
	, ('Category3', NULL)
	, ('Category4', NULL)
	, ('Category5', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
      ('Title1', 1, 2013, '1:42:23', 1, 1, 7.5, NULL)
	, ('Title2', 2, 2019, '2:09:10', 2, 3, 6.6, NULL)
	, ('Title3', 3, 2017, '1:47:50', 3, 2, 6.1, NULL)
	, ('Title4', 4, 2018, '1:39:00', 4, 1, 5.9, NULL)
	, ('Title5', 5, 2015, '1:25:00', 5, 5, 8.1, NULL)

SELECT * FROM Directors
SELECT * FROM Genres
SELECT * FROM Categories
SELECT * FROM Movies

--Problem 14. Car Rental Database
CREATE DATABASE CarRental

CREATE TABLE Categories
(
     Id INT PRIMARY KEY IDENTITY
   , CategoryName NVARCHAR(20) NOT NULL
   , DailyRate DECIMAL (5, 2) NOT NULL
   , WeeklyRate DECIMAL (6, 2) NOT NULL
   , MonthlyRate DECIMAL (6, 2) NOT NULL
   , WeekendRate DECIMAL (5, 2) NOT NULL
)

CREATE TABLE Cars
(
     Id INT PRIMARY KEY IDENTITY
   , PlateNumber VARCHAR(20) NOT NULL
   , Manufacturer VARCHAR (20) NOT NULL
   , Model VARCHAR (20) NOT NULL
   , CarYear CHAR(4)
   , CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
   , Doors INT
   , Picture VARBINARY(MAX)
   , Condition VARCHAR (50) NOT NULL
   , Available BIT
)

CREATE TABLE Employees
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName NVARCHAR(20) NOT NULL
   , LastName NVARCHAR(20) NOT NULL
   , Title NVARCHAR(50)
   , Notes TEXT
)

CREATE TABLE Customers
(
     Id INT PRIMARY KEY IDENTITY
   , DriverLicenceNumber VARCHAR (30) NOT NULL
   , FullName VARCHAR (50) NOT NULL
   , [Address] VARCHAR (100)
   , City VARCHAR (20)
   , ZIPCode VARCHAR (10)
   , Notes TEXT
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY
	, EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
	, CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
	, CarId INT FOREIGN KEY REFERENCES Cars(Id)
	, TankLevel REAL NOT NULL
	, KilometrageStart INT NOT NULL
	, KilometrageEnd INT NOT NULL
	, TotalKilometrage AS KilometrageEnd - KilometrageEnd
	, StartDate DATETIME2 NOT NULL
	, EndDate DATETIME2 NOT NULL
	, TotalDates AS DATEDIFF(day,StartDate,EndDate)
	, RateApplied MONEY NOT NULL
	, TaxRate MONEY NOT NULL
	, OrderStatus VARCHAR(50) NOT NULL
	, Notes TEXT
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
     ('Economy', 20.00, 100.00, 300.00, 60.00)
   , ('Standard', 30.00, 150.00, 450.00, 100.00)
   , ('Luxury', 50.00, 250.00, 800.00, 150.00)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
     ('CA7777GZ', 'Moskvitch', '318', '1970', 3, 5, NULL, 'Bad', 0)
   , ('CA6666PA', 'Maybah', 'BahLiGo', '2010', 3, 5, NULL, 'Super', 1)
   , ('CA0001KP', 'Renault', 'Clio', '2017', 1, 5, NULL, 'Ok', 0)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
     ('Shisho', 'Bakshisho', 'Driver', 'Reliable')
   , ('Desa', 'Poetesa', 'Call Girl', 'Horny')
   , ('Kanalin', 'Tsolov', 'Plumber', NULL)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
     ('352877945', 'Prasemir Saturov', 'Susamenata Fabrika, Vlqvo 2', 'Kaspichan', 2050, NULL)
   , ('332241931', 'Debelin Dignibutov', 'Kurnovo Kornare 1', 'Korevo', 3421, NULL)
   , ('332951220', 'Shunko Svinski', 'Boxhagener Str 15', 'Berlin', 13187, NULL)

INSERT INTO RentalOrders (EmployeeId, 
						CustomerId, 
						CarId, 
						TankLevel, 
						KilometrageStart, 
						KilometrageEnd, 
						StartDate, 
						EndDate,
						RateApplied, 
						TaxRate, 
						OrderStatus, 
						Notes) 
VALUES
	(1, 3, 2, 44, 123455, 123555, GETDATE(), GETDATE(), 12.11, 0.2, 'Completed', NULL)
	, (2, 2, 3, 43, 123456, 123655, GETDATE(), GETDATE(), 13.11, 0.2, 'Completed', NULL)
	, (3, 1, 1, 42, 123457, 123755, GETDATE(), GETDATE(), 11.11, 0.2, 'Completed', NULL)

   SELECT * FROM Categories
   SELECT * FROM Cars
   SELECT * FROM Employees
   SELECT * FROM Customers
   SELECT * FROM RentalOrders

--Problem 15. Hotel Database
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
     Id INT PRIMARY KEY IDENTITY
   , FirstName VARCHAR (50) NOT NULL
   , LastName VARCHAR (50) NOT NULL
   , Title VARCHAR (50)
   , Notes TEXT
)

CREATE TABLE Customers
(
     AccountNumber VARCHAR(50) PRIMARY KEY
   , FirstName VARCHAR (50) NOT NULL
   , LastName VARCHAR (50) NOT NULL
   , PhoneNumber VARCHAR (50) NOT NULL
   , EmergencyName VARCHAR (50) NOT NULL
   , EmergencyNumber VARCHAR (50) NOT NULL
   , Notes TEXT
)

CREATE TABLE RoomStatus
(
     RoomStatus VARCHAR(10) PRIMARY KEY
   , Notes TEXT
)

CREATE TABLE RoomTypes
(
     RoomType VARCHAR(50) PRIMARY KEY
   , Notes TEXT
)

CREATE TABLE BedTypes
(
     BedType VARCHAR(50) PRIMARY KEY
   , Notes TEXT
)

CREATE TABLE Rooms
(
     RoomNumber INT PRIMARY KEY
   , RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes (RoomType)
   , BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes (BedType)
   , Rate MONEY NOT NULL
   , RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus (RoomStatus)
   , Notes TEXT
)

CREATE TABLE Payments
(
     Id INT PRIMARY KEY IDENTITY
   , EmployeeId INT FOREIGN KEY REFERENCES Employees (Id)
   , PaymentDate DATE NOT NULL
   , AccountNumber VARCHAR(50) FOREIGN KEY REFERENCES Customers (AccountNumber)
   , FirstDateOccupied DATE NOT NULL
   , LastDateOccupied DATE NOT NULL
   , TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied)
   , AmountCharged MONEY NOT NULL
   , TaxRate DECIMAL (5, 2) NOT NULL
   , TaxAmount MONEY NOT NULL
   , PaymentTotal MONEY NOT NULL
   , Notes TEXT
)

CREATE TABLE Occupancies
(
     Id INT PRIMARY KEY IDENTITY
   , EmployeeId INT FOREIGN KEY REFERENCES Employees (Id)
   , DateOccupied DATE NOT NULL
   , AccountNumber VARCHAR(50) FOREIGN KEY REFERENCES Customers (AccountNumber)
   , RoomNumber INT FOREIGN KEY REFERENCES Rooms (RoomNumber)
   , RateApplied DECIMAL (5, 2) NOT NULL
   , PhoneCharge Decimal (5, 2) NOT NULL
   , Notes TEXT
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
	  ('Shisho', 'Bakshisho', 'Piccolo', NULL)
	, ('Kanalin', 'Tsolov', 'Plumber', NULL)
	, ('Desa', 'Poetesa', 'Room Maid', NULL)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
	  ('123', 'Kiro', 'Butov', '0123456789', 'Mama', '0987654321', NULL)
	, ('122', 'Suzdurma', 'Svinksi', '0123456788', 'Tate', '0987654322', NULL)
	, ('111', 'Debelin', 'Butonoskov', '0123456787', 'Baba', '0987654323', NULL)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
	  ('Occupied', NULL)
	, ('Free', NULL)
	, ('Dirty', NULL)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
	  ('Single', NULL)
	, ('Double', NULL)
	, ('Suite', NULL)

INSERT INTO BedTypes(BedType, Notes) VALUES
	  ('Single', NULL)
	, ('Double', NULL)
	, ('King', NULL)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
	  (123, 'Single', 'Single', 22, 'Occupied', NULL)
	, (124, 'Double', 'Double', 32, 'Free', NULL)
	, (125, 'Suite', 'King', 42, 'Dirty', NULL)


INSERT INTO Payments
(
					EmployeeId, 
					PaymentDate, 
					AccountNumber, 
					FirstDateOccupied, 
					LastDateOccupied,
					AmountCharged,
					TaxRate,
					TaxAmount,
					PaymentTotal,
					Notes
) 
VALUES
	  (1, GETDATE(), 123, GETDATE(), GETDATE(), 100, 0.20, 20, 220.00, NULL)
	, (2, GETDATE(), 122, GETDATE(), GETDATE(), 200, 0.20, 40, 240.00, NULL)
	, (3, GETDATE(), 111, GETDATE(), GETDATE(), 250, 0.20, 50, 300.00, NULL)

INSERT INTO Occupancies
(
					EmployeeId, 
					DateOccupied, 
					AccountNumber, 
					RoomNumber, 
					RateApplied, 
					PhoneCharge, 
					Notes
) 
VALUES
	  (1, GETDATE(), 123, 123, 50, 10, NULL)
	, (2, GETDATE(), 122, 124, 50, 10, NULL)
	, (3, GETDATE(), 111, 125, 50, 10, NULL)

--Problem 16. Create SoftUni Database
--Problem 17. Backup Database
--Problem 18. Basic Insert

--Problem 19. Basic Select All Fields

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

-- Problem 20. Basic Select All Fields and Order Them

SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

-- Problem 21. Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

-- Problem 22. Increase Employees Salary

UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees

-- Problem 23. Decrease Tax Rate
UPDATE Payments
SET TaxRate /= 1.03
SELECT TaxRate FROM Payments

-- Problem 24. Delete All Records
TRUNCATE TABLE Occupancies