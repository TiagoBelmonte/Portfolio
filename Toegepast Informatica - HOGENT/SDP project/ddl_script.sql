-- tabel Edele
CREATE TABLE `Edele` (
  `idEdele` int(11) NOT NULL AUTO_INCREMENT,
  `prestigepunten` int(11) NOT NULL,
  `prijsWit` int(11) NOT NULL,
  `prijsRood` int(11) NOT NULL,
  `prijsZwart` int(11) NOT NULL,
  `prijsBlauw` int(11) NOT NULL,
  `prijsGroen` int(11) NOT NULL,
  PRIMARY KEY (`idEdele`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1

-- tabel Kaart
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
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1

-- tabel Speler
CREATE TABLE `Speler` (
  `spelerID` int(11) NOT NULL AUTO_INCREMENT,
  `voornaam` varchar(20) NOT NULL,
  `achternaam` varchar(30) NOT NULL,
  `username` varchar(255) NOT NULL,
  `geboortejaar` year(4) NOT NULL,
  PRIMARY KEY (`spelerID`),
  UNIQUE KEY `spelerID_UNIQUE` (`spelerID`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1