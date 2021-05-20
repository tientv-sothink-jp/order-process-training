CREATE TABLE [dbo].[Order]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [DateDelivered] DATETIME NULL , 
    [Discount] DECIMAL(18, 2) NOT NULL, 
    [OrderStatusId] INT NOT NULL, 
    [CreatedTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedTime] DATETIME NULL
)
