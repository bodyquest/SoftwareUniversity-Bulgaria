
USE SoftUni;

--13. Departments Total Salaries

SELECT DepartmentID, 
       SUM(Salary) AS TotalSalary
FROM   Employees
GROUP BY DepartmentID;

--14. Employees Minimum Salaries

SELECT DepartmentID, 
       MIN(Salary) AS MinimumSalary
FROM   Employees
WHERE  DepartmentID IN(2, 5, 7)
AND HireDate > '01/01/2000'
GROUP BY DepartmentID;

--15. Employees Average Salaries

SELECT *
INTO NewTable
FROM   Employees
WHERE  Salary > 30000;


DELETE FROM NewTable
WHERE       ManagerId = 42;


UPDATE NewTable
  SET  
      Salary+=5000
WHERE  DepartmentID = 1;


SELECT DepartmentID, 
       AVG(Salary) AS AverageSalary
FROM   NewTable
GROUP BY DepartmentID;


--16. Employees Maximum Salaries

SELECT DepartmentID, 
       MAX(Salary) AS MaxSalary
FROM   Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

/*17. Employees Count Salaries*/

SELECT COUNT(*) AS Count
FROM   Employees
WHERE  ManagerId IS NULL;

/*18. *3rd Highest Salary*/

SELECT DISTINCT 
       Ranking.DepartmentID, 
       Ranking.Salary
FROM
(
    SELECT DepartmentID, 
           Salary, 
           DENSE_RANK() OVER(PARTITION BY DepartmentID
           ORDER BY Salary DESC) AS Rank
    FROM Employees
) AS Ranking
WHERE Ranking.Rank = 3;

/*19. **Salary Challenge*/

SELECT TOP (10) FirstName, 
                LastName, 
                DepartmentID
FROM Employees AS e
WHERE Salary >
(
    SELECT AVG(Salary)
    FROM Employees AS em
    WHERE em.DepartmentID = e.DepartmentID
)
ORDER BY DepartmentID;