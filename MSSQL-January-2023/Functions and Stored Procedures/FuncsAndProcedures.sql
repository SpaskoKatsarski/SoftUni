--Procedure which finds all cities which start with a given string passed as an argument
GO

CREATE PROC usp_GetTownsStartingWith @Str NVARCHAR(50) AS
DECLARE @Length INT = LEN(@Str)
SELECT [Name] 
FROM Towns
WHERE LEFT([Name], @Length) = @Str

GO

--Procedure that finds all employees from a given town passed as an argument
CREATE PROC usp_GetEmployeesFromTown @Town VARCHAR(50)
AS
	SELECT e.FirstName, e.LastName
	  FROM Employees AS e
	  JOIN Addresses AS a ON e.AddressID = a.AddressID
	  JOIN Towns AS t ON t.TownID = a.TownID
     WHERE t.[Name] = @Town

--Function that gets the salary level of the employees based on their salary
GO

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18, 3))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @level VARCHAR(7)
	IF(@Salary < 30000)
	BEGIN
	SET @level = 'Low'
	END
	ELSE IF(@Salary <= 50000)
	BEGIN
	SET @level = 'Average'
	END
	ELSE
	BEGIN
	SET @level = 'High'
	END

	RETURN @level
END

GO

SELECT *, dbo.ufn_GetSalaryLevel(Salary) AS [Level] FROM Employees

--Function that gets all employees by a given salary level using the previous function
GO

CREATE PROC usp_EmployeesBySalaryLevel @level NVARCHAR(100)
AS
	SELECT FirstName, LastName
	  FROM Employees
	 WHERE dbo.ufn_GetSalaryLevel(Salary) = @level

GO