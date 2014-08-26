-- 1. Create a database with two tables:
-- Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.

USE TelerikAcademy

-- Create table Persons
CREATE TABLE Persons(
	PersonID int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN int NOT NULL UNIQUE CHECK (SSN >= 100000000 AND SSN <= 999999999) -- SSN is 9-digit
)
GO

-- Create table Accounts
CREATE TABLE Accounts(
	AccountID int IDENTITY PRIMARY KEY,
	PersonID int NOT NULL FOREIGN KEY REFERENCES Persons(PersonID),
	Balance money NOT NULL
)
GO

-- Insert few records
INSERT INTO Persons(FirstName, LastName, SSN)
VALUES
	('Svetlin', 'Nakov', 100000001),
	('Doncho', 'Minkov', 100000002),
	('Nikolay', 'Kostov', 100000003),
	('Ivaylo', 'Kenov', 100000004)

INSERT INTO Accounts(PersonID, Balance)
VALUES
	(1, 0),
	(2, 5000),
	(4, 10000),
	(3, 20000)
GO

-- Create procedure
CREATE PROC usp_SelectPersonsFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Persons
GO

-- Test procedure
EXEC usp_SelectPersonsFullName
GO

-- 2. Create a stored procedure that accepts a number as a parameter 
-- and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_FindBalanceOver(@minBalance money)
AS
	SELECT *
	FROM Persons p 
		JOIN Accounts a ON a.PersonID = p.PersonID
	WHERE Balance > @minBalance
GO

-- Test procedure
EXEC usp_FindBalanceOver 0
EXEC usp_FindBalanceOver 5000
GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_BalanceWithInterest(@sum money, @yearlyRate float, @months int)
	RETURNS money
AS
	BEGIN
		RETURN @sum * (1 + ((@yearlyRate / 100.0) / 12.0) * @months)
	END
GO

-- Test function
SELECT dbo.ufn_BalanceWithInterest(100, 10, 12) AS [$100 after 12 months at 10%]
SELECT dbo.ufn_BalanceWithInterest(100, 10, 6) AS [$100 after 6 months at 10%]
SELECT dbo.ufn_BalanceWithInterest(100, 12, 1) AS [$100 after 1 month at 12%]
GO

-- 4. Create a stored procedure that uses the function from the previous example
-- to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
CREATE PROCEDURE usp_AddInterestForOneMonth(@accountID int, @yearlyRate float)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_BalanceWithInterest(Balance, @yearlyRate, 1)
	WHERE AccountID = @accountID	
GO

-- Test function
DECLARE @accountID int = 3
DECLARE @annualInterestRate float = 12.0
EXEC usp_AddInterestForOneMonth @accountID, @annualInterestRate
SELECT * FROM Accounts
GO

-- 5. Add two more stored procedures:
-- WithdrawMoney(AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
CREATE PROCEDURE usp_WithdrawMoney(@accountID int, @money money)
AS
	DECLARE @currentBalance money;
	SELECT @currentBalance = Balance FROM Accounts
		WHERE AccountID = @accountID

	BEGIN TRAN
		UPDATE Accounts
		SET Balance -= @money
		WHERE AccountID = @accountID

		IF (@money < 0)
			BEGIN
				RAISERROR('Cannot withdraw negative amount!', 16, 1);
				ROLLBACK TRAN;
				RETURN;
			END
		ELSE IF (@currentBalance < @money)
			BEGIN
				RAISERROR('Insufficient balance!', 16, 1);
				ROLLBACK TRAN;
				RETURN;
			END
		ELSE
			COMMIT TRAN
GO

CREATE PROCEDURE usp_DepositMoney(@accountID int, @money money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance += @money
		WHERE AccountID = @accountID

		IF (@money < 0)
			BEGIN
				RAISERROR('Cannot deposit negative amount!', 16, 1);
				ROLLBACK TRAN;
				RETURN;
			END
		ELSE
			COMMIT TRAN
GO

-- Test procedures
EXEC usp_DepositMoney 1, 100
SELECT * FROM Accounts WHERE AccountID = 1

EXEC usp_WithdrawMoney 1, 100
SELECT * FROM Accounts WHERE AccountID = 1

EXEC usp_WithdrawMoney 1, 1000 -- Error
EXEC usp_WithdrawMoney 1, -1000 -- Error
EXEC usp_DepositMoney 1, -1000 -- Error

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
    LogID INT IDENTITY PRIMARY KEY,
    AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(AccountID),
    OldSum MONEY NOT NULL,
    NewSum MONEY NOT NULL
)
GO

CREATE TRIGGER tr_OnBalanceUpdate ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountID, OldSum, NewSum)
	SELECT del.AccountID, del.Balance, ins.Balance
	FROM Deleted del
		JOIN Inserted ins ON del.AccountID = ins.AccountID
GO

EXEC usp_DepositMoney 1, 100
EXEC usp_WithdrawMoney 1, 100
SELECT * FROM Logs
GO

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
-- and all town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
CREATE FUNCTION dbo.ufn_ContainsAllLetters(@Word nvarchar(50),  @Letters nvarchar(50))
    RETURNS bit
AS
BEGIN
	DECLARE @Contains bit = 1
	DECLARE @Counter INT = 1

	WHILE(@counter <= LEN(@Word))
		BEGIN
		IF (CHARINDEX(SUBSTRING(@Word, @Counter, 1), @Letters) = 0)
			SET @Contains = 0
		SET @Counter = @Counter + 1
		END
	RETURN @Contains
END
GO

CREATE PROC dbo.usp_FindAllNamesWithLetters(@Letters nvarchar(50))
AS
    DECLARE @Valid bit = 0
	SELECT * FROM (
		SELECT FirstName FROM Employees
		UNION ALL
		SELECT LastName FROM Employees
		UNION ALL
		SELECT Name FROM Towns
		) AS Temp(Name)

	WHERE
		1 = (SELECT dbo.ufn_ContainsAllLetters(Name, @Letters))
GO

EXEC dbo.usp_FindAllNamesWithLetters 'oistmiahf'
GO

-- 8. Using database cursor write a T-SQL script that scans all employees
-- and their addresses and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT t.Name, e1.FirstName, e1.LastName, e2.FirstName, e2.LastName
    FROM Employees e1
        JOIN Addresses a ON a.AddressID = e1.AddressID
        JOIN Towns t ON t.TownID = a.TownID,
    Employees e2
        JOIN Addresses a1 ON a1.AddressID = e2.AddressID
        JOIN Towns t1 ON t1.TownID = a1.TownID               
 
    OPEN empCursor
    DECLARE @e1fname nvarchar(50)
    DECLARE @e1lname nvarchar(50)
    DECLARE @e2fname nvarchar(50)
    DECLARE @e2lname nvarchar(50)
    DECLARE @town nvarchar(50)

	-- Get all pairs of employees in one town
    FETCH NEXT FROM empCursor
        INTO @town, @e1fname, @e1lname, @e2fname, @e2lname
 
    WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT @town + ': ' + @e1fname + ' ' + @e1lname + ', ' + @e2fname + ' ' + @e2lname
			FETCH NEXT FROM empCursor
				INTO @town, @e1fname, @e1lname, @e2fname, @e2lname
		END
 
CLOSE empCursor
DEALLOCATE empCursor

-- 9. Write a T-SQL script that shows for each town a list of all employees that live in it.
-- Sample output:
--    Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
--    Ottawa -> Jose Saraiva

-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings
-- and return a single string that consists of the input strings separated by ','.
-- For example the following SQL statement should return a single string:
--     SELECT StrConcat(FirstName + ' ' + LastName)
--     FROM Employees
DECLARE @name nvarchar(MAX) = N''
SELECT @name += e.FirstName + N', ' FROM Employees e
SELECT LEFT(@name, LEN(@name)-1)
GO