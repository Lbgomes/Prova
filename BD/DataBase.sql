CREATE DATABASE Projeto

USE Projeto

CREATE TABLE TipoUsuario(
IdTipo INT PRIMARY KEY IDENTITY,
Titulo VARCHAR (500)
);
go

INSERT INTO TipoUsuario (Titulo)
VALUES ('Pessoa Jurídica'),('Pessoa Física')
go


DROP TABLE UsuarioPJ
SELECT * FROM UsuarioPJ
CREATE TABLE UsuarioPJ(
IdUsuarioPJ INT PRIMARY KEY IDENTITY,
NomeUsuario VARCHAR(500),
IdTipo INT FOREIGN KEY REFERENCES TipoUsuario (IdTipo),
NumeroCnpj VARCHAR (500) UNIQUE,
Telefone VARCHAR (500)
)
go

CREATE TABLE UsuarioPF(
IdUsuarioPF INT PRIMARY KEY IDENTITY,
NomeUsuario VARCHAR(500),
IdTipo INT FOREIGN KEY REFERENCES TipoUsuario (IdTipo),
NumeroCpf VARCHAR (500) UNIQUE,
Telefone VARCHAR (500)
)
go

INSERT INTO UsuarioPF (NomeUsuario, IdTipo, NumeroCpf, Telefone)
VALUES ('Murilo', 2,321,11223334)
go

INSERT INTO UsuarioPJ (NomeUsuario, IdTipo, NumeroCnpj, Telefone)
VALUES ('Pedro', 1,123,11223334)
go

SELECT * FROM UsuarioPJ
go
SELECT * FROM UsuarioPF
go