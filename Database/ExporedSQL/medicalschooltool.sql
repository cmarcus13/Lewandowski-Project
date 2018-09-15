-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: medicalschooltool
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8mb4 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contactmethods`
--

DROP TABLE IF EXISTS `contactmethods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `contactmethods` (
  `ContactMethodId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `UserId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ContactMethodId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  KEY `fk_ContactMethods_Users1_idx` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactmethods`
--

LOCK TABLES `contactmethods` WRITE;
/*!40000 ALTER TABLE `contactmethods` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactmethods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactmethodtypes`
--

DROP TABLE IF EXISTS `contactmethodtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `contactmethodtypes` (
  `ContactMethodTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `ContactMethodId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ContactMethodTypeId`,`ContactMethodId`),
  UNIQUE KEY `idContactMethodTypes_UNIQUE` (`ContactMethodTypeId`),
  KEY `fk_ContactMethodTypes_ContactMethods1_idx` (`ContactMethodId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactmethodtypes`
--

LOCK TABLES `contactmethodtypes` WRITE;
/*!40000 ALTER TABLE `contactmethodtypes` DISABLE KEYS */;
/*!40000 ALTER TABLE `contactmethodtypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fellowships`
--

DROP TABLE IF EXISTS `fellowships`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `fellowships` (
  `FellowshipId` int(11) NOT NULL,
  `Location` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Fellow` bit(1) DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  `YearsInFellowship1` varchar(255) DEFAULT NULL,
  `YearsInFellowship2` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`FellowshipId`),
  KEY `fk_Fellowships_People1_idx` (`PersonId`),
  CONSTRAINT `fk_Fellowships_People1` FOREIGN KEY (`PersonId`) REFERENCES `people` (`personid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fellowships`
--

LOCK TABLES `fellowships` WRITE;
/*!40000 ALTER TABLE `fellowships` DISABLE KEYS */;
/*!40000 ALTER TABLE `fellowships` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genders`
--

DROP TABLE IF EXISTS `genders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `genders` (
  `GenderId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(7) DEFAULT NULL,
  `Abreviation` char(1) DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`GenderId`),
  KEY `fk_Genders_People_idx` (`PersonId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genders`
--

LOCK TABLES `genders` WRITE;
/*!40000 ALTER TABLE `genders` DISABLE KEYS */;
/*!40000 ALTER TABLE `genders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicalschools`
--

DROP TABLE IF EXISTS `medicalschools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `medicalschools` (
  `MedicalSchoolId` int(11) NOT NULL,
  `Location` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `MedicalSchoolStudent` bit(1) DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  `YearsInMedicalSchool` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`MedicalSchoolId`),
  KEY `fk_MedicalSchools_People1_idx` (`PersonId`),
  CONSTRAINT `fk_MedicalSchools_People1` FOREIGN KEY (`PersonId`) REFERENCES `people` (`personid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicalschools`
--

LOCK TABLES `medicalschools` WRITE;
/*!40000 ALTER TABLE `medicalschools` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicalschools` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `people`
--

DROP TABLE IF EXISTS `people`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `people` (
  `PersonId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Alumni` bit(1) NOT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `MiddleInitial` char(1) DEFAULT NULL,
  `Suffix` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PersonId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `people`
--

LOCK TABLES `people` WRITE;
/*!40000 ALTER TABLE `people` DISABLE KEYS */;
/*!40000 ALTER TABLE `people` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personaddresses`
--

DROP TABLE IF EXISTS `personaddresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `personaddresses` (
  `PersonAddressId` int(11) NOT NULL AUTO_INCREMENT,
  `Address 1` varchar(255) DEFAULT NULL,
  `Address 2` varchar(255) DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  `ZipCodeId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`PersonAddressId`),
  UNIQUE KEY `PersonAddressesId_UNIQUE` (`PersonAddressId`),
  KEY `fk_PersonAddresses_People1_idx` (`PersonId`),
  KEY `fk_PersonAddresses_ZipCodes1_idx` (`ZipCodeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personaddresses`
--

LOCK TABLES `personaddresses` WRITE;
/*!40000 ALTER TABLE `personaddresses` DISABLE KEYS */;
/*!40000 ALTER TABLE `personaddresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professions`
--

DROP TABLE IF EXISTS `professions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `professions` (
  `ProfessionId` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `PlaceOfWork` varchar(255) DEFAULT NULL,
  `ResearchInterest` varchar(255) DEFAULT NULL,
  `InProfession` bit(1) DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  `YearsInProfession` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ProfessionId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  KEY `fk_Professions_People1_idx` (`PersonId`),
  CONSTRAINT `fk_Professions_People1` FOREIGN KEY (`PersonId`) REFERENCES `people` (`personid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professions`
--

LOCK TABLES `professions` WRITE;
/*!40000 ALTER TABLE `professions` DISABLE KEYS */;
/*!40000 ALTER TABLE `professions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `residencies`
--

DROP TABLE IF EXISTS `residencies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `residencies` (
  `ResidencyId` int(11) NOT NULL,
  `Location` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Resident` bit(1) DEFAULT NULL,
  `Decription` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  `YearsInResidency` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ResidencyId`),
  KEY `fk_Residencies_People1_idx` (`PersonId`),
  CONSTRAINT `fk_Residencies_People1` FOREIGN KEY (`PersonId`) REFERENCES `people` (`personid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `residencies`
--

LOCK TABLES `residencies` WRITE;
/*!40000 ALTER TABLE `residencies` DISABLE KEYS */;
/*!40000 ALTER TABLE `residencies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `states`
--

DROP TABLE IF EXISTS `states`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `states` (
  `StateId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Abreviation` char(2) NOT NULL,
  PRIMARY KEY (`StateId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  UNIQUE KEY `Abreviation_UNIQUE` (`Abreviation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `states`
--

LOCK TABLES `states` WRITE;
/*!40000 ALTER TABLE `states` DISABLE KEYS */;
/*!40000 ALTER TABLE `states` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useractivities`
--

DROP TABLE IF EXISTS `useractivities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `useractivities` (
  `UserActivityId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(10) unsigned NOT NULL,
  `LastActive` datetime NOT NULL,
  `LastComment` datetime DEFAULT NULL,
  PRIMARY KEY (`UserActivityId`,`UserId`),
  UNIQUE KEY `UserActivityId_UNIQUE` (`UserActivityId`),
  KEY `fk_UserActivities_Users1_idx` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useractivities`
--

LOCK TABLES `useractivities` WRITE;
/*!40000 ALTER TABLE `useractivities` DISABLE KEYS */;
/*!40000 ALTER TABLE `useractivities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `UserId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) DEFAULT NULL,
  `PersonId` int(10) unsigned NOT NULL,
  `Password` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `IsActive` datetime DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`),
  KEY `fk_Users_People1_idx` (`PersonId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zipcodes`
--

DROP TABLE IF EXISTS `zipcodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `zipcodes` (
  `ZipCodeId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(10) NOT NULL,
  `StateId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ZipCodeId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  UNIQUE KEY `ZipCodeId_UNIQUE` (`ZipCodeId`),
  KEY `fk_ZipCodes_States1_idx` (`StateId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zipcodes`
--

LOCK TABLES `zipcodes` WRITE;
/*!40000 ALTER TABLE `zipcodes` DISABLE KEYS */;
/*!40000 ALTER TABLE `zipcodes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-15 18:13:58
