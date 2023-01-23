--Queris for SoftUni database
USE SoftUni

--Finding all employees with Rank 2
SELECT * FROM (SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS t
WHERE t.[Rank] = 2
ORDER BY Salary DESC

--Queries for Geography database
USE [Geography]

--Getting all countries in the Geography database which name has 3 or more a's
SELECT CountryName AS [Country Name], ISoCode AS [ISO Code]
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY [ISO Code]

--Other approach
SELECT CountryName AS [Country Name], ISoCode AS [ISO Code]
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(LOWER(CountryName), 'a', '')) >= 3
ORDER BY [ISO Code]

--Getting the mix of a name of a peak which ends with the same letter as the first letter of a name of a river
SELECT p.PeakName, r.RiverName, LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix] FROM Peaks as [p],
			Rivers as [r]
WHERE RIGHT(LOWER(p.PeakName), 1) = LEFT(LOWER(r.RiverName), 1)
ORDER BY Mix

--Queries for Diablo database
USE Diablo

--Getting only the games which release date is between 2011 and 2012
SELECT TOP(50) [Name], CONVERT(VARCHAR, [Start], 23) AS [Start] FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--Getting only the user email providers
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider], Username

--Getting only the users whose IP Address matches the following pattern: '___.1_%._%.___'
SELECT Username, IpAddress AS [Ip Address] FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username