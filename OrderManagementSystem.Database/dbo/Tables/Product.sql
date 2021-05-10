CREATE TABLE [dbo].[Product]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Name] NVARCHAR(150) NOT NULL, 
    [SKU] NCHAR(50) NOT NULL, 
    [Weight] FLOAT NOT NULL, 
    [Origin] NVARCHAR(150) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [ImageUrl] CHAR(10) NOT NULL,
    [CreateTime] DATETIME NOT NULL, 
    [UpdateTime] DATETIME NULL
)
