CREATE DATABASE  IF NOT EXISTS `ID400061_G002` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `ID400061_G002`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: ID400061_G002.db.webhosting.be    Database: ID400061_G002
-- ------------------------------------------------------
-- Server version	5.7.40-43-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Edele`
--

DROP TABLE IF EXISTS `Edele`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Edele` (
  `idEdele` int(11) NOT NULL AUTO_INCREMENT,
  `prestigepunten` int(11) NOT NULL,
  `prijsWit` int(11) NOT NULL,
  `prijsRood` int(11) NOT NULL,
  `prijsZwart` int(11) NOT NULL,
  `prijsBlauw` int(11) NOT NULL,
  `prijsGroen` int(11) NOT NULL,
  PRIMARY KEY (`idEdele`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Edele`
--

LOCK TABLES `Edele` WRITE;
/*!40000 ALTER TABLE `Edele` DISABLE KEYS */;
INSERT INTO `Edele` VALUES (1,3,4,0,4,0,0),(2,3,3,3,3,0,0),(3,3,3,0,3,3,0),(4,3,3,0,0,3,3),(5,3,0,3,3,0,3),(6,3,0,3,0,3,3),(7,3,0,0,0,4,4),(8,3,0,4,4,0,0),(9,3,4,0,0,4,0),(10,3,0,4,0,0,4);
/*!40000 ALTER TABLE `Edele` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Kaart`
--

DROP TABLE IF EXISTS `Kaart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Kaart` (
  `KaartID` int(11) NOT NULL AUTO_INCREMENT,
  `niveau` int(11) NOT NULL,
  `prestigepunten` int(11) NOT NULL,
  `prijsWit` int(11) NOT NULL,
  `prijsRood` int(11) NOT NULL,
  `prijsZwart` int(11) NOT NULL,
  `prijsBlauw` int(11) NOT NULL,
  `prijsGroen` int(11) NOT NULL,
  `kleur` varchar(10) NOT NULL,
  PRIMARY KEY (`KaartID`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Kaart`
--

LOCK TABLES `Kaart` WRITE;
/*!40000 ALTER TABLE `Kaart` DISABLE KEYS */;
INSERT INTO `Kaart` VALUES (1,1,1,0,0,0,4,0,'ZWART'),(2,1,0,1,2,1,0,1,'BLAUW'),(3,1,0,1,0,2,0,0,'BLAUW'),(4,1,0,0,3,1,0,1,'ZWART'),(5,1,0,3,0,0,0,0,'ROOD'),(6,1,0,2,0,2,0,1,'ROOD'),(7,1,0,2,0,0,1,0,'GROEN'),(8,1,0,0,0,0,0,3,'ZWART'),(9,1,0,0,0,2,2,0,'WIT'),(10,1,0,0,3,0,0,0,'GROEN'),(11,1,0,1,1,3,0,0,'ROOD'),(12,1,0,0,0,0,2,1,'ROOD'),(13,1,0,2,0,0,0,2,'ZWART'),(14,1,0,1,1,1,1,0,'GROEN'),(15,1,0,0,1,1,1,1,'WIT'),(16,1,0,2,1,0,2,0,'ZWART'),(17,1,0,1,0,0,3,1,'GROEN'),(18,1,0,0,1,1,1,2,'WIT'),(19,1,0,0,0,1,2,2,'WIT'),(20,1,0,0,0,0,3,0,'WIT'),(21,1,0,1,1,0,1,1,'ZWART'),(22,1,0,3,0,1,1,0,'WIT'),(23,1,0,0,1,0,0,2,'ZWART'),(24,1,0,0,2,2,1,0,'GROEN'),(25,1,0,0,0,3,0,0,'BLAUW'),(26,1,0,2,0,1,1,1,'ROOD'),(27,1,0,1,1,1,1,0,'GROEN'),(28,1,0,0,2,1,0,0,'WIT'),(29,1,0,0,1,0,1,3,'BLAUW'),(30,1,0,1,2,0,0,2,'BLAUW'),(31,1,1,0,0,0,0,4,'WIT'),(32,1,1,0,0,4,0,0,'GROEN'),(33,1,0,0,2,0,2,0,'GROEN'),(34,1,0,2,2,0,0,0,'ROOD'),(35,1,1,4,0,0,0,0,'ROOD'),(36,1,0,0,0,2,0,2,'BLAUW'),(37,1,0,1,1,1,0,1,'BLAUW'),(38,1,1,0,4,0,0,0,'BLAUW'),(39,1,0,1,0,1,1,1,'ROOD'),(40,1,0,1,1,0,2,1,'ZWART'),(41,2,2,5,0,0,0,0,'ZWART'),(42,2,1,3,0,0,2,2,'ZWART'),(43,2,1,0,2,3,3,0,'ROOD'),(44,2,1,2,0,2,3,0,'GROEN'),(45,2,2,0,4,2,0,1,'WIT'),(46,2,1,2,3,0,3,0,'WIT'),(47,2,1,3,3,0,0,2,'GROEN'),(48,2,2,2,1,4,0,0,'BLAUW'),(49,2,2,0,0,5,0,0,'ROOD'),(50,2,2,3,0,5,0,0,'ROOD'),(51,2,1,0,0,3,2,3,'BLAUW'),(52,2,1,2,2,3,0,0,'ROOD'),(53,2,3,0,0,0,0,6,'GROEN'),(54,2,2,1,0,0,4,2,'ROOD'),(55,2,2,0,0,0,5,0,'BLAUW'),(56,2,2,0,0,0,5,3,'GROEN'),(57,2,2,4,0,1,2,0,'GROEN'),(58,2,2,0,5,0,0,0,'WIT'),(59,2,3,6,0,0,0,0,'WIT'),(60,2,2,0,2,0,1,4,'ZWART'),(61,2,3,0,0,0,6,0,'BLAUW'),(62,2,2,0,3,0,0,5,'ZWART'),(63,2,1,0,2,2,0,3,'WIT'),(64,2,1,0,3,0,2,2,'BLAUW'),(65,2,1,3,0,2,0,3,'ZWART'),(66,2,2,0,0,0,0,5,'GROEN'),(67,2,2,0,5,3,0,0,'WIT'),(68,2,3,0,0,6,0,0,'ZWART'),(69,2,2,5,0,0,3,0,'BLAUW'),(70,2,3,0,6,0,0,0,'ROOD'),(71,3,4,0,3,0,3,6,'ROOD'),(72,3,5,0,7,3,0,0,'ZWART'),(73,3,4,0,6,3,0,3,'ZWART'),(74,3,4,3,0,0,6,3,'GROEN'),(75,3,5,3,0,7,0,0,'WIT'),(76,3,3,0,5,3,3,3,'WIT'),(77,3,5,0,3,0,0,7,'ROOD'),(78,3,3,3,3,5,0,3,'BLAUW'),(79,3,3,5,3,3,3,0,'GROEN'),(80,3,4,0,0,0,0,7,'ROOD'),(81,3,4,7,0,0,0,0,'BLAUW'),(82,3,4,0,7,0,0,0,'ZWART'),(83,3,4,0,0,7,0,0,'WIT'),(84,3,5,0,0,0,7,3,'GROEN'),(85,3,4,3,3,6,0,0,'WIT'),(86,3,4,6,0,3,3,0,'BLAUW'),(87,3,4,0,0,0,7,0,'GROEN'),(88,3,3,3,3,0,3,5,'ZWART'),(89,3,3,3,0,3,5,3,'ROOD'),(90,3,5,7,0,0,3,0,'BLAUW');
/*!40000 ALTER TABLE `Kaart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Speler`
--

DROP TABLE IF EXISTS `Speler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Speler` (
  `spelerID` int(11) NOT NULL AUTO_INCREMENT,
  `voornaam` varchar(20) NOT NULL,
  `achternaam` varchar(30) NOT NULL,
  `username` varchar(255) NOT NULL,
  `geboortejaar` year(4) NOT NULL,
  PRIMARY KEY (`spelerID`),
  UNIQUE KEY `spelerID_UNIQUE` (`spelerID`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Speler`
--

LOCK TABLES `Speler` WRITE;
/*!40000 ALTER TABLE `Speler` DISABLE KEYS */;
INSERT INTO `Speler` VALUES (1,'Taylon','Vandenbroecke','taylon',2004),(2,'Rune','Hautekier','RuneGeorgeHautekier',2004),(3,'Yentl','Belaen','Bilal456',2004),(4,'Tiago','Belmonte','TiagoBelmonte',2002),(5,'Chloe','De Leenheer','chloedl',1999),(6,'Jens','Janssens','JensJ',1997),(7,'Pieter','Testen','test01',2004),(8,'Jantje','TestenV2','Testen02',1969),(9,'Test','De Tester','Testertester',2004),(10,'Kapitein','haak','Haakje',2004),(11,'Dirk','Schoor','DirkS',1997),(12,'geert','smet','geerts',1967),(13,'testpersoon','persoons','testpersoon',1999),(14,'Rune','Hautekier','Rune',2004),(15,'Alberto','Hautekier','Alberto1',1970),(16,'Alberto','kok','Alberto10',1950),(17,'Albert','Janssens','Albert',1943);
/*!40000 ALTER TABLE `Speler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `test`
--

DROP TABLE IF EXISTS `test`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `test` (
  `idtest` int(11) NOT NULL,
  PRIMARY KEY (`idtest`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `test`
--

LOCK TABLES `test` WRITE;
/*!40000 ALTER TABLE `test` DISABLE KEYS */;
/*!40000 ALTER TABLE `test` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-15 20:12:51
