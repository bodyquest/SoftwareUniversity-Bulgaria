SELECT DepartmentID, SUM(Salary)
  FROM Employees
  GROUP BY DepartmentID
  ORDER BY DepartmentID

-------------------------------------------

SELECT DepartmentID, AVG(Salary) AS s
  FROM Employees
  GROUP BY DepartmentID
  ORDER BY s DESC

-------------------------------------------
  
SELECT e.DepartmentID,
	   COUNT(e.Salary) AS SalaryCount
  FROM Employees AS e
  GROUP BY e.DepartmentID

-------------------------------------------

SELECT
  DepartmentID
  , COUNT (*) AS EmployeesNumber
  , COUNT(MiddleName) AS EmpMiddleName 
  FROM Employees 
  GROUP BY DepartmentID

-------------------------------------------

SELECT
  DepartmentID,
  SUM(Salary) AS TotalSalary
  FROM Employees
  GROUP BY DepartmentID

-------------------------------------------
-- MAX Function
SELECT
  DepartmentID,
  ManagerID,
  MAX(Salary) AS MAXSalary 
  FROM Employees
  GROUP BY ManagerID, DepartmentID

SELECT
  DepartmentID,
  ManagerID,
  MAX(Salary) AS MAXSalary,
  MIN(Salary) AS MINSalary,
  MAX(Salary) - MIN(Salary) AS Diff,
  COUNT(EmployeeID) AS EmployeesCount,
  AVG(Salary) AS AVGSalary
  FROM Employees
  GROUP BY ManagerID, DepartmentID

-------------------------------------------
--STRING_AGG
SELECT
  DepartmentID,
  ManagerID,
  MAX(Salary) AS MAXSalary,
  MIN(Salary) AS MINSalary,
  MAX(Salary) - MIN(Salary) AS Diff,
  COUNT(EmployeeID) AS EmployeesCount,
  AVG(Salary) AS AVGSalary,
  STRING_AGG(Salary, ', ')
  FROM Employees 
  GROUP BY ManagerID, DepartmentID


SELECT Towns,
  STRING_AGG(email, ';') WITHIN GROUP
  (ORDER BY email ASC) AS emails
  FROM dbo.Employees
  GROUP BY Towns
 
-------------------------------------------
--HAVING
SELECT 
	DepartmentID,
	SUM(Salary) AS TotalSalary

FROM
	Employees
WHERE
	DepartmentID IN (1, 3, 15)
GROUP BY
	DepartmentID
HAVING SUM(Salary) > 30000

-------------------------------------------
-- Pivot Tables

SELECT 'AverageCost' AS Cpst_Sorted_By_Production_Days,
	[0], [1], [2], [3], [4]
FROM
(SELECT DaysToManufacture, StandardCost
	FROM Production.Product) AS SourceTable
PIVOT
(
	AVG(StandardCost)
	FOR DaysToManufacture IN ([0], [1], [2], [3], [4])
) AS PivtoTable

-----------------------
SELECT
	'Average Salary' AS [ ],
	[Marketing], [Production], [Purchasing]
FROM
(SELECT 
	d.[Name], Salary
FROM 
	Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID) AS dt
PIVOT
(
	AVG(Salary)
	FOR [Name] IN ([Marketing], [Production], [Purchasing])
) AS PivotTable

------------------------

SELECT 
	d.[Name], AVG(Salary)
FROM 
	Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]