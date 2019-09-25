CREATE DATABASE WMS;

USE WMS;

/***********
 Problem 1. 
***********/
--•	Clients – contains information about the customers that use the service
--•	Mechanics – contains information about employees
--•	Jobs – contains information about all machines that clients submitted for    repairs
--•	Models – list of all washing machine models that the servie operates with
--•	Orders – contains information about orders for parts
--•	Parts – list of all parts the service operates with
--•	OrderParts – mapping table between Orders and Parts with additional          Quantity field
--•	PartsNeeded – mapping table between Jobs and Parts with additional Quantity   field
--•	Vendors – list of vendors that supply parts to the service

CREATE TABLE Clients
(
      ClientId INT PRIMARY KEY IDENTITY
	, FirstName VARCHAR(50) NOT NULL
	, LastName VARCHAR(50) NOT NULL
	, Phone CHAR (12) NOT NULL
)

CREATE TABLE Mechanics
(
      MechanicId INT PRIMARY KEY IDENTITY
	, FirstName VARCHAR(50) NOT NULL
	, LastName VARCHAR(50) NOT NULL
	, [Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
      ModelId INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs -- after TABLE Models
(
      JobId INT PRIMARY KEY IDENTITY
	, ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL
	, [Status] VARCHAR(11) DEFAULT 'Pending' CHECK ([Status] = 'Pending' OR [Status] = 'In Progress' OR [Status] = 'Finished') NOT NULL
	, ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL
	, MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId)
	, IssueDate DATE NOT NULL
	, FinishDate DATE
)

CREATE TABLE Orders
(
      OrderId INT PRIMARY KEY IDENTITY
	, JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL
	, IssueDate DATE
	, Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
      VendorId INT PRIMARY KEY IDENTITY
	, [Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
      PartId INT PRIMARY KEY IDENTITY
	, SerialNumber VARCHAR(50) NOT NULL UNIQUE
	, [Description] VARCHAR(255)
	, Price DECIMAL (6,2) NOT NULL CHECK (Price >= 1)
	, VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL
	, StockQty INT DEFAULT 0 NOT NULL CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
      OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL
	, PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL
	, Quantity INT DEFAULT 1 CHECK (Quantity >= 1) NOT NULL

	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
      JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL
	, PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL
	, Quantity INT DEFAULT 1 NOT NULL

	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

/*****************
 Problem 2. Insert
******************/
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Teri','Ennaco','570-889-5187')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Merlyn','Lawler','201-588-7810')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Georgene','Montezuma','925-615-5185')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Jettie','Mconnell','908-802-3564')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Lemuel','Latzke','631-748-6479')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Melodie','Knipp','805-690-1682')
INSERT INTO Clients (FirstNAme, LastName, Phone) VALUES ('Candida','Corbley','908-275-8357')

INSERT INTO Parts (PartId, SerialNumber, [Description], Price, VendorId, StockQty)
VALUES
('WP8182119','Door Boot Seal', 117.86,2),
('W10780048','Suspension Rod', 42.81,1),
('W10841140','Silicone Adhesive', 6.77,4),
('WPY055980','High Temperature Adhesive', 13.94,3)