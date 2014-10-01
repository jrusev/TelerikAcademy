CREATE DATABASE PerformanceDB;

USE PerformanceDB;

CREATE TABLE Dates(
	DateId INT NOT NULL AUTO_INCREMENT,
	DateValue datetime NOT NULL,
	TextValue nvarchar(300),
	PRIMARY KEY (DateId, DateValue))
	PARTITION BY RANGE (YEAR(DateValue))(
		PARTITION p0 VALUES LESS THAN (2015),
		PARTITION p1 VALUES LESS THAN (2020),
		PARTITION p2 VALUES LESS THAN (2025),
		PARTITION p3 VALUES LESS THAN (2030),
		PARTITION p4 VALUES LESS THAN MAXVALUE
);

DELIMITER $$
CREATE PROCEDURE `start_routine`()
BEGIN
	DECLARE RowCount INT;
	SET RowCount = 1000;

	WHILE RowCount > 0
	DO
	BEGIN
		DECLARE Text nvarchar(100); 
		DECLARE Date datetime;
		SET Text = CONCAT('Text ', CAST(RowCount AS CHAR(100)), ': ',
		CAST(UUID() AS CHAR(100))); 
		SET Date = (now() + interval floor(rand()*(400)) MONTH);
	  INSERT INTO Dates(DateValue, TextValue)
	  VALUES(Date, Text);
	  SET RowCount = RowCount - 1;
	END;
	END WHILE;
END $$
DELIMITER ;

CALL start_routine;


-- This executes in (approximately) 9 minutes. Also creates approximately ~2 gigabytes database.
DELIMITER $$
CREATE PROCEDURE `fill_table`()
BEGIN
	DECLARE recordCount int;
	SET recordCount = (SELECT COUNT(*) FROM Dates);

	WHILE recordCount < 10000000
	DO
	BEGIN
		INSERT INTO Dates(DateValue, TextValue)
		SELECT DateValue, TextValue FROM Dates;
		SET recordCount = (SELECT COUNT(*) FROM Dates);
	END;
	END WHILE;
END $$
DELIMITER ;

CALL fill_table;

-- 16 seconds execution
SELECT COUNT(*) FROM Dates WHERE YEAR(DateValue) =2012;

DROP TABLE Dates;

CREATE TABLE Dates(
	DateId INT NOT NULL AUTO_INCREMENT,
	DateValue datetime NOT NULL,
	TextValue nvarchar(300),
	PRIMARY KEY (DateId, DateValue))
	PARTITION BY RANGE (YEAR(DateValue))(
		PARTITION p0 VALUES LESS THAN (2015),
		PARTITION p1 VALUES LESS THAN (2020),
		PARTITION p2 VALUES LESS THAN (2025),
		PARTITION p3 VALUES LESS THAN (2030),
		PARTITION p4 VALUES LESS THAN MAXVALUE
);

INSERT INTO Dates 
VALUES (DEFAULT, '2021-02-02', 'basi');

CALL start_routine;

CALL fill_table;

SELECT * FROM Dates PARTITION(p2);

