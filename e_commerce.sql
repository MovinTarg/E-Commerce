-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema e_commerce
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema e_commerce
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `e_commerce` DEFAULT CHARACTER SET utf8 ;
USE `e_commerce` ;

-- -----------------------------------------------------
-- Table `e_commerce`.`Customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e_commerce`.`Customer` (
  `CustomerId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`CustomerId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e_commerce`.`Product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e_commerce`.`Product` (
  `ProductId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Description` VARCHAR(255) NULL,
  `Quantity` INT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ProductId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e_commerce`.`Order`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e_commerce`.`Order` (
  `OrderId` INT NOT NULL AUTO_INCREMENT,
  `Quantity` INT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  `CustomerId` INT NOT NULL,
  `ProductId` INT NOT NULL,
  PRIMARY KEY (`OrderId`),
  INDEX `fk_Order_Customer_idx` (`CustomerId` ASC),
  INDEX `fk_Order_Product1_idx` (`ProductId` ASC),
  CONSTRAINT `fk_Order_Customer`
    FOREIGN KEY (`CustomerId`)
    REFERENCES `e_commerce`.`Customer` (`CustomerId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Order_Product1`
    FOREIGN KEY (`ProductId`)
    REFERENCES `e_commerce`.`Product` (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
