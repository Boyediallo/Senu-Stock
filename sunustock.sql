-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3309
-- Généré le :  ven. 01 oct. 2021 à 14:37
-- Version du serveur :  10.4.10-MariaDB
-- Version de PHP :  7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `sunustock`
--

-- --------------------------------------------------------

--
-- Structure de la table `facture`
--

DROP TABLE IF EXISTS `facture`;
CREATE TABLE IF NOT EXISTS `facture` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `produit` varchar(500) NOT NULL,
  `date` varchar(500) NOT NULL,
  `quantite` int(255) NOT NULL,
  `Company` varchar(500) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `facture`
--

INSERT INTO `facture` (`id`, `produit`, `date`, `quantite`, `Company`) VALUES
(1, 'Legumes', 'jeudi 8 juillet 2021', 45, 'AMADOU ARDO'),
(2, 'Fromage', 'jeudi 8 juillet 2021', 57, 'DUBAI BEURE'),
(4, 'Viande-Poisson', 'vendredi 16 juillet 2021', 40, 'AMADOU JEUF ZONE'),
(5, 'Boissons', 'samedi 24 juillet 2021', 100, 'AMADOU JEUF ZONE'),
(8, 'Fruit', 'samedi 31 juillet 2021', 67, 'PAPASAM');

-- --------------------------------------------------------

--
-- Structure de la table `fournisseur`
--

DROP TABLE IF EXISTS `fournisseur`;
CREATE TABLE IF NOT EXISTS `fournisseur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomFournisseur` varchar(50) NOT NULL,
  `telephone` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `email` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `fournisseur`
--

INSERT INTO `fournisseur` (`id`, `nomFournisseur`, `telephone`, `address`, `email`) VALUES
(1, 'AMADOU JEUF ZONE', '774482322', 'PIKINE', 'edk@gmail.com'),
(6, 'BOUFE DOUCE', '774553434', 'Paris', 'am@gmail.com'),
(7, 'AMAMSOMBOYE', '8888888', 'SALUT', 'sb@gmail.com'),
(8, 'AMADOU ARDO', '775583212', 'PIKINE', 'ardo@gmail.com'),
(9, 'DUBAI BEURE', '0033456738923', 'KHALAIREAIFI', 'gdb@dgb.dgb'),
(10, 'PAPASAM', '0022433678595', 'Guinea Bessia', 'papasam@gmail.gn');

-- --------------------------------------------------------

--
-- Structure de la table `manoeuvre`
--

DROP TABLE IF EXISTS `manoeuvre`;
CREATE TABLE IF NOT EXISTS `manoeuvre` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `telephone` varchar(50) NOT NULL,
  `poste` varchar(50) NOT NULL,
  `status` varchar(500) NOT NULL,
  `salaire` varchar(500) NOT NULL,
  `image` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `manoeuvre`
--

INSERT INTO `manoeuvre` (`id`, `nom`, `prenom`, `telephone`, `poste`, `status`, `salaire`, `image`) VALUES
(15, 'DER', 'Moustapha', '5666', 'ASSENIE', 'Homme', 'DAKAR', 'Guna.UI2.WinForms.Guna2PictureBox');

-- --------------------------------------------------------

--
-- Structure de la table `produit`
--

DROP TABLE IF EXISTS `produit`;
CREATE TABLE IF NOT EXISTS `produit` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prixAchat` int(11) NOT NULL,
  `prixVente` int(11) NOT NULL,
  `quantite` int(11) NOT NULL,
  `date` varchar(500) NOT NULL,
  `Company` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `produit`
--

INSERT INTO `produit` (`id`, `nom`, `prixAchat`, `prixVente`, `quantite`, `date`, `Company`) VALUES
(1, 'TOMATE', 12000, 13000, 245, 'mardi 8 juin 2021', 'HAMZA'),
(2, 'UNO', 34000, 45000, 56, 'mardi 8 juin 2021', 'DUBAI BEURE'),
(3, 'BANANE comores', 12000, 19000, 38, 'vendredi 2 juillet 2021', 'ZAMZAM'),
(4, 'COCO', 7477, 44444, 44, 'mercredi 9 juin 2021', 'ZAMZAM'),
(6, 'LCAZELLE', 3499, 60000, 67, 'jeudi 8 juillet 2021', 'PAPASAM'),
(8, 'CHOCOLAT', 4500, 160000, 67, 'jeudi 29 juillet 2021', 'MBOUROUNEX'),
(9, 'OIGONONS', 678, 7899, 67, 'jeudi 8 juillet 2021', 'ZAMZAM'),
(10, 'ANANACE', 56, 78, 6, 'vendredi 23 juillet 2021', 'BOUFE DOUCE'),
(11, 'POISSON', 45000, 65000, 45, 'jeudi 15 juillet 2021', 'JUMIA'),
(15, 'SEO', 200, 300, 56, 'dimanche 25 juillet 2021', 'JUMIA');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(500) NOT NULL,
  `password` varchar(500) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`id`, `username`, `password`) VALUES
(1, 'Passer', 'passer@1'),
(2, 'Admin', 'passer@1');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
