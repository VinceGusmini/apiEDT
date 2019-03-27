-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mer. 27 mars 2019 à 13:34
-- Version du serveur :  5.7.24
-- Version de PHP :  7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `proj`
--

-- --------------------------------------------------------

--
-- Structure de la table `completude`
--

DROP TABLE IF EXISTS `completude`;
CREATE TABLE IF NOT EXISTS `completude` (
  `id_complet` int(11) NOT NULL AUTO_INCREMENT,
  `id_period` int(11) NOT NULL,
  `id_mat` int(11) DEFAULT NULL,
  `id_prof` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_complet`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `completude`
--

INSERT INTO `completude` (`id_complet`, `id_period`, `id_mat`, `id_prof`) VALUES
(1, 2, 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `contrainte`
--

DROP TABLE IF EXISTS `contrainte`;
CREATE TABLE IF NOT EXISTS `contrainte` (
  `id_cont` int(11) NOT NULL AUTO_INCREMENT,
  `bPositive` tinyint(4) NOT NULL DEFAULT '0',
  `id_mat` int(11) DEFAULT NULL,
  `id_prof` int(11) DEFAULT NULL,
  `id_salle` int(11) DEFAULT NULL,
  `type_cont` text COLLATE utf8_bin NOT NULL,
  `valeur` text CHARACTER SET latin1,
  PRIMARY KEY (`id_cont`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `contrainte`
--

INSERT INTO `contrainte` (`id_cont`, `bPositive`, `id_mat`, `id_prof`, `id_salle`, `type_cont`, `valeur`) VALUES
(1, 0, 1, 3, NULL, 'jour', '{\"mardi\":[14,18.30], \n\"mercredi\":[8,18.30]}'),
(2, 1, 1, 3, NULL, 'creneau', '[\"M\":[2]]'),
(3, 0, NULL, NULL, NULL, 'vacances', '{\"Toussaint\":[1540767600,1541178000]}\n'),
(4, 0, NULL, NULL, 6, 'reservation', '{\"Akhaton\":[1574982000,1575048600]}');

-- --------------------------------------------------------

--
-- Structure de la table `creneau`
--

DROP TABLE IF EXISTS `creneau`;
CREATE TABLE IF NOT EXISTS `creneau` (
  `id_creneau` int(11) NOT NULL AUTO_INCREMENT,
  `tDeb` int(11) NOT NULL,
  `tFin` int(11) NOT NULL,
  `id_edth` int(11) NOT NULL,
  `id_mat` int(11) NOT NULL,
  `id_prof` int(11) NOT NULL,
  `id_grpe` int(11) NOT NULL,
  `id_salle` int(11) NOT NULL,
  PRIMARY KEY (`id_creneau`)
) ENGINE=InnoDB AUTO_INCREMENT=425 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `creneau`
--

INSERT INTO `creneau` (`id_creneau`, `tDeb`, `tFin`, `id_edth`, `id_mat`, `id_prof`, `id_grpe`, `id_salle`) VALUES
(1, 1539604800, 1539615600, 6, 17, 5, 11, 7),
(2, 1539640800, 1539678600, 6, 14, 9, 4, 8),
(3, 1539727200, 1539765000, 6, 16, 6, 11, 9),
(4, 1539777600, 1539788400, 6, 9, 4, 11, 10),
(5, 1539604800, 1539615600, 6, 1, 2, 10, 11),
(6, 1539640800, 1539680400, 6, 1, 2, 9, 11),
(7, 1539727200, 1539766800, 6, 1, 2, 12, 1),
(8, 1539777600, 1539788400, 6, 1, 2, 11, 1),
(9, 11, 12, 1, 1, 1, 1, 1),
(424, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Structure de la table `edth`
--

DROP TABLE IF EXISTS `edth`;
CREATE TABLE IF NOT EXISTS `edth` (
  `id_edth` int(11) NOT NULL AUTO_INCREMENT,
  `tDeb` int(11) NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  `bCourant` tinyint(4) NOT NULL,
  PRIMARY KEY (`id_edth`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `edth`
--

INSERT INTO `edth` (`id_edth`, `tDeb`, `label`, `bCourant`) VALUES
(1, 1536530400, '1', 1),
(2, 1537135200, '2', 1),
(3, 1537999200, '3', 1),
(4, 1538344800, '4', 1),
(5, 1538949600, '5', 1),
(6, 1539554400, '6', 1),
(7, 1540159200, '7', 1),
(8, 1541372400, 'DST C', 1),
(9, 1541977200, '1', 1),
(10, 1542582000, '2', 1),
(11, 1543186800, '3', 1),
(12, 1543791600, '4', 1),
(13, 1544396400, '5', 1),
(14, 1545001200, '6', 1),
(15, 1546815600, '7', 1),
(16, 1547420400, 'DST D', 1);

-- --------------------------------------------------------

--
-- Structure de la table `edtitem`
--

DROP TABLE IF EXISTS `edtitem`;
CREATE TABLE IF NOT EXISTS `edtitem` (
  `idItem` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `idPeriod` int(11) NOT NULL,
  `idModule` int(11) NOT NULL,
  `nbHeure` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `edtitem`
--

INSERT INTO `edtitem` (`idItem`, `idPeriod`, `idModule`, `nbHeure`) VALUES
(1, 1, 1, 199),
(2, 2, 2, 299),
(3, 2, 2, 388),
(4, 1, 1, 488);

-- --------------------------------------------------------

--
-- Structure de la table `edtperiod`
--

DROP TABLE IF EXISTS `edtperiod`;
CREATE TABLE IF NOT EXISTS `edtperiod` (
  `id_period` int(11) NOT NULL AUTO_INCREMENT,
  `id_promo` int(11) NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  `tDeb` int(11) NOT NULL,
  `tFin` int(11) NOT NULL,
  PRIMARY KEY (`id_period`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `edtperiod`
--

INSERT INTO `edtperiod` (`id_period`, `id_promo`, `label`, `tDeb`, `tFin`) VALUES
(1, 1, 'C', 1513292400, 1540656000),
(2, 1, 'D', 1540677600, 1541178000);

-- --------------------------------------------------------

--
-- Structure de la table `etudiant`
--

DROP TABLE IF EXISTS `etudiant`;
CREATE TABLE IF NOT EXISTS `etudiant` (
  `id_etu` int(11) NOT NULL AUTO_INCREMENT,
  `id_promo` int(11) NOT NULL,
  `id_grpe` int(11) NOT NULL,
  `genre` text COLLATE utf8_bin NOT NULL,
  `nom` text COLLATE utf8_bin NOT NULL,
  `prenom` text COLLATE utf8_bin NOT NULL,
  `email` text COLLATE utf8_bin NOT NULL,
  `login_etu` text COLLATE utf8_bin NOT NULL,
  `pass_etu` text COLLATE utf8_bin NOT NULL,
  `matricule` text COLLATE utf8_bin NOT NULL,
  `date_etu` date NOT NULL,
  `urlPhoto` text COLLATE utf8_bin NOT NULL,
  `bConnect` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_etu`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `etudiant`
--

INSERT INTO `etudiant` (`id_etu`, `id_promo`, `id_grpe`, `genre`, `nom`, `prenom`, `email`, `login_etu`, `pass_etu`, `matricule`, `date_etu`, `urlPhoto`, `bConnect`) VALUES
(1, 1, 1, 'Melle', 'Dahmani', 'Djaouida', 'ddahmani@parisdescartes.fr', 'ddahmani', '*B21D70FFCE8B3C8622A4C886A7A2F5C213912954', '12345678', '2018-09-10', '', 0),
(2, 1, 1, 'M', 'Karl', 'Bernard', 'bernard.karl@parisdescartes.fr', 'bkarl', '*B64D2DC5BB06AEAD6D5F0DBC01F6FB8D6AC6CA00', '40004000', '2018-09-10', '', 0),
(3, 1, 11, 'Melle', 'Mozart', 'lea', 'lea.mozart@parisdescartes.fr', 'lmozart', '*3D0D46868FDDF27F76B5F10DE31DB98318493F0D', '10001000', '2018-09-10', '', 0),
(4, 1, 3, 'M', 'Vincens', 'Bernard', 'bernard.vincens@parisdescartes.fr', 'bvincens', 'dc58ed24df48496f0a04ae624abe7286e61f0299', '12345678', '2018-09-10', '', 0),
(5, 1, 5, 'M', 'Lauzanne', 'Alain', 'alauzanne@parisdescartes.fr', 'alauzanne', 'cba74be83fd19dd61dee1ec1994c09e530e1678a', '22345678', '2018-09-10', '', 1),
(6, 1, 6, 'Melle', 'Rey', 'Annie', 'arey@parisdecartes.fr', 'arey', 'b65f2b9a5ca896d9b91ac617950f876fe9020017', '32345678', '2018-09-10', '', 0),
(7, 1, 6, 'M', 'Tao', 'minh', 'mtao@parisdescartes.fr', 'mtao', '*9DB4046E7187F79A01021185A9F9BA924149871B', '10001000', '2018-09-10', '', 0),
(8, 1, 7, 'M', 'Berger', 'Paul', 'pberger@parisdescartes.fr', 'pberger', '*A38C94F5CFA7532683B719FA7B83C04485426A37', '70000000', '2018-09-10', '', 0),
(9, 1, 8, 'Melle', 'Franceschinis', 'Octavia', 'ofranceschinis', 'ofrance', '*54678C481DA1C66E803E78FDF765195A24B2CD22', '', '2018-09-10', '', 0),
(10, 1, 11, 'M', 'test2', 'test', 'test@', 'test', 'test', '20000', '2018-09-10', '', 0);

-- --------------------------------------------------------

--
-- Structure de la table `etu_grps`
--

DROP TABLE IF EXISTS `etu_grps`;
CREATE TABLE IF NOT EXISTS `etu_grps` (
  `id_etu` int(11) NOT NULL,
  `id_grpe` int(11) NOT NULL,
  UNIQUE KEY `index_etuGrp` (`id_etu`,`id_grpe`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `etu_grps`
--

INSERT INTO `etu_grps` (`id_etu`, `id_grpe`) VALUES
(1, 1),
(2, 1),
(3, 11),
(4, 3),
(5, 5),
(6, 5),
(7, 6),
(8, 8),
(9, 7),
(10, 11);

-- --------------------------------------------------------

--
-- Structure de la table `formation`
--

DROP TABLE IF EXISTS `formation`;
CREATE TABLE IF NOT EXISTS `formation` (
  `id_form` int(4) NOT NULL AUTO_INCREMENT,
  `nom` text COLLATE utf8_bin NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_form`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `formation`
--

INSERT INTO `formation` (`id_form`, `nom`, `label`) VALUES
(1, 'DUT INFO - formation initiale', 'DUT INFO'),
(3, 'Licence PRO Métier de l\'informatique \r\nparcours IOT - apprentissage', 'LPIOT'),
(4, 'Licence PRO Métier de l\'informatique \r\nparcours ERP - formation apprentissage', 'LPERP_A'),
(5, 'Licence PRO Métier de l\'informatique \r\nparcours ERP - formation initiale', 'LPERP_I');

-- --------------------------------------------------------

--
-- Structure de la table `groupe`
--

DROP TABLE IF EXISTS `groupe`;
CREATE TABLE IF NOT EXISTS `groupe` (
  `id_grpe` int(11) NOT NULL AUTO_INCREMENT,
  `id_promo` int(11) NOT NULL,
  `type_grpe` text COLLATE utf8_bin NOT NULL,
  `num_grpe` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_grpe`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `groupe`
--

INSERT INTO `groupe` (`id_grpe`, `id_promo`, `type_grpe`, `num_grpe`) VALUES
(1, 1, 'mono', '201'),
(2, 1, 'mono', '202'),
(3, 1, 'mono', '203'),
(4, 1, 'mono', '204'),
(5, 1, 'mono', '205'),
(6, 1, 'mono', '206'),
(7, 1, 'mono', '207'),
(8, 1, 'mono', '208'),
(9, 1, 'bi', '201-202'),
(10, 1, 'bi', '203-204'),
(11, 1, 'bi', '205-206'),
(12, 1, 'bi', '207-208'),
(13, 1, 'promo', 'promo'),
(14, 1, '1/2promo', '1/2'),
(15, 1, '1/2promo', '2/2');

-- --------------------------------------------------------

--
-- Structure de la table `matiere`
--

DROP TABLE IF EXISTS `matiere`;
CREATE TABLE IF NOT EXISTS `matiere` (
  `id_mat` int(4) NOT NULL AUTO_INCREMENT,
  `id_ue` int(11) NOT NULL,
  `id_mod` int(4) NOT NULL,
  `id_period` int(11) NOT NULL,
  `nom` text COLLATE utf8_bin NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  `nbH` int(11) NOT NULL,
  `couleur` text COLLATE utf8_bin NOT NULL,
  `themes` text COLLATE utf8_bin NOT NULL,
  `typeEns` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_mat`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `matiere`
--

INSERT INTO `matiere` (`id_mat`, `id_ue`, `id_mod`, `id_period`, `nom`, `label`, `nbH`, `couleur`, `themes`, `typeEns`) VALUES
(1, 1, 1, 1, 'Programmation WEB côté Serveur (M3104)', 'PWEB MVC', 25, '#1DE124', '{\n\"web\":\"Client Serveur HTTP\", \n\"pattern\":\"MVC\",\n\"Langage\":\"PHP\"\n}\n', '{\n\"A\":[\"promo\", 1.5],\n\'M\':[\"bi\",3]\n}'),
(2, 1, 1, 2, 'Programmation WEB côté Serveur - JAVA (M3104-2)', 'PWEB JAVA', 0, '', '{\n\"Systeme WEB\":\"Client Serveur HTTP\", \n\"Langage\":\"JAVA\"\n}\n', '{\n\"A\":[\"promo\",1.5],\n\"M\":[\"bi\",3]\n}'),
(9, 1, 1, 1, 'Algorithmique avancée', 'AAV', 0, '', '{\"complexite\": \"tri\"}', '{\n\"A\":[\"promo\",1.5],\n\"T\":[\"bi\",1.5],\n\"M\":[\"mono\",1.5]\n}'),
(14, 2, 1, 1, 'Anglais', 'ANG', 0, '', 'vocabulaire', '{\"M\":[\"mono\",1.5]}'),
(15, 2, 1, 1, 'Expression Communication', 'EC', 0, '', '{\n\"expression\":\"écriture de rapport de stage\",\n\"communication\":\"soutenance orale\"\n}', '{\n\"T\":[\"bi\",1.5]\n}'),
(16, 1, 1, 1, 'Modélisation Objet', 'MO', 0, '', '{\"modele\" : \"UML\"}', '{\"A\":[\"promo\",1.5],\n\'M\':[\"bi\",3]\n}'),
(17, 2, 1, 1, 'PROBA STAT', 'PS', 0, '', '{\"proba\": [\"espace\"], \n\"stat\": [\"régression\"]}', '{ \"A\":[\"promo\",1.5], \"M\":[\"bi\",3] }');

-- --------------------------------------------------------

--
-- Structure de la table `message`
--

DROP TABLE IF EXISTS `message`;
CREATE TABLE IF NOT EXISTS `message` (
  `id_msg` int(11) NOT NULL AUTO_INCREMENT,
  `typeMsg` int(11) NOT NULL,
  `id_src` int(11) NOT NULL,
  `id_dest` int(11) NOT NULL,
  `contenu` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_msg`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Structure de la table `period`
--

DROP TABLE IF EXISTS `period`;
CREATE TABLE IF NOT EXISTS `period` (
  `id_period` int(11) NOT NULL AUTO_INCREMENT,
  `id_promo` int(11) NOT NULL,
  `label` text NOT NULL,
  `tDeb` timestamp(6) NOT NULL,
  `tFin` timestamp(6) NOT NULL,
  PRIMARY KEY (`id_period`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `period`
--

INSERT INTO `period` (`id_period`, `id_promo`, `label`, `tDeb`, `tFin`) VALUES
(1, 1, 'C', '2017-12-14 22:00:00.000000', '2017-10-27 21:00:00.000000'),
(2, 1, 'D', '2017-10-27 20:00:00.000000', '2018-11-02 16:00:00.000000');

-- --------------------------------------------------------

--
-- Structure de la table `prof`
--

DROP TABLE IF EXISTS `prof`;
CREATE TABLE IF NOT EXISTS `prof` (
  `id_prof` int(11) NOT NULL AUTO_INCREMENT,
  `genre` text COLLATE utf8_bin NOT NULL,
  `nom` text COLLATE utf8_bin NOT NULL,
  `prenom` text COLLATE utf8_bin NOT NULL,
  `email` text COLLATE utf8_bin NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  `login_prof` text COLLATE utf8_bin NOT NULL,
  `pass_prof` text COLLATE utf8_bin NOT NULL,
  `date_prof` date NOT NULL,
  `urlPhoto` text COLLATE utf8_bin NOT NULL,
  `couleur` text COLLATE utf8_bin NOT NULL,
  `bConnect` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_prof`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `prof`
--

INSERT INTO `prof` (`id_prof`, `genre`, `nom`, `prenom`, `email`, `label`, `login_prof`, `pass_prof`, `date_prof`, `urlPhoto`, `couleur`, `bConnect`) VALUES
(1, 'M', 'Ilié', 'Jean-Michel', 'jmilie@parisdescartes.fr', 'JMI', 'jmilie', '0e700c97a56f97b1643f66bdbbedee54', '2018-09-12', '', '#E1B36E', 0),
(2, 'M', 'Foughali', 'Karim', 'kfoughali@gmail.com', 'KF', 'kfoughali', 'ecf66de73808530b5e5dc5462cfd074d085fa89c', '2018-01-12', '', '#0002E1', 0),
(3, 'M', 'Kurtz', 'Camille', 'ckurtz@parisdescartes.fr', 'CK', 'ckurtz', 'ed9b1bd745d9a724280d8374184de26b0718960b', '2018-09-09', '', '', 0),
(4, 'M', 'Sortais', 'Michel', 'msortais@parisdescartes.fr', 'MS', 'msortais', '*69358EEA623E244E978C10364CA96398D642E1BE', '2018-09-10', '', '#0002E1', 0),
(5, 'M', 'Ouziri', 'Mourad', 'mouziri@parisdescartes.fr', 'MO', 'mouziri', '*F07FBB4086D1DF19106B375B6E5D7A11BB485C2E', '2018-09-10', '', '#040e00', 0),
(6, 'Mme', 'Dirani', 'Hélène', 'hdirani@parisdescartes.fr', 'HD', 'hdirani', '*81DD599CAA08EA3C67AB17DD86AB3094216B1EC4', '2018-09-10', '', '#fffd00', 0),
(7, 'M', 'Poitrenaud', 'Denis', 'dpoitrenaud', 'DP', 'dpoitrenaud', '*A6C32F3A9310014F2B06BDCCD1752D9C47A73A38', '2018-09-10', '', '', 0),
(8, 'Mme', 'Marechal', 'Laurence', 'lmarechal@parisdescartes.fr', 'LM', 'lmarechal', '*0DFC2E234404E6A97CC9456A8DD457521BF77C97', '2018-09-10', '', '', 0),
(9, 'M', 'Oliviero', 'Philippe', 'poliviero@parisdescartes.fr', 'PhO', 'poliviero', '*2CED6004642B247385E3DEEF9ECF1D4007AC2492', '2018-09-10', '', '', 0);

-- --------------------------------------------------------

--
-- Structure de la table `prof_roles`
--

DROP TABLE IF EXISTS `prof_roles`;
CREATE TABLE IF NOT EXISTS `prof_roles` (
  `id_role` int(11) NOT NULL AUTO_INCREMENT,
  `objet` text COLLATE utf8_bin NOT NULL,
  `id_objet` int(11) NOT NULL,
  `bResp` tinyint(4) NOT NULL DEFAULT '0',
  `id_prof` int(11) NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `prof_roles`
--

INSERT INTO `prof_roles` (`id_role`, `objet`, `id_objet`, `bResp`, `id_prof`, `label`) VALUES
(1, 'edt', 1, 1, 8, 'Responsable EDT - DUT 1 DUT 2'),
(6, 'matiere', 1, 1, 2, 'Responsable PWEB'),
(7, 'matiere', 9, 1, 4, 'Responsable AAV'),
(8, 'matiere', 14, 1, 9, 'Responsable ANG'),
(9, 'matiere', 10, 1, 7, 'Responsable EC'),
(10, 'matiere', 16, 1, 6, 'Responsable MO'),
(12, 'matiere', 17, 1, 1, 'Responsable PROBA STAT'),
(13, 'matiere', 1, 0, 1, 'Intervenant PWEB'),
(14, 'matiere', 1, 0, 3, 'Intervenant PWEB'),
(15, 'matiere', 9, 0, 4, 'Intervenant AAV'),
(16, 'matiere', 17, 0, 5, 'Intervenant PROBA STAT'),
(17, 'matiere', 14, 0, 9, 'Intervenant ANG'),
(18, 'matiere', 16, 0, 6, 'Intervenant MO'),
(19, 'matiere', 15, 0, 10, 'Intervenant EC');

-- --------------------------------------------------------

--
-- Structure de la table `promotion`
--

DROP TABLE IF EXISTS `promotion`;
CREATE TABLE IF NOT EXISTS `promotion` (
  `id_promo` tinyint(4) NOT NULL,
  `id_form` int(11) NOT NULL,
  `num` int(11) NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_promo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `promotion`
--

INSERT INTO `promotion` (`id_promo`, `id_form`, `num`, `label`) VALUES
(1, 1, 2018, 'INFOA1 2018'),
(2, 1, 2018, 'INFOA2 2018'),
(3, 2, 2018, 'LPIOT 2018'),
(4, 3, 2018, 'LPERP-A 2018'),
(5, 4, 2018, 'LPERP-I 2018');

-- --------------------------------------------------------

--
-- Structure de la table `salle`
--

DROP TABLE IF EXISTS `salle`;
CREATE TABLE IF NOT EXISTS `salle` (
  `id_salle` int(11) NOT NULL AUTO_INCREMENT,
  `nom` text COLLATE utf8_bin NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  `batiment` text COLLATE utf8_bin NOT NULL,
  `type_salle` text COLLATE utf8_bin NOT NULL,
  `nb_postes` int(11) NOT NULL,
  PRIMARY KEY (`id_salle`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `salle`
--

INSERT INTO `salle` (`id_salle`, `nom`, `label`, `batiment`, `type_salle`, `nb_postes`) VALUES
(1, 'B1-12', 'B1-12', 'Blériot\niut-Paris', 'M', 25),
(2, 'IOT WIFI 1', 'B2-15', 'Blériot\nIUT-Paris', 'M', 25),
(3, 'V1-11', 'V1-11', 'Versailles-\nIUT Paris', 'M', 30),
(4, 'Daumart', 'A-1', 'iut-paris', 'A', 200),
(5, 'IOT WIFI 2', 'V1-11', 'iut-Paris', 'M', 30),
(6, 'Olympe de Gouge', 'A-2', 'iut-paris', 'A', 200),
(7, 'B2-12', 'B2-12', 'Blériot\r\niut-Paris', 'T', 22),
(8, 'B2-17', 'B2-17', 'Blériot\r\niut-Paris', 'T', 22),
(9, 'B0-13', 'B0-13', 'Blériot\r\niut-Paris', 'M', 22),
(10, 'B1-17', 'B1-17', 'Blériot\r\niut-Paris', 'M', 22),
(11, 'B0-3', 'B0-3', 'Blériot\r\niut-Paris', 'M', 22);

-- --------------------------------------------------------

--
-- Structure de la table `uemodule`
--

DROP TABLE IF EXISTS `uemodule`;
CREATE TABLE IF NOT EXISTS `uemodule` (
  `id_uemod` int(11) NOT NULL AUTO_INCREMENT,
  `id_form` int(11) NOT NULL,
  `classif` text COLLATE utf8_bin NOT NULL,
  `nom` text COLLATE utf8_bin NOT NULL,
  `label` text COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id_uemod`),
  KEY `id_form` (`id_form`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `uemodule`
--

INSERT INTO `uemodule` (`id_uemod`, `id_form`, `classif`, `nom`, `label`) VALUES
(1, 1, 'ue', 'Informatique avancée', '31'),
(2, 1, 'ue', 'Culture scientifique, sociale et humaine avancées', '32'),
(3, 1, 'module', 'Programmation Web côté serveur', '3104'),
(4, 1, 'module', 'Algorithmique avancée', '3103'),
(5, 1, 'module', 'Conception et programmation objet avancées', '3105'),
(6, 1, 'module', 'Probabilités et statistiques', '3201'),
(7, 1, 'module', 'Expression-Communication – Communication\r\nprofessionnelle', '3205'),
(8, 1, 'module', 'Collaborer en anglais', '3206');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
