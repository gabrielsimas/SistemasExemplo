CREATE DATABASE AngularJSMVC
GO

USE AngularJSMVC
GO

CREATE TABLE Categoria(
	id	INT	IDENTITY(1,1),
	nome	VARCHAR(100),
	estado	INT DEFAULT 1
)
GO

CREATE TABLE Unidade(
	id		INT	IDENTITY(1,1),
	nome	VARCHAR(100)
)
GO

drop table consumo

CREATE TABLE Consumo(
	id			INT IDENTITY(1,1),
	idUnidade	INT,
	idCategoria	INT,
	mes			INT,
	ano			INT,
	valor		MONEY
)
GO

ALTER TABLE Categoria ADD CONSTRAINT PK_Categoria PRIMARY KEY(id)
GO

ALTER TABLE Unidade ADD CONSTRAINT PK_Unidade PRIMARY KEY(id)
GO

ALTER TABLE Consumo ADD CONSTRAINT PK_Consumo PRIMARY KEY(id)
GO

ALTER TABLE Consumo ADD CONSTRAINT FK_Consumo_Categoria FOREIGN KEY(idCategoria)
	REFERENCES Categoria(id)
GO

ALTER TABLE Consumo ADD CONSTRAINT FK_Consumo_Unidade FOREIGN KEY(idUnidade)
	REFERENCES Unidade(id)
GO
