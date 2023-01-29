USE Gringotts

--Selecting all deposit groups and their total deposit sums only for the wizzards who their magic wands crafted by the Ollivander family aknd the total deposit amount is fewer than 150000 
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC

--Getting the average interest of all deposit groups, split by whether the deposit has expired or not
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC

USE SoftUni
--CRUD operations on duplicated table (Employees) and getting the average salary of each department from the new table
SELECT *
INTO Employees2
FROM Employees
WHERE Salary > 30000

DELETE FROM Employees2
WHERE ManagerID = 42

UPDATE Employees2
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM Employees2
GROUP BY DepartmentID

--Getting the second highest salary of each department
SELECT DepartmentID, Salary AS ThirdHighestSalary
FROM (
		SELECT
		DepartmentID,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary) AS [Rank],
		Salary
		FROM Employees ) AS e
WHERE [Rank] = 2