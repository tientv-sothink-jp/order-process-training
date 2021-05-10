CREATE TABLE [dbo].[Order]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [DateReceive] DATETIME NOT NULL, 
    [DateDelivery] NCHAR(10) NOT NULL, 
    [Discount] INT NOT NULL, 
    [OrderStatusId] INT NOT NULL, 
    [CustomerName] INT NOT NULL,
    [CustomerPhone] INT NOT NULL,
    [CustomerAddress] NVARCHAR(250) NOT NULL,
    [CreateTime] DATETIME NOT NULL, 
    [UpdateTime] DATETIME NULL
)
