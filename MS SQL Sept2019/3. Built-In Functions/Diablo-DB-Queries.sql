USE Diablo

--14.	Games from 2011 and 2012 year
SELECT TOP (50) [Name], FORMAT([Start], 'yyy-MM-dd') AS [Start]
  FROM Games
  WHERE YEAR([Start]) BETWEEN 2011 AND 2012
  ORDER BY [Start], [Name]

--15.	User Email Providers
SELECT 
    Username
	,SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
  FROM Users
  ORDER BY [Email Provider], Username

--16.	Get Users with IPAdress Like Pattern
SELECT Username, IPAddress
  From Users
  WHERE IPAddress LIKE '___.1_%._%.___'
  ORDER BY Username

--17.	Show All Games with Duration and Part of the Day
SELECT 
    [Name]
	,CASE
	 WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	 WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	 WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	 END AS [Part of the Day]
	,CASE
	 WHEN Duration <= 3 THEN 'Extra Short'
	 WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	 WHEN Duration > 6 THEN 'Long'
	 WHEN Duration IS NULL THEN 'Extra Long'
	 END AS [Duration]
  FROM Games
  ORDER BY [Name], Duration, [Part of the Day]

--18.




--19.