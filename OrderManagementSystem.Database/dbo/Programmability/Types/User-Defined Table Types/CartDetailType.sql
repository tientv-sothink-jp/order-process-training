﻿CREATE TYPE [dbo].[CartDetailType] AS TABLE(
    [Id] UNIQUEIDENTIFIER NOT NULL, 
    [CartId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [ProductPrice] DECIMAL(18,2) NOT NULL,
    [Quantity] INT NOT NULL,
    [CreatedTime] DATETIME NULL,
    [UpdatedTime] DATETIME NULL
)