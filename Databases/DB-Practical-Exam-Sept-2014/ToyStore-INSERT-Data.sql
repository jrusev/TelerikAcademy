---------------------------------------------------------------------
-- Generate random sample data in the toys store.
---------------------------------------------------------------------
USE ToyStore
GO

-- Delete all existing data
DELETE FROM ToysCategories
DELETE FROM Toys
DELETE FROM Manufacturers
DELETE FROM Categories
DELETE FROM AgeRanges
GO

-- Create 50 manufacturers
DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Manufacturers) < 50
BEGIN
  INSERT INTO Manufacturers(Name, Country)
  VALUES('Hipoland' + CONVERT(varchar, @Counter), 'BG')
  SET @Counter = @Counter + 1
END

SELECT COUNT(*) AS 'Manufacturers' FROM Manufacturers
GO

-- Create 100 categories
WHILE (SELECT COUNT(*) FROM Categories) < 100
BEGIN
  INSERT INTO Categories(Name)
  VALUES('Category-' + CONVERT(varchar(255), NEWID())) -- adds unique identifier at the end
END

SELECT COUNT(*) AS 'Categories' FROM Categories
GO

-- Create 100 age ranges
DECLARE @MinAge int, @MaxAge int
WHILE (SELECT COUNT(*) FROM AgeRanges) < 50
BEGIN  
  SET @MinAge = 1 + CONVERT(INT, 3*RAND())
  SET @MaxAge = @MinAge + 1 + CONVERT(INT, 10*RAND())
  INSERT INTO AgeRanges(MinAge, MaxAge) -- from 1 to 12  
  VALUES(@MinAge, @MaxAge)
END

SELECT COUNT(*) AS 'AgeRanges' FROM AgeRanges
GO

-- Create 10 000 toys
SET NOCOUNT ON -- Suppresses the "xx rows affected" message
WHILE (SELECT COUNT(*) FROM Toys) < 10000
BEGIN
  DECLARE @Name nvarchar(50) = 'Toy' + SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 9)
  DECLARE @Price money = (ABS(CHECKSUM(NewId())) % 100 / 100.0) * 199 -- random from 0.00 to 199.00
  DECLARE @ManufacturerId int = (SELECT TOP 1 Id FROM Manufacturers ORDER BY NEWID())
  INSERT INTO Toys(Name, Price, ManufacturerId) 
  VALUES(@Name, @Price, @ManufacturerId)
END
SET NOCOUNT OFF

SELECT COUNT(*) AS 'Toys' FROM Toys
GO

-- Add categories to toys (use loop to iterate over each toy)
SELECT RowNum = ROW_NUMBER() OVER(ORDER BY Id), Id INTO #Toys FROM Toys
DECLARE @MaxRow INT = (SELECT MAX(RowNum) FROM #Toys)
DECLARE @Row INT = (SELECT MIN(RowNum) FROM #Toys)

SET NOCOUNT ON -- Suppresses the "xx rows affected" message
WHILE @Row <= @MaxRow
BEGIN -- foreach toy
	DECLARE @ToyId int = (SELECT Id FROM #Toys WHERE RowNum = @Row) -- the Id of the current toy  
	-- Add category
	IF (RAND(CAST( NEWID() AS varbinary)) > 0.5) -- will execute 50% of the time
	BEGIN
		DECLARE @MaxCategories int = (ABS(CHECKSUM(NewId())) % 5) -- from 0 to 4 categories per toy
		DECLARE @CountCategories int = 0
		WHILE @CountCategories < @MaxCategories
		BEGIN
			DECLARE @CategoryId int = (SELECT TOP 1 Id FROM Categories ORDER BY NEWID()) -- random categoryId
			DECLARE @IsDuplicate int = 
				(SELECT COUNT(*) FROM ToysCategories WHERE (ToyId = @ToyId AND CategoryId = @CategoryId))
			-- if the category is not already added to this toy
			IF (@IsDuplicate = 0)
			BEGIN			
				INSERT INTO ToysCategories(ToyId, CategoryId) 
				VALUES(@ToyId, @CategoryId)				
			END
			SET @CountCategories = @CountCategories + 1
		END
	END    
	SET @Row = @Row + 1
END
SET NOCOUNT OFF

DROP TABLE #Toys
GO

SELECT COUNT(*) AS 'ToysCategories' FROM ToysCategories
---------------------------------------------------------------------
