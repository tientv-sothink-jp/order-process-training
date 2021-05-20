CREATE TYPE [dbo].[OrderDetailType] AS TABLE(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [OrderId] UNIQUEIDENTIFIER NOT NULL, 
    [ProductId] UNIQUEIDENTIFIER NOT NULL, 
    [ProductPrice] DECIMAL NOT NULL, 
    [Quantity] INT NOT NULL, 
    [CreatedTime] DATETIME NULL, 
    [UpdatedTime] DATETIME NULL
)