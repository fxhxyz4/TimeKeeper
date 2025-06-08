-- MySQL dump 10.13  Distrib 8.0.42, for Linux (x86_64)
--
-- Host: 127.0.0.1    Database: TimeKeeper
-- ------------------------------------------------------
-- Server version  8.0.36-28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table Admin
--

DROP TABLE IF EXISTS Admin;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE Admin (
  id int NOT NULL AUTO_INCREMENT,
  user varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  pass varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table Admin
--

LOCK TABLES Admin WRITE;
/*!40000 ALTER TABLE Admin DISABLE KEYS */;
INSERT INTO Admin VALUES (1,'admin','8nc8w1ncks91w001s9xj1w9jdnxw91kxa9xk31cz28lpoai38snvba8r34jfs9q1');
/*!40000 ALTER TABLE Admin ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table BlockUsers
--

DROP TABLE IF EXISTS BlockUsers;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE BlockUsers (
  id int NOT NULL AUTO_INCREMENT,
  SID varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table BlockUsers
--

LOCK TABLES BlockUsers WRITE;
/*!40000 ALTER TABLE BlockUsers DISABLE KEYS */;
/*!40000 ALTER TABLE BlockUsers ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table Persons
--

DROP TABLE IF EXISTS Persons;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE Persons (
  id int NOT NULL AUTO_INCREMENT,
  first_name varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  last_name varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  year_of_birth year NOT NULL DEFAULT '1970',
  rank enum('рекрут','солдат','старший солдат','молодший сержант','сержант','старший сержант','головний сержант','перший сержант','штаб-сержант','майстер-сержант','старший майстер-сержант','головний майстер-сержант','молодший лейтенант','лейтенант','старший лейтенант','капітан','майор','підполковник','полковник','бригадний генерал','генерал-майор','генерал-лейтенант','генерал','головнокомандувач') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  position enum('гість','абітурієнт','курсант','асистент','викладач','старший викладач','курсовий оффіцер','начальник курсу','заступник начальника','начальник') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  date_time datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  UNIQUE KEY first_name (first_name,last_name,year_of_birth)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table Persons
--

LOCK TABLES Persons WRITE;
/*!40000 ALTER TABLE Persons DISABLE KEYS */;
/*!40000 ALTER TABLE Persons ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'TimeKeeper'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS daily_cleanup */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8mb4 */ ;;
/*!50003 SET character_set_results = utf8mb4 */ ;;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=TimeKeeper_pencilrow`@%*/ /*!50106 EVENT `cleanup ON SCHEDULE EVERY 1 DAY STARTS '2025-06-08 00:01:00' ON COMPLETION NOT PRESERVE ENABLE DO DELETE FROM Persons WHERE date < CURDATE() */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-07 15:32:24
