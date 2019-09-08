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