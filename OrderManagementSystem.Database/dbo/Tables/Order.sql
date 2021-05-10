CREATE TABLE [dbo].[Order]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [DateDelivered] DATETIME NULL , 
    [Discount] DECIMAL(18, 2) NOT NULL, 
    [OrderStatusId] INT NOT NULL, 
    [CustomerName] NVARCHAR(250) NOT NULL,
    [CustomerPhone] CHAR(15) NOT NULL,
    [CustomerEmail] CHAR(150) NOT NULL,
    [CustomerAddress] NVARCHAR(250) NOT NULL,
    [CreatedTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedTime] DATETIME NULL
)
