/*
SQLyog Community v12.5.1 (64 bit)
MySQL - 5.5.45 : Database - northwind
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`northwind` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `northwind`;

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_name` varchar(100) DEFAULT NULL,
  `unit_price` float DEFAULT NULL,
  `unit_in_stock` int(11) DEFAULT NULL,
  `qty_per_unit` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=165 DEFAULT CHARSET=latin1;

/*Data for the table `products` */

insert  into `products`(`product_id`,`product_name`,`unit_price`,`unit_in_stock`,`qty_per_unit`) values 
(88,'Chai',18,39,'10 boxes x 20 bags'),
(89,'Chang',19,17,'24 - 12 oz bottles'),
(90,'Aniseed Syrup',10,13,'12 - 550 ml bottles'),
(91,'Chef Anton\'s Cajun Seasoning',22,53,'48 - 6 oz jars'),
(92,'Chef Anton\'s Gumbo Mix',21.35,0,'36 boxes'),
(93,'Grandma\'s Boysenberry Spread',25,120,'12 - 8 oz jars'),
(94,'Uncle Bob\'s Organic Dried Pears',30,15,'12 - 1 lb pkgs.'),
(95,'Northwoods Cranberry Sauce',40,6,'12 - 12 oz jars'),
(96,'Mishi Kobe Niku',97,29,'18 - 500 g pkgs.'),
(97,'Ikura',31,31,'12 - 200 ml jars'),
(98,'Queso Cabrales',21,22,'1 kg pkg.'),
(99,'Queso Manchego La Pastora',38,86,'10 - 500 g pkgs.'),
(100,'Konbu',6,24,'2 kg box'),
(101,'Tofu',23.25,35,'40 - 100 g pkgs.'),
(102,'Genen Shouyu',15.5,39,'24 - 250 ml bottles'),
(103,'Pavlova',17.45,29,'32 - 500 g boxes'),
(104,'Alice Mutton',39,0,'20 - 1 kg tins'),
(105,'Carnarvon Tigers',62.5,42,'16 kg pkg.'),
(106,'Teatime Chocolate Biscuits',9.2,25,'10 boxes x 12 pieces'),
(107,'Sir Rodney\'s Marmalade',81,40,'30 gift boxes'),
(108,'Sir Rodney\'s Scones',10,3,'24 pkgs. x 4 pieces'),
(109,'Gustaf\'s Knäckebröd',21,104,'24 - 500 g pkgs.'),
(110,'Tunnbröd',9,61,'12 - 250 g pkgs.'),
(111,'Guaraná Fantástica',4.5,20,'12 - 355 ml cans'),
(112,'NuNuCa Nuß-Nougat-Creme',14,76,'20 - 450 g glasses'),
(113,'Gumbär Gummibärchen',31.23,15,'100 - 250 g bags'),
(114,'Schoggi Schokolade',43.9,49,'100 - 100 g pieces'),
(115,'Rössle Sauerkraut',45.6,26,'25 - 825 g cans'),
(116,'Thüringer Rostbratwurst',123.79,0,'50 bags x 30 sausgs.'),
(117,'Nord-Ost Matjeshering',25.89,10,'10 - 200 g glasses'),
(118,'Gorgonzola Telino',12.5,0,'12 - 100 g pkgs'),
(119,'Mascarpone Fabioli',32,9,'24 - 200 g pkgs.'),
(120,'Geitost',2.5,112,'500 g'),
(121,'Sasquatch Ale',14,111,'24 - 12 oz bottles'),
(122,'Steeleye Stout',18,20,'24 - 12 oz bottles'),
(123,'Inlagd Sill',19,112,'24 - 250 g  jars'),
(124,'Gravad lax',26,11,'12 - 500 g pkgs.'),
(125,'Côte de Blaye',263.5,17,'12 - 75 cl bottles'),
(126,'Chartreuse verte',18,69,'750 cc per bottle'),
(127,'Boston Crab Meat',18.4,123,'24 - 4 oz tins'),
(128,'Jack\'s New England Clam Chowder',9.65,85,'12 - 12 oz cans'),
(129,'Singaporean Hokkien Fried Mee',14,26,'32 - 1 kg pkgs.'),
(130,'Ipoh Coffee',46,17,'16 - 500 g tins'),
(131,'Gula Malacca',19.45,27,'20 - 2 kg bags'),
(132,'Rogede sild',9.5,5,'1k pkg.'),
(133,'Spegesild',12,95,'4 - 450 g glasses'),
(134,'Zaanse koeken',9.5,36,'10 - 4 oz boxes'),
(135,'Chocolade',12.75,15,'10 pkgs.'),
(136,'Maxilaku',20,10,'24 - 50 g pkgs.'),
(137,'Valkoinen suklaa',16.25,65,'12 - 100 g bars'),
(138,'Manjimup Dried Apples',53,20,'50 - 300 g pkgs.'),
(139,'Filo Mix',7,38,'16 - 2 kg boxes'),
(140,'Perth Pasties',32.8,0,'48 pieces'),
(141,'Tourtière',7.45,21,'16 pies'),
(142,'Pâté chinois',24,115,'24 boxes x 2 pies'),
(143,'Gnocchi di nonna Alice',38,21,'24 - 250 g pkgs.'),
(144,'Ravioli Angelo',19.5,36,'24 - 250 g pkgs.'),
(145,'Escargots de Bourgogne',13.25,62,'24 pieces'),
(146,'Raclette Courdavault',55,79,'5 kg pkg.'),
(147,'Camembert Pierrot',34,19,'15 - 300 g rounds'),
(148,'Sirop d\'érable',28.5,113,'24 - 500 ml bottles'),
(149,'Tarte au sucre',49.3,17,'48 pies'),
(150,'Vegie-spread',43.9,24,'15 - 625 g jars'),
(151,'Wimmers gute Semmelknödel',33.25,22,'20 bags x 4 pieces'),
(152,'Louisiana Fiery Hot Pepper Sauce',21.05,76,'32 - 8 oz bottles'),
(153,'Louisiana Hot Spiced Okra',17,4,'24 - 8 oz jars'),
(154,'Laughing Lumberjack Lager',14,52,'24 - 12 oz bottles'),
(155,'Scottish Longbreads',12.5,6,'10 boxes x 8 pieces'),
(156,'Gudbrandsdalsost',36,26,'10 kg pkg.'),
(157,'Outback Lager',15,15,'24 - 355 ml bottles'),
(158,'Flotemysost',21.5,26,'10 - 500 g pkgs.'),
(159,'Mozzarella di Giovanni',34.8,14,'24 - 200 g pkgs.'),
(160,'Röd Kaviar',15,101,'24 - 150 g jars'),
(161,'Longlife Tofu',10,4,'5 kg pkg.'),
(162,'Rhönbräu Klosterbier',7.75,125,'24 - 0.5 l bottles'),
(163,'Lakkalikööri',18,57,'500 ml'),
(164,'Original Frankfurter grüne Soße',13,32,'12 boxes');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
