﻿CREATE TABLE [dbo].[Cart]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
	[UserId] UNIQUEIDENTIFIER NOT NULL, 
    [ProductId] UNIQUEIDENTIFIER NOT NULL, 
    [ProductImageUrl] VARCHAR(500) NOT NULL, 
    [ProductName] NVARCHAR(250) NOT NULL, 
    [ProductPrice] DECIMAL(18, 2) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [CreatedTime] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedTime] DATETIME NULL
)
