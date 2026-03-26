CREATE DATABASE Wordly;

USE Wordly;

CREATE TABLE Words (
id INT PRIMARY KEY IDENTITY(1,1),
Word NVARCHAR(100) NOT NULL
);

INSERT INTO Words (Word)
VALUES
('волюнтаризм'),
('электрификация'),
('ковёр'),
('однодневка'),
('конфедерация'),
('сверхдостопримечательность'),
('труба'),
('колл'),
('меритократия'),
('беспрестрастно'),
('ложка'),
('апеляшка'),
('парламент'),
('межконтинентальный'),
('сани'),
('шурик');