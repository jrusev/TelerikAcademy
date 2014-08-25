--NOTE: You can execute each query individually by selecting the query and pressing F5

-- 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary <= 1.1 * (SELECT MIN(Salary) FROM Employees)

-- 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
SELECT FirstName, LastName, d.Name AS Department, Salary
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY Name

-- 4. Write a SQL query to find the average salary in the department #1.
SELECT d.DepartmentID, d.Name AS Department, ROUND(AVG(e.Salary), 2) AS [Avg. Salary] 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1
GROUP BY d.DepartmentID, d.Name

-- 5. Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name AS Department, ROUND(AVG(e.Salary), 2) AS [Avg. Salary] 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name


-- 6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT d.Name, Count(*) AS [Number of Employees] FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

-- second variant:
SELECT COUNT(*) AS [Number of Employees] FROM Employees
WHERE DepartmentId = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

-- 7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employees that have manager] 
FROM Employees
WHERE ManagerID IS NOT NULL

-- or
SELECT COUNT(ManagerID) AS [Employees that have manager] FROM Employees

-- 8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [6ef4eta] FROM Employees WHERE ManagerID IS NULL

-- 9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, ROUND(AVG(e.Salary),2) AS [Avg. Salary]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY [Avg. Salary] DESC

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

-- First query (employees in each department)
SELECT d.Name AS Department, COUNT(e.EmployeeId) AS [Employee Count]
FROM Employees e 
JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- Second query (employees in each town)
SELECT t.Name AS Town, COUNT(e.EmployeeId) AS [Employee Count]
FROM Employees e 
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName, m.LastName
FROM Employees m
JOIN Employees e ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING Count(*) = 5

-- second variant:
SELECT e.FirstName, e.LastName FROM Employees e
WHERE 5 = (SELECT COUNT(*) FROM Employees WHERE ManagerID = e.EmployeeID)

-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT 
  e.FirstName + ' ' + e.LastName AS [Employee],
  ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager]
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

-- second variant:
SELECT 
  e.LastName as [Employee],
  CASE WHEN e.ManagerId IS NULL THEN '(no manager)' ELSE m.LastName END AS [Manager]
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT LastName, LEN(LastName) AS [Name Length]  FROM Employees
WHERE LEN(LastName) = 5

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(varchar, GETDATE(), 113) AS [Current Date and Time]
-- second variant:
SELECT FORMAT(GETDATE(), 'dd MMM yyyy HH:mm:ss:fff') AS [Current Date and Time]

-- 15. Write a SQL statement to create a table Users with username, password, full name and last login time.
CREATE TABLE Users (
    UserID INT IDENTITY PRIMARY KEY,
    Username nvarchar(50) NOT NULL UNIQUE, 
    [Password] nvarchar(50) CHECK(LEN(Password) >= 5),
    FullName nvarchar(100) NOT NULL,
    LastLogin DATETIME
)
GO

-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
CREATE VIEW [UsersLoggedToday] AS
SELECT Username  FROM Users
WHERE DATEDIFF(day, LastLogin, GETDATE()) = 0
GO

-- Insert some users to test: (UserName, Password, FullName, LastLogin)
INSERT INTO Users VALUES ('Nakov', 'nakov123', 'Svetlin Nakov', GETDATE())
INSERT INTO Users VALUES('Kenov', 'kenov123', 'Ivaylo Kenov', '01.01.2000')
INSERT INTO Users VALUES ('NikolayIT', 'niki123', 'Nikolay Kostov', DATEADD(DAY, -1, GETDATE()))
INSERT INTO Users VALUES('Dodo', 'dodo123', 'Doncho Minkov', GETDATE() - 1)
GO

SELECT * FROM Users
SELECT Username AS [Users Logged In Today] FROM UsersLoggedToday

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name. Define primary key and identity column.
CREATE TABLE Groups (
    GroupId INT IDENTITY PRIMARY KEY,
	Name nvarchar(100) NOT NULL UNIQUE 
)
GO

-- 18. Write a SQL statement to add a column GroupID to the table Users. Add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
ADD GroupId INT FOREIGN KEY REFERENCES Groups(GroupId)

-- 19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT Groups VALUES ('Managers')
INSERT Groups VALUES ('Trainers')
INSERT Groups VALUES ('Admins')

INSERT Users VALUES ('TStoyanov', '123456', 'Todor Stoyanov',  GETDATE(), 3)

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users SET GroupId = 1 WHERE Username = 'Nakov'
UPDATE Users SET GroupId = 1 WHERE Username = 'NikolayIT'
UPDATE Users SET GroupId = 2 WHERE Username = 'Kenov'
UPDATE Users SET GroupId = 2 WHERE Username = 'Dodo'

UPDATE Groups SET Name = 'Team Leaders' WHERE Name = 'Managers'

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE UserName = 'TStoyanov'

DELETE FROM Groups
WHERE GroupID = 3

-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name. 
-- For username use the first letter of the first name + the last name (in lowercase). 
-- Use the same for the password, and NULL for last login time.
INSERT INTO Users(UserName, [Password], FullName)
	SELECT 
		--LOWER(LEFT(FirstName, 1) + LastName),
		LOWER(LEFT(FirstName, 1) + LastName) + CONVERT(nvarchar(10), EmployeeID),
		LOWER(LEFT(FirstName, 1) + LastName) + '*****',
		FirstName + ' ' + LastName
	FROM Employees
GO

-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users SET Password = NULL
WHERE LastLogin <  CONVERT(DATE, '10.03.2010', 104)

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users WHERE Password IS NULL

-- 25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle

-- 26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT LastName, d.Name AS Department, JobTitle, Salary
FROM Employees e JOIN Departments d ON e.DepartmentId = d.DepartmentId
WHERE e.Salary =
	(SELECT MIN(Salary) FROM Employees emp WHERE emp.DepartmentId = e.DepartmentId)

-- 27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP(1) t.Name AS Town, COUNT(*) AS Employees
FROM Employees e 
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY Employees DESC

-- 28. Write a SQL query to display the number of managers from each town.

-- first variant
SELECT t.Name, COUNT(DISTINCT m.EmployeeID) [Managers Count]
FROM Employees e 
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Addresses a ON m.AddressID = a.AddressID -- join on manager address
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Managers Count] DESC

-- second variant
SELECT t.Name, Count(*) [Managers Count]
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
WHERE e.EmployeeID IN (SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name
ORDER BY [Managers Count] DESC

-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
CREATE TABLE WorkHours (
  ReportID int IDENTITY PRIMARY KEY,
  EmployeeID int FOREIGN KEY REFERENCES Employees (EmployeeID),
  ReportDate DateTime,
  Task nvarchar(50),
  TaskHours decimal(5,2),
  Comments nvarchar(200)
)

-- Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO WorkHours(EmployeeID, ReportDate, Task, TaskHours, Comments)
VALUES (1, GETDATE(), 'Coding', 40, 'Completed query 29');

INSERT INTO WorkHours(EmployeeID, ReportDate, Task, TaskHours, Comments)
VALUES(2, GETDATE(), 'Reading', 4, 'Lectures');

INSERT INTO WorkHours(EmployeeID, ReportDate, Task, TaskHours, Comments)
VALUES(3, GETDATE(), 'Research MongoDB', 5, 'MongoLab');

UPDATE WorkHours SET Comments = 'Raise salary' WHERE EmployeeID = 1

DELETE FROM WorkHours WHERE EmployeeID = 3

-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
-- For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHourLogs(
	ChangeID int IDENTITY PRIMARY KEY,
	OldEmployeeID int NULL,
	OldReportDate DateTime NULL,
	OldTask nvarchar(50) NULL,
	OldTaskHours decimal(5,2) NULL,
	OldComments nvarchar(200) NULL,
	NewEmployeeID int NULL,
	NewReportDate DateTime NULL,
	NewTask nvarchar(50) NULL,
	NewTaskHours decimal(5,2) NULL,
	NewComments nvarchar(200) NULL,
	Command nvarchar(20)
)
GO

CREATE TRIGGER tr_InsertTrigger ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHourLogs
	SELECT NULL, NULL, NULL, NULL, NULL, i.EmployeeID, i.ReportDate,
	i.Task, i.TaskHours, i.Comments, 'INSERTED'
	FROM inserted i
GO

CREATE TRIGGER tr_UpdateTrigger ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHourLogs
	SELECT d.EmployeeID, d.ReportDate, d.Task, d.TaskHours, d.Comments, i.EmployeeID, i.ReportDate,
	i.Task, i.TaskHours, i.Comments, 'UPDATED'
	FROM inserted i, deleted d
GO

CREATE TRIGGER tr_DeleteTrigger ON WorkHours FOR DELETE
AS
	INSERT INTO WorkHourLogs
	SELECT d.EmployeeID, d.ReportDate, d.Task, d.TaskHours, d.Comments, NULL, NULL,
	NULL, NULL, NULL, 'DELETED'
	FROM deleted d
GO

-- Test triggers
INSERT INTO WorkHours VALUES(3, GETDATE(), 'Research MongoDB', 5, 'MongoLab')

DELETE FROM WorkHours WHERE EmployeeID = 3

UPDATE WorkHours SET Comments = 'Completed query 30' WHERE EmployeeID = 1

-- 30. Start a database transaction. 
-- Delete all employees from the 'Sales' department along with all dependent records from the other tables.
-- At the end rollback the transaction.

----BEGIN TRAN
----DELETE FROM Employees
----	SELECT d.Name
----	FROM Employees e JOIN Departments d
----		ON e.DepartmentID = d.DepartmentID
----	WHERE d.Name = 'Sales'
----	GROUP BY d.Name
----ROLLBACK TRAN

-- 31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?

----BEGIN TRAN
----	DROP TABLE EmployeesProjects
----ROLLBACK TRAN

-- 32. Find how to use temporary tables in SQL Server.
-- Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
SELECT * INTO #Temp FROM EmployeesProjects
DROP TABLE EmployeesProjects
SELECT * INTO EmployeeProjects FROM #Temp
DROP TABLE #Temp