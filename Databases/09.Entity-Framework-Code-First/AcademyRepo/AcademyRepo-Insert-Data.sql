---------------------------------------------------------------------
-- Generate random sample data in the toys store.
---------------------------------------------------------------------
USE AcademyLite
GO

-- Delete all existing data
DELETE FROM StudentCourses
DELETE FROM Homework
DELETE FROM Courses
DELETE FROM Students
GO

-- Create 50 Courses
WHILE (SELECT COUNT(*) FROM Courses) < 50
BEGIN
  DECLARE @Name nvarchar(50) = 'Course' + SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 5)
  INSERT INTO Courses(Id, Name)
  VALUES(NEWID(), @Name)
END

SELECT COUNT(*) AS 'Courses' FROM Courses
GO

-- Create 20 000 students
SET NOCOUNT ON -- Suppresses the "xx rows affected" message
WHILE (SELECT COUNT(*) FROM Students) < 1000
BEGIN
  DECLARE @FirstName nvarchar(50) = 'FName' + SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 5)
  DECLARE @LastName nvarchar(50) = 'LName' + SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 5)
  INSERT INTO Students(FirstName, LastName)
  VALUES(@FirstName, @LastName)
  -- Add category
  DECLARE @Student_Id int = (SELECT @@Identity) -- the id of the last added toy
  DECLARE @Course_Id uniqueidentifier = (SELECT TOP 1 Id FROM Courses ORDER BY NEWID()) -- random categoryId
  INSERT INTO StudentCourses(Student_Id, Course_Id) 
  VALUES(@Student_Id, @Course_Id)
END
SET NOCOUNT OFF

SELECT COUNT(*) AS 'Students' FROM Students
SELECT COUNT(*) AS 'StudentCourses' FROM StudentCourses
GO