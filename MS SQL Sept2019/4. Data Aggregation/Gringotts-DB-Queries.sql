USE Gringotts

SELECT 
	*
FROM WizzardDeposits

--1. Records' Count

SELECT 
	COUNT(*) AS [Count]
FROM WizzardDeposits

--2. Longest Magic Wand

SELECT
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--3. Problem 3.	Longest Magic Wand per Deposit Groups

SELECT
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--4.* Smallest Deposit Group per Magic Wand Size

SELECT TOP (2)
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--5. Deposits Sum

SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--7. Deposits Filter
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--8. Deposit Charge
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9. Age Groups
SELECT AgeGroupTable.AgeGroup AS [AgeGroup], COUNT(AgeGroupTable.AgeGroup) AS [WizardCount]
FROM
(SELECT
	CASE 
	  WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	  ELSE '[60+]'
	END AS AgeGroup
FROM WizzardDeposits
) AS AgeGroupTable
GROUP BY AgeGroupTable.AgeGroup

--10. First LEtter
SELECT DISTINCT LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY [FirstLetter]

--11. Average Interest
SELECT 
	DepositGroup
	,IsDepositExpired
	,FORMAT(AVG(DepositInterest), 'N2') AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--12. *Rich Wizard, Poor Wizard

SELECT SUM(Diff.[Difference]) AS SumDifference
FROM
(
	SELECT wd.FirstName, wd.DepositAmount-
	(
		SELECT
		w.DepositAmount FROM WizzardDeposits AS w
		WHERE w.Id = wd.Id + 1
	) AS [Difference]
	FROM WizzardDeposits AS wd
) AS Diff

-----------------
-- Using LEAD 
SELECT SUM(k.SumDiff) AS SumDifference
FROM
(
	SELECT DepositAmount- LEAD(DepositAmount)
	OVER (ORDER BY Id) AS SumDiff
	FROM WizzardDeposits
) AS k

--13. Departments Total Salaries