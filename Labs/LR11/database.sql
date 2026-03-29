CREATE DATABASE AlarmClockDB;
GO

USE AlarmClockDB;
GO

CREATE TABLE Alarms(
    ID INT PRIMARY KEY IDENTITY(1,1),
    AlarmTime TIME(7),
    IsActive bit,
    RepeatDaily bit,
    Label NVARCHAR(100),
    CreatedDate DATETIME
);
GO