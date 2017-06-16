IF NOT EXISTS(SELECT * FROM sys.databases where Name = 'GestEcole')
CREATE DATABASE [GestEcole];


USE [GestEcole];

IF NOT EXISTS(SELECT * FROM sysobjects WHERE Id = OBJECT_ID(N'[dbo].[Groupe]') AND OBJECTPROPERTY(Id, N'IsUserTable') = 1)
CREATE TABLE Groupe(
	Id INT NOT NULL IDENTITY,
	Libelle NVARCHAR(30) NOT NULL,
	PRIMARY KEY(Id),
	CONSTRAINT uk_Groupe UNIQUE(Libelle)
);

IF NOT EXISTS(SELECT * FROM sysobjects WHERE Id = OBJECT_ID(N'[dbo].[Utilisateur]') AND OBJECTPROPERTY(Id, N'IsUserTable') = 1)
CREATE TABLE Utilisateur(
	Id INT NOT NULL IDENTITY,
	Nom NVARCHAR(30) NOT NULL,
	Prenom NVARCHAR(30) NOT NULL,
	Email NVARCHAR(125) NOT NULL,
	MotDePasse NVARCHAR(32) NOT NULL,
	Groupe_Id INT NOT NULL,
	PRIMARY KEY(Id),
	CONSTRAINT fk_Utilisateur_Groupe FOREIGN KEY(Groupe_Id) REFERENCES Groupe(Id),
	CONSTRAINT uk_Utilisateur UNIQUE(Email),
	INDEX ix_Utilisateur_Email(Email)
);

IF NOT EXISTS(SELECT * FROM sysobjects WHERE Id = OBJECT_ID(N'[dbo].[Matiere]') AND OBJECTPROPERTY(Id, N'IsUserTable') = 1)
CREATE TABLE Matiere(
	Id INT NOT NULL IDENTITY,
	Libelle NVARCHAR(30) NOT NULL
	PRIMARY KEY(Id),
	CONSTRAINT uk_Matiere UNIQUE(Libelle)
);

IF NOT EXISTS(SELECT * FROM sysobjects WHERE Id = OBJECT_ID(N'[dbo].[Devoir]') AND OBJECTPROPERTY(Id, N'IsUserTable') = 1)
CREATE TABLE Devoir(
	Id INT NOT NULL IDENTITY,
	DateDevoir DATETIME NOT NULL,
	DatePublication DATETIME NOT NULL,
	Coefficient FLOAT NOT NULL,
	Matiere_Id INT NOT NULL,
	Formateur_Id iNT NOT NULL,
	PRIMARY KEY(Id),
	CONSTRAINT fk_Devoir_Matiere FOREIGN KEY(Matiere_Id) REFERENCES Matiere(Id),
	CONSTRAINT fk_Devoir_Formateur FOREIGN KEY(Formateur_Id) REFERENCES Utilisateur(Id),
	CONSTRAINT uk_Devoir UNIQUE(DateDevoir,Matiere_Id),
);

IF NOT EXISTS(SELECT * FROM sysobjects WHERE Id = OBJECT_ID(N'[dbo].[Note]') AND OBJECTPROPERTY(Id, N'IsUserTable') = 1)
CREATE TABLE Note(
	Devoir_Id INT NOT NULL,
	Eleve_Id INT NOT NULL,
	Valeur FLOAT NOT NULL DEFAULT 0
	PRIMARY KEY(Devoir_Id, Eleve_Id),
	CONSTRAINT fk_Note_Devoir FOREIGN KEY(Devoir_Id) REFERENCES Devoir(Id),
	CONSTRAINT fk_Note_Eleve FOREIGN KEY(Eleve_Id) REFERENCES Utilisateur(Id)
);

INSERT INTO Groupe(Libelle)VALUES('Formateur'),('Eleve');
INSERT INTO Utilisateur(Nom, Prenom, Email, MotDePasse, Groupe_Id) VALUES
	('DANIEL','Cedric', 'cedric@monhoraire.fr', 'formation', 1),
	('GINESTOU', 'Didier', 'd.ginestou@iia-laval.fr', 'toto123', 1),
	('PAMISEUX', 'Marc-Henri', 'not24get@iia-laval.fr', 'not24get', 1),
	('CHIRON', 'Anthony', 'a.chiron@iia-laval.fr', 'ac', 1),
	('GILET', 'Marius', 'g.marius@iia-laval.fr', 'gm', 1),
	('GUILLOCHEAU', 'Jeanne', 'j.guillocheau@iia-laval.fr', 'jg', 1),
	('MORISSEAU', 'Valentin', 'v.morisseau@iia-laval.fr', 'vm', 1),
	('PAUMIER', 'Florian', 'f.paumier@iia-laval.fr', 'fp', 1),
	('RADIGUE', 'Damien', 'd.radigue@iia-laval.fr', 'dr', 1),
	('SAUVAGE', 'Dimitri', 'd.sauvage@iia-laval.fr', 'ds', 1);
INSERT INTO Matiere(Libelle)VALUES('ASP.Net'),('Linux'), ('Base de données');



