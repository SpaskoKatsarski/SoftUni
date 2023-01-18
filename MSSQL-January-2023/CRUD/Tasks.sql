USE Diablo

--  SELECT CountryName,
--	  CountryCode,
--	CASE CurrencyCode
--	WHEN 'EUR' THEN 'Euro'
--	ELSE 'Not Euro'
--	 END
--	  AS Currency
--    FROM Countries
--ORDER BY CountryName

----16
--SELECT * FROM Employees

--GO

--CREATE VIEW V_EmployeesSalaries AS 
--SELECT FirstName, LastName, Salary
--FROM Employees

--GO

----18
--SELECT DISTINCT JobTitle
--FROM Employees

----20
--SELECT TOP (7) FirstName, LastName, HireDate
--FROM Employees
--ORDER BY HireDate DESC

--22
--SELECT * FROM Countries

--SELECT TOP (30) CountryName, [Population] FROM Countries
--WHERE ContinentCode = 'EU'
--ORDER BY 
--	[Population] DESC,
--	CountryName

--24
SELECT [Name] FROM Characters
ORDER BY [Name]