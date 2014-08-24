SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema UniversityDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `UniversityDB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UniversityDB` ;

-- -----------------------------------------------------
-- Table `UniversityDB`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Faculties` (
  `FacultyID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`FacultyID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Departments` (
  `DepartmentID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`DepartmentID`),
  INDEX `fk_Departments_Faculties_idx` (`FacultyID` ASC),
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `UniversityDB`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Students` (
  `StudentID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`StudentID`),
  INDEX `fk_Students_Faculties1_idx` (`FacultyID` ASC),
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `UniversityDB`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Professors` (
  `ProfessorID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `DepartmentID` INT NOT NULL,
  PRIMARY KEY (`ProfessorID`),
  INDEX `fk_Professors_Departments1_idx` (`DepartmentID` ASC),
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `UniversityDB`.`Departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Titles` (
  `TitleID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`TitleID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`Courses` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Professors_ProfessorID` INT NOT NULL,
  `Departments_DepartmentID` INT NOT NULL,
  PRIMARY KEY (`CourseID`),
  INDEX `fk_Courses_Professors1_idx` (`Professors_ProfessorID` ASC),
  INDEX `fk_Courses_Departments1_idx` (`Departments_DepartmentID` ASC),
  CONSTRAINT `fk_Courses_Professors1`
    FOREIGN KEY (`Professors_ProfessorID`)
    REFERENCES `UniversityDB`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Departments1`
    FOREIGN KEY (`Departments_DepartmentID`)
    REFERENCES `UniversityDB`.`Departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`StudentsCourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`StudentsCourses` (
  `StudentID` INT NOT NULL,
  `CourseID` INT NOT NULL,
  INDEX `fk_StudentsCourses_Students1_idx` (`StudentID` ASC),
  INDEX `fk_StudentsCourses_Courses1_idx` (`CourseID` ASC),
  PRIMARY KEY (`StudentID`, `CourseID`),
  CONSTRAINT `fk_StudentsCourses_Students1`
    FOREIGN KEY (`StudentID`)
    REFERENCES `UniversityDB`.`Students` (`StudentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentsCourses_Courses1`
    FOREIGN KEY (`CourseID`)
    REFERENCES `UniversityDB`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversityDB`.`ProfessorsTitles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversityDB`.`ProfessorsTitles` (
  `ProfessorID` INT NOT NULL,
  `TitleID` INT NOT NULL,
  INDEX `fk_ProfessorsTitles_Titles1_idx` (`TitleID` ASC),
  INDEX `fk_ProfessorsTitles_Professors1_idx` (`ProfessorID` ASC),
  PRIMARY KEY (`ProfessorID`, `TitleID`),
  CONSTRAINT `fk_ProfessorsTitles_Titles1`
    FOREIGN KEY (`TitleID`)
    REFERENCES `UniversityDB`.`Titles` (`TitleID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsTitles_Professors1`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `UniversityDB`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
