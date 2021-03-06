--CREATE DATABASE DB_quiz

USE DB_quiz

CREATE TABLE Tema(
IDTema int IDENTITY(1, 1) NOT NULL,
Descricao VARCHAR(400) NOT NULL,
PRIMARY KEY(IDTema))



CREATE TABLE Questao(
IDQuestao INT IDENTITY(1, 1) NOT NULL,
IDTema INT NOT NULL,
Questao VARCHAR(800) NOT NULL,
FOREIGN KEY (IDTema) References Tema(IDTema)
	ON UPDATE NO ACTION
	ON DELETE CASCADE,
PRIMARY KEY(IDQuestao))


CREATE TABLE Alternativa(
IDAlternativa INT IDENTITY(1, 1) NOT NULL,
IDQuestao INT NOT NULL,
Alternativa VARCHAR(320) NOT NULL,
Correta BIT NOT NULL,
FOREIGN KEY (IDQuestao) REFERENCES Questao(IDQuestao)
	ON UPDATE NO ACTION
	ON DELETE CASCADE,
PRIMARY KEY (IDAlternativa))
