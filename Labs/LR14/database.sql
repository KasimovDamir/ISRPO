CREATE DATABASE NumberSystemsDB;
GO
USE NumberSystemsDB;
GO
CREATE TABLE ConversionHistory (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    InputNumber NVARCHAR(50) NOT NULL,
    InputBase INT NOT NULL,
    OutputNumber NVARCHAR(50) NOT NULL,
    OutputBase INT NOT NULL,
    ConversionDate DATETIME DEFAULT GETDATE()
);