CREATE DATABASE Prova

USE Prova

CREATE TABLE TipoUsuario(
IdTipo INT PRIMARY KEY IDENTITY,
Titulo VARCHAR (500)
);

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
DROP TABLE UsuarioPF
CREATE TABLE UsuarioPF(
IdUsuarioPF INT PRIMARY KEY IDENTITY,
NomeUsuario VARCHAR(500),
IdTipo INT FOREIGN KEY REFERENCES TipoUsuario (IdTipo),
NumeroCpf VARCHAR (500) UNIQUE,
Telefone VARCHAR (500)
)

INSERT INTO UsuarioPF (NomeUsuario, IdTipo, NumeroCpf, Telefone)
VALUES ('Murilo', 2,11111111,11223334)

INSERT INTO UsuarioPJ (NomeUsuario, IdTipo, NumeroCnpj, Telefone)
VALUES ('Muliro', 1,222222222,11223334)

SELECT * FROM UsuarioPJ
SELECT * FROM UsuarioPJ



SELECT * FROM UsuarioPJ WHERE NumeroCnpj = 125
UPDATE UsuarioPJ SET NomeUsuario = @NomeUsuario, IdTipo = @IdTipo, NumeroCnpj = @NumeroCnpj, Telefone = @Telefone
UPDATE UsuarioPJ SET NomeUsuario = 'bruno', IdTipo = '1', NumeroCnpj = 23456, Telefone = 123456 where NumeroCnpj = 125
DELETE FROM UsuarioPJ WHERE NumeroCnpj = 125;
SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome LIKE '%' + @NomeProcurado + '%'
SELECT * FROM UsuarioPF WHERE NomeUsuario LIKE '%' + 'Muliro' + '%'
SELECT * FROM UsuarioP
INSERT INTO UsuarioPF (NomeUsuario, IdTipo, NumeroCpf, Telefone)
VALUES('@NomeUsuario', @IdTipo, @NumeroCpf, @Telefone)
DELETE FROM UsuarioPF WHERE NumeroCpf = 125
SELECT * FROM UsuarioPF