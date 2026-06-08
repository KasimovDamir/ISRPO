CREATE DATABASE SnakeGameDB;
GO

USE SnakeGameDB;
GO

CREATE TABLE GameResults (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PlayerName NVARCHAR(100) NULL,
    Score INT NULL,
    GameDate DATETIME NULL,
    GameDuration INT NULL
);
GO