USE SoftUni

SELECT *
  FROM Employees



UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentID IN (
						SELECT DepartmentID
						  FROM Departments
						 WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
					  )

SELECT Salary
  FROM Employees