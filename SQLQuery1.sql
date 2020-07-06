CREATE DATABASE Prova

USE Prova

CREATE TABLE TipoUsuario(
IdTipo INT PRIMARY KEY IDENTITY,
Titulo VARCHAR (500)
);

INSERT INTO TipoUsuario (Titulo)
VALUES ('Pessoa Jurídica'),('Pessoa Física')
go

CREATE TABLE IdUsuario(
IdUsuario INT PRIMARY KEY IDENTITY
)

SELECT * FROM TipoUsuario
CREATE TABLE UsuarioPJ(
IdUsuario INT FOREIGN KEY REFERENCES IdUsuario(IdUsuario),
NomeUsuario VARCHAR(500),
IdTipo INT FOREIGN KEY REFERENCES TipoUsuario (IdTipo),
NumeroCnpj VARCHAR (500),
Telefone VARCHAR (500)
)

CREATE TABLE UsuarioPF(
IdUsuario INT FOREIGN KEY REFERENCES IdUsuario(IdUsuario),
NomeUsuario VARCHAR(500),
IdTipo INT FOREIGN KEY REFERENCES TipoUsuario (IdTipo),
NumeroCpf VARCHAR (500),
Telefone VARCHAR (500)
)
