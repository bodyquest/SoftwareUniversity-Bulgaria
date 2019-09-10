USE Geography;

SELECT c.CountryName
     , MountainRange
     , PeakName AS Elevation
FROM   Mountains AS m
       JOIN Peaks AS p ON m.Id = p.MountainId
       JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
       JOIN Countries AS c ON mc.CountryCode = .c.CountryCode
WHERE  m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC;