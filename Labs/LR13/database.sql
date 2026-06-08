CREATE DATABASE DailyPlanerDB;
GO

USE DailyPlanerDB;
GO

CREATE TABLE Notes (
    Id INT IDENTITY(1,1),
    NoteDate DATETIME,
    NoteText NVARCHAR(MAX),
    CreatedAt DATETIME
);
GO
