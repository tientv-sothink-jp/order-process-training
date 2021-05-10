﻿CREATE TABLE [dbo].[Role]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Name] NVARCHAR(150) NOT NULL, 
    [CreatedTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedTime] DATETIME NULL
)
