-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 07 mai 2021 à 08:11
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `tvtime`
--

-- --------------------------------------------------------

--
-- Structure de la table `episode`
--

DROP TABLE IF EXISTS `episode`;
CREATE TABLE IF NOT EXISTS `episode` (
  `idEpisode` int(11) NOT NULL AUTO_INCREMENT,
  `titreEpisode` varchar(100) NOT NULL,
  `idSaison` int(11) NOT NULL,
  PRIMARY KEY (`idEpisode`),
  KEY `Episode_Saison_FK` (`idSaison`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `partager`
--

DROP TABLE IF EXISTS `partager`;
CREATE TABLE IF NOT EXISTS `partager` (
  `idUser` int(11) NOT NULL,
  `idUser_Partager` int(11) NOT NULL,
  PRIMARY KEY (`idUser`,`idUser_Partager`),
  KEY `Partager_User0_FK` (`idUser_Partager`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `regarder`
--

DROP TABLE IF EXISTS `regarder`;
CREATE TABLE IF NOT EXISTS `regarder` (
  `idUser` int(11) NOT NULL,
  `idSerie` int(11) NOT NULL,
  PRIMARY KEY (`idUser`,`idSerie`),
  KEY `Regarder_Serie0_FK` (`idSerie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `saison`
--

DROP TABLE IF EXISTS `saison`;
CREATE TABLE IF NOT EXISTS `saison` (
  `idSaison` int(11) NOT NULL AUTO_INCREMENT,
  `partieSaison` int(11) NOT NULL,
  `idSerie` int(11) NOT NULL,
  PRIMARY KEY (`idSaison`),
  KEY `Saison_Serie_FK` (`idSerie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `serie`
--

DROP TABLE IF EXISTS `serie`;
CREATE TABLE IF NOT EXISTS `serie` (
  `idSerie` int(11) NOT NULL AUTO_INCREMENT,
  `nomSerie` varchar(150) NOT NULL,
  PRIMARY KEY (`idSerie`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `serie`
--

INSERT INTO `serie` (`idSerie`, `nomSerie`) VALUES
(1, 'GAYSISR');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `loginUser` varchar(50) NOT NULL,
  `mdpUser` varchar(100) NOT NULL,
  `mailUser` varchar(100) NOT NULL,
  PRIMARY KEY (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `visionner`
--

DROP TABLE IF EXISTS `visionner`;
CREATE TABLE IF NOT EXISTS `visionner` (
  `idEpisode` int(11) NOT NULL,
  `idUser` int(11) NOT NULL,
  PRIMARY KEY (`idEpisode`,`idUser`),
  KEY `Visionner_User0_FK` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `episode`
--
ALTER TABLE `episode`
  ADD CONSTRAINT `Episode_Saison_FK` FOREIGN KEY (`idSaison`) REFERENCES `saison` (`idSaison`);

--
-- Contraintes pour la table `partager`
--
ALTER TABLE `partager`
  ADD CONSTRAINT `Partager_User0_FK` FOREIGN KEY (`idUser_Partager`) REFERENCES `user` (`idUser`),
  ADD CONSTRAINT `Partager_User_FK` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`);

--
-- Contraintes pour la table `regarder`
--
ALTER TABLE `regarder`
  ADD CONSTRAINT `Regarder_Serie0_FK` FOREIGN KEY (`idSerie`) REFERENCES `serie` (`idSerie`),
  ADD CONSTRAINT `Regarder_User_FK` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`);

--
-- Contraintes pour la table `saison`
--
ALTER TABLE `saison`
  ADD CONSTRAINT `Saison_Serie_FK` FOREIGN KEY (`idSerie`) REFERENCES `serie` (`idSerie`);

--
-- Contraintes pour la table `visionner`
--
ALTER TABLE `visionner`
  ADD CONSTRAINT `Visionner_Episode_FK` FOREIGN KEY (`idEpisode`) REFERENCES `episode` (`idEpisode`),
  ADD CONSTRAINT `Visionner_User0_FK` FOREIGN KEY (`idUser`) REFERENCES `user` (`idUser`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
