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

--Removing relations before deleting departments and employees
GO

CREATE PROC usp_DeleteEmployeesFromDepartment @deparmentId INT
         AS
	  BEGIN
			DECLARE @employeesToDelete TABLE (Id INT);

			--Creating a table with employees that we should delete
			INSERT INTO @employeesToDelete
						SELECT EmployeeId 
						  FROM Employees
						 WHERE DepartmentID = @deparmentId

			--Removing the relation with EmeployeesProjects if any employees are working on a project
			DELETE
			  FROM EmployeesProjects
			 WHERE EmployeeID IN (
									SELECT * 
									  FROM @employeesToDelete
								)
			
			
			--Some employees we want to delete may be managers to a department
			--So first we need to set the ManagerId in departments table to null

			ALTER TABLE Departments
			ALTER COLUMN ManagerID INT

			UPDATE Departments
			   SET ManagerID = NULL
			 WHERE ManagerID IN (
									SELECT * 
									  FROM @employeesToDelete
								)

			--Employees which we are going to remove can be managers of other employees
			--So we need to set ManagerID to NULL of all Employees with futurely deleted managers
			UPDATE Employees
			   SET ManagerID = NULL
			 WHERE ManagerID IN (
									SELECT *
									  FROM @employeesToDelete
								 )

			--Since we removed the relations from the employees we want to remove we can safely delete them
			DELETE
			  FROM Employees
			 WHERE DepartmentID = @deparmentId

			DELETE
			  FROM Departments
			 WHERE DepartmentID = @deparmentId

			SELECT COUNT(*)
			  FROM Employees
			 WHERE DepartmentID = @deparmentId
        END
GO

--Finding the future value
GO

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @numOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @result DECIMAL(18, 4) = @sum * POWER((1 + @yearlyInterestRate), @numOfYears)
	RETURN ROUND(@result, 4)
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--Using the previous function to calculate the future value of an account after 5 years
GO

CREATE  OR ALTER PROC usp_CalculateFutureValueForAccount @accId INT, @interestRate FLOAT
AS
BEGIN
	DECLARE @years INT = 5

	SELECT a.Id AS [Account Id],
		   ah.FirstName AS [First Name],
		   ah.LastName AS [Last Name],
		   a.Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, @years) AS [Balance in 5 years]
	  FROM AccountHolders
	    AS ah
	  JOIN Accounts
	    AS a
		ON ah.Id = a.AccountHolderId
	 WHERE a.Id = @accId
END

GO