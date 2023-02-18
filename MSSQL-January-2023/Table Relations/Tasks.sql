USE SoftUni

--TASK 1
CREATE TABLE Persons (
	PersonID INT NOT NULL,
	FirstName NVARCHAR(50),
	Salary DECIMAL(8, 2),
	PassportID INT UNIQUE NOT NULL
)

CREATE TABLE Passports (
	PassportID INT UNIQUE NOT NULL,
	PassportNumber NVARCHAR(50)
)

INSERT INTO Persons
	VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

INSERT INTO Passports
	VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

ALTER TABLE Persons
ADD CONSTRAINT PK_Persons PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_Passports PRIMARY KEY (PassportID)

ALTER TABLE Passports
ADD FOREIGN KEY (PassportID) REFERENCES Persons(PassportID)

--TASK 2
DROP TABLE Models
DROP TABLE Manufacturers

CREATE TABLE Models (
	ModelID INT NOT NULL, --PRIMARY KEY
	[Name] NVARCHAR(50),
	ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers (
	ManufacturerID INT NOT NULL,
	[Name] NVARCHAR(50),
	EstablishedOn DATETIME2
)

INSERT INTO Models
	VALUES
	(101, 'X1', 1),
	(102, 'i6', 1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova', 3)

INSERT INTO Manufacturers
	VALUES
	(1, 'BMW', '07/03/1916'),
	(2, 'Tesla', '01/01/2003'),
	(3, 'Lada', '01/05/1966')

--SELECT * FROM Models
--SELECT * FROM Manufacturers

ALTER TABLE Models
ADD CONSTRAINT PK_Models PRIMARY KEY (ModelID)

ALTER TABLE Manufacturers
ADD CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
ADD CONSTRAINT FK_ManufacturerID FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)

--TASK 3
CREATE TABLE Students (
	StudentID INT NOT NULL,
	[Name] NVARCHAR(50)

	PRIMARY KEY(StudentID)
)

CREATE TABLE Exams (
	ExamID INT NOT NULL,
	[Name] NVARCHAR(50)

	PRIMARY KEY(ExamID)
)

CREATE TABLE StudentsExams (
	StudentID INT NOT NULL,
	ExamID INT NOT NULL

	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students
(StudentID, [Name])
	VALUES
	(1, 'Mila'),
	(2, 'Toni'),
	(3, 'Ron')

INSERT INTO Exams
(ExamID, [Name])
	VALUES
	(101, 'SpringMVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

INSERT INTO StudentsExams
(StudentID, ExamID)
	VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--TASK 4
CREATE TABLE Teachers (
	TeacherID INT NOT NULL,
	[Name] NVARCHAR(50),
	ManagerID INT,

	PRIMARY KEY (TeacherID),
	FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
	(TeacherID, [Name], ManagerID)
	VALUES
	(101, 'John', NULL),
	(102, 'Maya', 106),
	(103, 'Silvia', 106),
	(104, 'Ted', 105),
	(105, 'Mark', 101),
	(106, 'Greta', 101)

--TASK 5
CREATE DATABASE [Online Store]

CREATE TABLE Cities (
	CityID INT NOT NULL,
	[Name] NVARCHAR(50)

	PRIMARY KEY (CityID)
)

CREATE TABLE Customers (
	CustomerID INT NOT NULL,
	[Name] NVARCHAR(50),
	Birthday DATETIME2,
	CityID INT NOT NULL,

	PRIMARY KEY (CustomerID),
	FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
	OrderID INT NOT NULL,
	CustomerID INT NOT NULl,

	PRIMARY KEY (OrderID),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

--ALL DONE TIL HERE

CREATE TABLE ItemTypes (
	ItemTypeID INT NOT NULL,
	[Name] NVARCHAR(50),

	PRIMARY KEY (ItemTypeID)
)

CREATE TABLE Items (
	ItemID INT NOT NULL,
	[Name] NVARCHAR(50),
	ItemTypeID INT NOT NULL,

	PRIMARY KEY (ItemID),
	FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems (
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,

	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

--TASK 6
CREATE DATABASE University

USE University

--FOR JUDGE:
CREATE TABLE Majors (
	MajorID INT NOT NULL,
	[Name] NVARCHAR(50),

	PRIMARY KEY (MajorID)
)

CREATE TABLE Students (
	StudentID INT NOT NULL,
	StudentNumber INT,
	StudentName NVARCHAR(50),
	MajorID INT NOT NULL,

	PRIMARY KEY (StudentID),
	FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	PaymentID INT NOT NULL,
	PaymentDate DATETIME2,
	PaymentAmount DECIMAL(8, 2),
	StudentID INT NOT NULL,

	PRIMARY KEY (PaymentID),
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Subjects (
	SubjectID INT NOT NULL,
	SubjectName NVARCHAR(50),

	PRIMARY KEY (SubjectID)
)

CREATE TABLE Agenda (
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,

	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

--TASK 9
USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation 
FROM Mountains AS m
JOIN Peaks AS p ON m.Id = p.MountainId AND m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC