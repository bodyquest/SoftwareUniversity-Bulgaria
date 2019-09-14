USE SoftUni


/*******************
 Inner JOIN example 
*******************/

SELECT 
     *
FROM 
     Employees AS e
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;

/***********************************************************************
 Left outer JOIN example 
 Take all LEFT TABLE columns, from RIGHT TABLE only the matching columns
 We CANNOT join by [text], [varchar], [picture]
***********************************************************************/

SELECT 
     *
FROM 
     Employees AS e
     LEFT OUTER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;

/***********************************************************************
 Right outer JOIN example 
 Take all RIGHT TABLE columns, from LEFT TABLE only the matching columns
 We CANNOT join by [text], [picture]
 OUTER JOIN is usually used to see irregularities/differences in the TABLES
***********************************************************************/

SELECT 
     *
FROM 
     Employees AS e
     RIGHT OUTER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;

-------------------------
CREATE TABLE Orders
(
	 Id    INT
     PRIMARY KEY IDENTITY(1, 1)
   , OrderNo INT
   , OrderName NVARCHAR(50)
)

CREATE TABLE Items
(
	 Id    INT
     PRIMARY KEY IDENTITY(1, 1)
   , OrderNumber INT
   , ItemName NVARCHAR(50)
   , OrderName NVARCHAR(50)
)

INSERT INTO Orders (OrderName, OrderNo) VALUES ('My First Order', 1)
INSERT INTO Orders (OrderName, OrderNo) VALUES ('My Second Order', 2)
INSERT INTO Orders (OrderName, OrderNo) VALUES ('My NULL Order', NULL)
INSERT INTO Orders (OrderName, OrderNo) VALUES (NULL, 3)

INSERT INTO Items (ItemName, OrderName, OrderNumber) VALUES ('Mouse', 'My First Order', 1)
INSERT INTO Items (ItemName, OrderName, OrderNumber) VALUES ('Keyboard', 'My Non Exisitng Order', 43)
INSERT INTO Items (ItemName, OrderName, OrderNumber) VALUES ('Monitor', NULL, 2)
INSERT INTO Items (ItemName, OrderName, OrderNumber) VALUES ('Computer', 'My Second Order', 5)

SELECT * FROM Orders
SELECT * FROM Items

SELECT * FROM Orders As o JOIN Items AS i ON o.OrderNo = i.OrderNumber
SELECT * FROM Orders As o LEFT JOIN Items AS i ON o.OrderNo = i.OrderNumber
SELECT * FROM Orders AS o FULL JOIN Items AS i ON o.OrderNo = i.OrderNumber


/***********************************************************************
Problem: Addresses with Towns
***********************************************************************/

SELECT TOP(50)
     FirstName
   , LastName
   , [Name] AS Town
   , AddressText
FROM 
     Employees AS e
     JOIN Addresses AS a ON e.AddressID = a.AddressID
     JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName;

/*******************************************************************************
Problem: Sales Employees. Find all employees that are in the "Sales" department.
********************************************************************************/

SELECT 
     EmployeeID
   , FirstName
   , LastName
   , [Name] AS DepartmentName
FROM 
     Employees AS e
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
                              AND d.[Name] = 'Sales'
ORDER BY 
     EmployeeID;

/**********************************************************************************
Problem: Employees Hired After 1/1/1999 and are in "Sales" or "Finance" departments
***********************************************************************************/

SELECT  
     FirstName
   , LastName
   , HireDate
   , [Name] AS DeptName
FROM  
     Employees AS e
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
     AND HireDate > '1/1/1999'
     AND d.[Name] IN ('Sales', 'Finance')
ORDER BY 
     HireDate;

/**********************************************************************************
Problem: Employees Summary. Display info about Employee's manager and department
***********************************************************************************/

SELECT TOP (50) 
     e.EmployeeID
   , CONCAT(' ', e.FirstName, e.LastName) AS EmployeeName
   , CONCAT(' ', m.FirstName, m.LastName) AS ManagerName
   , d.[Name] AS DepartmentName
FROM 
     Employees AS e
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
     LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
ORDER BY 
     EmployeeID;


/***************
Subquery Syntax
****************/

SELECT  
     *
FROM  
     Employees AS e
WHERE e.DepartmentID IN
(
    SELECT  
         d.DepartmentID
    FROM  
         Departments AS d
    WHERE d.[Name] = 'Finance'
);

/**************************
Problem: Min Average Salary
***************************/

SELECT MIN(sdata.avgs) FROM
(SELECT   
     AVG(Salary) AS avgs

FROM  
     Employees
GROUP BY DepartmentID) AS sdata

/*****************************
CTE - Common Table Expressions
******************************/
WITH Employees_CTE
(FirstName, LastName, DepartmentName)
AS
(
	SELECT e.FirstName, e.LastName, d.[Name]
	FROM Employees AS e
	LEFT JOIN Departments AS d ON
	d.DepartmentID = e.DepartmentID
)

SELECT FirstName, LastName, DepartmentName FROM Employees_CTE

/*****************************
Temporary Tables
******************************/

CREATE TABLE #Employees
(
     Id        INT
     PRIMARY KEY
   , FirstName VARCHAR(50) NOT NULL
   , LastName  VARCHAR(50)
   , Address   VARCHAR(50)
)

SELECT 
     *
FROM 
     #Employees;

--------------------------------

CREATE TABLE #Employees
(
     Id             INT PRIMARY KEY
   , FirstName      VARCHAR(50) NOT NULL
   , LastName       VARCHAR(50) NOT NULL
   , DepartmentName VARCHAR(50) NOT NULL
)

/**************************************
Indices
Clustered Index is inside the Table
Non-Clustered index - outside the Table
***************************************/

CREATE NONCLUSTERED INDEX IX_Employees_FirstName_LastName ON Employees(FirstName, LastName);