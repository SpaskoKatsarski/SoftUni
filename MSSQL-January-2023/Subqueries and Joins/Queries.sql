--Finding all employees who work on a project with start date '2002-08-13' and is still not finished
USE SoftUni

SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Finding the highest peaks in Bulgaria
USE [Geography]

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE p.Elevation > 2835 AND c.CountryName = 'Bulgaria'
ORDER BY p.Elevation DESC

--Getting the count of all mountain ranges in United States, Russia and Bulgaria
SELECT c.CountryCode, COUNT(m.MountainRange) FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

--Getting the highest peak and the longest river in a country which has both of them
   SELECT TOP (5) c.CountryName
		   , MAX(p.Elevation) AS HighestPeakElevation
		   , MAX(r.[Length]) AS LongestRiverLength
    FROM Rivers AS r
	JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
	JOIN Countries AS c ON c.CountryCode = cr.CountryCode
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName