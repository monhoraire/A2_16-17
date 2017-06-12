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
	CONSTRAINT fk_Utilisateur_Groupe FOREIGN KEY(Groupe_Id) REFERENCES Utilisateur(Id),
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
	CONSTRAINT fk_Devoir_Formateur FOREIGN KEY(Formateur_Id) REFERENCES Formateur(Id),
	CONSTRAINT uk_Devoir UNIQUE(DateDevoir,Matiere_Id),
);

--IF NOT EXISTS(SELECT * FROM sysobjects WHERE Id = OBJECT_ID(N'[dbo].[Note]') AND OBJECTPROPERTY(Id, N'IsUserTable') = 1)
--CREATE TABLE Note(
	
--);




