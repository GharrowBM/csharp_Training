--Création de tables
CREATE TABLE personne (
	id INT IDENTITY(1,1),
	nom VARCHAR(150),
	prenom VARCHAR(150)
);

CREATE TABLE voiture (
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	model VARCHAR(100)
);

-- Suppression de table
DROP TABLE personne;

-- Modification de table
ALTER TABLE personne ADD telephone VARCHAR(100);
ALTER TABLE personne DROP COLUMN telephone;

INSERT INTO voiture (model) VALUES ('ford');

UPDATE voiture SET model = 'kia' WHERE id = 1;

DELETE FROM voiture WHERE id > 2;

-- Exo 1 

--Créer une TABLE personne avec les champs suivants :
--✓ Id
--✓ titre (« Mr », « Mme », « Mlle »)
--✓ prenom
--✓ nom
--✓ email
--✓ telephone
CREATE TABLE personnes (
	id INT,
	titre VARCHAR(4),
	prenom VARCHAR(50),
	nom VARCHAR(50),
	email VARCHAR(50),
	telephone VARCHAR(15)
);

--1. Créez un fichier de requête sql permettant de saisir une entrée (INSER INTO) puis modifier le afin de pouvoir réinitialiser la base avec quelques entrées.
INSERT INTO personne VALUES ();
--2. Créez un fichier de requête sql permettant d’afficher l’intégralité des personnes présente dans la BDD, ordonnées par nom de famille croissant.
SELECT * FROM personne ORDER BY nom;
--3. Créez un fichier de requête sql permettant d’afficher l’intégralité des personnes présente dans la BDD, triées par le titre « Mlle » puis « Mme », puis « Mr ».
SELECT * FROM personne ORDER BY titre;
--4. Créez un fichier de requête sql permettant de rechercher un contact par son email et testez-le avec un email de votre base
SELECT * FROM personne WHERE email = 'mail@tofind.fr';

-- Exo 2 

--1. Créer une table nommée « dbo.livre » détenant les champs suivant :
--• Id
--• titre
--• auteur
--• editeur
--• date_publication
--• isbn_10
--• isbn_13

CREATE TABLE dbo.livre (
	Id INT NOT NULL IDENTITY(1,1),
	titre VARCHAR(200),
	auteur VARCHAR(100),
	editeur VARCHAR(100),
	date_publication DATE,
	isbn_10 VARCHAR(50),
	isbn_13 VARCHAR(50)
);

DROP TABLE dbo.livre;
DROP TABLE livre;

--• Question1 : Créez une requête permettant d’afficher les livres par titre par ordre alphabétique.
SELECT * FROM dbo.livre ORDER BY titre;
--• Question2 : Créez une requête permettant d’afficher les livres par date de publication.
SELECT * FROM dbo.livre ORDER BY date_publication;
--• Question3 : Créez une requête permettant d’afficher les 10 dates de publication les plus anciennes classés par ordre croissant.
SELECT TOP 10 * FROM dbo.livre ORDER BY date_publication;
--• Question4 : Créez une requête permettant d’afficher les 10 livres les plus anciens (avec toutes les colonnes) classés par ordre croissant.
SELECT TOP 10 * FROM dbo.livre ORDER BY date_publication;
--• Question5 : Créez une requête permettant d’afficher les 10 livres les plus anciens (Seulement l’affichage des colonnes : date_publication, auteur, titre) classés par ordre croissant.
SELECT TOP 10 date_publication, auteur, titre FROM dbo.livre ORDER BY date_publication;
--• Question6 : Créez une requête permettant d’afficher tous les livres de « Agatha Christie » présent dans la base (à ce stade 3 livres).
SELECT * FROM dbo.livre WHERE auteur = 'Agatha Christie';
--• Question7 : On nous informe qu’une erreur s’est glissée sur un livre de « Agatha Christie » présent dans la base. En effet, une entrée de la BDD aurait comme auteur « Agatha Christies ». Faites une requête permettant de modifier cette erreur puis exécutez de nouveau la requête « Reponse6 » afin d’afficher de nouveau le nombre de livre de « Agatha christie » présent dans la BDD (4 à ce stade).
UPDATE dbo.livre SET auteur = 'Agatha Christie' WHERE auteur = 'Agatha Christies';
SELECT COUNT(*) FROM dbo.livre WHERE auteur = 'Agatha Christie';
--• Question8 : Insérez le livre de votre choix dans la BDD en respectant toutes les colonnes.
INSERT INTO dbo.livre VALUES ('Poil de Carrottes','Jules Renard','Livre de Poche','1999-08-25','2253160431','978-2253160434');
--• Question9 : Supprimer le livre de votre choix par les critères d’auteur et titre.
DELETE FROM dbo.livre WHERE auteur LIKE '%Renard%'; 


--Exo 03

CREATE TABLE villes_france_free (
  ville_id int check (ville_id > 0) NOT NULL,
  ville_departement varchar(3) DEFAULT NULL,
  ville_slug varchar(255) DEFAULT NULL,
  ville_nom varchar(45) DEFAULT NULL,
  ville_nom_simple varchar(45) DEFAULT NULL,
  ville_nom_reel varchar(45) DEFAULT NULL,
  ville_nom_soundex varchar(20) DEFAULT NULL,
  ville_nom_metaphone varchar(22) DEFAULT NULL,
  ville_code_postal varchar(255) DEFAULT NULL,
  ville_commune varchar(3) DEFAULT NULL,
  ville_code_commune varchar(5) NOT NULL,
  ville_arrondissement smallint check (ville_arrondissement > 0) DEFAULT NULL,
  ville_canton varchar(4) DEFAULT NULL,
  ville_amdi smallint check (ville_amdi > 0) DEFAULT NULL,
  ville_population_2010 int check (ville_population_2010 > 0) DEFAULT NULL,
  ville_population_1999 int check (ville_population_1999 > 0) DEFAULT NULL,
  ville_population_2012 int check (ville_population_2012 > 0) DEFAULT NULL ,
  ville_densite_2010 int DEFAULT NULL,
  ville_surface float DEFAULT NULL,
  ville_longitude_deg float DEFAULT NULL,
  ville_latitude_deg float DEFAULT NULL,
  ville_longitude_grd varchar(9) DEFAULT NULL,
  ville_latitude_grd varchar(8) DEFAULT NULL,
  ville_longitude_dms varchar(9) DEFAULT NULL,
  ville_latitude_dms varchar(8) DEFAULT NULL,
  ville_zmin int DEFAULT NULL,
  ville_zmax int DEFAULT NULL,
  PRIMARY KEY (ville_id),
) ;


--1. Obtenir la liste des 10 villes les plus peuplées en 2012
SELECT TOP 10 * FROM villes_france_free ORDER BY ville_population_2012;
--2. Obtenir la liste des 50 villes ayant la plus faible superficie
SELECT TOP 50 * FROM villes_france_free ORDER BY ville_surface;
--3. Obtenir la liste des départements d’outre-mer, c’est-à-dire ceux dont le numéro de département commençant par “97”
SELECT departement_nom FROM villes_france_free, departement WHERE ville_departement = '91'; 
--4. Obtenir le nom des 10 villes les plus peuplées en 2012, ainsi que le nom du département associé
SELECT TOP 10 ville_nom, ville_departement ORDER BY ville_population_2012;
--5. Obtenir la liste du nom de chaque département, associé à son code et du nombre de commune au sein de ces départements, en triant afin d’obtenir en priorité les départements qui possèdent le plus de communes

--6. Obtenir la liste des 10 plus grands départements, en termes de superficie
--7. Compter le nombre de villes dont le nom commence par “Saint”
SELECT COUNT(DISTINCT ville
--8. Obtenir la liste des villes qui ont un nom existants plusieurs fois, et trier afin d’obtenir en premier celles dont le nom est le plus souvent utilisé par plusieurs communes
--9. Obtenir en une seule requête SQL la liste des villes dont la superficie est supérieure à la superficie moyenne
--10. Obtenir la liste des départements qui possèdent plus de 2 millions d’habitants
--11. Remplacez les tirets par un espace vide, pour toutes les villes commençant par “SAINT-” (dans la colonne qui contient les noms en majuscule)