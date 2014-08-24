/*
  1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
  
    SQL is a declarative querying and data manipulation language for relational database systems loosely based on relational algebra.
    DML is the subset of SQL concerned with "CRUD" operations - manipulating and extracting the stored data,
    while DDL is used for defining its structure and interrelationships.
    An additional subset is the DCL, "Data Control Language", which is used for managing access rights to tables and databases.
    The most important SQL commands include:
  
      DML: INSERT, SELECT, UPDATE, DELETE
      
      DDL: CREATE DATABASE/TABLE, DROP DATABASE/TABLE, ALTER Table
  
  2. What is Transact-SQL (T-SQL)?
  
    T-SQL is a proprietary extension to SQL developed by Microsoft that allows defining and performing advanced operations on data stored in SQL Server,
    including procedural language constructs that allow program logic similar to general purpose programmign languages.
  
  3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
*/

-- NOTE: You can execute each query individually by selecting the query and pressing F5

-- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments

-- 5. Write a SQL query to find all department names.
SELECT Name FROM Departments

-- 6. Write a SQL query to find the salary of each employee.
SELECT FirstName + ' ' + LastName AS Employee, Salary FROM Employees

-- 7. Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees

/*
8. Write a SQL query to find the email addresses of each employee (by his first and last name).
Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
The produced column should be named "Full Email Addresses".
*/
SELECT 
	FirstName + ' ' + LastName AS [Full Name],
	CONCAT(FirstName, '.', LastName, '@telerik.com') AS [Full Email Address]
FROM Employees

-- 9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary FROM Employees

-- 10. Write a SQL query to find all information about the employees whose job title is "Sales Representative".
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

-- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT * FROM Employees WHERE FirstName LIKE 'SA%'

-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT * FROM Employees WHERE LastName LIKE '%ei%'

-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000...30000].
SELECT LastName, Salary FROM Employees WHERE Salary BETWEEN 20000 AND 30000

-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT LastName, Salary 
FROM Employees 
WHERE Salary IN (25000, 14000, 12500, 23600) 
ORDER BY Salary ASC

-- 15. Write a SQL query to find all employees that do not have manager.
SELECT FirstName, LastName, ManagerID FROM Employees WHERE ManagerID IS NULL

-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT LastName, Salary FROM Employees WHERE Salary >= 50000 ORDER BY Salary DESC

-- 17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 * FROM Employees ORDER BY Salary  DESC

-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT FirstName + ' ' + LastName AS Name, AddressText AS Address
FROM Employees
JOIN Addresses ON Employees.AddressID = Addresses.AddressID

-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT FirstName + ' ' + LastName AS Name, AddressText AS Address
FROM Employees, Addresses
WHERE Employees.AddressID = Addresses.AddressID

-- 20. Write a SQL query to find all employees along with their manager.
SELECT e.LastName AS Employee, m.LastName AS Manager
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID

-- 21. Write a SQL query to find all employees, along with their manager and their address.
SELECT
  e.LastName AS [Employee],
  a.AddressText AS [Address],
  SUBSTRING(m.FirstName, 1, 1) + '. ' + m.LastName AS [Manager]
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
JOIN Addresses a ON e.AddressID = a.AddressID --Employee Address

-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

-- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager.
-- Use right outer join. Rewrite the query to use left outer join.
SELECT e.LastName AS Employee, e.JobTitle, m.LastName AS Manager
FROM Employees m
RIGHT JOIN Employees e ON e.ManagerID = m.EmployeeID

SELECT e.LastName AS Employee, e.JobTitle, m.LastName AS Manager
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

-- 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName, e.LastName, d.Name AS Department, e.HireDate 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE 
  d.Name IN ('Sales', 'Finance') 
  AND DATEPART(YEAR, e.HireDate) BETWEEN 1995 AND 2005