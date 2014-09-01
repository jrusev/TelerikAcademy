--Task 1.
CREATE DATABASE PerformanceTestingDatabase
GO

USE PerformanceTestingDatabase

CREATE TABLE Dates(
  DateId INT NOT NULL IDENTITY,
  DateValue datetime NOT NULL,
  TextValue nvarchar(300),
  CONSTRAINT PK_Dates_DateId PRIMARY KEY (DateId)
)

SET NOCOUNT ON
DECLARE @RowCount int = 1000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) = 
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Dates(DateValue, TextValue)
  VALUES(@Date, @Text)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF

-- This executes in (approximately) 9 minutes. Also creates approximately ~2 gigabytes database.
WHILE (SELECT COUNT(*) FROM Dates) < 10000000
BEGIN
  INSERT INTO Dates(DateValue, TextValue)
  SELECT DateValue, TextValue FROM Dates
END

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

--Executes in 13 seconds on my machine when cached and 40 seconds when not.
SELECT DateValue FROM Dates
WHERE DateValue > '31-Dec-1990' and DateValue < '1-Jan-2010'

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

--Task 2

-- Another 1 minute 30 seconds and 300 additional Mb on the database.
CREATE INDEX IDX_Dates_DateValue ON Dates(DateValue)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

--Executes in 15 seconds. Caching seems to not matter.
SELECT DateValue FROM Dates
WHERE DateValue > '31-Dec-1990' and DateValue < '1-Jan-2010'

--Task 3.

--Executes in approximately 1 minute
SELECT TextValue FROM Dates
WHERE TextValue LIKE '%544%'

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

CREATE FULLTEXT CATALOG DatesFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Dates(TextValue)
KEY INDEX PK_Dates_DateId
ON DatesFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

--Executes in less than 3 seconds
SELECT TextValue FROM Dates
WHERE CONTAINS(TextValue, '%544%')