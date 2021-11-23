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

