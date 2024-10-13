CREATE DATABASE  IF NOT EXISTS `ProbleemMelden` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ProbleemMelden`;

-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: probleemmelden
-- ------------------------------------------------------
-- Server version	5.7.9-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblWerknemers`
--

DROP TABLE IF EXISTS `tblWerknemers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblWerknemers` (
  `werknemerID` int(2) NOT NULL AUTO_INCREMENT,
  `naam` varchar(30) NOT NULL NULL,
  `telefoonnummer` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `wachtwoord` varchar(50) NOT NULL,
  `itCoordinator` int(1) NOT NULL,
  PRIMARY KEY (`werknemerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table 'tblWerknemers'
--

LOCK TABLES `tblWerknemers` WRITE;
/*!40000 ALTER TABLE `tblWerknemers` DISABLE KEYS */;
INSERT INTO `tblWerknemers` VALUES 
(1,'Tiago Belmonte','0497 99 04 22','t.belmonte@hotmail.com', 'ITcoordinatorTB' ,1),
(2,'Laura Sar','0497 42 22 29','laura.sar04@outlook.com', 'WerknemerLS' ,0),
(3,'Marika Pruvoost','0494 74 32 12','m.pruvoost@outlook.com', 'WerknemerMP' ,0),
(4,'Ruben Belmonte','0494 24 00 51','ruben.belmonte@hotmail.com', 'ITcoordinatorRB' ,1),
(5,'Andres Dhaene','0493 19 14 33', 'andres.dhaene@leerling.molenland.be', 'WerknemerAD' ,0);
/*!40000 ALTER TABLE `tblWerknemers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblProbleem'
--

DROP TABLE IF EXISTS `tblProbleem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblProbleem` (
  `ProbleemID` int(3) NOT NULL AUTO_INCREMENT,
  `Werknemer` int(1) NOT NULL,
  `toestel` varchar(30) NOT NULL,
  `omschrijving` varchar(60) NOT NULL,
  `plaats` varchar(30) NOT NULL,
  `status` varchar(30) DEFAULT 'niet gestart',
  `ITcoordinator` varchar(30) default null,
  `datum` datetime default now(),
  PRIMARY KEY (`ProbleemID`),
  FOREIGN KEY (`Werknemer`) REFERENCES `tblWerknemers` (`WerknemerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `tblProbleem` WRITE;
/*!40000 ALTER TABLE `tblProbleem` DISABLE KEYS */;
INSERT INTO `tblProbleem` VALUES 
(1,5,'laptop nr100','scherm blijft zwart ook als hij aan staat','bureau nr25','niet gestart', '' ,now()),
(2,3,'computer nr33', 'muis ontbreekt','bureau nr12','niet gestart', '' ,now()),
(3,2,'beamer nr6','beamer verbind niet met computer','vergaderkamer nr2','niet gestart', '' ,now()),
(4,3,'computer nr16','applicaties office synchroniseren niet','bureau nr15','niet gestart', '' ,now()),
(5,2,'laptop nr38','laptop kan niet meer opladen','bureau nr12','niet gestart', '' ,now());
/*!40000 ALTER TABLE `tblProbleem` ENABLE KEYS */;
UNLOCK TABLES;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;



