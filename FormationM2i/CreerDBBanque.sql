CREATE TABLE clients
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nom VARCHAR(150),
	prenom VARCHAR(150),
	telephone VARCHAR(15)
)

CREATE TABLE operations
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	montant DECIMAL,
	date_operation DATETIME,
	compte_id INT
)

CREATE TABLE comptes
(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	solde DECIMAL,
	client_id INT
)